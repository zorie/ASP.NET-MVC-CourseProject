using DearDiary.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DearDiary.Data
{
    public interface IDearDiaryDbContext
    {
        IDbSet<Aim> Aims { get; set; }
        
        IDbSet<AimCategory> AimCategories { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<Country> Countries { get; set; }
        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<T> Entry<T>(T entity) where T : class;

        int SaveChanges();
    }
}
