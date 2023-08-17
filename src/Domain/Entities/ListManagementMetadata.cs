using System;

namespace PropertyCore.Domain.Entities
{
    public partial class ListManagementMetadata
    {
        public Guid InstanceId { get; set; }
        public string InstanceSecurity { get; set; }
        public string WorkflowStage { get; set; }
        public Guid? ContainerSourceId { get; set; }
        public Guid? ContainerId { get; set; }
        public string InstanceLocation { get; set; }
        public decimal? Xcoordinate { get; set; }
        public decimal? Ycoordinate { get; set; }
        public Guid? AuthorId { get; set; }
        public Guid? OwnerId { get; set; }
        public bool? IsValid { get; set; }
        public Guid? AssignedToId { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool IsSealed { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual ListManagement Instance { get; set; }
    }
}