using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheetPgcTransactions
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string PgcTransactionTypeId { get; set; }
        public string PgcTransactionType { get; set; }
        public DateTime? PgcTransDateTime { get; set; }
        public string PgcTransferToFromId { get; set; }
        public string PgcTransferToFrom { get; set; }
        public string PgcTransferFromToId { get; set; }
        public string PgcTransferFromTo { get; set; }
        public string PgcTransferJustificaiton { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetPgcAssociatedProperty PropertySheetPgcAssociatedProperty { get; set; }
    }
}
