using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test01.Data.Models.Ident
{
    public partial class IdentDbContext : DbContext
    {
        public IdentDbContext()
        {
        }

        public IdentDbContext(DbContextOptions<IdentDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppModules> AppModules { get; set; }
        public virtual DbSet<AppRoles> AppRoles { get; set; }
        public virtual DbSet<AppRolesModules> AppRolesModules { get; set; }
        public virtual DbSet<AppSecuritytypes> AppSecuritytypes { get; set; }
        public virtual DbSet<AppSettings> AppSettings { get; set; }
        public virtual DbSet<AppSyslog> AppSyslog { get; set; }
        public virtual DbSet<AppTokens> AppTokens { get; set; }
        public virtual DbSet<AppUserRoles> AppUserRoles { get; set; }
        public virtual DbSet<AppUsers> AppUsers { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Eventtype> Eventtype { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=TrinityPROD;Username=TrinityDBOwner;Password=askmeonce");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppModules>(entity =>
            {
                entity.ToTable("app_modules", "ident");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app_modules_id_seq'::regclass)");

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasMaxLength(25);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(75);

                entity.Property(e => e.EncryptedSid)
                    .IsRequired()
                    .HasColumnName("encrypted_sid")
                    .HasMaxLength(100);

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(64);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(25);

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<AppRoles>(entity =>
            {
                entity.ToTable("app_roles", "ident");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app_roles_id_seq'::regclass)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(1024);

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(64);

                entity.Property(e => e.Rolename)
                    .IsRequired()
                    .HasColumnName("rolename")
                    .HasMaxLength(50);

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("1");
            });

            modelBuilder.Entity<AppRolesModules>(entity =>
            {
                entity.ToTable("app_roles_modules", "ident");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app_roles_modules_id_seq'::regclass)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(64);

                entity.Property(e => e.ModuleId).HasColumnName("module_id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.Module)
                    .WithMany(p => p.AppRolesModules)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app_roles_modules_app_users_fk");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AppRolesModules)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app_roles_modules_app_roles_fk");
            });

            modelBuilder.Entity<AppSecuritytypes>(entity =>
            {
                entity.ToTable("app_securitytypes", "ident");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AppSettings>(entity =>
            {
                entity.ToTable("app_settings", "ident");

                entity.HasIndex(e => e.Id)
                    .HasName("app_settings_auto_increment_key");

                entity.HasIndex(e => e.Idappuser)
                    .HasName("app_settings_idappuser_idx");

                entity.HasIndex(e => new { e.Application, e.Keyname, e.Idappuser, e.Computername })
                    .HasName("app_settings_keyname_application_idappuser_computername_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app_settings_id_seq'::regclass)");

                entity.Property(e => e.Application)
                    .HasColumnName("application")
                    .HasMaxLength(30);

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Computername)
                    .HasColumnName("computername")
                    .HasMaxLength(64);

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Defaultvalue)
                    .HasColumnName("defaultvalue")
                    .HasMaxLength(64);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(512);

                entity.Property(e => e.Idappuser).HasColumnName("idappuser");

                entity.Property(e => e.Keyname)
                    .IsRequired()
                    .HasColumnName("keyname")
                    .HasMaxLength(50);

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasMaxLength(64);

                entity.HasOne(d => d.IdappuserNavigation)
                    .WithMany(p => p.AppSettings)
                    .HasForeignKey(d => d.Idappuser)
                    .HasConstraintName("app_settings_app_users_fk");
            });

            modelBuilder.Entity<AppSyslog>(entity =>
            {
                entity.ToTable("app_syslog", "ident");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app_syslog_id_seq'::regclass)");

                entity.Property(e => e.AppUserId).HasColumnName("app_user_id");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(256);

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Emailto)
                    .HasColumnName("emailto")
                    .HasMaxLength(255);

                entity.Property(e => e.Eventdate).HasColumnName("eventdate");

                entity.Property(e => e.EventtypeId).HasColumnName("eventtype_id");

                entity.Property(e => e.IsVisible)
                    .HasColumnName("is_visible")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasMaxLength(255);

                entity.HasOne(d => d.AppUser)
                    .WithMany(p => p.AppSyslog)
                    .HasForeignKey(d => d.AppUserId)
                    .HasConstraintName("fk_app_syslog_app_users");

                entity.HasOne(d => d.Eventtype)
                    .WithMany(p => p.AppSyslog)
                    .HasForeignKey(d => d.EventtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_app_syslog_eventtype");
            });

            modelBuilder.Entity<AppTokens>(entity =>
            {
                entity.ToTable("app_tokens", "ident");

                entity.HasIndex(e => e.Value)
                    .HasName("app_tokens_uk")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app_tokens_id_seq'::regclass)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.ExpiryDate).HasColumnName("expiry_date");

                entity.Property(e => e.IsUsed).HasColumnName("is_used");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modified_by")
                    .HasMaxLength(64);

                entity.Property(e => e.Provider)
                    .IsRequired()
                    .HasColumnName("provider")
                    .HasMaxLength(64);

                entity.Property(e => e.Purpose)
                    .IsRequired()
                    .HasColumnName("purpose")
                    .HasMaxLength(64);

                entity.Property(e => e.UsageDate).HasColumnName("usage_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AppTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("app_tokens_app_users_fk");
            });

            modelBuilder.Entity<AppUserRoles>(entity =>
            {
                entity.ToTable("app_user_roles", "ident");

                entity.HasIndex(e => e.Idappuser)
                    .HasName("app_user_roles_iduser_idx");

                entity.HasIndex(e => e.Idrole)
                    .HasName("app_user_roles_idrole_idx");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app_user_roles_id_seq'::regclass)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Idappuser).HasColumnName("idappuser");

                entity.Property(e => e.Idrole).HasColumnName("idrole");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(64);

                entity.Property(e => e.ValidFrom)
                    .HasColumnName("valid_from")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ValidTo).HasColumnName("valid_to");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("1");

                entity.HasOne(d => d.IdappuserNavigation)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.Idappuser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app_user_roles_app_users_fk");

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.AppUserRoles)
                    .HasForeignKey(d => d.Idrole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app_user_roles_app_roles_fk");
            });

            modelBuilder.Entity<AppUsers>(entity =>
            {
                entity.ToTable("app_users", "ident");

                entity.HasIndex(e => e.Winusername)
                    .HasName("app_users_uk1")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('app_users_id_seq'::regclass)");

                entity.Property(e => e.Accessfailedcount).HasColumnName("accessfailedcount");

                entity.Property(e => e.Apppassword)
                    .HasColumnName("apppassword")
                    .HasMaxLength(64);

                entity.Property(e => e.Appusername)
                    .HasColumnName("appusername")
                    .HasMaxLength(64);

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Concurrencystamp).HasColumnName("concurrencystamp");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Displayname)
                    .HasColumnName("displayname")
                    .HasMaxLength(64);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.Emailconfirmed).HasColumnName("emailconfirmed");

                entity.Property(e => e.Emailsignature).HasColumnName("emailsignature");

                entity.Property(e => e.Idcontact).HasColumnName("idcontact");

                entity.Property(e => e.Idsecuritytype).HasColumnName("idsecuritytype");

                entity.Property(e => e.Isactive)
                    .IsRequired()
                    .HasColumnName("isactive")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.Lockoutenabled).HasColumnName("lockoutenabled");

                entity.Property(e => e.Lockoutend).HasColumnName("lockoutend");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Normalizedemail)
                    .HasColumnName("normalizedemail")
                    .HasMaxLength(256);

                entity.Property(e => e.Normalizedusername)
                    .HasColumnName("normalizedusername")
                    .HasMaxLength(256);

                entity.Property(e => e.Osusername)
                    .HasColumnName("osusername")
                    .HasMaxLength(64);

                entity.Property(e => e.Passwordhash).HasColumnName("passwordhash");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");

                entity.Property(e => e.Phonenumberconfirmed).HasColumnName("phonenumberconfirmed");

                entity.Property(e => e.Securitystamp).HasColumnName("securitystamp");

                entity.Property(e => e.Twofactorenabled).HasColumnName("twofactorenabled");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(256);

                entity.Property(e => e.Winusername)
                    .HasColumnName("winusername")
                    .HasMaxLength(64)
                    .HasComment("Windows OS user name");

                entity.HasOne(d => d.IdsecuritytypeNavigation)
                    .WithMany(p => p.AppUsers)
                    .HasForeignKey(d => d.Idsecuritytype)
                    .HasConstraintName("app_users_app_securitytypes_fk");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("customers", "ident");

                entity.HasIndex(e => e.Id1)
                    .HasName("customers_id1_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('customers_id_seq'::regclass)");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(48);

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(64);

                entity.Property(e => e.Company1)
                    .HasColumnName("company1")
                    .HasMaxLength(64);

                entity.Property(e => e.Country)
                    .HasColumnName("country")
                    .HasMaxLength(32);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Createdby)
                    .IsRequired()
                    .HasColumnName("createdby")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(64);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(128);

                entity.Property(e => e.Homepage)
                    .HasColumnName("homepage")
                    .HasMaxLength(100);

                entity.Property(e => e.Id1).HasColumnName("id1");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Modifiedby)
                    .HasColumnName("modifiedby")
                    .HasMaxLength(64);

                entity.Property(e => e.Post)
                    .HasColumnName("post")
                    .HasMaxLength(32);

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasMaxLength(10)
                    .HasComment("flag for origin declaration of record (support as, asystdb ad, myfactory mf)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasComment("flag for dobavit - 0 dobavitelj, 1 kupec, 2 oboje)");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(128);

                entity.Property(e => e.Street1)
                    .HasColumnName("street1")
                    .HasMaxLength(128);

                entity.Property(e => e.Suppliercode)
                    .HasColumnName("suppliercode")
                    .HasMaxLength(5)
                    .HasComment("for storing string based dobavit.kodadobavitelja on synchronisation. by default all string based customers will be inserted.");

                entity.Property(e => e.Telefax)
                    .HasColumnName("telefax")
                    .HasMaxLength(32);

                entity.Property(e => e.Telefon1)
                    .HasColumnName("telefon1")
                    .HasMaxLength(32);

                entity.Property(e => e.Telefon2)
                    .HasColumnName("telefon2")
                    .HasMaxLength(32);

                entity.Property(e => e.Vatnumber)
                    .HasColumnName("vatnumber")
                    .HasMaxLength(32);

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Zip)
                    .HasColumnName("zip")
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Eventtype>(entity =>
            {
                entity.ToTable("eventtype", "ident");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.Shortname)
                    .HasColumnName("shortname")
                    .HasMaxLength(32);

                entity.Property(e => e.Sifgroup)
                    .HasColumnName("sifgroup")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
