using DearDiary.Data.Repositories;
using DearDiary.Models;

namespace DearDiary.Data
{
    public interface IDearDiaryData
    {
        IEFGenericRepository<Aim> Aims { get; }
        IEFGenericRepository<User> Users { get; }
        IEFGenericRepository<AimCategory> AimCategories { get; }
        IEFGenericRepository<City> Cities { get; }
        IEFGenericRepository<Country> Countries { get; }
        int SaveChanges();
    }
}
