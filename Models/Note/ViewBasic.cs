using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Models.Note
{
    public class ViewBasic
    {
        public ViewBasic(Data.Entities.Note note)
        {
            Id = note.Id;
            Grade = note.Grade;
            Discipline = note.Discipline.Topic.Name;
        }
        public Guid Id { get; set; }
        public int Grade { get; set; }
        public string Discipline { get; set; }
        
    }
}
