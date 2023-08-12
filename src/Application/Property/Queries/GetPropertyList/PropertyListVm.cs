using PropertyCore.Application.Common.Models;
using System.Collections.Generic;

namespace PropertyCore.Application.Property.Queries.GetPropertyList
{
    /// <summary>
    /// Viewmodel class used to return a list of property items.
    /// </summary>
    public class PropertyListVm
    {
        /// <summary>
        /// A collection of property items converted to <see cref="PropertyListPropertyItemDto"/>
        /// </summary>
        public ICollection<PropertyListPropertyItemDto> PropertyItems { get; set; }
        /// <summary>
        /// A paging info object used to provide paging functionality.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
        /// <summary>
        /// Contains any value provided in the BarCodeSearch of the associated query.
        /// </summary>
        public string BarCode { get; set; } = "";
        /// <summary>
        /// Contains any value provided in the CaseNumberSearch of the associated query.
        /// </summary>
        public string CaseNumber { get; set; } = "";
        /// <summary>
        /// Contains any value provided in the PropertySheetSearch of the associated query.
        /// </summary>
        public string PropertySheet { get; set; } = "";
        /// <summary>
        /// Contains the current sorting value being applied to the list.
        /// </summary>
        public string CurrentSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the date column.
        /// </summary>
        public string DateSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort by the Case Number column.
        /// </summary>
        public string CaseNumberSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort by the Property Sheet column.
        /// </summary>
        public string PropertySheetSort { get; set; } = "";
    }
}
