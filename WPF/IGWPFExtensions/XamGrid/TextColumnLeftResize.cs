using Infragistics.Controls.Grids;

namespace IGExtension.WPF.XamGrid
{
    public class TextColumnLeftResize : TextColumn
    {
        protected override CellBase GenerateHeaderCell(RowBase row)
        {
            return new HeaderCellLeftResize(row, this);
        }
    }
}
