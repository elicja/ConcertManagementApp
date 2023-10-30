using DataAccess.Data;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using Models.Base;

namespace DataAccess.Implementation.Base
{
    public class DictionaryDataProviderBase<T> : IGenericProvider<T> where T : DictionaryTableBase
    {
        private DataDbContext _db;
        internal DbSet<T> dbSet;

        public DictionaryDataProviderBase(DataDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
            _db.SaveChanges();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
            _db.SaveChanges();
        }

        public List<T> GetAll()
        {
            IQueryable<T> query = dbSet;

            return query.ToList();
        }

        public T Get(int id)
        {
            IQueryable<T> query = dbSet;

            return query.FirstOrDefault(x => x.Id == id);
        }
    }
}
