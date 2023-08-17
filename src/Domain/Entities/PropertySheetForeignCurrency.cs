using System;

namespace PropertyCore.Domain.Entities
{
    public partial class PropertySheetForeignCurrency
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string TypeForeignCurrencyId { get; set; }
        public string TypeForeignCurrency { get; set; }
        public string CurrencyDesc { get; set; }
        public string CurrSerialNo { get; set; }
        public string Quantity { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetTags PropertySheetTags { get; set; }
    }
}
