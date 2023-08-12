using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities.DHStore
{
    public partial class PropertySheetInvolvedPeopleAddresses
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string AddressTypeId { get; set; }
        public string AddressType { get; set; }
        public string Address { get; set; }
        public string CityStateZip { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public string CountryId { get; set; }
        public string Country { get; set; }
        public DateTime? DateInserted { get; set; }
        public string PostalCity { get; set; }

        public virtual PropertySheetInvolvedPeople PropertySheetInvolvedPeople { get; set; }
    }
}
