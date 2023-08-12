using MediatR;

namespace PropertyCore.Application.Property.Queries.GetPropertyList
{
    /// <summary>
    /// Implementation of <see cref="IRequest"/> that handles requests to retrieve a list of property items.
    /// </summary>
    public class GetPropertyListQuery : IRequest<PropertyListVm>
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
        /// An optional sort order string that will sort the result list.
        /// </summary>
        public string SortOrder { get; set; } = "";
        /// <summary>
        /// The page number of the result set; defaults to page 1.
        /// </summary>
        public int PageNumber { get; set; } = 1;
        /// <summary>
        /// The number of results to return per page; defaults to 25.
        /// </summary>
        public int PageSize { get; set; } = 25;
    }
}
