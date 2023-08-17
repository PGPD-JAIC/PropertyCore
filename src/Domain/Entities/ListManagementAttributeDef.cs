using System;

namespace PropertyCore.Domain.Entities
{
    public partial class ListManagementAttributeDef
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public string Name { get; set; }
        public DateTime? Created { get; set; }
        public string Description { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual ListManagement Instance { get; set; }
    }
}