using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test01.Data.Models.KB
{
    public partial class KbDbContext : DbContext
    {
        public KbDbContext()
        {
        }

        public KbDbContext(DbContextOptions<KbDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Eventtype> Eventtype { get; set; }
        public virtual DbSet<FeedbackType> FeedbackType { get; set; }
        public virtual DbSet<Label> Label { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Robot> Robot { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Template> Template { get; set; }
        public virtual DbSet<Templatetype> Templatetype { get; set; }
        public virtual DbSet<Topic> Topic { get; set; }
        public virtual DbSet<TopicCategory> TopicCategory { get; set; }
        public virtual DbSet<TopicCategoryVersion> TopicCategoryVersion { get; set; }
        public virtual DbSet<TopicEvent> TopicEvent { get; set; }
        public virtual DbSet<TopicFeedback> TopicFeedback { get; set; }
        public virtual DbSet<TopicLabel> TopicLabel { get; set; }
        public virtual DbSet<TopicVersion> TopicVersion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=TrinityPROD;Username=TrinityDBOwner;Password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('category_id_seq'::regclass)");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IdParent).HasColumnName("id_parent");

                entity.Property(e => e.IdTemplate).HasColumnName("id_template");

                entity.Property(e => e.Imageurl)
                    .HasColumnName("imageurl")
                    .HasMaxLength(128);

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.Property(e => e.Position).HasColumnName("position");

                entity.HasOne(d => d.IdParentNavigation)
                    .WithMany(p => p.InverseIdParentNavigation)
                    .HasForeignKey(d => d.IdParent)
                    .HasConstraintName("category_category_fk");

                entity.HasOne(d => d.IdTemplateNavigation)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.IdTemplate)
                    .HasConstraintName("category_template_fk");
            });

            modelBuilder.Entity<Eventtype>(entity =>
            {
                entity.ToTable("eventtype", "kb");

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

            modelBuilder.Entity<FeedbackType>(entity =>
            {
                entity.ToTable("feedback_type", "kb");

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

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasColumnName("is_active")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.IsPositive).HasColumnName("is_positive");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Label>(entity =>
            {
                entity.ToTable("label", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('label_id_seq'::regclass)");

                entity.Property(e => e.Attributes)
                    .HasColumnName("attributes")
                    .HasMaxLength(512);

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasMaxLength(255);

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Label1)
                    .IsRequired()
                    .HasColumnName("label")
                    .HasMaxLength(255);

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "kb");

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

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Robot>(entity =>
            {
                entity.ToTable("robot", "kb");

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

                entity.Property(e => e.Htmltag).HasColumnName("htmltag");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.Shortname)
                    .HasColumnName("shortname")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('status_id_seq'::regclass)");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Entity)
                    .IsRequired()
                    .HasColumnName("entity")
                    .HasMaxLength(50);

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Template>(entity =>
            {
                entity.ToTable("template", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('template_id_seq'::regclass)");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Htmltemplate).HasColumnName("htmltemplate");

                entity.Property(e => e.IdTemplatetype).HasColumnName("id_templatetype");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(128);

                entity.HasOne(d => d.IdTemplatetypeNavigation)
                    .WithMany(p => p.Template)
                    .HasForeignKey(d => d.IdTemplatetype)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("template_templatetype_fk");
            });

            modelBuilder.Entity<Templatetype>(entity =>
            {
                entity.ToTable("templatetype", "kb");

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
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.ToTable("topic", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topic_id_seq'::regclass)");

                entity.Property(e => e.AliasUrl)
                    .HasColumnName("alias_url")
                    .HasMaxLength(256);

                entity.Property(e => e.AssigneeId).HasColumnName("assignee_id");

                entity.Property(e => e.AvgRating)
                    .HasColumnName("avg_rating")
                    .HasColumnType("numeric");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Contentastext).HasColumnName("contentastext");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Deadline).HasColumnName("deadline");

                entity.Property(e => e.EditorId).HasColumnName("editor_id");

                entity.Property(e => e.Featured).HasColumnName("featured");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.IsVisible).HasColumnName("is_visible");

                entity.Property(e => e.LastResolved).HasColumnName("last_resolved");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.MetaAuthor)
                    .HasColumnName("meta_author")
                    .HasMaxLength(64);

                entity.Property(e => e.MetaDescription)
                    .HasColumnName("meta_description")
                    .HasMaxLength(256);

                entity.Property(e => e.MetaKeywords)
                    .HasColumnName("meta_keywords")
                    .HasMaxLength(256);

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.NumViews).HasColumnName("num_views");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PublishStart)
                    .HasColumnName("publish_start")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.PublishStop).HasColumnName("publish_stop");

                entity.Property(e => e.RequestorId).HasColumnName("requestor_id");

                entity.Property(e => e.RobotId).HasColumnName("robot_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(256);

                entity.Property(e => e.ValidProductStart)
                    .HasColumnName("valid_product_start")
                    .HasMaxLength(64);

                entity.Property(e => e.ValidProductStop)
                    .HasColumnName("valid_product_stop")
                    .HasMaxLength(64);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_topic_product");

                entity.HasOne(d => d.Robot)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.RobotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_robot");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Topic)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_status");
            });

            modelBuilder.Entity<TopicCategory>(entity =>
            {
                entity.ToTable("topic_category", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topic_category_id_seq'::regclass)");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.IsDeleted).HasColumnName("is_deleted");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TopicCategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_category_category");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicCategory)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_category_topic");
            });

            modelBuilder.Entity<TopicCategoryVersion>(entity =>
            {
                entity.ToTable("topic_category_version", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topic_category_version_id_seq'::regclass)");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.TopicVersionId).HasColumnName("topic_version_id");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TopicCategoryVersion)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_category_version_category");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicCategoryVersion)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_category_version_topic");
            });

            modelBuilder.Entity<TopicEvent>(entity =>
            {
                entity.ToTable("topic_event", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topic_event_id_seq'::regclass)");

                entity.Property(e => e.AppUserId).HasColumnName("app_user_id");

                entity.Property(e => e.AssigneeId).HasColumnName("assignee_id");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Cuser)
                    .IsRequired()
                    .HasColumnName("cuser")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("\"current_user\"()");

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

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Summary)
                    .HasColumnName("summary")
                    .HasMaxLength(255);

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.HasOne(d => d.Eventtype)
                    .WithMany(p => p.TopicEvent)
                    .HasForeignKey(d => d.EventtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topicevent_eventtype");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TopicEvent)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_topicevent_status");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicEvent)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topicevent_topic");
            });

            modelBuilder.Entity<TopicFeedback>(entity =>
            {
                entity.ToTable("topic_feedback", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topic_feedback_id_seq'::regclass)");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Cuser)
                    .IsRequired()
                    .HasColumnName("cuser")
                    .HasMaxLength(256)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.FeedbackComment).HasColumnName("feedback_comment");

                entity.Property(e => e.FeedbackDate)
                    .HasColumnName("feedback_date")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FeedbackTypeId).HasColumnName("feedback_type_id");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.HasOne(d => d.FeedbackType)
                    .WithMany(p => p.TopicFeedback)
                    .HasForeignKey(d => d.FeedbackTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_feedback_feedback_type");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicFeedback)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_feedback_topic");
            });

            modelBuilder.Entity<TopicLabel>(entity =>
            {
                entity.ToTable("topic_label", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topic_label_id_seq'::regclass)");

                entity.Property(e => e.Cdate)
                    .HasColumnName("cdate")
                    .HasDefaultValueSql("('now'::text)::timestamp without time zone");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("\"current_user\"()");

                entity.Property(e => e.LabelId).HasColumnName("label_id");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.HasOne(d => d.Label)
                    .WithMany(p => p.TopicLabel)
                    .HasForeignKey(d => d.LabelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_label_label");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicLabel)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_label_topic");
            });

            modelBuilder.Entity<TopicVersion>(entity =>
            {
                entity.ToTable("topic_version", "kb");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('topic_version_id_seq'::regclass)");

                entity.Property(e => e.AliasUrl)
                    .HasColumnName("alias_url")
                    .HasMaxLength(256);

                entity.Property(e => e.AssigneeId).HasColumnName("assignee_id");

                entity.Property(e => e.Cdate).HasColumnName("cdate");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Cuser)
                    .HasColumnName("cuser")
                    .HasMaxLength(50);

                entity.Property(e => e.Deadline).HasColumnName("deadline");

                entity.Property(e => e.EditorId).HasColumnName("editor_id");

                entity.Property(e => e.IsVisible).HasColumnName("is_visible");

                entity.Property(e => e.LastResolved).HasColumnName("last_resolved");

                entity.Property(e => e.Mdate).HasColumnName("mdate");

                entity.Property(e => e.MetaAuthor)
                    .HasColumnName("meta_author")
                    .HasMaxLength(64);

                entity.Property(e => e.MetaDescription)
                    .HasColumnName("meta_description")
                    .HasMaxLength(256);

                entity.Property(e => e.MetaKeywords)
                    .HasColumnName("meta_keywords")
                    .HasMaxLength(256);

                entity.Property(e => e.Muser)
                    .HasColumnName("muser")
                    .HasMaxLength(50);

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.PublishStart).HasColumnName("publish_start");

                entity.Property(e => e.PublishStop).HasColumnName("publish_stop");

                entity.Property(e => e.RequestorId).HasColumnName("requestor_id");

                entity.Property(e => e.RobotId).HasColumnName("robot_id");

                entity.Property(e => e.StatusId).HasColumnName("status_id");

                entity.Property(e => e.Title)
                    .HasColumnName("title")
                    .HasMaxLength(256);

                entity.Property(e => e.TopicId).HasColumnName("topic_id");

                entity.Property(e => e.ValidProductStart)
                    .HasColumnName("valid_product_start")
                    .HasMaxLength(64);

                entity.Property(e => e.ValidProductStop)
                    .HasColumnName("valid_product_stop")
                    .HasMaxLength(64);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TopicVersion)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_topic_version_product");

                entity.HasOne(d => d.Robot)
                    .WithMany(p => p.TopicVersion)
                    .HasForeignKey(d => d.RobotId)
                    .HasConstraintName("fk_topic_version_robot");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.TopicVersion)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("fk_topic_version_status");

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.TopicVersion)
                    .HasForeignKey(d => d.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_topic_version_topic");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
