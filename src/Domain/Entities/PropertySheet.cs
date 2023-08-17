using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheet
    {
        public PropertySheet()
        {
            PropertySheetAssistingOfficers = new HashSet<PropertySheetAssistingOfficers>();
            PropertySheetInvolvedPeople = new HashSet<PropertySheetInvolvedPeople>();
            PropertySheetPgcAssociatedProperty = new HashSet<PropertySheetPgcAssociatedProperty>();
            PropertySheetTags = new HashSet<PropertySheetTags>();
        }

        public Guid InstanceId { get; set; }
        public bool? IsJuvenile { get; set; }
        public string AgencyIdid { get; set; }
        public string AgencyId { get; set; }
        public string SheetNumber { get; set; }
        public string CaseNumber { get; set; }
        public string Subject { get; set; }
        public string EvidenceTypeId { get; set; }
        public string EvidenceType { get; set; }
        public string Cadnumber { get; set; }
        public string SubmittingOfficerId { get; set; }
        public string SubmittingOfficer { get; set; }
        public string SubmitRank { get; set; }
        public string SubmitBadgeNumber { get; set; }
        public string SubmitUnit { get; set; }
        public DateTime? SubmitDate { get; set; }
        public string ResponsibleOfficerId { get; set; }
        public string ResponsibleOfficer { get; set; }
        public string ResponsibleRank { get; set; }
        public string ResponsibleBadgeNumber { get; set; }
        public string ResponsibleUnit { get; set; }
        public string SupervisorOfficerId { get; set; }
        public string SupervisorOfficer { get; set; }
        public string SupervisorRank { get; set; }
        public string SupervisorBadgeNumber { get; set; }
        public string SupervisorUnit { get; set; }
        public string InitialLocationId { get; set; }
        public string InitialLocation { get; set; }
        public string LockerNumber { get; set; }
        public string TransportOfficerId { get; set; }
        public string TransportOfficer { get; set; }
        public string TransportFromId { get; set; }
        public string TransportFrom { get; set; }
        public string TransportToId { get; set; }
        public string TransportTo { get; set; }
        public string BinMonthId { get; set; }
        public string BinMonth { get; set; }
        public string Bin { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string RecoveryLocation { get; set; }
        public DateTime? RecoveredDate { get; set; }
        public string ReceiverOfficerId { get; set; }
        public string ReceiverOfficer { get; set; }
        public string ReceiverBadgeNumber { get; set; }
        public string Receipt { get; set; }
        public string Ncicentry { get; set; }
        public string AgencyEntered { get; set; }
        public string Notes { get; set; }
        public long? TagsNextNumber { get; set; }
        public string OldCaseNo { get; set; }
        public DateTime? DateInserted { get; set; }
        public string Version { get; set; }
        public string PgcagencyId { get; set; }
        public string Pgcagency { get; set; }
        public string PgassignId { get; set; }
        public string Pgassign { get; set; }
        public string PropAddress { get; set; }
        public string PropCsz { get; set; }
        public string PropCity { get; set; }
        public string PropState { get; set; }
        public string PropZip { get; set; }
        public string IncidentTypeId { get; set; }
        public string IncidentType { get; set; }
        public string LocationMasterDocId { get; set; }
        public string LocationMasterFolderId { get; set; }
        public string NewSubject { get; set; }
        public string InvestigatorAssignedToId { get; set; }
        public string InvestigatorAssignedTo { get; set; }

        public virtual PropertySheetMetadata PropertySheetMetadata { get; set; }
        public virtual ICollection<PropertySheetAssistingOfficers> PropertySheetAssistingOfficers { get; set; }
        public virtual ICollection<PropertySheetInvolvedPeople> PropertySheetInvolvedPeople { get; set; }
        public virtual ICollection<PropertySheetPgcAssociatedProperty> PropertySheetPgcAssociatedProperty { get; set; }
        public virtual ICollection<PropertySheetTags> PropertySheetTags { get; set; }
    }
}
