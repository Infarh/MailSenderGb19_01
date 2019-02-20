using System.Data.Entity;
using MailSender.lib.Migrations;

namespace MailSender.lib.Data.Context
{
    public class MailDatabaseContext : DbContext
    {
        static MailDatabaseContext()
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<MailDatabaseContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<MailDatabaseContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MailDatabaseContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MailDatabaseContext, Configuration>());
        }

        public MailDatabaseContext() : base("name=MailDatabaseContext") { }
        //public MailDatabaseContext(string ConnectionStr) : base(ConnectionStr) { }

        public DbSet<Mail> Mails { get; set; }

        public DbSet<MailsList> MailsLists { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<SendingList> SendingLists { get; set; }

        public DbSet<SchedulerTask> SchedulerTasks { get; set; }

        public DbSet<Server> Servers { get; set; }

        protected override void OnModelCreating(DbModelBuilder model)
        {
            base.OnModelCreating(model);

            model.Entity<Sender>()
                .Property(sender => sender.Name)
                .HasMaxLength(255);
        }
    }
}
