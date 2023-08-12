using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities.DHStore
{
    public partial class PropertySheetInvolvedPeople
    {
        public PropertySheetInvolvedPeople()
        {
            PropertySheetInvolvedPeopleAddresses = new HashSet<PropertySheetInvolvedPeopleAddresses>();
            PropertySheetInvolvedPeoplePhone = new HashSet<PropertySheetInvolvedPeoplePhone>();
        }

        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public string IsSealed { get; set; }
        public string InvolvedPeopleId { get; set; }
        public string TypeId { get; set; }
        public string Type { get; set; }
        public string PeopleCentralIndexId { get; set; }
        public string PeopleMasterId { get; set; }
        public string PeopleNo { get; set; }
        public string SexId { get; set; }
        public string Sex { get; set; }
        public string RaceId { get; set; }
        public string Race { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Pob { get; set; }
        public string ControlNumber { get; set; }
        public string InvolvedFelonId { get; set; }
        public string InvolvedFelon { get; set; }
        public string Age { get; set; }
        public string JuvenileId { get; set; }
        public string Juvenile { get; set; }
        public string Notes { get; set; }
        public DateTime? DateInserted { get; set; }
        public string Id { get; set; }
        public string Merged { get; set; }
        public string Name { get; set; }
        public string InvolvedAddress { get; set; }
        public string InvolvedCsz { get; set; }
        public string CurrentInvolvedAddress { get; set; }
        public string CurrentInvolvedCsz { get; set; }

        public virtual PropertySheet Instance { get; set; }
        public virtual ICollection<PropertySheetInvolvedPeopleAddresses> PropertySheetInvolvedPeopleAddresses { get; set; }
        public virtual ICollection<PropertySheetInvolvedPeoplePhone> PropertySheetInvolvedPeoplePhone { get; set; }
    }
}
