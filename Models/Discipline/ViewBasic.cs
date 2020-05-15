using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Models.Discipline
{
    public class ViewBasic
    {
        public ViewBasic(Data.Entities.Discipline discipline)
        {
            Id = discipline.Id;
            Name = discipline.Name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
