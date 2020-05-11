using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Topic
    {
        public Topic()
        {
            Teachers = new List<Teacher>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URI { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
