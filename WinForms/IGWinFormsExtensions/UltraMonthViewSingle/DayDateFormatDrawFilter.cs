using Infragistics.Win;
using Infragistics.Win.UltraWinSchedule.MonthViewSingle;

namespace IGExtension.WinForms.UltraMonthViewSingle
{
    public class DayDateFormatDrawFilter:IUIElementDrawFilter
    {
        public DrawPhase GetPhasesToFilter(ref UIElementDrawParams drawParams)
        {
            if (drawParams.Element is TextUIElement && drawParams.Element.Parent is DayNumberUIElement)
                return DrawPhase.BeforeDrawElement;
            return DrawPhase.None;
        }

        public bool DrawElement(DrawPhase drawPhase, ref UIElementDrawParams drawParams)
        {
            DayUIElement dayNumberUiElement = drawParams.Element.Parent.Parent as DayUIElement;
            TextUIElement textElement = drawParams.Element as TextUIElement;
            textElement.Text = dayNumberUiElement.Date.ToLongDateString();
            return false;
        }
    }
}
