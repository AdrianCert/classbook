using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Student : User
    {
        public Student()
        {
            Notes = new List<Note>();
        }
        public virtual Parent Parent { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
