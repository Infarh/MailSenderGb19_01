using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using MailSender.lib.Data;
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
            if (!context.Servers.Any())
            {
                foreach (var server in Servers.Items)
                {
                    context.Servers.Add(server);
                }

                context.SaveChanges();
            }
        }
    }
}
