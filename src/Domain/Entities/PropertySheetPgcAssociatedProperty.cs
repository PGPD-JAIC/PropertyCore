using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities.DHStore
{
    public partial class PropertySheetPgcAssociatedProperty
    {
        public PropertySheetPgcAssociatedProperty()
        {
            PropertySheetPgcAssociatedPropertyConclusion = new HashSet<PropertySheetPgcAssociatedPropertyConclusion>();
            PropertySheetPgcPropertyTag = new HashSet<PropertySheetPgcPropertyTag>();
            PropertySheetPgcTransactions = new HashSet<PropertySheetPgcTransactions>();
        }

        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public DateTime? DateInserted { get; set; }
        public string PropertyTag { get; set; }
        public string PropTypeCodesId { get; set; }
        public string PropTypeCodes { get; set; }
        public string PgcpropertyCentralIndexId { get; set; }
        public string PgcpropertyMasterId { get; set; }
        public string Description { get; set; }
        public string RecoveredById { get; set; }
        public string RecoveredBy { get; set; }
        public DateTime? RecoveredDateTime { get; set; }
        public string RecovOtherJursId { get; set; }
        public string RecovOtherJurs { get; set; }
        public string OtherCaseNo { get; set; }
        public string PropertyStatusId { get; set; }
        public string PropertyStatus { get; set; }
        public string HoldStatusId { get; set; }
        public string HoldStatus { get; set; }
        public string BioHazardId { get; set; }
        public string BioHazard { get; set; }
        public DateTime? DateReceived { get; set; }
        public DateTime? DateRangeStart { get; set; }
        public DateTime? DateRangeComplete { get; set; }
        public string Suspects { get; set; }
        public string LabNo { get; set; }
        public string BeforeDescription { get; set; }
        public string BeforeWeight { get; set; }
        public string AfterWeight { get; set; }
        public string AnalystNameId { get; set; }
        public string AnalystName { get; set; }
        public string TechnicalReviewId { get; set; }
        public string TechnicalReview { get; set; }
        public string FirearmLabNo { get; set; }
        public DateTime? FrecoveredDateTime { get; set; }
        public DateTime? FdateReceived { get; set; }
        public DateTime? FdateStart { get; set; }
        public DateTime? FdateComplete { get; set; }
        public string FanalystId { get; set; }
        public string Fanalyst { get; set; }
        public string FtechnicalReviewId { get; set; }
        public string FtechnicalReview { get; set; }
        public string Fsuspects { get; set; }
        public string DnalabNo { get; set; }
        public decimal? FeubarrelLength { get; set; }
        public decimal? FeuoverallLength { get; set; }
        public string FeufirearmTypeId { get; set; }
        public string FeufirearmType { get; set; }
        public string FeufirearmMakeModelId { get; set; }
        public string FeufirearmMakeModel { get; set; }
        public string FeucaliberId { get; set; }
        public string Feucaliber { get; set; }
        public string FeuserialNo { get; set; }
        public string Feuresult1Id { get; set; }
        public string Feuresult1 { get; set; }
        public string Feuresult2 { get; set; }
        public string FeuwitnessId { get; set; }
        public string Feuwitness { get; set; }
        public string FeuunitId { get; set; }
        public string Feuunit { get; set; }
        public DateTime? DrecoveredDateTime { get; set; }
        public DateTime? DdateReceived { get; set; }
        public DateTime? DdateRangeStart { get; set; }
        public DateTime? DdateCompleted { get; set; }
        public string DanalystNameId { get; set; }
        public string DanalystName { get; set; }
        public string DtechnicalReviewId { get; set; }
        public string DtechnicalReview { get; set; }
        public string FeualteredId { get; set; }
        public string Feualtered { get; set; }
        public string FeumeasReviewId { get; set; }
        public string FeumeasReview { get; set; }
        public string FeumrunitId { get; set; }
        public string Feumrunit { get; set; }
        public string FeuserialNoRestId { get; set; }
        public string FeuserialNoRest { get; set; }
        public string FeuserNoRestId { get; set; }
        public string FeuserNoRest { get; set; }
        public string FeuserNoRevId { get; set; }
        public string FeuserNoRev { get; set; }
        public string FeuserNoRevUnitId { get; set; }
        public string FeuserNoRevUnit { get; set; }
        public string FeuserNoRemarks { get; set; }
        public decimal? FeubarrelLength2 { get; set; }

        public virtual PropertySheet Instance { get; set; }
        public virtual ICollection<PropertySheetPgcAssociatedPropertyConclusion> PropertySheetPgcAssociatedPropertyConclusion { get; set; }
        public virtual ICollection<PropertySheetPgcPropertyTag> PropertySheetPgcPropertyTag { get; set; }
        public virtual ICollection<PropertySheetPgcTransactions> PropertySheetPgcTransactions { get; set; }
    }
}
