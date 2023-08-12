using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities.DHStore
{
    public partial class PropertySheetPgcPropColor
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string PgcColorTypeId { get; set; }
        public string PgcColorType { get; set; }
        public string PropColorId { get; set; }
        public string PropColor { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetTags PropertySheetTags { get; set; }
    }
}
