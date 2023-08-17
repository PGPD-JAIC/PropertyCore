using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheetTagsChainOfCustody
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string TransactionTypeId { get; set; }
        public string TransactionType { get; set; }
        public DateTime? TransactionDatetime { get; set; }
        public string CheckedInFromId { get; set; }
        public string CheckedInFrom { get; set; }
        public string CheckedInToId { get; set; }
        public string CheckedInTo { get; set; }
        public string CheckedOutToId { get; set; }
        public string CheckedOutTo { get; set; }
        public string MoveToId { get; set; }
        public string MoveTo { get; set; }
        public string ReceivedFromId { get; set; }
        public string ReceivedFrom { get; set; }
        public string ReleasedToId { get; set; }
        public string ReleasedTo { get; set; }
        public string UserId { get; set; }
        public string User { get; set; }
        public string AuthorizerId { get; set; }
        public string Authorizer { get; set; }
        public string Details { get; set; }
        public string Notes { get; set; }
        public DateTime? DateInserted { get; set; }
        public DateTime? TransactionServerDatetime { get; set; }

        public virtual PropertySheetTags PropertySheetTags { get; set; }
    }
}
