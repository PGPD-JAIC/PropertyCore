using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities.DHStore
{
    public partial class PropertySheetTagsVehicleColors
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string ColorTypeId { get; set; }
        public string ColorType { get; set; }
        public string ColorId { get; set; }
        public string Color { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetTags PropertySheetTags { get; set; }
    }
}
