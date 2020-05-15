using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories;

namespace Business.DataService
{
    public class DataService<Entity> : IDataService<Entity>
        where Entity : class
    {
        private readonly IRepository<Entity> db = new Repository<Entity>();
        public List<Entity> GetAll()
        {
            return db.GetAll().ToList();
        }

        public Entity GetById(object id)
        {
            Entity entity = db.GetById(id);
            if(entity == null)
            {
                throw new KeyNotFoundException($"Entity with id { id } not found");
            }
            return entity;
        }
        public void Insert(Entity entity)
        {
            db.Insert(entity);
            db.Save();
        }
        public void Delete(object id)
        {
            db.Delete(id);
            db.Save();
        }
        public void Update(Entity entity)
        {
            db.Update(entity);
            db.Save();
        }
    }
}
