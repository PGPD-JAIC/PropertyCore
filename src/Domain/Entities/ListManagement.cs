using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyCore.Domain.Entities
{
    public partial class ListManagement
    {
        public ListManagement()
        {
            ListManagementAttributeDef = new HashSet<ListManagementAttributeDef>();
            ListManagementAttributesattributedef = new HashSet<ListManagementAttributesattributedef>();
            ListManagementCode = new HashSet<ListManagementCode>();
        }

        public Guid InstanceId { get; set; }
        public string Name { get; set; }
        public DateTime? LastUpdated { get; set; }
        public DateTime? LastUpdated1 { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual ListManagementMetadata ListManagementMetadata { get; set; }
        public virtual ICollection<ListManagementAttributeDef> ListManagementAttributeDef { get; set; }
        public virtual ICollection<ListManagementAttributesattributedef> ListManagementAttributesattributedef { get; set; }
        public virtual ICollection<ListManagementCode> ListManagementCode { get; set; }
    }
}
