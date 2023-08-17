using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheetPgcPropertyTag
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string PgcPropertyDetailTag { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetPgcAssociatedProperty PropertySheetPgcAssociatedProperty { get; set; }
    }
}
