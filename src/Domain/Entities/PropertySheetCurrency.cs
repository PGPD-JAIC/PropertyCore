using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities.DHStore
{
    public partial class PropertySheetCurrency
    {
        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public int SeqNo2 { get; set; }
        public string CurrTypeId { get; set; }
        public string CurrType { get; set; }
        public string CurrDenomId { get; set; }
        public string CurrDenom { get; set; }
        public string Amount { get; set; }
        public string SerialNo { get; set; }
        public string DenomAmount { get; set; }
        public string CoinTotal { get; set; }
        public string Total { get; set; }
        public string CoinTotalAmt { get; set; }
        public DateTime? DateInserted { get; set; }

        public virtual PropertySheetTags PropertySheetTags { get; set; }
    }
}
