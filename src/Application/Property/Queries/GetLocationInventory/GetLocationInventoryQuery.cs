using MediatR;

namespace PropertyCore.Application.Property.Queries.GetLocationInventory
{
    /// <summary>
    /// Implementation of <see cref="IRequest"/> that retrieves a list of property Items in a given location.
    /// </summary>
    public class GetLocationInventoryQuery : IRequest<LocationInventoryVm>
    {
        /// <summary>
        /// The Id of the Location.
        /// </summary>
        public string SelectedLocationId { get; set; }
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
