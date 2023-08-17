using System.Collections.Generic;
using System;

namespace PropertyCore.Domain.Entities
{
    public partial class ListManagementCode
    {
        public ListManagementCode()
        {
            ListManagementCodeAttribute = new HashSet<ListManagementCodeAttribute>();
            ListManagementCodeAttributes = new HashSet<ListManagementCodeAttributes>();
            ListManagementCodeEntry = new HashSet<ListManagementCodeEntry>();
            ListManagementCodeGroupEntry = new HashSet<ListManagementCodeGroupEntry>();
        }

        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public string Id { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Type { get; set; }
        public string Version { get; set; }
        public DateTime? LastUpdated1 { get; set; }
        public DateTime? StartDate1 { get; set; }
        public DateTime? EndDate1 { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual ListManagement Instance { get; set; }
        public virtual ICollection<ListManagementCodeAttribute> ListManagementCodeAttribute { get; set; }
        public virtual ICollection<ListManagementCodeAttributes> ListManagementCodeAttributes { get; set; }
        public virtual ICollection<ListManagementCodeEntry> ListManagementCodeEntry { get; set; }
        public virtual ICollection<ListManagementCodeGroupEntry> ListManagementCodeGroupEntry { get; set; }
    }
}