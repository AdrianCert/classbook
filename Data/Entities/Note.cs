using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public int Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Discipline Discipline  { get; set; }
        public virtual Teacher Teacher  { get; set; }
    }
}
