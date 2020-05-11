using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Teacher : User
    {
        public Teacher()
        {
            TopicsKnolage = new List<Topic>();
            Classes = new List<Class>();
            ClassesMaster = new List<Class>();
        }
        public virtual ICollection<Topic> TopicsKnolage { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Class> ClassesMaster { get; set; }
    }
}
