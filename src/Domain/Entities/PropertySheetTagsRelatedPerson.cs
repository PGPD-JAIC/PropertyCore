using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheetTagsRelatedPerson
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string InvolvedPeopleId { get; set; }
        public string InvolvedPeople { get; set; }
        public string RelationTypeId { get; set; }
        public string RelationType { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetTags PropertySheetTags { get; set; }
    }
}
