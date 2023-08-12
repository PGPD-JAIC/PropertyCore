using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities.DHStore
{
    public partial class PropertyPropertyAlert
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public string PropertyAlertId { get; set; }
        public string PropertyAlert { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual Property Instance { get; set; }
    }
}
