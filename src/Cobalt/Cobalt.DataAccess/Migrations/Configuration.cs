using System.Data.Entity.Migrations;
using Cobalt.DataAccess.Context;

namespace Cobalt.DataAccess.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CobaltContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CobaltContext context)
        {
        }
    }
}