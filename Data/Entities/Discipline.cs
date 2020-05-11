using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Discipline
    {
        public Discipline()
        {
            Notes = new List<Note>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
