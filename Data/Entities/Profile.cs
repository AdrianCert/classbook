using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Profile
    {
        public Profile()
        {
            Years = new List<ProfileYear>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TotalYears { get; set; }
        public virtual ICollection<ProfileYear> Years { get; set; }
    }
}
