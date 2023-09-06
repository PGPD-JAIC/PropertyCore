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
        /// A collection of <see cref="DropDownListItem"/> containing Property category options.
        /// </summary>
        public ICollection<DropDownListItem> PropertyCategories { get; set; }
        /// <summary>
        /// A collection of <see cref="DropDownListItem"/> containing Property type options.
        /// </summary>
        public ICollection<DropDownListItem> PropertyTypes { get; set; }
        /// <summary>
        /// A collection of <see cref="DropDownListItem"/> containing Property status options.
        /// </summary>
        public ICollection<DropDownListItem> PropertyStatuses { get; set; }
        /// <summary>
        /// A collection of <see cref="DropDownListItem"/> containing Property Hold status options.
        /// </summary>
        public ICollection<DropDownListItem> HoldStatuses { get; set; }
        /// <summary>
        /// A colleciton of <see cref="DropDownListItem"/> containing RMS Realm Identifiers.
        /// </summary>
        public ICollection<DropDownListItem> Realms { get; set; }
        /// <summary>
        /// A paging info object used to provide paging functionality.
        /// </summary>
        public PagingInfo PagingInfo { get; set; }
        /// <summary>
        /// The value of the selected property type Id, if any.
        /// </summary>
        public string SelectedPropertyTypeId { get; set; }
        /// <summary>
        /// The value of the selected property category, if any.
        /// </summary>
        public string SelectedPropertyCategory { get; set; }
        /// <summary>
        /// The value of the selected property status Id, if any.
        /// </summary>
        public string SelectedPropertyStatusId { get; set; }
        /// <summary>
        /// The value of the selected property hold status Id, if any.
        /// </summary>
        public string SelectedPropertyHoldStatusId { get; set; }
        /// <summary>
        /// An optional ID for the selected realm. Defaults to PGPD Realm.
        /// </summary>
        public string SelectedRealmId { get; set; } = "";
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
        /// Contains a value that can be used to sort the results list by the Bar Code column.
        /// </summary>
        public string BarCodeSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the Property Type column.
        /// </summary>
        public string PropertyTypeSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the Property Category column.
        /// </summary>
        public string PropertyCategorySort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the Date column.
        /// </summary>
        public string DateSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the Case Number column.
        /// </summary>
        public string CaseNumberSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the Property Sheet column.
        /// </summary>
        public string PropertySheetSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the Disposition column.
        /// </summary>
        public string DispositionSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the Location column.
        /// </summary>
        public string LocationSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the status column.
        /// </summary>
        public string StatusSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the hold status column.
        /// </summary>
        public string HoldStatusSort { get; set; } = "";
        /// <summary>
        /// Contains a value that can be used to sort the results list by the agency name column.
        /// </summary>
        public string AgencyNameSort { get; set; } = "";
    }
}
