using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities.DHStore
{
    public partial class PropertyTransactionDetails
    {
        public Guid InstanceId { get; set; }
        public string CustomCommand { get; set; }
        public string GeneralStatus { get; set; }
        public string GeneralStatusId { get; set; }
        public string ItmNumber { get; set; }
        public string ItmStatus { get; set; }
        public string ItmStatusId { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedById { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ExecutedOn { get; set; }
        public string Tag { get; set; }
        public string AuthorizedBy { get; set; }
        public string AuthorizedById { get; set; }
        public string CheckedInFrom { get; set; }
        public string CheckedInFromId { get; set; }
        public string CheckedInToLocation { get; set; }
        public string CheckedInToLocationId { get; set; }
        public string CheckedOutTo { get; set; }
        public string CheckedOutToId { get; set; }
        public string DisposalMethod { get; set; }
        public string DisposalMethodId { get; set; }
        public string MoveToLocation { get; set; }
        public string MoveToLocationId { get; set; }
        public string ReasonforVariance { get; set; }
        public string ReasonforVarianceId { get; set; }
        public string ReceivedFrom { get; set; }
        public string ReceivedFromId { get; set; }
        public string ReleasedTo { get; set; }
        public string ReleasedToId { get; set; }
        public string Measure { get; set; }
        public string MeasureId { get; set; }
        public string Notes { get; set; }
        public string Quantity { get; set; }
        public string ExpectedReturnDate { get; set; }
    }
}
