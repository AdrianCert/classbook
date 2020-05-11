using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Class
    {
        public Class()
        {
            Students = new List<Student>();
            Teachers = new List<Teacher>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
