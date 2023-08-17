using System;

namespace PropertyCore.Domain.Entities
{
    public partial class ListManagementCodeGroupEntry
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string Locale { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual ListManagementCode ListManagementCode { get; set; }
    }
}