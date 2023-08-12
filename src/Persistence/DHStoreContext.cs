using Microsoft.EntityFrameworkCore;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Common;
using PropertyCore.Domain.Entities.DHStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropertyCore.Persistence
{
    public partial class DHStoreContext : DbContext, IDHStoreContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTime _dateTime;
        /// <summary>
        /// Creates a new instance of the <see cref="DHStoreContext"/> class.
        /// </summary>
        /// <param name="options">An implementation of <see cref="DbContextOptions{DHStoreContext}"/></param>
        public DHStoreContext(DbContextOptions<DHStoreContext> options) : base(options) { }
        /// <summary>
        /// Creates a new instance of the <see cref="DHStoreContext"></see>
        /// </summary>
        /// <param name="options">An implementation of <see cref="DbContextOptions{DHStoreContext}"/></param>
        /// <param name="currentUserService">An implementation of <see cref="ICurrentUserService"/></param>
        /// <param name="dateTime">An implementation of <see cref="IDateTime"/></param>
        public DHStoreContext(
            DbContextOptions<DHStoreContext> options,
            ICurrentUserService currentUserService,
            IDateTime dateTime)
            : base(options)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }

        public virtual DbSet<Property> Property { get; set; }

        public DbSet<PropertySheetTags> PropertySheetTags { get; set; }

        public DbSet<PropertySheetMetadata> PropertySheetMetadata { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(e => e.InstanceId);

                entity.Property(e => e.InstanceId).ValueGeneratedNever();

                entity.Property(e => e.BarrelLength)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleMake)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleMakeId)
                    .HasColumnName("BicycleMakeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleModel)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleModelId)
                    .HasColumnName("BicycleModelID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleSpeed).HasColumnType("decimal(17, 0)");

                entity.Property(e => e.BicycleWheelSize).HasColumnType("decimal(17, 0)");

                entity.Property(e => e.Color)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ColorId)
                    .HasColumnName("ColorID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Condition)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountyTag)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Disposition)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DocPullPath)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugMeasure)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugMeasureId)
                    .HasColumnName("DrugMeasureID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugQuantity)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DrugType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugTypeId)
                    .HasColumnName("DrugTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.EvidenceTag)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Finish)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmAction)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmActionId)
                    .HasColumnName("FirearmActionID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmCaliber)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmCaliberId)
                    .HasColumnName("FirearmCaliberID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmColor)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmColorId)
                    .HasColumnName("FirearmColorID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmTypeId)
                    .HasColumnName("FirearmTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.IdentifyingMarks)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseCountry)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseCountryId)
                    .HasColumnName("LicenseCountryID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseNumber)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseState)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseStateId)
                    .HasColumnName("LicenseStateID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseYear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(155)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(155)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Owner)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAppliedNumber)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyDescription)
                    .HasMaxLength(155)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyNumber)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyStatus)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyStatusId)
                    .HasColumnName("PropertyStatusID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTypeCategory)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTypeId)
                    .HasColumnName("PropertyTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyValue)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveryDate).HasColumnType("datetime");

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Source)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SourceDate).HasColumnType("datetime");

                entity.Property(e => e.SourceId)
                    .HasColumnName("SourceID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SourceInstanceId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SourceNumber)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.StateId)
                    .HasColumnName("StateID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Ucrcode)
                    .HasColumnName("UCRCode")
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Units)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VerificationDate).HasColumnType("datetime");

                entity.Property(e => e.Verified)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.VerifiedBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.VerifiedById)
                    .HasColumnName("VerifiedByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.VerifiedId)
                    .HasColumnName("VerifiedID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Year)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PropertyAlerts>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1 });

                entity.ToTable("Property.Alerts");

                entity.Property(e => e.Alert)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.AlertId)
                    .HasColumnName("AlertID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TransactionId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.PropertyAlerts)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK_Property.Alerts_Property");
            });

            modelBuilder.Entity<PropertyMetadata>(entity =>
            {
                entity.HasKey(e => e.InstanceId);

                entity.ToTable("Property__Metadata");

                entity.Property(e => e.InstanceId).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.InstanceLocation).HasColumnType("xml");

                entity.Property(e => e.InstanceSecurity).HasColumnType("xml");

                entity.Property(e => e.WorkflowStage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Xcoordinate)
                    .HasColumnName("XCoordinate")
                    .HasColumnType("decimal(18, 14)");

                entity.Property(e => e.Ycoordinate)
                    .HasColumnName("YCoordinate")
                    .HasColumnType("decimal(18, 14)");

                entity.HasOne(d => d.Instance)
                    .WithOne(p => p.PropertyMetadata)
                    .HasForeignKey<PropertyMetadata>(d => d.InstanceId)
                    .HasConstraintName("FK_Property__Metadata_Property");
            });

            modelBuilder.Entity<PropertyPropertyAlert>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1 });

                entity.ToTable("Property.PropertyAlert");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.PropertyAlert)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyAlertId)
                    .HasColumnName("PropertyAlertID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.PropertyPropertyAlert)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK_Property.PropertyAlert_Property");
            });

            modelBuilder.Entity<PropertySheet>(entity =>
            {
                entity.HasKey(e => e.InstanceId);

                entity.Property(e => e.InstanceId).ValueGeneratedNever();

                entity.Property(e => e.AgencyEntered)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.AgencyId)
                    .HasColumnName("AgencyID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.AgencyIdid)
                    .HasColumnName("AgencyIDID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Bin)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BinMonth)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BinMonthId)
                    .HasColumnName("BinMonthID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Cadnumber)
                    .HasColumnName("CADNumber")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CaseNumber)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.EvidenceType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.EvidenceTypeId)
                    .HasColumnName("EvidenceTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.IncidentType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.IncidentTypeId)
                    .HasColumnName("IncidentTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.InitialLocation)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.InitialLocationId)
                    .HasColumnName("InitialLocationID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.InvestigatorAssignedTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.InvestigatorAssignedToId)
                    .HasColumnName("InvestigatorAssignedToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LocationMasterDocId)
                    .HasColumnName("LocationMasterDocID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LocationMasterFolderId)
                    .HasColumnName("LocationMasterFolderID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LockerNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Ncicentry)
                    .HasColumnName("NCICEntry")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.NewSubject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OldCaseNo)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Pgassign)
                    .HasColumnName("PGAssign")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgassignId)
                    .HasColumnName("PGAssignID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Pgcagency)
                    .HasColumnName("PGCAgency")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcagencyId)
                    .HasColumnName("PGCAgencyID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropAddress)
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.PropCity)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.PropCsz)
                    .HasColumnName("PropCSZ")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.PropState)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.PropZip)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Receipt)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedDate).HasColumnType("datetime");

                entity.Property(e => e.ReceiverBadgeNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverOfficer)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverOfficerId)
                    .HasColumnName("ReceiverOfficerID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveredDate).HasColumnType("datetime");

                entity.Property(e => e.RecoveryLocation)
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsibleBadgeNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsibleOfficer)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsibleOfficerId)
                    .HasColumnName("ResponsibleOfficerID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsibleRank)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.ResponsibleUnit)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SheetNumber)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubmitBadgeNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SubmitDate).HasColumnType("datetime");

                entity.Property(e => e.SubmitRank)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.SubmitUnit)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SubmittingOfficer)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SubmittingOfficerId)
                    .HasColumnName("SubmittingOfficerID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorBadgeNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorOfficer)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorOfficerId)
                    .HasColumnName("SupervisorOfficerID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorRank)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.SupervisorUnit)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransportFrom)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransportFromId)
                    .HasColumnName("TransportFromID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransportOfficer)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransportOfficerId)
                    .HasColumnName("TransportOfficerID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransportTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransportToId)
                    .HasColumnName("TransportToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasMaxLength(512)
                    .IsUnicode(false);


            });

            modelBuilder.Entity<PropertySheetAssistingOfficers>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1 });

                entity.ToTable("PropertySheet.AssistingOfficers");

                entity.Property(e => e.AssistingOfficer)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.AssistingOfficerId)
                    .HasColumnName("AssistingOfficerID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Pedate)
                    .HasColumnName("PEDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Perole)
                    .HasColumnName("PERole")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PeroleId)
                    .HasColumnName("PERoleID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.PropertySheetAssistingOfficers)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK_PropertySheet.AssistingOfficers_PropertySheet");
            });

            modelBuilder.Entity<PropertySheetCurrency>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.Currency");

                entity.Property(e => e.Amount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CoinTotal)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CoinTotalAmt)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CurrDenom)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CurrDenomId)
                    .HasColumnName("CurrDenomID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CurrType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CurrTypeId)
                    .HasColumnName("CurrTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DenomAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Total)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetTags)
                    .WithMany(p => p.PropertySheetCurrency)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.Currency_PropertySheet.Tags");
            });

            modelBuilder.Entity<PropertySheetFieldTransaction>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.FieldTransaction");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.TransDateTime).HasColumnType("datetime");

                entity.Property(e => e.TransFrom)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransFromId)
                    .HasColumnName("TransFromID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransJustify)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TransTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransToId)
                    .HasColumnName("TransToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetTags)
                    .WithMany(p => p.PropertySheetFieldTransaction)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.FieldTransaction_PropertySheet.Tags");
            });

            modelBuilder.Entity<PropertySheetForeignCurrency>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.ForeignCurrency");

                entity.Property(e => e.CurrSerialNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyDesc)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Quantity)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TypeForeignCurrency)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TypeForeignCurrencyId)
                    .HasColumnName("TypeForeignCurrencyID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetTags)
                    .WithMany(p => p.PropertySheetForeignCurrency)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.ForeignCurrency_PropertySheet.Tags");
            });

            modelBuilder.Entity<PropertySheetInvolvedPeople>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1 });

                entity.ToTable("PropertySheet.InvolvedPeople");

                entity.Property(e => e.Age)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ControlNumber)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentInvolvedAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentInvolvedCsz)
                    .HasColumnName("CurrentInvolvedCSZ")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Height)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.InvolvedAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InvolvedCsz)
                    .HasColumnName("InvolvedCSZ")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.InvolvedFelon)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.InvolvedFelonId)
                    .HasColumnName("InvolvedFelonID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.InvolvedPeopleId)
                    .HasColumnName("InvolvedPeopleID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.IsSealed)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Juvenile)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.JuvenileId)
                    .HasColumnName("JuvenileID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Merged)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PeopleCentralIndexId)
                    .HasColumnName("PeopleCentralIndexID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PeopleMasterId)
                    .HasColumnName("PeopleMasterID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PeopleNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Pob)
                    .HasColumnName("POB")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Race)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RaceId)
                    .HasColumnName("RaceID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SexId)
                    .HasColumnName("SexID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasColumnName("TypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.PropertySheetInvolvedPeople)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK_PropertySheet.InvolvedPeople_PropertySheet");
            });

            modelBuilder.Entity<PropertySheetInvolvedPeopleAddresses>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.InvolvedPeople.Addresses");

                entity.Property(e => e.Address)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.AddressType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.AddressTypeId)
                    .HasColumnName("AddressTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.CityStateZip)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CountryId)
                    .HasColumnName("CountryID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.County)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.PostalCity)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetInvolvedPeople)
                    .WithMany(p => p.PropertySheetInvolvedPeopleAddresses)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.InvolvedPeople.Addresses_PropertySheet.InvolvedPeople");
            });

            modelBuilder.Entity<PropertySheetInvolvedPeoplePhone>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.InvolvedPeople.Phone");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneTypeId)
                    .HasColumnName("PhoneTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetInvolvedPeople)
                    .WithMany(p => p.PropertySheetInvolvedPeoplePhone)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.InvolvedPeople.Phone_PropertySheet.InvolvedPeople");
            });

            modelBuilder.Entity<PropertySheetMetadata>(entity =>
            {
                entity.HasKey(e => e.InstanceId);

                entity.ToTable("PropertySheet__Metadata");

                entity.Property(e => e.InstanceId).ValueGeneratedNever();

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.InstanceLocation).HasColumnType("xml");

                entity.Property(e => e.InstanceSecurity).HasColumnType("xml");

                entity.Property(e => e.WorkflowStage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Xcoordinate)
                    .HasColumnName("XCoordinate")
                    .HasColumnType("decimal(18, 14)");

                entity.Property(e => e.Ycoordinate)
                    .HasColumnName("YCoordinate")
                    .HasColumnType("decimal(18, 14)");

                entity.HasOne(d => d.Instance)
                    .WithOne(p => p.PropertySheetMetadata)
                    .HasForeignKey<PropertySheetMetadata>(d => d.InstanceId)
                    .HasConstraintName("FK_PropertySheet__Metadata_PropertySheet");
            });

            modelBuilder.Entity<PropertySheetPgcAssociatedProperty>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1 });

                entity.ToTable("PropertySheet.pgcAssociatedProperty");

                entity.Property(e => e.AfterWeight)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AnalystName)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.AnalystNameId)
                    .HasColumnName("AnalystNameID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BeforeDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.BeforeWeight)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BioHazard)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BioHazardId)
                    .HasColumnName("BioHazardID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DanalystName)
                    .HasColumnName("DAnalystName")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DanalystNameId)
                    .HasColumnName("DAnalystNameID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.DateRangeComplete).HasColumnType("datetime");

                entity.Property(e => e.DateRangeStart).HasColumnType("datetime");

                entity.Property(e => e.DateReceived).HasColumnType("datetime");

                entity.Property(e => e.DdateCompleted)
                    .HasColumnName("DDateCompleted")
                    .HasColumnType("datetime");

                entity.Property(e => e.DdateRangeStart)
                    .HasColumnName("DDateRangeStart")
                    .HasColumnType("datetime");

                entity.Property(e => e.DdateReceived)
                    .HasColumnName("DDateReceived")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DnalabNo)
                    .HasColumnName("DNALabNo")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DrecoveredDateTime)
                    .HasColumnName("DRecoveredDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtechnicalReview)
                    .HasColumnName("DTechnicalReview")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DtechnicalReviewId)
                    .HasColumnName("DTechnicalReviewID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Fanalyst)
                    .HasColumnName("FAnalyst")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FanalystId)
                    .HasColumnName("FAnalystID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FdateComplete)
                    .HasColumnName("FDateComplete")
                    .HasColumnType("datetime");

                entity.Property(e => e.FdateReceived)
                    .HasColumnName("FDateReceived")
                    .HasColumnType("datetime");

                entity.Property(e => e.FdateStart)
                    .HasColumnName("FDateStart")
                    .HasColumnType("datetime");

                entity.Property(e => e.Feualtered)
                    .HasColumnName("FEUAltered")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeualteredId)
                    .HasColumnName("FEUAlteredID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeubarrelLength)
                    .HasColumnName("FEUBarrelLength")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.FeubarrelLength2)
                    .HasColumnName("FEUBarrelLength2")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.Feucaliber)
                    .HasColumnName("FEUCaliber")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeucaliberId)
                    .HasColumnName("FEUCaliberID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeufirearmMakeModel)
                    .HasColumnName("FEUFirearmMakeModel")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeufirearmMakeModelId)
                    .HasColumnName("FEUFirearmMakeModelID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeufirearmType)
                    .HasColumnName("FEUFirearmType")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeufirearmTypeId)
                    .HasColumnName("FEUFirearmTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeumeasReview)
                    .HasColumnName("FEUMeasReview")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeumeasReviewId)
                    .HasColumnName("FEUMeasReviewID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Feumrunit)
                    .HasColumnName("FEUMRUnit")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeumrunitId)
                    .HasColumnName("FEUMRUnitID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuoverallLength)
                    .HasColumnName("FEUOverallLength")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.Feuresult1)
                    .HasColumnName("FEUResult1")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Feuresult1Id)
                    .HasColumnName("FEUResult1ID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Feuresult2)
                    .HasColumnName("FEUResult2")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserNoRemarks)
                    .HasColumnName("FEUSerNoRemarks")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserNoRest)
                    .HasColumnName("FEUSerNoRest")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserNoRestId)
                    .HasColumnName("FEUSerNoRestID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserNoRev)
                    .HasColumnName("FEUSerNoRev")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserNoRevId)
                    .HasColumnName("FEUSerNoRevID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserNoRevUnit)
                    .HasColumnName("FEUSerNoRevUnit")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserNoRevUnitId)
                    .HasColumnName("FEUSerNoRevUnitID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserialNo)
                    .HasColumnName("FEUSerialNo")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserialNoRest)
                    .HasColumnName("FEUSerialNoRest")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuserialNoRestId)
                    .HasColumnName("FEUSerialNoRestID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Feuunit)
                    .HasColumnName("FEUUnit")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuunitId)
                    .HasColumnName("FEUUnitID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Feuwitness)
                    .HasColumnName("FEUWitness")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FeuwitnessId)
                    .HasColumnName("FEUWitnessID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmLabNo)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FrecoveredDateTime)
                    .HasColumnName("FRecoveredDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.Fsuspects)
                    .HasColumnName("FSuspects")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FtechnicalReview)
                    .HasColumnName("FTechnicalReview")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FtechnicalReviewId)
                    .HasColumnName("FTechnicalReviewID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.HoldStatus)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.HoldStatusId)
                    .HasColumnName("HoldStatusID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LabNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.OtherCaseNo)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PgcpropertyCentralIndexId)
                    .HasColumnName("PGCPropertyCentralIndexID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcpropertyMasterId)
                    .HasColumnName("PGCPropertyMasterID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropTypeCodes)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropTypeCodesId)
                    .HasColumnName("PropTypeCodesID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyStatus)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyStatusId)
                    .HasColumnName("PropertyStatusID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTag)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.RecovOtherJurs)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RecovOtherJursId)
                    .HasColumnName("RecovOtherJursID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveredBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveredById)
                    .HasColumnName("RecoveredByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveredDateTime).HasColumnType("datetime");

                entity.Property(e => e.Suspects)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalReview)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TechnicalReviewId)
                    .HasColumnName("TechnicalReviewID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.PropertySheetPgcAssociatedProperty)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK_PropertySheet.pgcAssociatedProperty_PropertySheet");
            });

            modelBuilder.Entity<PropertySheetPgcAssociatedPropertyConclusion>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.pgcAssociatedProperty.Conclusion");

                entity.Property(e => e.Conclusion)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ConclusionId)
                    .HasColumnName("ConclusionID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.PropertySheetPgcAssociatedProperty)
                    .WithMany(p => p.PropertySheetPgcAssociatedPropertyConclusion)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.pgcAssociatedProperty.Conclusion_PropertySheet.pgcAssociatedProperty");
            });

            modelBuilder.Entity<PropertySheetPgcPropColor>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.pgcPropColor");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.PgcColorType)
                    .HasColumnName("pgcColorType")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcColorTypeId)
                    .HasColumnName("pgcColorTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropColor)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropColorId)
                    .HasColumnName("PropColorID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetTags)
                    .WithMany(p => p.PropertySheetPgcPropColor)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.pgcPropColor_PropertySheet.Tags");
            });

            modelBuilder.Entity<PropertySheetPgcPropertyTag>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.pgcPropertyTag");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.PgcPropertyDetailTag)
                    .HasColumnName("pgcPropertyDetailTag")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetPgcAssociatedProperty)
                    .WithMany(p => p.PropertySheetPgcPropertyTag)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.pgcPropertyTag_PropertySheet.pgcAssociatedProperty");
            });

            modelBuilder.Entity<PropertySheetPgcTransactions>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.pgcTransactions");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.PgcTransDateTime)
                    .HasColumnName("pgcTransDateTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.PgcTransactionType)
                    .HasColumnName("pgcTransactionType")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcTransactionTypeId)
                    .HasColumnName("pgcTransactionTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcTransferFromTo)
                    .HasColumnName("pgcTransferFromTo")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcTransferFromToId)
                    .HasColumnName("pgcTransferFromToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcTransferJustificaiton)
                    .HasColumnName("pgcTransferJustificaiton")
                    .HasMaxLength(365)
                    .IsUnicode(false);

                entity.Property(e => e.PgcTransferToFrom)
                    .HasColumnName("pgcTransferToFrom")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcTransferToFromId)
                    .HasColumnName("pgcTransferToFromID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetPgcAssociatedProperty)
                    .WithMany(p => p.PropertySheetPgcTransactions)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.pgcTransactions_PropertySheet.pgcAssociatedProperty");
            });

            modelBuilder.Entity<PropertySheetTags>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1 });

                entity.ToTable("PropertySheet.Tags");

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.AssignedToId)
                    .HasColumnName("AssignedToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BarrelLength)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleMake)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleMakeId)
                    .HasColumnName("BicycleMakeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleModel)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleModelId)
                    .HasColumnName("BicycleModelID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BicycleSpeed).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.BicycleWheelSize).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.Biohazard)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BiohazardId)
                    .HasColumnName("BiohazardID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BoatLength).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.BoatName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.BoatType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.BoatTypeId)
                    .HasColumnName("BoatTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CartridgesAtScene)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CartridgesInChamber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CartridgesInCylinder)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CartridgesInMagazine)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedById)
                    .HasColumnName("CheckedByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CisbadgeNumber)
                    .HasColumnName("CISBadgeNumber")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Cisofficer)
                    .HasColumnName("CISOfficer")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CisofficerId)
                    .HasColumnName("CISOfficerID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Cissupervisor)
                    .HasColumnName("CISSupervisor")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CissupervisorId)
                    .HasColumnName("CISSupervisorID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Cocked)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CockedId)
                    .HasColumnName("CockedID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ColorId)
                    .HasColumnName("ColorID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Condition)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyCoins)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyFifties).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.CurrencyFives).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.CurrencyHundreds).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.CurrencyOnes).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.CurrencyOther)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyTens).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.CurrencyTotal)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CurrencyTwenties).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.CurrentDisposition)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentDispositionId)
                    .HasColumnName("CurrentDispositionID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentLocation)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentLocationId)
                    .HasColumnName("CurrentLocationID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Denomination)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DenominationId)
                    .HasColumnName("DenominationID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DischargedCartridgesAtScene)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DischargedCartridgesInCylinder)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalMethod)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalMethodId)
                    .HasColumnName("DisposalMethodID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DomesticViolence)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DomesticViolenceId)
                    .HasColumnName("DomesticViolenceID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DropLocation)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DropLocationId)
                    .HasColumnName("DropLocationID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugFieldTestResults)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugFieldTestResultsId)
                    .HasColumnName("DrugFieldTestResultsID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugMeasure)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugMeasureId)
                    .HasColumnName("DrugMeasureID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugPkgdBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugPkgdById)
                    .HasColumnName("DrugPkgdByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugPkgdDateTime).HasColumnType("datetime");

                entity.Property(e => e.DrugQuantity)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DrugSealDateTime).HasColumnType("datetime");

                entity.Property(e => e.DrugSealedBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugSealedById)
                    .HasColumnName("DrugSealedByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugTypeId)
                    .HasColumnName("DrugTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugWitness)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DrugWitnessId)
                    .HasColumnName("DrugWitnessID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ExpectedReturnDate).HasColumnType("datetime");

                entity.Property(e => e.Explain)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.Finish)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmAction)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmActionId)
                    .HasColumnName("FirearmActionID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmBadgeNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmCaliber)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmCaliberId)
                    .HasColumnName("FirearmCaliberID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmCapacity)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmColor)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmColorId)
                    .HasColumnName("FirearmColorID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmMake)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmMakeModel)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmMakeModelId)
                    .HasColumnName("FirearmMakeModelID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmMarkings)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmModel)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmQueryBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmQueryById)
                    .HasColumnName("FirearmQueryByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmTypeId)
                    .HasColumnName("FirearmTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmsPriority)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.FirearmsPriorityId)
                    .HasColumnName("FirearmsPriorityID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Hin)
                    .HasColumnName("HIN")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HoldStatus)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.HoldStatusId)
                    .HasColumnName("HoldStatusID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.HullShape)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.HullShapeId)
                    .HasColumnName("HullShapeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Hyppropdetails)
                    .HasColumnName("hyppropdetails")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IbrtypeCode)
                    .HasColumnName("IBRTypeCode")
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.IdentifyingMarks)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Importer)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.JuvenileInvolved)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.JuvenileInvolvedId)
                    .HasColumnName("JuvenileInvolvedID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LabNumber)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.LabProcessingRequired)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LabProcessingRequiredId)
                    .HasColumnName("LabProcessingRequiredID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.License)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseCountry)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseCountryId)
                    .HasColumnName("LicenseCountryID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseExpDate).HasColumnType("datetime");

                entity.Property(e => e.LicenseState)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LicenseStateId)
                    .HasColumnName("LicenseStateID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Loaded)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.LoadedId)
                    .HasColumnName("LoadedID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Manufacturer)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Merged)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NciccheckedBy)
                    .HasColumnName("NCICCheckedBy")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.NciccheckedById)
                    .HasColumnName("NCICCheckedByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.NciccrimeCode)
                    .HasColumnName("NCICCrimeCode")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.NciccrimeCodeId)
                    .HasColumnName("NCICCrimeCodeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.NextReviewDate).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyMethod)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.NotifyMethodId)
                    .HasColumnName("NotifyMethodID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ObtainedById)
                    .HasColumnName("ObtainedByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ObtainedByIdid)
                    .HasColumnName("ObtainedByIDID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ObtainedDate).HasColumnType("datetime");

                entity.Property(e => e.ObtainedFrom)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OdometerReading).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.Offense)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OffenseId)
                    .HasColumnName("OffenseID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OrigSubmittingOfficer)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.OriginalSubmittingOfficer)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OrinotifiedBy)
                    .HasColumnName("ORINotifiedBy")
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.OtherAgencyIdentifier)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerAppliedNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerNotified)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerNotifiedBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerNotifiedById)
                    .HasColumnName("OwnerNotifiedByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerNotifiedId)
                    .HasColumnName("OwnerNotifiedID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.OwnerNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PgcAgencyEntered)
                    .HasColumnName("pgcAgencyEntered")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PgcCurrencyDimes)
                    .HasColumnName("pgcCurrencyDimes")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.PgcCurrencyDollarCoins)
                    .HasColumnName("pgcCurrencyDollarCoins")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.PgcCurrencyHalfDollars)
                    .HasColumnName("pgcCurrencyHalfDollars")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.PgcCurrencyNickels)
                    .HasColumnName("pgcCurrencyNickels")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.PgcCurrencyPennies)
                    .HasColumnName("pgcCurrencyPennies")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.PgcCurrencyQuarters)
                    .HasColumnName("pgcCurrencyQuarters")
                    .HasColumnType("decimal(17, 10)");

                entity.Property(e => e.PgcCurrencyWitness)
                    .HasColumnName("pgcCurrencyWitness")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcCurrencyWitnessId)
                    .HasColumnName("pgcCurrencyWitnessID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcDrugCaseType)
                    .HasColumnName("pgcDrugCaseType")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcDrugCaseTypeId)
                    .HasColumnName("pgcDrugCaseTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcLabProcessingType)
                    .HasColumnName("pgcLabProcessingType")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcLabProcessingTypeId)
                    .HasColumnName("pgcLabProcessingTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcNcicentry)
                    .HasColumnName("pgcNCICEntry")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PgcOrinotified)
                    .HasColumnName("pgcORINotified")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcOrinotifiedId)
                    .HasColumnName("pgcORINotifiedID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Pgcnciccheck)
                    .HasColumnName("PGCNCICCheck")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PgcnciccheckId)
                    .HasColumnName("PGCNCICCheckID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropDrugQuant).HasColumnType("decimal(17, 10)");

                entity.Property(e => e.PropStatus)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropStatusId)
                    .HasColumnName("PropStatusID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyCategory)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropertyTypeId)
                    .HasColumnName("PropertyTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Propulsion)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.PropulsionId)
                    .HasColumnName("PropulsionID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonforVariance)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonforVarianceId)
                    .HasColumnName("ReasonforVarianceID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptIssued)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiptIssuedId)
                    .HasColumnName("ReceiptIssuedID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveredforOtherJurisdiction)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RecoveredforOtherJurisdictionId)
                    .HasColumnName("RecoveredforOtherJurisdictionID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Rfidno)
                    .HasColumnName("RFIDNo")
                    .HasMaxLength(65)
                    .IsUnicode(false);

                entity.Property(e => e.Safety)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SafetyId)
                    .HasColumnName("SafetyID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ScheduledPurgeDate).HasColumnType("datetime");

                entity.Property(e => e.SecuritiesIssueDate).HasColumnType("datetime");

                entity.Property(e => e.SecuritiesIssuer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SecuritiesType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SecuritiesTypeId)
                    .HasColumnName("SecuritiesTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SeizedPendingForfeiture)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SeizedPendingForfeitureId)
                    .HasColumnName("SeizedPendingForfeitureID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.StatusOwnerPossessor)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.StatusOwnerPossessorId)
                    .HasColumnName("StatusOwnerPossessorID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Stolen)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.StolenId)
                    .HasColumnName("StolenID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TagNumber)
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.Property(e => e.TagsCaseNoRtf)
                    .HasColumnName("TagsCaseNoRTF")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TagsSheetNoRtf)
                    .HasColumnName("TagsSheetNoRTF")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TagsSummary)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Units)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UscoinTotal)
                    .HasColumnName("USCoinTotal")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UscurrencyTotal)
                    .HasColumnName("USCurrencyTotal")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleTypeId)
                    .HasColumnName("VehicleTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.VehicleYear)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Instance)
                    .WithMany(p => p.PropertySheetTags)
                    .HasForeignKey(d => d.InstanceId)
                    .HasConstraintName("FK_PropertySheet.Tags_PropertySheet");
            });

            modelBuilder.Entity<PropertySheetTagsChainOfCustody>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.Tags.ChainOfCustody");

                entity.Property(e => e.Authorizer)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorizerId)
                    .HasColumnName("AuthorizerID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedInFrom)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedInFromId)
                    .HasColumnName("CheckedInFromID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedInTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedInToId)
                    .HasColumnName("CheckedInToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedOutTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedOutToId)
                    .HasColumnName("CheckedOutToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Details)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MoveTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.MoveToId)
                    .HasColumnName("MoveToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedFrom)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedFromId)
                    .HasColumnName("ReceivedFromID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReleasedTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReleasedToId)
                    .HasColumnName("ReleasedToID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionDatetime).HasColumnType("datetime");

                entity.Property(e => e.TransactionServerDatetime).HasColumnType("datetime");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.TransactionTypeId)
                    .HasColumnName("TransactionTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.User)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetTags)
                    .WithMany(p => p.PropertySheetTagsChainOfCustody)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.Tags.ChainOfCustody_PropertySheet.Tags");
            });

            modelBuilder.Entity<PropertySheetTagsRelatedPerson>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.Tags.RelatedPerson");

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.InvolvedPeople)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.InvolvedPeopleId)
                    .HasColumnName("InvolvedPeopleID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RelationType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.RelationTypeId)
                    .HasColumnName("RelationTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.HasOne(d => d.PropertySheetTags)
                    .WithMany(p => p.PropertySheetTagsRelatedPerson)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.Tags.RelatedPerson_PropertySheet.Tags");
            });

            modelBuilder.Entity<PropertySheetTagsVehicleColors>(entity =>
            {
                entity.HasKey(e => new { e.InstanceId, e.SeqNo1, e.SeqNo2 });

                entity.ToTable("PropertySheet.Tags.VehicleColors");

                entity.Property(e => e.Color)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ColorId)
                    .HasColumnName("ColorID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ColorType)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ColorTypeId)
                    .HasColumnName("ColorTypeID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DateInserted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.HasOne(d => d.PropertySheetTags)
                    .WithMany(p => p.PropertySheetTagsVehicleColors)
                    .HasForeignKey(d => new { d.InstanceId, d.SeqNo1 })
                    .HasConstraintName("FK_PropertySheet.Tags.VehicleColors_PropertySheet.Tags");
            });

            modelBuilder.Entity<PropertyTransactionDetails>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("PropertyTransactionDetails");

                entity.Property(e => e.AuthorizedBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorizedById)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedInFrom)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedInFromId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedInToLocation)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedInToLocationId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedOutTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CheckedOutToId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedByID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomCommand)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalMethod)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.DisposalMethodId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ExecutedOn).HasColumnType("datetime");

                entity.Property(e => e.ExpectedReturnDate)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralStatus)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.GeneralStatusId)
                    .HasColumnName("GeneralStatusID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ItmNumber)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ItmStatus)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ItmStatusId)
                    .HasColumnName("ItmStatusID")
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Measure)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.MeasureId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.MoveToLocation)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.MoveToLocationId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonforVariance)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReasonforVarianceId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedFrom)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReceivedFromId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReleasedTo)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.ReleasedToId)
                    .HasMaxLength(512)
                    .IsUnicode(false);

                entity.Property(e => e.Tag)
                    .HasMaxLength(512)
                    .IsUnicode(false);
            });
        }
    }
}
