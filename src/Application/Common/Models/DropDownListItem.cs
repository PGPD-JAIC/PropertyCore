using PropertyCore.Application.Common.Interfaces;

namespace PropertyCore.Application.Common.Models
{
    /// <summary>
    /// Class used to create drop down list items.
    /// </summary>
    public class DropDownListItem : IDropDownListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
