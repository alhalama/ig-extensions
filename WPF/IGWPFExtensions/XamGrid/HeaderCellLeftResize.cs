using Infragistics.Controls.Grids;
using Infragistics.Controls.Grids.Primitives;

namespace IGExtension.WPF.XamGrid
{
    public class HeaderCellLeftResize : HeaderCell
    {
        protected internal HeaderCellLeftResize(RowBase row, Column column) : base(row, column)
        {
        }

        protected override CellControlBase CreateInstanceOfRecyclingElement()
        {
            return new HeaderCellLeftResizeControl();
        }
    }
}
