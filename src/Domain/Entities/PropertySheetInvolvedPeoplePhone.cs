using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheetInvolvedPeoplePhone
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string PhoneTypeId { get; set; }
        public string PhoneType { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetInvolvedPeople PropertySheetInvolvedPeople { get; set; }
    }
}
