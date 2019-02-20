using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using MailSender.lib.Data.Context;

namespace MailSender.lib.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MailDatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(MailDatabaseContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
