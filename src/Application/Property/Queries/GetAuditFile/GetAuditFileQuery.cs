using MediatR;

namespace PropertyCore.Application.Property.Queries.GetAuditFile
{
    /// <summary>
    /// Implementation of <see cref="IRequest"/> that retrieves a file containing audit results of the provided barcodes against the selected Location Audit.
    /// </summary>
    public class GetAuditFileQuery : IRequest<AuditFileVm>
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
