namespace PhonebookManager.DataAccess.Migrations
{
    using PhonebookManager.DataAccess.Migrations.DataHelpers;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhonebookManager.DataAccess.Context.PhonebookManagerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PhonebookManager.DataAccess.Context.PhonebookManagerContext context)
        {
            var result = UserDataHelper.CreateAdminUser(context).Result;
        }
    }
}
