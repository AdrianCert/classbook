using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataService
{
    public interface IDataService<Entity>
    {
        List<Entity> GetAll();
        Entity GetById(object id);
        void Insert(Entity entity);
        void Delete(object id);
        void Update(Entity entity);
    }
}
