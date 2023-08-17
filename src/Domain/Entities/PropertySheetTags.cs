using System;
using System.Collections.Generic;

namespace PropertyCore.Domain.Entities
{ 
    public partial class PropertySheetTags
    {
        public PropertySheetTags()
        {
            PropertySheetCurrency = new HashSet<PropertySheetCurrency>();
            PropertySheetFieldTransaction = new HashSet<PropertySheetFieldTransaction>();
            PropertySheetForeignCurrency = new HashSet<PropertySheetForeignCurrency>();
            PropertySheetPgcPropColor = new HashSet<PropertySheetPgcPropColor>();
            PropertySheetTagsChainOfCustody = new HashSet<PropertySheetTagsChainOfCustody>();
            PropertySheetTagsRelatedPerson = new HashSet<PropertySheetTagsRelatedPerson>();
            PropertySheetTagsVehicleColors = new HashSet<PropertySheetTagsVehicleColors>();
        }

        public Guid InstanceId { get; set; }
        public int SeqNo1 { get; set; }
        public string TagsSummary { get; set; }
        public byte[] Photo { get; set; }
        public string TagNumber { get; set; }
        public string LabProcessingRequiredId { get; set; }
        public string LabProcessingRequired { get; set; }
        public string LabNumber { get; set; }
        public string Description { get; set; }
        public string VehicleDescription { get; set; }
        public string PropertyTypeId { get; set; }
        public string PropertyType { get; set; }
        public string PropertyCategory { get; set; }
        public string SeizedPendingForfeitureId { get; set; }
        public string SeizedPendingForfeiture { get; set; }
        public string RecoveredforOtherJurisdictionId { get; set; }
        public string RecoveredforOtherJurisdiction { get; set; }
        public string OtherAgencyIdentifier { get; set; }
        public string StatusId { get; set; }
        public string Status { get; set; }
        public string CurrentDispositionId { get; set; }
        public string CurrentDisposition { get; set; }
        public string CurrentLocationId { get; set; }
        public string CurrentLocation { get; set; }
        public DateTime? ExpectedReturnDate { get; set; }
        public DateTime? ScheduledPurgeDate { get; set; }
        public DateTime? NextReviewDate { get; set; }
        public string DisposalMethodId { get; set; }
        public string DisposalMethod { get; set; }
        public string BiohazardId { get; set; }
        public string Biohazard { get; set; }
        public string Value { get; set; }
        public string Quantity { get; set; }
        public string Units { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Importer { get; set; }
        public string SerialNumber { get; set; }
        public string OwnerAppliedNumber { get; set; }
        public string IdentifyingMarks { get; set; }
        public string ColorId { get; set; }
        public string Color { get; set; }
        public string Finish { get; set; }
        public string Condition { get; set; }
        public string License { get; set; }
        public string StolenId { get; set; }
        public string Stolen { get; set; }
        public string OrinotifiedBy { get; set; }
        public string FirearmsPriorityId { get; set; }
        public string FirearmsPriority { get; set; }
        public string FirearmCaliberId { get; set; }
        public string FirearmCaliber { get; set; }
        public string FirearmTypeId { get; set; }
        public string FirearmType { get; set; }
        public string BarrelLength { get; set; }
        public string FirearmColorId { get; set; }
        public string FirearmColor { get; set; }
        public string FirearmActionId { get; set; }
        public string FirearmAction { get; set; }
        public string FirearmCapacity { get; set; }
        public string FirearmMarkings { get; set; }
        public string FirearmQueryById { get; set; }
        public string FirearmQueryBy { get; set; }
        public string FirearmBadgeNumber { get; set; }
        public string LoadedId { get; set; }
        public string Loaded { get; set; }
        public string SafetyId { get; set; }
        public string Safety { get; set; }
        public string CockedId { get; set; }
        public string Cocked { get; set; }
        public string CartridgesInCylinder { get; set; }
        public string CartridgesInChamber { get; set; }
        public string CartridgesInMagazine { get; set; }
        public string CartridgesAtScene { get; set; }
        public string DischargedCartridgesInCylinder { get; set; }
        public string DischargedCartridgesAtScene { get; set; }
        public string VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
        public string VehicleYear { get; set; }
        public DateTime? LicenseExpDate { get; set; }
        public string LicenseStateId { get; set; }
        public string LicenseState { get; set; }
        public string LicenseCountryId { get; set; }
        public string LicenseCountry { get; set; }
        public decimal? OdometerReading { get; set; }
        public string BoatName { get; set; }
        public string BoatTypeId { get; set; }
        public string BoatType { get; set; }
        public string Hin { get; set; }
        public string HullShapeId { get; set; }
        public string HullShape { get; set; }
        public string PropulsionId { get; set; }
        public string Propulsion { get; set; }
        public decimal? BoatLength { get; set; }
        public string BicycleMakeId { get; set; }
        public string BicycleMake { get; set; }
        public string BicycleModelId { get; set; }
        public string BicycleModel { get; set; }
        public decimal? BicycleSpeed { get; set; }
        public decimal? BicycleWheelSize { get; set; }
        public string DenominationId { get; set; }
        public string Denomination { get; set; }
        public string CurrencyCoins { get; set; }
        public decimal? CurrencyOnes { get; set; }
        public decimal? CurrencyFives { get; set; }
        public decimal? CurrencyTens { get; set; }
        public decimal? CurrencyTwenties { get; set; }
        public decimal? CurrencyFifties { get; set; }
        public decimal? CurrencyHundreds { get; set; }
        public string CurrencyOther { get; set; }
        public string CurrencyTotal { get; set; }
        public string SecuritiesTypeId { get; set; }
        public string SecuritiesType { get; set; }
        public string SecuritiesIssuer { get; set; }
        public DateTime? SecuritiesIssueDate { get; set; }
        public string DrugTypeId { get; set; }
        public string DrugType { get; set; }
        public string DrugQuantity { get; set; }
        public string DrugMeasureId { get; set; }
        public string DrugMeasure { get; set; }
        public string ReasonforVarianceId { get; set; }
        public string ReasonforVariance { get; set; }
        public string ObtainedByIdid { get; set; }
        public string ObtainedById { get; set; }
        public DateTime? ObtainedDate { get; set; }
        public string ObtainedFrom { get; set; }
        public string OwnerNumber { get; set; }
        public string OffenseId { get; set; }
        public string Offense { get; set; }
        public string NciccrimeCodeId { get; set; }
        public string NciccrimeCode { get; set; }
        public string Explain { get; set; }
        public string CisofficerId { get; set; }
        public string Cisofficer { get; set; }
        public string CisbadgeNumber { get; set; }
        public string CissupervisorId { get; set; }
        public string Cissupervisor { get; set; }
        public string CheckedById { get; set; }
        public string CheckedBy { get; set; }
        public string AssignedToId { get; set; }
        public string AssignedTo { get; set; }
        public string JuvenileInvolvedId { get; set; }
        public string JuvenileInvolved { get; set; }
        public string DomesticViolenceId { get; set; }
        public string DomesticViolence { get; set; }
        public string TagsCaseNoRtf { get; set; }
        public string TagsSheetNoRtf { get; set; }
        public string Notes { get; set; }
        public string Hyppropdetails { get; set; }
        public string DrugWitnessId { get; set; }
        public string DrugWitness { get; set; }
        public decimal? PgcCurrencyDollarCoins { get; set; }
        public decimal? PgcCurrencyHalfDollars { get; set; }
        public decimal? PgcCurrencyQuarters { get; set; }
        public decimal? PgcCurrencyDimes { get; set; }
        public decimal? PgcCurrencyNickels { get; set; }
        public decimal? PgcCurrencyPennies { get; set; }
        public string PgcCurrencyWitnessId { get; set; }
        public string PgcCurrencyWitness { get; set; }
        public string PgcNcicentry { get; set; }
        public string PgcAgencyEntered { get; set; }
        public string PgcOrinotifiedId { get; set; }
        public string PgcOrinotified { get; set; }
        public string PgcLabProcessingTypeId { get; set; }
        public string PgcLabProcessingType { get; set; }
        public DateTime? DateInserted { get; set; }
        public string Id { get; set; }
        public string Merged { get; set; }
        public string NciccheckedById { get; set; }
        public string NciccheckedBy { get; set; }
        public string OwnerNotifiedId { get; set; }
        public string OwnerNotified { get; set; }
        public string OwnerNotifiedById { get; set; }
        public string OwnerNotifiedBy { get; set; }
        public string NotifyMethodId { get; set; }
        public string NotifyMethod { get; set; }
        public string ReceiptIssuedId { get; set; }
        public string ReceiptIssued { get; set; }
        public string DropLocationId { get; set; }
        public string DropLocation { get; set; }
        public string PropStatusId { get; set; }
        public string PropStatus { get; set; }
        public string Rfidno { get; set; }
        public string StatusOwnerPossessorId { get; set; }
        public string StatusOwnerPossessor { get; set; }
        public string FirearmMakeModelId { get; set; }
        public string FirearmMakeModel { get; set; }
        public string FirearmMake { get; set; }
        public string FirearmModel { get; set; }
        public string DrugPkgdById { get; set; }
        public string DrugPkgdBy { get; set; }
        public DateTime? DrugPkgdDateTime { get; set; }
        public string DrugSealedById { get; set; }
        public string DrugSealedBy { get; set; }
        public DateTime? DrugSealDateTime { get; set; }
        public decimal? PropDrugQuant { get; set; }
        public string UscurrencyTotal { get; set; }
        public string UscoinTotal { get; set; }
        public string HoldStatusId { get; set; }
        public string HoldStatus { get; set; }
        public string OriginalSubmittingOfficer { get; set; }
        public string OrigSubmittingOfficer { get; set; }
        public string ItemNumber { get; set; }
        public string PgcnciccheckId { get; set; }
        public string Pgcnciccheck { get; set; }
        public string DrugFieldTestResultsId { get; set; }
        public string DrugFieldTestResults { get; set; }
        public string PgcDrugCaseTypeId { get; set; }
        public string PgcDrugCaseType { get; set; }
        public string IbrtypeCode { get; set; }

        public virtual PropertySheet Instance { get; set; }
        public virtual ICollection<PropertySheetCurrency> PropertySheetCurrency { get; set; }
        public virtual ICollection<PropertySheetFieldTransaction> PropertySheetFieldTransaction { get; set; }
        public virtual ICollection<PropertySheetForeignCurrency> PropertySheetForeignCurrency { get; set; }
        public virtual ICollection<PropertySheetPgcPropColor> PropertySheetPgcPropColor { get; set; }
        public virtual ICollection<PropertySheetTagsChainOfCustody> PropertySheetTagsChainOfCustody { get; set; }
        public virtual ICollection<PropertySheetTagsRelatedPerson> PropertySheetTagsRelatedPerson { get; set; }
        public virtual ICollection<PropertySheetTagsVehicleColors> PropertySheetTagsVehicleColors { get; set; }
    }
}
