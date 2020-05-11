using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Context;
using System.Data.Entity;


namespace Data.Repositories 
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private Context.Database _context = null;
        private DbSet<T> table = null;
        public Repository()
        {
            this._context = new Context.Database();
            table = _context.Set<T>();
        }
        public Repository(Context.Database _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }
        public T GetById(object id)
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
            _context.Entry(obj).State = EntityState.Modified;
        }
        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }
        public void Save()
        {
            _context.SaveChanges();
            _context.Dispose();
        }
    }
}
