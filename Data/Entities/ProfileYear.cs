using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class ProfileYear
    {
        public ProfileYear()
        {
            Topics = new List<Topic>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
    }
}
