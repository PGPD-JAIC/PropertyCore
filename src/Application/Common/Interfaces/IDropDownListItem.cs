namespace PropertyCore.Application.Common.Interfaces
{
    /// <summary>
    /// Defines an interface used to create Drop Down List Items.
    /// </summary>
    public interface IDropDownListItem
    {
        /// <summary>
        /// The Value of the item.
        /// </summary>
        string Value { get; set; }
        /// <summary>
        /// The Text of the item.
        /// </summary>
        string Text { get; set; }
    }
}
