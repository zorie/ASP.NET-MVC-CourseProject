using DearDiary.Data.Repositories;
using DearDiary.Models;
using System;

namespace DearDiary.Data
{
    // TODO: should it be IDisposable
    public interface IDearDiaryData : IDisposable
    {
        IEFGenericRepository<Aim> Aims { get; }
        IEFGenericRepository<User> Users { get; }
        IEFGenericRepository<AimCategory> AimCategories { get; }
        IEFGenericRepository<City> Cities { get; }
        IEFGenericRepository<Country> Countries { get; }

        // TODO: should it be int?
        int SaveChanges();
    }
}
