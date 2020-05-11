using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Situation
    {
        public Situation()
        {
            Notes = new List<Note>();
        }
        public Guid Id { get; set; }
        public string Formula { get; set; }
        public string MinimumQualificationStandard { get; set; }
        public int Grade { get; set; }
        public bool FinalGrade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
    }
}
