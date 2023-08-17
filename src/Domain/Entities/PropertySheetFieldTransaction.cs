using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheetFieldTransaction
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public DateTime? TransDateTime { get; set; }
        public string TransFromId { get; set; }
        public string TransFrom { get; set; }
        public string TransToId { get; set; }
        public string TransTo { get; set; }
        public string TransJustify { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetTags PropertySheetTags { get; set; }
    }
}
