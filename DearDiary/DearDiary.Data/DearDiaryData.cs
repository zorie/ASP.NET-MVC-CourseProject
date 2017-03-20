using System;
using DearDiary.Data.Repositories;
using DearDiary.Models;

namespace DearDiary.Data
{
    public class DearDiaryData : IDearDiaryData
    {
        private readonly IDearDiaryDbContext dbContext;
        private readonly IEFGenericRepository<AimCategory> aimCategories;
        private readonly IEFGenericRepository<Aim> aims;
        private readonly IEFGenericRepository<User> users;
        private readonly IEFGenericRepository<City> cities;
        private readonly IEFGenericRepository<Country> countries;

        public DearDiaryData(
            IDearDiaryDbContext dbContext,
            IEFGenericRepository<User> usersRepo,
            IEFGenericRepository<Aim> aimsRepo,
            IEFGenericRepository<AimCategory> categoriesRepo,
            IEFGenericRepository<City> citiesRepo,
            IEFGenericRepository<Country> countriesRepo)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Database context cannot be null.");
            }

            if (usersRepo == null)
            {
                throw new ArgumentNullException("Users entity framework repository cannot be null.");
            }

            if (aimsRepo == null)
            {
                throw new ArgumentNullException("Aims entity framework repository cannot be null.");
            }

            if (categoriesRepo == null)
            {
                throw new ArgumentNullException("AimCategories entity framework repository cannot be null.");
            }

            if (citiesRepo == null)
            {
                throw new ArgumentNullException("Cities entity framework repository cannot be null.");
            }

            if (countriesRepo == null)
            {
                throw new ArgumentNullException("Countries entity framework repository cannot be null.");
            }

            this.dbContext = dbContext;
            this.users = usersRepo;
            this.aims = aimsRepo;
            this.aimCategories = categoriesRepo;
            this.cities = citiesRepo;
            this.countries = countriesRepo;
        }

        public IEFGenericRepository<AimCategory> AimCategories
        {
            get { return this.aimCategories; }
        }

        public IEFGenericRepository<Aim> Aims
        {
            get { return this.aims; }
        }

        public IEFGenericRepository<City> Cities
        {
            get { return this.cities; }
        }

        public IEFGenericRepository<Country> Countries
        {
            get { return this.countries; }
        }

        public IEFGenericRepository<User> Users
        {
            get { return this.users; }
        }

        public int SaveChanges()
        {
            return this.dbContext.SaveChanges();
        }
        public void Dispose()
        {            
        }
    }
}
