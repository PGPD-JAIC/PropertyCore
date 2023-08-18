using MediatR;

namespace PropertyCore.Application.Property.Commands.LocationAudit
{
    /// <summary>
    /// Implementation of <see cref="IRequest"/> that conducts an audit of the provided barcodes against the selected Location Audit.
    /// </summary>
    public class LocationAuditCommand : IRequest<LocationAuditResultVm>
    {
        /// <summary>
        /// A string containing a list of BarCodes separated by commas.
        /// </summary>
        public string BarCodes { get; set; }
        /// <summary>
        /// The Id of the Property Location to audit against the list of barcodes.
        /// </summary>
        public string LocationId { get; set; }
    }
}
