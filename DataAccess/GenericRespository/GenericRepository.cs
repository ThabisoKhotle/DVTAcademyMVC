using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.GenericRespository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MVCDbContext context = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.context = new MVCDbContext();
            table = context.Set<T>();
        }

        public GenericRepository(MVCDbContext context)
        {
            this.context = context;
            table = context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetByID(object id)
        {
            return table.Find(id);
        }
        public void Insert(T obj)
        {
            table.Add(obj);
        }
        public void Update(T obj)
        {
            table.Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            Save();
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
            Save();
        }
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
