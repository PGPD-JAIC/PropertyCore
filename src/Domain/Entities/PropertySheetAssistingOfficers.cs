using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheetAssistingOfficers
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public string AssistingOfficerId { get; set; }
        public string AssistingOfficer { get; set; }
        public string PeroleId { get; set; }
        public string Perole { get; set; }
        public DateTime? Pedate { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheet Instance { get; set; }
    }
}
