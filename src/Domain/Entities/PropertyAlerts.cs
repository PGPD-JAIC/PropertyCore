using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertyAlerts
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public string AlertId { get; set; }
        public string Alert { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string TransactionId { get; set; }
        public string Notes { get; set; }
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual Property Instance { get; set; }
    }
}
