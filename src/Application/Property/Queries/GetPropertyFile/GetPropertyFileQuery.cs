using MediatR;

namespace PropertyCore.Application.Property.Queries.GetPropertyFile
{
    /// <summary>
    /// Implementation of <see cref="IRequest"/> that handles requests to retrieve a list of property items.
    /// </summary>
    public class GetPropertyFileQuery : IRequest<PropertyFileVm>
    {
        /// <summary>
        /// An optional search parameter that searches against the Bar Code value.
        /// </summary>
        public string BarCodeSearch { get; set; } = "";
        /// <summary>
        /// An optional search parameter that searches against the Case Number value.
        /// </summary>
        public string CaseNumberSearch { get; set; } = "";
        /// <summary>
        /// An optional search parameter that searches against the Property Sheet Number value.
        /// </summary>
        public string PropertySheetSearch { get; set; } = "";
        /// <summary>
        /// An optional ID for the selected property type.
        /// </summary>
        public string SelectedPropertyTypeId { get; set; } = "";
        /// <summary>
        /// An optional ID for the selected property category.
        /// </summary>
        public string SelectedPropertyCategory { get; set; } = "";
        /// <summary>
        /// An optional ID for the selected property status.
        /// </summary>
        public string SelectedPropertyStatusId { get; set; } = "";
        /// <summary>
        /// An optional ID for the selected hold status.
        /// </summary>
        public string SelectedHoldStatusId { get; set; } = "";
        /// <summary>
        /// An optional ID for the Realm.
        /// </summary>
        public string SelectedRealmId { get; set; } = "";
        /// <summary>
        /// An optional sort order string that will sort the result list.
        /// </summary>
        public string SortOrder { get; set; } = "";
    }
}
