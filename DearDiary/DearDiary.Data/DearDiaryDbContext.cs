using System.Data.Entity;
using DearDiary.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DearDiary.Data
{
    public class DearDiaryDbContext : IdentityDbContext<User>, IDearDiaryDbContext
    {
        public DearDiaryDbContext() 
            : base("DearDiaryTestDB")
        {
        }

        public IDbSet<AimCategory> AimCategories { get; set; }

        public IDbSet<Aim> Aims { get; set; }

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public static DearDiaryDbContext Create()
        {
            return new DearDiaryDbContext();
        }

        IDbSet<T> IDearDiaryDbContext.Set<T>()
        {
            return this.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(x => x.AccomplishedAims).WithMany(x => x.InUsersDoneList);
            modelBuilder.Entity<User>().HasMany(x => x.FutureAims).WithMany(x => x.InUsersBucketList);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
