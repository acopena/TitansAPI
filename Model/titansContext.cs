using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TitansAPI.Model
{
    public partial class titansContext : DbContext
    {
        public titansContext()
        {
        }

        public titansContext(DbContextOptions<titansContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressType> AddressType { get; set; }
        public virtual DbSet<BAccountType> BAccountType { get; set; }
        public virtual DbSet<BAddressType> BAddressType { get; set; }
        public virtual DbSet<BAssociation> BAssociation { get; set; }
        public virtual DbSet<BAssociationAddress> BAssociationAddress { get; set; }
        public virtual DbSet<BAssociationBank> BAssociationBank { get; set; }
        public virtual DbSet<BAssociationContactInfo> BAssociationContactInfo { get; set; }
        public virtual DbSet<BAssociationProfile> BAssociationProfile { get; set; }
        public virtual DbSet<BCalendar> BCalendar { get; set; }
        public virtual DbSet<BCart> BCart { get; set; }
        public virtual DbSet<BCartStatus> BCartStatus { get; set; }
        public virtual DbSet<BCoa> BCoa { get; set; }
        public virtual DbSet<BCoachSchedule> BCoachSchedule { get; set; }
        public virtual DbSet<BContactType> BContactType { get; set; }
        public virtual DbSet<BContactUs> BContactUs { get; set; }
        public virtual DbSet<BContent> BContent { get; set; }
        public virtual DbSet<BContentApproved> BContentApproved { get; set; }
        public virtual DbSet<BContentDocuments> BContentDocuments { get; set; }
        public virtual DbSet<BContentType> BContentType { get; set; }
        public virtual DbSet<BDiscountFeeType> BDiscountFeeType { get; set; }
        public virtual DbSet<BDiscountFees> BDiscountFees { get; set; }
        public virtual DbSet<BDivision> BDivision { get; set; }
        public virtual DbSet<BEventAddress> BEventAddress { get; set; }
        public virtual DbSet<BEventDivision> BEventDivision { get; set; }
        public virtual DbSet<BEventTeamConfirmation> BEventTeamConfirmation { get; set; }
        public virtual DbSet<BEventTeams> BEventTeams { get; set; }
        public virtual DbSet<BEventType> BEventType { get; set; }
        public virtual DbSet<BEvents> BEvents { get; set; }
        public virtual DbSet<BFeeTrx> BFeeTrx { get; set; }
        public virtual DbSet<BFeeType> BFeeType { get; set; }
        public virtual DbSet<BFees> BFees { get; set; }
        public virtual DbSet<BGymInfo> BGymInfo { get; set; }
        public virtual DbSet<BImageGroup> BImageGroup { get; set; }
        public virtual DbSet<BJersey> BJersey { get; set; }
        public virtual DbSet<BLeagueSchedule> BLeagueSchedule { get; set; }
        public virtual DbSet<BMember> BMember { get; set; }
        public virtual DbSet<BMemberContactInfo> BMemberContactInfo { get; set; }
        public virtual DbSet<BMemberDiscount> BMemberDiscount { get; set; }
        public virtual DbSet<BMemberEmergencyContact> BMemberEmergencyContact { get; set; }
        public virtual DbSet<BMemberFees> BMemberFees { get; set; }
        public virtual DbSet<BMemberRegistration> BMemberRegistration { get; set; }
        public virtual DbSet<BMemberServiceFee> BMemberServiceFee { get; set; }
        public virtual DbSet<BMemberaddress> BMemberaddress { get; set; }
        public virtual DbSet<BOfficial> BOfficial { get; set; }
        public virtual DbSet<BOfficialStatus> BOfficialStatus { get; set; }
        public virtual DbSet<BOrfile> BOrfile { get; set; }
        public virtual DbSet<BOrtrx> BOrtrx { get; set; }
        public virtual DbSet<BPageContent> BPageContent { get; set; }
        public virtual DbSet<BPaymentStatus> BPaymentStatus { get; set; }
        public virtual DbSet<BPaymentType> BPaymentType { get; set; }
        public virtual DbSet<BPicture> BPicture { get; set; }
        public virtual DbSet<BPosition> BPosition { get; set; }
        public virtual DbSet<BPositionType> BPositionType { get; set; }
        public virtual DbSet<BReceipt> BReceipt { get; set; }
        public virtual DbSet<BRelationshipType> BRelationshipType { get; set; }
        public virtual DbSet<BSchedule> BSchedule { get; set; }
        public virtual DbSet<BScheduleType> BScheduleType { get; set; }
        public virtual DbSet<BSeason> BSeason { get; set; }
        public virtual DbSet<BSeasonSetting> BSeasonSetting { get; set; }
        public virtual DbSet<BServicesFee> BServicesFee { get; set; }
        public virtual DbSet<BServicesType> BServicesType { get; set; }
        public virtual DbSet<BSiteApprover> BSiteApprover { get; set; }
        public virtual DbSet<BSociaMedia> BSociaMedia { get; set; }
        public virtual DbSet<BSponsors> BSponsors { get; set; }
        public virtual DbSet<BStatus> BStatus { get; set; }
        public virtual DbSet<BTeam> BTeam { get; set; }
        public virtual DbSet<BTeamContact> BTeamContact { get; set; }
        public virtual DbSet<BTeamDiscussion> BTeamDiscussion { get; set; }
        public virtual DbSet<BTeamGame> BTeamGame { get; set; }
        public virtual DbSet<BTeamOfficial> BTeamOfficial { get; set; }
        public virtual DbSet<BTeamPlayers> BTeamPlayers { get; set; }
        public virtual DbSet<BTeamStat> BTeamStat { get; set; }
        public virtual DbSet<BTvMenu> BTvMenu { get; set; }
        public virtual DbSet<BUpload> BUpload { get; set; }
        public virtual DbSet<BUserType> BUserType { get; set; }
        public virtual DbSet<BUsers> BUsers { get; set; }
        public virtual DbSet<BWaiver> BWaiver { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // optionsBuilder.UseSqlServer("Server=PINOY\\PINOY;Initial Catalog=titans;Integrated Security=True");
                //var db = optionsBuilder. _configuration.GetValue<string>("Connectionstring:Local");

                //string cn = @"Data Source=tcp:sql2k1602.discountasp.net;Initial Catalog=SQL2016_921245_opena;User ID=SQL2016_921245_opena_user;Password=@co1367551;";
                //optionsBuilder.UseSqlServer(cn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<AddressType>(entity =>
            {
                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.AddressTypeDescFr)
                    .HasColumnName("AddressTypeDesc_Fr")
                    .HasMaxLength(50);

                entity.Property(e => e.AddressTypeNameEn)
                    .HasColumnName("AddressTypeName_En")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BAccountType>(entity =>
            {
                entity.HasKey(e => e.AccountTypeId);

                entity.ToTable("b_AccountType");

                entity.Property(e => e.AccountTypeId)
                    .HasColumnName("AccountTypeID")
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountTypeDesc).HasMaxLength(150);
            });

            modelBuilder.Entity<BAddressType>(entity =>
            {
                entity.HasKey(e => e.AddressTypeId)
                    .HasName("PK__b_Addres__8BF56CC103317E3D");

                entity.ToTable("b_AddressType");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.AddressTypeName).HasMaxLength(25);
            });

            modelBuilder.Entity<BAssociation>(entity =>
            {
                entity.HasKey(e => e.AssociationId)
                    .HasName("PK__b_Associ__B51A19CD07020F21");

                entity.ToTable("b_Association");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.AssociationLogo).HasColumnType("image");

                entity.Property(e => e.AssociationName).HasMaxLength(50);

                entity.Property(e => e.AssociationShortName).HasMaxLength(50);

                entity.Property(e => e.CreateUserId).HasColumnName("CreateUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.UpdateUserId).HasColumnName("UpdateUserID");
            });

            modelBuilder.Entity<BAssociationAddress>(entity =>
            {
                entity.HasKey(e => e.AssociationAddressId)
                    .HasName("PK__b_Associ__12D1023F0AD2A005");

                entity.ToTable("b_AssociationAddress");

                entity.Property(e => e.AssociationAddressId).HasColumnName("AssociationAddressID");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.AssociationCity).HasMaxLength(25);

                entity.Property(e => e.AssociationCountry).HasMaxLength(25);

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.AssociationPostalCode).HasMaxLength(10);

                entity.Property(e => e.AssociationProvince).HasMaxLength(5);

                entity.Property(e => e.AssociationStreetName).HasMaxLength(25);

                entity.Property(e => e.AssociationStreetNo).HasMaxLength(10);

                entity.Property(e => e.AssociationStreetType).HasMaxLength(25);

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.BAssociationAddress)
                    .HasForeignKey(d => d.AddressTypeId)
                    .HasConstraintName("FK_b_AssociationAddress_b_AddressType");

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BAssociationAddress)
                    .HasForeignKey(d => d.AssociationId)
                    .HasConstraintName("FK_b_AssociationAddress_b_Association");
            });

            modelBuilder.Entity<BAssociationBank>(entity =>
            {
                entity.HasKey(e => e.BankAccountId);

                entity.ToTable("b_AssociationBank");

                entity.Property(e => e.BankAccountId).HasColumnName("BankAccountID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.BankAccountName).HasMaxLength(50);

                entity.Property(e => e.BankAccountNo).HasMaxLength(25);

                entity.Property(e => e.BankContactEmail).HasMaxLength(50);

                entity.Property(e => e.BankContactPerson).HasMaxLength(50);

                entity.Property(e => e.BankContactPhone).HasMaxLength(20);

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BAssociationBank)
                    .HasForeignKey(d => d.AssociationId)
                    .HasConstraintName("FK_b_AssociationBank_b_Association1");
            });

            modelBuilder.Entity<BAssociationContactInfo>(entity =>
            {
                entity.HasKey(e => e.AssociationContactId)
                    .HasName("PK__b_Associ__5491A19B108B795B");

                entity.ToTable("b_AssociationContactInfo");

                entity.Property(e => e.AssociationContactId).HasColumnName("AssociationContactID");

                entity.Property(e => e.AssociationCellPhone).HasMaxLength(12);

                entity.Property(e => e.AssociationContactName).HasMaxLength(50);

                entity.Property(e => e.AssociationContactTypeId).HasColumnName("AssociationContactTypeID");

                entity.Property(e => e.AssociationEmail).HasMaxLength(50);

                entity.Property(e => e.AssociationFaxNo).HasMaxLength(12);

                entity.Property(e => e.AssociationHomePhone).HasMaxLength(12);

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.AssociationWorkPhone).HasMaxLength(12);

                entity.Property(e => e.AssociationWorkPhoneExt).HasMaxLength(6);

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BAssociationContactInfo)
                    .HasForeignKey(d => d.AssociationId)
                    .HasConstraintName("FK_b_AssociationContactInfo_b_Association");

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.BAssociationContactInfo)
                    .HasForeignKey(d => d.ContactTypeId)
                    .HasConstraintName("FK_b_AssociationContactInfo_b_ContactType");
            });

            modelBuilder.Entity<BAssociationProfile>(entity =>
            {
                entity.HasKey(e => e.AssociationId);

                entity.ToTable("b_AssociationProfile");

                entity.Property(e => e.AssociationId)
                    .HasColumnName("AssociationID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ContactInformation)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EmergencyContact)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.OtherInfomration)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UploadImage)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Association)
                    .WithOne(p => p.BAssociationProfile)
                    .HasForeignKey<BAssociationProfile>(d => d.AssociationId)
                    .HasConstraintName("FK_b_AssociationProfile_b_Association");
            });

            modelBuilder.Entity<BCalendar>(entity =>
            {
                entity.HasKey(e => e.CalendarId);

                entity.ToTable("b_Calendar");

                entity.Property(e => e.CalendarId).HasColumnName("CalendarID");

                entity.Property(e => e.DatePosted)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateTimeEnd).HasColumnType("datetime");

                entity.Property(e => e.DateTimeStart).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.PostedById).HasColumnName("PostedByID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");
            });

            modelBuilder.Entity<BCart>(entity =>
            {
                entity.HasKey(e => e.CartGuid);

                entity.ToTable("b_Cart");

                entity.Property(e => e.CartGuid).ValueGeneratedNever();

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.CartDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CartStatusId).HasColumnName("CartStatusID");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CartStatus)
                    .WithMany(p => p.BCart)
                    .HasForeignKey(d => d.CartStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Cart_b_CartStatus");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BCart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Cart_b_Users");
            });

            modelBuilder.Entity<BCartStatus>(entity =>
            {
                entity.HasKey(e => e.CartStatusId);

                entity.ToTable("b_CartStatus");

                entity.Property(e => e.CartStatusId).HasColumnName("CartStatusID");

                entity.Property(e => e.CartStatusName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<BCoa>(entity =>
            {
                entity.HasKey(e => e.AccountNo);

                entity.ToTable("b_COA");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(4)
                    .ValueGeneratedNever();

                entity.Property(e => e.AccountName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.AccountTypeId).HasColumnName("AccountTypeID");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.BCoa)
                    .HasForeignKey(d => d.AccountTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_COA_b_AccountType");
            });

            modelBuilder.Entity<BCoachSchedule>(entity =>
            {
                entity.HasKey(e => e.CoachScheduleId);

                entity.ToTable("b_CoachSchedule");

                entity.Property(e => e.CoachScheduleId).HasColumnName("CoachScheduleID");

                entity.Property(e => e.CoachScheduleAttend).HasColumnName("CoachSchedule_Attend");

                entity.Property(e => e.CoachScheduleAttended).HasColumnName("CoachSchedule_Attended");

                entity.Property(e => e.CoachScheduleDate)
                    .HasColumnName("CoachSchedule_Date")
                    .HasColumnType("date");

                entity.Property(e => e.CoachScheduleNotes)
                    .HasColumnName("CoachSchedule_Notes")
                    .HasColumnType("text");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BCoachSchedule)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_CoachSchedule_b_Users");
            });

            modelBuilder.Entity<BContactType>(entity =>
            {
                entity.HasKey(e => e.ContactTypeId)
                    .HasName("PK__b_Contac__17E1EE7232E0915F");

                entity.ToTable("b_ContactType");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.ContactGroupId).HasColumnName("ContactGroupID");

                entity.Property(e => e.ContactTypeDesc).HasMaxLength(50);
            });

            modelBuilder.Entity<BContactUs>(entity =>
            {
                entity.ToTable("b_ContactUs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateFrom).HasColumnType("datetime");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.ResponseDate).HasColumnType("datetime");

                entity.Property(e => e.Subject).HasColumnName("subject");
            });

            modelBuilder.Entity<BContent>(entity =>
            {
                entity.HasKey(e => e.ContentId);

                entity.ToTable("b_Content");

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.ContentDetails).HasColumnType("text");

                entity.Property(e => e.ContentTitle).HasMaxLength(250);

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.PageContentId).HasColumnName("PageContentID");

                entity.Property(e => e.PublishedEndDate).HasColumnType("date");

                entity.Property(e => e.PublishedStartDate).HasColumnType("date");

                entity.Property(e => e.SortKey).HasDefaultValueSql("((0))");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.ContentType)
                    .WithMany(p => p.BContent)
                    .HasForeignKey(d => d.ContentTypeId)
                    .HasConstraintName("FK_b_Content_b_ContentType");

                entity.HasOne(d => d.PageContent)
                    .WithMany(p => p.BContent)
                    .HasForeignKey(d => d.PageContentId)
                    .HasConstraintName("FK_b_Content_b_PageContent");
            });

            modelBuilder.Entity<BContentApproved>(entity =>
            {
                entity.HasKey(e => e.SiteContentApprovedId);

                entity.ToTable("b_ContentApproved");

                entity.Property(e => e.SiteContentApprovedId).HasColumnName("SiteContentApprovedID");

                entity.Property(e => e.AppprovedId).HasColumnName("AppprovedID");

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.DateApproved).HasColumnType("date");

                entity.HasOne(d => d.Appproved)
                    .WithMany(p => p.BContentApproved)
                    .HasForeignKey(d => d.AppprovedId)
                    .HasConstraintName("FK_b_ContentApproved_b_SiteApprover");

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.BContentApproved)
                    .HasForeignKey(d => d.ContentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_ContentApproved_b_Content");
            });

            modelBuilder.Entity<BContentDocuments>(entity =>
            {
                entity.HasKey(e => e.DocumentId);

                entity.ToTable("b_ContentDocuments");

                entity.Property(e => e.DocumentId).HasColumnName("DocumentID");

                entity.Property(e => e.ContentId).HasColumnName("ContentID");

                entity.Property(e => e.DateUploaded).HasColumnType("date");

                entity.Property(e => e.DocumentFileName).HasMaxLength(500);

                entity.Property(e => e.DocumentNotes).HasColumnType("text");

                entity.Property(e => e.DocumentTitle).HasMaxLength(500);

                entity.Property(e => e.DocumentType).HasMaxLength(500);

                entity.HasOne(d => d.Content)
                    .WithMany(p => p.BContentDocuments)
                    .HasForeignKey(d => d.ContentId)
                    .HasConstraintName("FK_b_ContentDocuments_b_Content");
            });

            modelBuilder.Entity<BContentType>(entity =>
            {
                entity.HasKey(e => e.ContentTypeId);

                entity.ToTable("b_ContentType");

                entity.Property(e => e.ContentTypeId).HasColumnName("ContentTypeID");

                entity.Property(e => e.ContentTypeName).HasMaxLength(150);
            });

            modelBuilder.Entity<BDiscountFeeType>(entity =>
            {
                entity.HasKey(e => e.DiscountFeeTypeId);

                entity.ToTable("b_DiscountFeeType");

                entity.Property(e => e.DiscountFeeTypeId).HasColumnName("DiscountFeeTypeID");

                entity.Property(e => e.DiscountFeeTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<BDiscountFees>(entity =>
            {
                entity.HasKey(e => e.DiscountFeeId);

                entity.ToTable("b_DiscountFees");

                entity.Property(e => e.DiscountFeeId).HasColumnName("DiscountFeeID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.DiscountFeeAmount).HasColumnType("money");

                entity.Property(e => e.DiscountFeeName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.DiscountFeeTypeId).HasColumnName("DiscountFeeTypeID");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BDiscountFees)
                    .HasForeignKey(d => d.AssociationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_DiscountFees_b_Association");

                entity.HasOne(d => d.DiscountFeeType)
                    .WithMany(p => p.BDiscountFees)
                    .HasForeignKey(d => d.DiscountFeeTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_DiscountFees_b_DiscountFeeType");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.BDiscountFees)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_DiscountFees_b_Season");
            });

            modelBuilder.Entity<BDivision>(entity =>
            {
                entity.HasKey(e => e.DivisionId)
                    .HasName("PK__b_Divisi__20EFC688440B1D61");

                entity.ToTable("b_Division");

                entity.Property(e => e.DivisionId).HasColumnName("DivisionID");

                entity.Property(e => e.AccountNo).HasMaxLength(4);

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.CreatedUserId).HasColumnName("CreatedUserID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.DivisionName).HasMaxLength(100);

                entity.Property(e => e.DivisionTypeId).HasColumnName("DivisionTypeID");

                entity.Property(e => e.GenderId)
                    .HasColumnName("GenderID")
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.MaximumAge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinimumAge).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<BEventAddress>(entity =>
            {
                entity.HasKey(e => e.EventAddressId);

                entity.ToTable("b_EventAddress");

                entity.Property(e => e.EventAddressId).HasColumnName("EventAddressID");

                entity.Property(e => e.EventCity).HasMaxLength(50);

                entity.Property(e => e.EventPostalCode).HasMaxLength(10);

                entity.Property(e => e.EventProvince).HasMaxLength(15);

                entity.Property(e => e.EventStreetNo).HasMaxLength(10);

                entity.Property(e => e.EventStreetType).HasMaxLength(25);

                entity.HasOne(d => d.EventNoNavigation)
                    .WithMany(p => p.BEventAddress)
                    .HasForeignKey(d => d.EventNo)
                    .HasConstraintName("FK_b_EventAddress_b_Events");
            });

            modelBuilder.Entity<BEventDivision>(entity =>
            {
                entity.HasKey(e => e.EventDivisionId);

                entity.ToTable("b_EventDivision");

                entity.Property(e => e.EventDivisionId).HasColumnName("EventDivisionID");

                entity.Property(e => e.DivisionId).HasColumnName("DivisionID");

                entity.HasOne(d => d.EventNoNavigation)
                    .WithMany(p => p.BEventDivision)
                    .HasForeignKey(d => d.EventNo)
                    .HasConstraintName("FK_b_EventDivision_b_Events");
            });

            modelBuilder.Entity<BEventTeamConfirmation>(entity =>
            {
                entity.HasKey(e => e.EventTeamConfirmationId);

                entity.ToTable("b_EventTeamConfirmation");

                entity.Property(e => e.EventTeamConfirmationId).HasColumnName("EventTeamConfirmationID");

                entity.Property(e => e.EventTeamConfirmationDate)
                    .HasColumnName("EventTeamConfirmation_Date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EventsTeamId).HasColumnName("Events_TeamID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.EventsTeam)
                    .WithMany(p => p.BEventTeamConfirmation)
                    .HasForeignKey(d => d.EventsTeamId)
                    .HasConstraintName("FK_b_EventTeamConfirmation_b_Event_Teams");
            });

            modelBuilder.Entity<BEventTeams>(entity =>
            {
                entity.HasKey(e => e.EventsTeamId);

                entity.ToTable("b_Event_Teams");

                entity.Property(e => e.EventsTeamId).HasColumnName("Events_TeamID");

                entity.Property(e => e.DateJoin).HasColumnType("date");

                entity.Property(e => e.PostedById).HasColumnName("PostedByID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.EventNoNavigation)
                    .WithMany(p => p.BEventTeams)
                    .HasForeignKey(d => d.EventNo)
                    .HasConstraintName("FK_b_Event_Teams_b_Events");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BEventTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Event_Teams_b_Team");
            });

            modelBuilder.Entity<BEventType>(entity =>
            {
                entity.HasKey(e => e.EventTypeId);

                entity.ToTable("b_EventType");

                entity.Property(e => e.EventTypeId).HasColumnName("EventTypeID");

                entity.Property(e => e.EventTypeName).HasMaxLength(50);
            });

            modelBuilder.Entity<BEvents>(entity =>
            {
                entity.HasKey(e => e.EventNo);

                entity.ToTable("b_Events");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.EventConfirmationLastDate).HasColumnType("datetime");

                entity.Property(e => e.EventContactEmail).HasMaxLength(50);

                entity.Property(e => e.EventContactName).HasMaxLength(50);

                entity.Property(e => e.EventContactNo).HasMaxLength(25);

                entity.Property(e => e.EventCost).HasColumnType("money");

                entity.Property(e => e.EventDescription).IsRequired();

                entity.Property(e => e.EventEndDate).HasColumnType("date");

                entity.Property(e => e.EventEndTime).HasMaxLength(10);

                entity.Property(e => e.EventHost).HasMaxLength(150);

                entity.Property(e => e.EventPosition).HasMaxLength(50);

                entity.Property(e => e.EventStartDate).HasColumnType("date");

                entity.Property(e => e.EventStartTime).HasMaxLength(10);

                entity.Property(e => e.PostEventMemo).HasColumnType("text");

                entity.Property(e => e.PostedById).HasColumnName("PostedByID");

                entity.Property(e => e.PreEventMemo).HasColumnType("text");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BEvents)
                    .HasForeignKey(d => d.AssociationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Events_b_Association");

                entity.HasOne(d => d.EventTypeNavigation)
                    .WithMany(p => p.BEvents)
                    .HasForeignKey(d => d.EventType)
                    .HasConstraintName("FK_b_Events_b_EventType");
            });

            modelBuilder.Entity<BFeeTrx>(entity =>
            {
                entity.HasKey(e => e.FeeTrxId);

                entity.ToTable("b_FeeTrx");

                entity.Property(e => e.FeeTrxId).HasColumnName("FeeTrxID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.FeeAmount).HasColumnType("money");

                entity.Property(e => e.FeeId).HasColumnName("FeeID");

                entity.Property(e => e.Gst).HasColumnName("GST");

                entity.Property(e => e.Hst).HasColumnName("HST");

                entity.Property(e => e.Pst).HasColumnName("PST");

                entity.Property(e => e.Qst).HasColumnName("QST");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BFeeTrx)
                    .HasForeignKey(d => d.AssociationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_FeeTrx_b_Association");

                entity.HasOne(d => d.Fee)
                    .WithMany(p => p.BFeeTrx)
                    .HasForeignKey(d => d.FeeId)
                    .HasConstraintName("FK_b_FeeTrx_b_Fees");
            });

            modelBuilder.Entity<BFeeType>(entity =>
            {
                entity.HasKey(e => e.FeeTypeId);

                entity.ToTable("b_FeeType");

                entity.Property(e => e.FeeTypeId).HasColumnName("FeeTypeID");

                entity.Property(e => e.FeeTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BFees>(entity =>
            {
                entity.HasKey(e => e.FeeId);

                entity.ToTable("b_Fees");

                entity.Property(e => e.FeeId).HasColumnName("FeeID");

                entity.Property(e => e.FeeName).HasMaxLength(150);

                entity.Property(e => e.FeeTypeId).HasColumnName("FeeTypeID");

                entity.HasOne(d => d.FeeType)
                    .WithMany(p => p.BFees)
                    .HasForeignKey(d => d.FeeTypeId)
                    .HasConstraintName("FK_b_Fees_b_FeeType");
            });

            modelBuilder.Entity<BGymInfo>(entity =>
            {
                entity.HasKey(e => e.GymId);

                entity.ToTable("b_GymInfo");

                entity.Property(e => e.GymId).HasColumnName("GymID");

                entity.Property(e => e.GymAddress).IsRequired();

                entity.Property(e => e.GymLangtitude).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.GymLatitude).HasColumnType("decimal(18, 5)");

                entity.Property(e => e.GymName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.GymNotes)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            });

            modelBuilder.Entity<BImageGroup>(entity =>
            {
                entity.HasKey(e => e.ImageGroupId);

                entity.ToTable("b_ImageGroup");

                entity.Property(e => e.ImageGroupId).HasColumnName("ImageGroupId");

                entity.Property(e => e.ImageGroupName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<BJersey>(entity =>
            {
                entity.HasKey(e => e.JerseyId);

                entity.ToTable("b_Jersey");

                entity.Property(e => e.JerseyId).HasColumnName("JerseyID");

                entity.Property(e => e.JerseyFee).HasColumnType("money");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            });

            modelBuilder.Entity<BLeagueSchedule>(entity =>
            {
                entity.HasKey(e => e.LeagueScheduleId)
                    .HasName("PK_b_LeagueSchedule");

                entity.ToTable("b_leagueSchedule");

                entity.Property(e => e.LeagueScheduleId).HasColumnName("leagueScheduleID");

                entity.Property(e => e.LeagueDate).HasColumnType("date");

                entity.Property(e => e.LeagueScore)
                    .HasColumnName("leagueScore")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeagueScoreVs)
                    .HasColumnName("leagueScoreVS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LeagueStatus).HasColumnName("leagueStatus");

                entity.Property(e => e.LeagueVenue)
                    .HasColumnName("leagueVenue")
                    .HasMaxLength(250);

                entity.Property(e => e.LeagueVs)
                    .HasColumnName("leagueVS")
                    .HasMaxLength(150);

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.TimeEnd).HasMaxLength(12);

                entity.Property(e => e.TimeStart).HasMaxLength(12);

                entity.HasOne(d => d.EventNoNavigation)
                    .WithMany(p => p.BLeagueSchedule)
                    .HasForeignKey(d => d.EventNo)
                    .HasConstraintName("FK_b_leagueSchedule_b_Events");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BLeagueSchedule)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_b_leagueSchedule_b_Team");
            });

            modelBuilder.Entity<BMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__b_Member__0CF04B385EBF139D");

                entity.ToTable("b_Member");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.JerseyNo)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Language).HasMaxLength(10);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.MemberHealthCardNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MemberNotes).HasColumnType("text");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BMember)
                    .HasForeignKey(d => d.AssociationId)
                    .HasConstraintName("FK_b_Member_b_Association");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.BMember)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_b_Member_b_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BMember)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_b_Member_b_Users");
            });

            modelBuilder.Entity<BMemberContactInfo>(entity =>
            {
                entity.HasKey(e => e.MemberContactId)
                    .HasName("PK__b_Member__6882F48866603565");

                entity.ToTable("b_MemberContactInfo");

                entity.Property(e => e.MemberContactId).HasColumnName("MemberContactID");

                entity.Property(e => e.ContactTypeId).HasColumnName("ContactTypeID");

                entity.Property(e => e.MemberCellPhone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemberContactName).HasMaxLength(50);

                entity.Property(e => e.MemberEmail).HasMaxLength(50);

                entity.Property(e => e.MemberHomePhone)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.MemberWorkPhone).HasMaxLength(25);

                entity.HasOne(d => d.ContactType)
                    .WithMany(p => p.BMemberContactInfo)
                    .HasForeignKey(d => d.ContactTypeId)
                    .HasConstraintName("FK_b_MemberContactInfo_b_ContactType");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BMemberContactInfo)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_b_MemberContactInfo_b_Member");
            });

            modelBuilder.Entity<BMemberDiscount>(entity =>
            {
                entity.HasKey(e => e.MemberDiscountId);

                entity.ToTable("b_MemberDiscount");

                entity.Property(e => e.MemberDiscountId).HasColumnName("MemberDiscountID");

                entity.Property(e => e.DiscountFeeAmount).HasColumnType("money");

                entity.Property(e => e.DiscountFeeDate).HasColumnType("date");

                entity.Property(e => e.DiscountFeeId).HasColumnName("DiscountFeeID");

                entity.Property(e => e.DiscountFeeTypeId).HasColumnName("DiscountFeeTypeID");

                entity.Property(e => e.MemberRegId).HasColumnName("MemberRegID");

                entity.HasOne(d => d.CartGu)
                    .WithMany(p => p.BMemberDiscount)
                    .HasForeignKey(d => d.CartGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberDiscount_b_Cart");

                entity.HasOne(d => d.DiscountFee)
                    .WithMany(p => p.BMemberDiscount)
                    .HasForeignKey(d => d.DiscountFeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberDiscount_b_DiscountFees");

                entity.HasOne(d => d.MemberReg)
                    .WithMany(p => p.BMemberDiscount)
                    .HasForeignKey(d => d.MemberRegId)
                    .HasConstraintName("FK_b_MemberDiscount_b_MemberRegistration");
            });

            modelBuilder.Entity<BMemberEmergencyContact>(entity =>
            {
                entity.HasKey(e => e.EmergencyContactId);

                entity.ToTable("b_MemberEmergencyContact");

                entity.Property(e => e.EmergencyContactId).HasColumnName("EmergencyContactID");

                entity.Property(e => e.EmergencyContactName).HasMaxLength(50);

                entity.Property(e => e.EmergencyContactNo).HasMaxLength(50);

                entity.Property(e => e.EmergencyRelationShip).HasMaxLength(50);

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BMemberEmergencyContact)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_b_MemberEmergencyContact_b_Member");
            });

            modelBuilder.Entity<BMemberFees>(entity =>
            {
                entity.HasKey(e => e.MemberFeeId);

                entity.ToTable("b_MemberFees");

                entity.Property(e => e.MemberFeeId).HasColumnName("MemberFeeID");

                entity.Property(e => e.FeeAmount).HasColumnType("money");

                entity.Property(e => e.FeeTrxId).HasColumnName("FeeTrxID");

                entity.Property(e => e.Gst).HasColumnName("GST");

                entity.Property(e => e.Hst).HasColumnName("HST");

                entity.Property(e => e.MemberRegId).HasColumnName("MemberRegID");

                entity.Property(e => e.Pst).HasColumnName("PST");

                entity.Property(e => e.Qst).HasColumnName("QST");

                entity.Property(e => e.TotalFee).HasColumnType("money");

                entity.HasOne(d => d.CartGu)
                    .WithMany(p => p.BMemberFees)
                    .HasForeignKey(d => d.CartGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberFees_b_Cart");

                entity.HasOne(d => d.FeeTrx)
                    .WithMany(p => p.BMemberFees)
                    .HasForeignKey(d => d.FeeTrxId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberFees_b_FeeTrx");

                entity.HasOne(d => d.MemberReg)
                    .WithMany(p => p.BMemberFees)
                    .HasForeignKey(d => d.MemberRegId)
                    .HasConstraintName("FK_b_MemberFees_b_MemberRegistration");
            });

            modelBuilder.Entity<BMemberRegistration>(entity =>
            {
                entity.HasKey(e => e.MemberRegId);

                entity.ToTable("b_MemberRegistration");

                entity.Property(e => e.MemberRegId).HasColumnName("MemberRegID");

                entity.Property(e => e.DateReg).HasColumnType("date");

                entity.Property(e => e.DivisionId).HasColumnName("DivisionID");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.WaiverIagree).HasColumnName("WaiverIAgree");

                entity.Property(e => e.WaiverId).HasColumnName("WaiverID");

                entity.HasOne(d => d.CartGu)
                    .WithMany(p => p.BMemberRegistration)
                    .HasForeignKey(d => d.CartGuid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_b_MemberRegistration_b_Cart");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.BMemberRegistration)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK_b_MemberRegistration_b_Division");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BMemberRegistration)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_b_MemberRegistration_b_Member");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.BMemberRegistration)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberRegistration_b_Season");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BMemberRegistration)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberRegistration_b_Users");

                entity.HasOne(d => d.Waiver)
                    .WithMany(p => p.BMemberRegistration)
                    .HasForeignKey(d => d.WaiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberRegistration_b_Waiver");
            });

            modelBuilder.Entity<BMemberServiceFee>(entity =>
            {
                entity.HasKey(e => e.MemberServiceFeeId);

                entity.ToTable("b_MemberServiceFee");

                entity.Property(e => e.MemberServiceFeeId).HasColumnName("MemberServiceFeeID");

                entity.Property(e => e.Amount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MemberRegId).HasColumnName("MemberRegID");

                entity.Property(e => e.ServicesFeeId).HasColumnName("ServicesFeeID");

                entity.Property(e => e.TrxDate).HasColumnType("date");

                entity.HasOne(d => d.CartGu)
                    .WithMany(p => p.BMemberServiceFee)
                    .HasForeignKey(d => d.CartGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberServiceFee_b_Cart");

                entity.HasOne(d => d.MemberReg)
                    .WithMany(p => p.BMemberServiceFee)
                    .HasForeignKey(d => d.MemberRegId)
                    .HasConstraintName("FK_b_MemberServiceFee_b_MemberRegistration");

                entity.HasOne(d => d.ServicesFee)
                    .WithMany(p => p.BMemberServiceFee)
                    .HasForeignKey(d => d.ServicesFeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_MemberServiceFee_b_ServicesFee");
            });

            modelBuilder.Entity<BMemberaddress>(entity =>
            {
                entity.HasKey(e => e.MemberAddressId)
                    .HasName("PK__b_Member__AD5BA651628FA481");

                entity.ToTable("b_Memberaddress");

                entity.Property(e => e.MemberAddressId).HasColumnName("MemberAddressID");

                entity.Property(e => e.AddressTypeId).HasColumnName("AddressTypeID");

                entity.Property(e => e.MemberCity).HasMaxLength(25);

                entity.Property(e => e.MemberCountry).HasMaxLength(25);

                entity.Property(e => e.MemberCreateUserId).HasColumnName("MemberCreateUserID");

                entity.Property(e => e.MemberDateCreated).HasColumnType("datetime");

                entity.Property(e => e.MemberDateUpdated).HasColumnType("datetime");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.MemberPostalCode).HasMaxLength(10);

                entity.Property(e => e.MemberProvince).HasMaxLength(5);

                entity.Property(e => e.MemberStreetName).HasMaxLength(25);

                entity.Property(e => e.MemberStreetNo).HasMaxLength(10);

                entity.Property(e => e.MemberStreetType).HasMaxLength(25);

                entity.Property(e => e.MemberUpdateUserId).HasColumnName("MemberUpdateUserID");

                entity.HasOne(d => d.AddressType)
                    .WithMany(p => p.BMemberaddress)
                    .HasForeignKey(d => d.AddressTypeId)
                    .HasConstraintName("FK_b_Memberaddress_b_AddressType");
            });

            modelBuilder.Entity<BOfficial>(entity =>
            {
                entity.HasKey(e => e.OfficialId);

                entity.ToTable("b_Official");

                entity.Property(e => e.OfficialId).HasColumnName("OfficialID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.CellPhone).HasMaxLength(15);

                entity.Property(e => e.EmailAddress).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Notes).HasColumnType("text");

                entity.Property(e => e.OfficialDateOfBirth).HasColumnType("date");

                entity.Property(e => e.OfficialFirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OfficialLastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.OfficialStatusId).HasColumnName("OfficialStatusID");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.TelNo).HasMaxLength(15);

                entity.HasOne(d => d.OfficialStatus)
                    .WithMany(p => p.BOfficial)
                    .HasForeignKey(d => d.OfficialStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Official_b_OfficialStatus");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.BOfficial)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Official_b_Position");
            });

            modelBuilder.Entity<BOfficialStatus>(entity =>
            {
                entity.HasKey(e => e.OfficialStatusId);

                entity.ToTable("b_OfficialStatus");

                entity.Property(e => e.OfficialStatusId).HasColumnName("OfficialStatusID");

                entity.Property(e => e.OfficialStatusName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BOrfile>(entity =>
            {
                entity.HasKey(e => e.Orno);

                entity.ToTable("b_ORFile");

                entity.Property(e => e.Orno)
                    .HasColumnName("ORNo")
                    .HasMaxLength(6)
                    .ValueGeneratedNever();

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.DatePosted).HasColumnType("date");

                entity.Property(e => e.Oramount)
                    .HasColumnName("ORAmount")
                    .HasColumnType("money");

                entity.Property(e => e.OrapplicationId).HasColumnName("ORApplicationID");

                entity.Property(e => e.Ordate)
                    .HasColumnName("ORDate")
                    .HasColumnType("date");

                entity.Property(e => e.PayeeName).HasMaxLength(150);

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.PostedById).HasColumnName("PostedByID");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            });

            modelBuilder.Entity<BOrtrx>(entity =>
            {
                entity.HasKey(e => e.OrtrxId);

                entity.ToTable("b_ORTrx");

                entity.Property(e => e.OrtrxId).HasColumnName("ORTrxID");

                entity.Property(e => e.FeeAmount)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.MemberRegId).HasColumnName("MemberRegID");

                entity.Property(e => e.Orno)
                    .IsRequired()
                    .HasColumnName("ORNo")
                    .HasMaxLength(6);

                entity.HasOne(d => d.MemberReg)
                    .WithMany(p => p.BOrtrx)
                    .HasForeignKey(d => d.MemberRegId)
                    .HasConstraintName("FK_b_ORTrx_b_MemberRegistration");

                entity.HasOne(d => d.OrnoNavigation)
                    .WithMany(p => p.BOrtrx)
                    .HasForeignKey(d => d.Orno)
                    .HasConstraintName("FK_b_ORTrx_b_ORFile");
            });

            modelBuilder.Entity<BPageContent>(entity =>
            {
                entity.HasKey(e => e.PageContentId);

                entity.ToTable("b_PageContent");

                entity.Property(e => e.PageContentId).HasColumnName("PageContentID");

                entity.Property(e => e.PageContentTitle)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<BPaymentStatus>(entity =>
            {
                entity.HasKey(e => e.PaymentStatusId);

                entity.ToTable("b_PaymentStatus");

                entity.Property(e => e.PaymentStatusId).HasColumnName("PaymentStatusID");

                entity.Property(e => e.PaymentStatusName)
                    .IsRequired()
                    .HasMaxLength(25);
            });

            modelBuilder.Entity<BPaymentType>(entity =>
            {
                entity.HasKey(e => e.PaymentTypeId);

                entity.ToTable("b_PaymentType");

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.PaymentTypeName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<BPicture>(entity =>
            {
                entity.HasKey(e => e.PictureId);

                entity.ToTable("b_Picture");

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.DateUploaded).HasColumnType("date");

                entity.Property(e => e.DocumentPhoto).HasColumnType("image");

                entity.Property(e => e.DocumentUploadedDate).HasColumnType("date");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.Photo).HasColumnType("image");
            });

            modelBuilder.Entity<BPosition>(entity =>
            {
                entity.HasKey(e => e.PositionId);

                entity.ToTable("b_Position");

                entity.Property(e => e.PositionId).HasColumnName("PositionID");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PositionTypeId).HasColumnName("PositionTypeID");

                entity.HasOne(d => d.PositionType)
                    .WithMany(p => p.BPosition)
                    .HasForeignKey(d => d.PositionTypeId)
                    .HasConstraintName("FK_b_Position_b_PositionType");
            });

            modelBuilder.Entity<BPositionType>(entity =>
            {
                entity.HasKey(e => e.PositionTypeId);

                entity.ToTable("b_PositionType");

                entity.Property(e => e.PositionTypeId).HasColumnName("PositionTypeID");

                entity.Property(e => e.PositionTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BReceipt>(entity =>
            {
                entity.HasKey(e => e.ReceiptNo);

                entity.ToTable("b_Receipt");

                entity.Property(e => e.Oramount)
                    .HasColumnName("ORAmount")
                    .HasColumnType("money");

                entity.Property(e => e.Ordate)
                    .HasColumnName("ORDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Orno)
                    .HasColumnName("ORNo")
                    .HasMaxLength(8);

                entity.Property(e => e.Ornotes)
                    .HasColumnName("ORNotes")
                    .HasMaxLength(250);

                entity.Property(e => e.PaymentTypeId).HasColumnName("PaymentTypeID");

                entity.Property(e => e.PostedById).HasColumnName("PostedByID");

                entity.Property(e => e.PostedDate)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReceiptAmount).HasColumnType("money");

                entity.Property(e => e.ReceiptDate).HasColumnType("smalldatetime");

                entity.Property(e => e.ReferenceNo).HasMaxLength(25);

                entity.HasOne(d => d.CartGu)
                    .WithMany(p => p.BReceipt)
                    .HasForeignKey(d => d.CartGuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Receipt_b_Cart");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.BReceipt)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Receipt_b_PaymentType");
            });

            modelBuilder.Entity<BRelationshipType>(entity =>
            {
                entity.HasKey(e => e.RelationshipId);

                entity.ToTable("b_RelationshipType");

                entity.Property(e => e.RelationshipId).HasColumnName("RelationshipID");

                entity.Property(e => e.RelationshipName).HasMaxLength(50);
            });

            modelBuilder.Entity<BSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId);

                entity.ToTable("b_Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("ScheduleID");

                entity.Property(e => e.ScheduleDate).HasColumnType("date");

                entity.Property(e => e.ScheduleEndTime).HasMaxLength(10);

                entity.Property(e => e.ScheduleStartTime).HasMaxLength(10);

                entity.Property(e => e.ScheduleTypeId).HasColumnName("ScheduleTypeID");
            });

            modelBuilder.Entity<BScheduleType>(entity =>
            {
                entity.HasKey(e => e.ScheduleTypeId);

                entity.ToTable("b_ScheduleType");

                entity.Property(e => e.ScheduleTypeId).HasColumnName("ScheduleTypeID");

                entity.Property(e => e.ScheduleTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BSeason>(entity =>
            {
                entity.HasKey(e => e.SeasonId)
                    .HasName("PK__b_Season__C1814E180E6E26BF");

                entity.ToTable("b_Season");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<BSeasonSetting>(entity =>
            {
                entity.HasKey(e => e.SeasonSettingId);

                entity.ToTable("b_SeasonSetting");

                entity.Property(e => e.SeasonSettingId).HasColumnName("SeasonSettingID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.DivisionCutOfDate).HasColumnType("date");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");
            });

            modelBuilder.Entity<BServicesFee>(entity =>
            {
                entity.HasKey(e => e.ServicesFeeId);

                entity.ToTable("b_ServicesFee");

                entity.Property(e => e.ServicesFeeId).HasColumnName("ServicesFeeID");

                entity.Property(e => e.AccountNo)
                    .IsRequired()
                    .HasMaxLength(4);

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.DivisionId).HasColumnName("DivisionID");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.Property(e => e.ServicesTypeId).HasColumnName("ServicesTypeID");

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.BServicesFee)
                    .HasForeignKey(d => d.AccountNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_ServicesFee_b_COA");

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.BServicesFee)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK_b_ServicesFee_b_Division");

                entity.HasOne(d => d.ServicesType)
                    .WithMany(p => p.BServicesFee)
                    .HasForeignKey(d => d.ServicesTypeId)
                    .HasConstraintName("FK_b_ServicesFee_b_ServicesType");
            });

            modelBuilder.Entity<BServicesType>(entity =>
            {
                entity.HasKey(e => e.ServicesTypeId);

                entity.ToTable("b_ServicesType");

                entity.Property(e => e.ServicesTypeId).HasColumnName("ServicesTypeID");

                entity.Property(e => e.ServicesTypeDesc).HasMaxLength(150);
            });

            modelBuilder.Entity<BSiteApprover>(entity =>
            {
                entity.HasKey(e => e.ApprovedId);

                entity.ToTable("b_SiteApprover");

                entity.Property(e => e.ApprovedId).HasColumnName("ApprovedID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.EmailAddress).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PostedDate).HasColumnType("date");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BSiteApprover)
                    .HasForeignKey(d => d.AssociationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_SiteApprover_b_Association");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.BSiteApprover)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_SiteApprover_b_Season");
            });

            modelBuilder.Entity<BSociaMedia>(entity =>
            {
                entity.HasKey(e => e.SocialMediaId);

                entity.ToTable("b_SociaMedia");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.KeyId).HasMaxLength(50);

                entity.Property(e => e.KeyId2).HasMaxLength(50);

                entity.Property(e => e.MediaName).HasMaxLength(50);
            });

            modelBuilder.Entity<BSponsors>(entity =>
            {
                entity.HasKey(e => e.SponsorsId);

                entity.ToTable("b_Sponsors");

                entity.Property(e => e.SponsorsId).HasColumnName("SponsorsID");

                entity.Property(e => e.SponsorsDateCreated).HasColumnType("date");

                entity.Property(e => e.SponsorsImageUrl).HasMaxLength(150);

                entity.Property(e => e.SponsorsName).HasMaxLength(250);

                entity.Property(e => e.SponsorsNavigateUrl)
                    .HasColumnName("SponsorsNavigateURL")
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<BStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("b_Status");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.StatusName).HasMaxLength(20);
            });

            modelBuilder.Entity<BTeam>(entity =>
            {
                entity.HasKey(e => e.TeamId)
                    .HasName("PK__b_Team__123AE7B91F98B2C1");

                entity.ToTable("b_Team");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.CreatedUserId).HasColumnName("CreatedUserID");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DivisionId).HasColumnName("DivisionID");

                entity.Property(e => e.IsPibnateam).HasColumnName("IsPIBNATeam");

                entity.Property(e => e.MaxAge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.MinAge).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SeasonId).HasColumnName("SeasonID");

                entity.Property(e => e.ServiceFeeId).HasColumnName("ServiceFeeID");

                entity.Property(e => e.TeamFee).HasColumnType("money");

                entity.Property(e => e.TeamName).HasMaxLength(50);

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.BTeam)
                    .HasForeignKey(d => d.DivisionId)
                    .HasConstraintName("FK_b_Team_b_Division");

                entity.HasOne(d => d.ServiceFee)
                    .WithMany(p => p.BTeam)
                    .HasForeignKey(d => d.ServiceFeeId)
                    .HasConstraintName("FK_b_Team_b_ServicesFee");
            });

            modelBuilder.Entity<BTeamContact>(entity =>
            {
                entity.HasKey(e => e.TeamContactId)
                    .HasName("PK__b_TeamCo__051F9D2D236943A5");

                entity.ToTable("b_TeamContact");

                entity.Property(e => e.TeamContactId).HasColumnName("TeamContactID");

                entity.Property(e => e.ContactId).HasColumnName("ContactID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BTeamContact)
                    .HasForeignKey(d => d.TeamId)
                    .HasConstraintName("FK_b_TeamContact_b_Team");
            });

            modelBuilder.Entity<BTeamDiscussion>(entity =>
            {
                entity.HasKey(e => e.TeamDiscussionId);

                entity.ToTable("b_TeamDiscussion");

                entity.Property(e => e.TeamDiscussionId).HasColumnName("TeamDiscussionID");

                entity.Property(e => e.DiscussionDate).HasColumnType("datetime");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BTeamDiscussion)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamDiscussion_b_Team");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BTeamDiscussion)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamDiscussion_b_Users");
            });

            modelBuilder.Entity<BTeamGame>(entity =>
            {
                entity.HasKey(e => e.TeamGameId);

                entity.ToTable("b_TeamGame");

                entity.Property(e => e.DatePlayed).HasColumnType("date");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TeamVsName)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.PostedBy)
                    .WithMany(p => p.BTeamGame)
                    .HasForeignKey(d => d.PostedById)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamGame_b_Users");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BTeamGame)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamGame_b_Team");
            });

            modelBuilder.Entity<BTeamOfficial>(entity =>
            {
                entity.HasKey(e => e.TeamOfficialId);

                entity.ToTable("b_TeamOfficial");

                entity.Property(e => e.TeamOfficialId).HasColumnName("TeamOfficialID");

                entity.Property(e => e.OfficialId).HasColumnName("OfficialID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.Official)
                    .WithMany(p => p.BTeamOfficial)
                    .HasForeignKey(d => d.OfficialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamOfficial_b_Official");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BTeamOfficial)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamOfficial_b_Team");
            });

            modelBuilder.Entity<BTeamPlayers>(entity =>
            {
                entity.HasKey(e => e.TeamPlayerId);

                entity.ToTable("b_TeamPlayers");

                entity.Property(e => e.TeamPlayerId).HasColumnName("TeamPlayerID");

                entity.Property(e => e.DateJoined).HasColumnType("date");

                entity.Property(e => e.MemberId).HasColumnName("MemberID");

                entity.Property(e => e.PostedById).HasColumnName("PostedByID");

                entity.Property(e => e.TeamId).HasColumnName("TeamID");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BTeamPlayers)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamPlayers_b_Member");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.BTeamPlayers)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamPlayers_b_Team");
            });

            modelBuilder.Entity<BTeamStat>(entity =>
            {
                entity.HasKey(e => e.TeamStatId);

                entity.ToTable("b_TeamStat");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BTeamStat)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_TeamStat_b_Member");

                entity.HasOne(d => d.TeamGame)
                    .WithMany(p => p.BTeamStat)
                    .HasForeignKey(d => d.TeamGameId)
                    .HasConstraintName("FK_b_TeamStat_b_TeamGame");
            });

            modelBuilder.Entity<BTvMenu>(entity =>
            {
                entity.HasKey(e => e.TvMenuId)
                    .HasName("PK_t_tvMenu");

                entity.ToTable("b_tvMenu");

                entity.Property(e => e.TvMenuId).HasColumnName("tvMenuID");

                entity.Property(e => e.MenuOrderGroup).HasColumnType("decimal(6, 2)");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.TvMenuDescription)
                    .HasColumnName("tvMenuDescription")
                    .HasMaxLength(100);

                entity.Property(e => e.TvMenuGroupId).HasColumnName("tvMenuGroupID");

                entity.Property(e => e.TvMenuNodeType).HasColumnName("tvMenuNodeType");

                entity.Property(e => e.TvMenuNodeUrl)
                    .HasColumnName("tvMenuNodeUrl")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BUpload>(entity =>
            {
                entity.HasKey(e => e.UploadId)
                    .HasName("PK_Upload");

                entity.ToTable("b_Upload");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ImagePath)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BUserType>(entity =>
            {
                entity.HasKey(e => e.UserTypeId);

                entity.ToTable("b_UserType");

                entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");

                entity.Property(e => e.UserTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BUsers>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__b_Users__1788CCAC367C1819");

                entity.ToTable("b_Users");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AccessCode).HasMaxLength(50);

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.CellPhone).HasMaxLength(15);

                entity.Property(e => e.City).HasMaxLength(25);

                entity.Property(e => e.Country).HasMaxLength(25);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.HomePhone).HasMaxLength(15);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Photo).HasColumnType("image");

                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.Property(e => e.Province).HasMaxLength(5);

                entity.Property(e => e.StreetName).HasMaxLength(25);

                entity.Property(e => e.StreetNo).HasMaxLength(10);

                entity.Property(e => e.StreetType).HasMaxLength(25);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserTypeId)
                    .HasColumnName("UserTypeID")
                    .HasDefaultValueSql("((5))");

                entity.Property(e => e.WorkPhone).HasMaxLength(25);

                entity.Property(e => e.WorkPhoneExt).HasMaxLength(10);

                entity.HasOne(d => d.Association)
                    .WithMany(p => p.BUsers)
                    .HasForeignKey(d => d.AssociationId)
                    .HasConstraintName("FK_b_Users_b_Association");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.BUsers)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_b_Users_b_UserType");
            });

            modelBuilder.Entity<BWaiver>(entity =>
            {
                entity.HasKey(e => e.WaiverId);

                entity.ToTable("b_Waiver");

                entity.Property(e => e.WaiverId).HasColumnName("WaiverID");

                entity.Property(e => e.AssociationId).HasColumnName("AssociationID");

                entity.Property(e => e.DateCreated).HasColumnType("date");

                entity.Property(e => e.WaiverBody)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.WaiverTitle)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
