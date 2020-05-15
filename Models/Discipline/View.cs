using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Models.Discipline
{
    public class View
    {
        public View(Data.Entities.Note note)
        {
            Id = note.Id;
            Grade = note.Grade;
            Discipline = note.Discipline.Name;
            Teacher = new Models.Teacher.ViewBasic(note.Teacher);
        }
        public Guid Id { get; set; }
        public int Grade { get; set; }
        public string Discipline { get; set; }
        public Models.Teacher.ViewBasic Teacher { get; set; }
    }
}
