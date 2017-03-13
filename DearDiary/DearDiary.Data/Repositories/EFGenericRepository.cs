using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DearDiary.Data.Repositories
{
    public class EFGenericRepository<T> : IEFGenericRepository<T> where T : class
    {
        private IDearDiaryDbContext dbContext;
        private IDbSet<T> dbSet;

        public EFGenericRepository(IDearDiaryDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("Database context cannot be null.");
            }

            this.dbContext = new DearDiaryDbContext();
            this.dbSet = this.dbContext.Set<T>();
        }

        public IQueryable<T> All
        {
            get
            {
               return this.dbSet;
            }
        }

        public void Add(T entity)
        {
            var entry = this.GetAttachedEntry(entity);
            entry.State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            var entry = this.GetAttachedEntry(entity);
            entry.State = EntityState.Deleted;
        }

        public T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public void Update(T entity)
        {
            var entry = this.GetAttachedEntry(entity);
            entry.State = EntityState.Modified;
        }

        private DbEntityEntry GetAttachedEntry(T entity)
        {
            var entry = this.dbContext.Entry(entity);
            if(entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            return entry;
        }
    }
}
