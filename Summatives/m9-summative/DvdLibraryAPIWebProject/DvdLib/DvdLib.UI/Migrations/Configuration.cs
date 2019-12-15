namespace DvdLib.UI.Migrations
{
    using DvdLib.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdLib.Models.DvdLibEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdLib.Models.DvdLibEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Dvds.AddOrUpdate(
                d => d.DvdId,
                new Dvd
                {
                    DvdId = 1,
                    Title = "Saving Private Ryan",
                    ReleaseYear = 1999,
                    Director = "Spielberg",
                    Rating = "R",
                    Notes = "Emotional"
                },
                new Dvd
                {
                    DvdId = 2,
                    Title = "Elf",
                    ReleaseYear = 2003,
                    Director = "Berenbaum",
                    Rating = "PG",
                    Notes = "Best"
                });
        }
    }
}
