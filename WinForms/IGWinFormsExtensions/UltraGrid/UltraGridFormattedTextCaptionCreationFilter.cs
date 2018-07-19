using System;
using System.Linq;
using Infragistics.Win;
using Infragistics.Win.FormattedLinkLabel;
using Infragistics.Win.UltraWinGrid;

namespace IGExtension.WinForms.UltraGrid
{
    public class UltraGridFormattedTextCaptionCreationFilter : IUIElementCreationFilter
    {
        public string Template { get; set; } = "<p align=\"center\">{0}</p>";

        public bool BeforeCreateChildElements(UIElement parent)
        {
            if (parent is CaptionAreaUIElement)
            {
                FormattedTextUIElement childElement = parent.ChildElements.OfType<FormattedTextUIElement>().FirstOrDefault();

                if (childElement == null)
                {
                    childElement = new FormattedTextUIElement(parent);
                    parent.ChildElements.Add(childElement);
                }

                string formattedText = string.Format(Template, parent.Control.Text);
                childElement.Value = ParsedFormattedTextValue.Parse(formattedText, ParsedFormattedTextValue.ValueType.AutoDetect, out Exception ex);
                childElement.Rect = parent.RectInsideBorders;
                return true;
            }
            return false;
        }

        public void AfterCreateChildElements(UIElement parent)
        {
        }
    }

}
