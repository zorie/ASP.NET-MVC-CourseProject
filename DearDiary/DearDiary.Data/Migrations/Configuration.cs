using DearDiary.Models;
using System.Data.Entity.Migrations;

namespace DearDiary.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<DearDiary.Data.DearDiaryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(DearDiary.Data.DearDiaryDbContext context)
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

            //context.AimCategories.AddOrUpdate(
            //        new AimCategory {Id=3, Name="TestCategory" }
            //    );

            //context.Cities.AddOrUpdate(
            //        new City { Id = 3, Name = "CityTest" }
            //    );

            //context.Aims.AddOrUpdate(
            //    new Aim { Name="test", Type="type", AimCategoryId=3, CityId=3}
            //    );
        }
    }
}
