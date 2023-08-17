using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{
    public partial class Property
    {
        public Property()
        {
            PropertyAlerts = new HashSet<PropertyAlerts>();
            PropertyPropertyAlert = new HashSet<PropertyPropertyAlert>();
        }

        public Guid InstanceId { get; set; }
        public string VerifiedId { get; set; }
        public string Verified { get; set; }
        public string VerifiedById { get; set; }
        public string VerifiedBy { get; set; }
        public DateTime? VerificationDate { get; set; }
        public byte[] PropertyPhoto { get; set; }
        public string PropertyNumber { get; set; }
        public string Owner { get; set; }
        public string PropertyTypeId { get; set; }
        public string PropertyType { get; set; }
        public string PropertyTypeCategory { get; set; }
        public string PropertyDescription { get; set; }
        public string Ucrcode { get; set; }
        public string PropertyStatusId { get; set; }
        public string PropertyStatus { get; set; }
        public string Disposition { get; set; }
        public DateTime? RecoveryDate { get; set; }
        public string Quantity { get; set; }
        public string PropertyValue { get; set; }
        public string Units { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string SerialNumber { get; set; }
        public string OwnerAppliedNumber { get; set; }
        public string IdentifyingMarks { get; set; }
        public string Description { get; set; }
        public string LicenseNumber { get; set; }
        public string LicenseYear { get; set; }
        public string LicenseStateId { get; set; }
        public string LicenseState { get; set; }
        public string LicenseCountryId { get; set; }
        public string LicenseCountry { get; set; }
        public string ColorId { get; set; }
        public string Color { get; set; }
        public string Finish { get; set; }
        public string Condition { get; set; }
        public string EvidenceTag { get; set; }
        public string StateId { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string CountyTag { get; set; }
        public string DrugTypeId { get; set; }
        public string DrugType { get; set; }
        public string DrugQuantity { get; set; }
        public string DrugMeasureId { get; set; }
        public string DrugMeasure { get; set; }
        public string FirearmCaliberId { get; set; }
        public string FirearmCaliber { get; set; }
        public string FirearmTypeId { get; set; }
        public string FirearmType { get; set; }
        public string BarrelLength { get; set; }
        public string FirearmColorId { get; set; }
        public string FirearmColor { get; set; }
        public string FirearmActionId { get; set; }
        public string FirearmAction { get; set; }
        public string BicycleMakeId { get; set; }
        public string BicycleMake { get; set; }
        public string BicycleModelId { get; set; }
        public string BicycleModel { get; set; }
        public decimal? BicycleSpeed { get; set; }
        public decimal? BicycleWheelSize { get; set; }
        public string SourceId { get; set; }
        public string Source { get; set; }
        public string SourceNumber { get; set; }
        public DateTime? SourceDate { get; set; }
        public string SourceInstanceId { get; set; }
        public string Notes { get; set; }
        public bool? HasAlerts { get; set; }
        public DateTime? DateInserted { get; set; }
        public string DocPullPath { get; set; }

        public virtual PropertyMetadata PropertyMetadata { get; set; }
        public virtual ICollection<PropertyAlerts> PropertyAlerts { get; set; }
        public virtual ICollection<PropertyPropertyAlert> PropertyPropertyAlert { get; set; }
    }
}
