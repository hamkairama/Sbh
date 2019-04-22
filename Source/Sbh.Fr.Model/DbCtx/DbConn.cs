namespace Sbh.Fr.Model.DbCtx
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Master;
    using Transaksi;
    using View;

    public partial class DbConn : DbContext
    {
        public DbConn()
            : base("name=ConnString")
        {
        }

        public object EntityState { get; set; }
        public virtual DbSet<QuestionAndAnswer> QuestionAndAnswers { get; set; }
        public virtual DbSet<MostAct> MostAct { get; set; }
        public virtual DbSet<ListUser> ListUser { get; set; }
        public virtual DbSet<TaskListUser> TaskListUser { get; set; }


        public virtual DbSet<SBH_TM_ARTICLE_CAT> SBH_TM_ARTICLE_CAT { get; set; }
        public virtual DbSet<SBH_TM_CATEGORY_QUESTIONS> SBH_TM_CATEGORY_QUESTIONS { get; set; }
        public virtual DbSet<SBH_TM_CONTACT_US> SBH_TM_CONTACT_US { get; set; }
        public virtual DbSet<SBH_TM_GENDER> SBH_TM_GENDER { get; set; }
        public virtual DbSet<SBH_TM_GROUP> SBH_TM_GROUP { get; set; }
       
        public virtual DbSet<SBH_TM_SOSMED> SBH_TM_SOSMED { get; set; }
        public virtual DbSet<SBH_TM_USER_ADMIN> SBH_TM_USER_ADMIN { get; set; }
        public virtual DbSet<SBH_TM_USER_PROFILE_ADMIN> SBH_TM_USER_PROFILE_ADMIN { get; set; }
        public virtual DbSet<SBH_TM_USER_PROFILE_SOSMED> SBH_TM_USER_PROFILE_SOSMED { get; set; }
        public virtual DbSet<SBH_TR_ANSWER> SBH_TR_ANSWER { get; set; }
        public virtual DbSet<SBH_TR_ARTICLE> SBH_TR_ARTICLE { get; set; }
        public virtual DbSet<SBH_TR_QUESTIONS> SBH_TR_QUESTIONS { get; set; }
        public virtual DbSet<SBH_TM_MOSTCOMMENT> SBH_TM_MOSTCOMMENT { get; set; }
        public virtual DbSet<SBH_TM_MOSTACTIVITY> SBH_TM_MOSTACTIVITY { get; set; }
        public virtual DbSet<SBH_TR_QUESTIONS_TAGGING> SBH_TR_QUESTIONS_TAGGING { get; set; }
        public virtual DbSet<SBH_TM_NEWS> SBH_TM_NEWS { get; set; }
        public virtual DbSet<SBH_TM_CATEGORY> SBH_TM_CATEGORY { get; set; }
        public virtual DbSet<SBH_TM_SLIDESHOW> SBH_TM_SLIDESHOW { get; set; }
        public virtual DbSet<SBH_TM_GALERY_FOTO> SBH_TM_GALERY_FOTO { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SBH_TM_GENDER>()
                .HasKey(e => e.GENDER_ID);

            modelBuilder.Entity<SBH_TM_ARTICLE_CAT>()
               .Property(e => e.ARTICLE_CAT_DESC)
               .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_ARTICLE_CAT>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_ARTICLE_CAT>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_ARTICLE_CAT>()
                .HasMany(e => e.SBH_TR_ARTICLE)
                .WithOptional(e => e.SBH_TM_ARTICLE_CAT)
                .HasForeignKey(e => e.ID_ARTICLE_CAT);

            modelBuilder.Entity<SBH_TM_CATEGORY_QUESTIONS>()
                .Property(e => e.CATEGORY_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY_QUESTIONS>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY_QUESTIONS>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY_QUESTIONS>()
                .HasMany(e => e.SBH_TR_QUESTIONS)
                .WithOptional(e => e.SBH_TM_CATEGORY_QUESTIONS)
                .HasForeignKey(e => e.ID_CATEGORY);

            modelBuilder.Entity<SBH_TM_CONTACT_US>()
                .Property(e => e.NAME_SENDER)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CONTACT_US>()
                .Property(e => e.EMAIL_SENDER)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CONTACT_US>()
                .Property(e => e.PHONE_SENDER)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CONTACT_US>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CONTACT_US>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CONTACT_US>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GENDER>()
                .Property(e => e.GENDER_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GENDER>()
                .Property(e => e.GENDER_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GENDER>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GENDER>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GROUP>()
                .Property(e => e.GROUP_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GROUP>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GROUP>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GROUP>()
                .HasMany(e => e.SBH_TM_USER_ADMIN)
                .WithOptional(e => e.SBH_TM_GROUP)
                .HasForeignKey(e => e.ID_GROUP);

            //modelBuilder.Entity<SBH_TM_NEWS>()
            //    .Property(e => e.TITLE)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SBH_TM_NEWS>()
            //    .Property(e => e.DESCRIPTION)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SBH_TM_NEWS>()
            //    .Property(e => e.CREATED_BY)
            //    .IsUnicode(false);

            //modelBuilder.Entity<SBH_TM_NEWS>()
            //    .Property(e => e.LAST_MODIFIED_BY)
            //    .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.TYPE)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.ICON)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.DATA_EMBED)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.DATA_WIDGET_ID)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SOSMED>()
                .Property(e => e.PHOTO_PATH)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .Property(e => e.ID_USER_ADMIN)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .Property(e => e.USER_MAIL)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .Property(e => e.USER_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .Property(e => e.PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .HasMany(e => e.SBH_TR_ANSWER)
                .WithOptional(e => e.SBH_TM_USER_ADMIN)
                .HasForeignKey(e => e.ID_USER_ADMIN);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .HasMany(e => e.SBH_TR_ARTICLE)
                .WithOptional(e => e.SBH_TM_USER_ADMIN)
                .HasForeignKey(e => e.ID_USER_ADMIN);

            modelBuilder.Entity<SBH_TM_USER_ADMIN>()
                .HasMany(e => e.SBH_TR_QUESTIONS)
                .WithOptional(e => e.SBH_TM_USER_ADMIN)
                .HasForeignKey(e => e.ID_USER);
            
            //modelBuilder.Entity<SBH_TM_USER_ADMIN>()
            // .HasMany(e => e.SBH_TM_GALERY_FOTO)
            // .WithOptional(e => e.SBH_TM_USER_ADMIN)
            // .HasForeignKey(e => e.USER_ID);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.PHOTO_PATH)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.GENDER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.ADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.JOB)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.COMPANY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.HOBBY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_ADMIN>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_SOSMED>()
                .Property(e => e.SOSMED_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_SOSMED>()
                .Property(e => e.SOSMED_PATH)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_SOSMED>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_USER_PROFILE_SOSMED>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_ANSWER>()
                .Property(e => e.ANSWER)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_ANSWER>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_ANSWER>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_ARTICLE>()
                .Property(e => e.ARTICLE)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_ARTICLE>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_ARTICLE>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_QUESTIONS>()
                .Property(e => e.QUESTIONS)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_QUESTIONS>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_QUESTIONS>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TR_QUESTIONS>()
                .HasMany(e => e.SBH_TR_ANSWER)
                .WithOptional(e => e.SBH_TR_QUESTIONS)
                .HasForeignKey(e => e.ID_QUESTIONS);

            modelBuilder.Entity<SBH_TM_MOSTCOMMENT>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<SBH_TM_MOSTACTIVITY>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<SBH_TR_QUESTIONS_TAGGING>()
                .HasKey(e => e.ID);

            modelBuilder.Entity<SBH_TM_NEWS>()
               .Property(e => e.TITLE)
               .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_NEWS>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_NEWS>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_NEWS>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_NEWS>()
                .HasMany(e => e.SBH_TM_GALERY_FOTO)
                .WithRequired(e => e.SBH_TM_NEWS)
                .HasForeignKey(e => e.NEWS_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SBH_TM_CATEGORY>()
                .Property(e => e.CATEGORY_NAME)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY>()
                .Property(e => e.IMAGE_PATH)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY>()
                .Property(e => e.CLASS)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_CATEGORY>()
                 .HasMany(e => e.SBH_TM_NEWS)
                 .WithRequired(e => e.SBH_TM_CATEGORY)
                 .HasForeignKey(e => e.CATEGORY_ID)
                 .WillCascadeOnDelete(false);


            modelBuilder.Entity<SBH_TM_SLIDESHOW>()
                .Property(e => e.TITTLE)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SLIDESHOW>()
                .Property(e => e.CONTENT_DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SLIDESHOW>()
                .Property(e => e.CLASS)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SLIDESHOW>()
                .Property(e => e.PHOTO_PATH)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SLIDESHOW>()
                .Property(e => e.URL)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SLIDESHOW>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_SLIDESHOW>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GALERY_FOTO>()
               .Property(e => e.PHOTO_PATH)
               .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GALERY_FOTO>()
                .Property(e => e.DESCRIPTION)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GALERY_FOTO>()
                .Property(e => e.CREATED_BY)
                .IsUnicode(false);

            modelBuilder.Entity<SBH_TM_GALERY_FOTO>()
                .Property(e => e.LAST_MODIFIED_BY)
                .IsUnicode(false);
        }
    }
}
