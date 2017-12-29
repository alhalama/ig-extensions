using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using Infragistics.Controls.Grids;
using Infragistics.Controls.Grids.Primitives;

namespace IGExtension.WPF.XamGrid
{
    public class HeaderCellLeftResizeControl : HeaderCellControl
    {
        protected override bool DetermineCursorHelper(Column column, Rect bounds, double xPosition)
        {
            return column.IsResizable && xPosition < (bounds.Left + this.ResizingThreshold) && xPosition > bounds.Left;
        }

        protected override void OnMouseMoveColumnResizing(MouseEventArgs e)
        {
            if (this.Cell == null || this.Cell.Row == null || this.Cell.Row.ColumnLayout == null)
                return;

            ColumnResizingSettingsOverride columnResizeSettings = this.Cell.Row.ColumnLayout.ColumnResizingSettings;

            if (columnResizeSettings.AllowColumnResizingResolved == ColumnResizingType.Disabled)
            {
                return;
            }

            Type cellControlBaseType = typeof(CellControlBase);
            Type xamGridType = typeof(Infragistics.Controls.Grids.XamGrid);

            if (!this.IsResizing)
            {
                // set cursor up always
                MethodInfo determineCursorMethod = cellControlBaseType.GetMethod("DetermineCursor",
                    BindingFlags.InvokeMethod | BindingFlags.Instance | BindingFlags.NonPublic);
                this.AllowUserResizing = (bool)determineCursorMethod.Invoke(this, new object[] { e });
            }

            else
            {
                // ok we have detemined that we are actually resizing the column, so move it.
                this.Focus();
                RowBase rowBase = this.Cell.Row;
                Infragistics.Controls.Grids.XamGrid grid = rowBase.ColumnLayout.Grid;
                PropertyInfo panelPropery = xamGridType.GetProperty("Panel",
                    BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.NonPublic);
                Panel gridPanel = panelPropery.GetValue(grid) as Panel;
                Point rootPoint = e.GetPosition(null);
                Point elemPoint = e.GetPosition(gridPanel);
                Popup columnResizingIndicatorContainer = columnResizeSettings.IndicatorContainer;

                UIElement relativeTo = null;

                relativeTo = GetRootVisual(this);

                MatrixTransform mt = null;

                if (this.Parent != null)
                    mt = this.TransformToVisual(relativeTo) as MatrixTransform;

                double scaleX = 1.0;

                if (mt != null)
                {
                    scaleX = Math.Abs(mt.Matrix.M11);
                }

                FieldInfo originalWidthField = cellControlBaseType.GetField("_originalWidthValue", BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic);
                FieldInfo currentWidthField = cellControlBaseType.GetField("_currentWidth", BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic);
                FieldInfo dragStartPointField = cellControlBaseType.GetField("_dragStartPoint", BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic);
                FieldInfo resizedColumnField = cellControlBaseType.GetField("_resizedColumn", BindingFlags.Instance | BindingFlags.GetField | BindingFlags.NonPublic);

                double columnWidthInView = (double)originalWidthField.GetValue(this);
                double currentWidth = (columnWidthInView - (rootPoint.X - ((Point)dragStartPointField.GetValue(this)).X) / scaleX);

                MethodInfo validateColumnWidthMethod = cellControlBaseType.GetMethod("ValidateColumnWidth", BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod);

                Column resizedColumn = (Column)resizedColumnField.GetValue(this);

                currentWidth = (double)validateColumnWidthMethod.Invoke(this, new object[] { resizedColumn, currentWidth });

                currentWidthField.SetValue(this, currentWidth);

                if (columnResizeSettings.AllowColumnResizingResolved == ColumnResizingType.Immediate)
                {
                    if (resizedColumn != null && currentWidth >= 0)
                    {
                        resizedColumn.Width = new ColumnWidth((double)validateColumnWidthMethod.Invoke(this, new object[] { resizedColumn, currentWidth }), false);
                    }
                }

                if (columnResizeSettings.AllowColumnResizingResolved == ColumnResizingType.Indicator)
                    columnResizingIndicatorContainer.HorizontalOffset = elemPoint.X;
            }
        }

        public static UIElement GetRootVisual(DependencyObject scopedElement)
        {
            if (scopedElement == null)
            {
                return Application.Current.MainWindow;
            }
            UIElement uiElement = scopedElement as UIElement;
            DependencyObject element = scopedElement;

            while (element is ContentElement)
            {
                element = LogicalTreeHelper.GetParent(element);
            }

            while (element != null)
            {
                if (element is Visual || element is Visual3D)
                {
                    element = VisualTreeHelper.GetParent(element);
                }

                if (element is UIElement)
                {
                    uiElement = (UIElement)element;
                }
            }

            return uiElement;
        }

    }
}
