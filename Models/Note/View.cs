using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Models.Note
{
    public class View
    {
        public View(Data.Entities.Note note)
        {
            Id = note.Id;
            Grade = note.Grade;
            Discipline = new Models.Discipline.ViewBasic(note.Discipline);
            Teacher = new Models.Teacher.ViewBasic(note.Teacher);
        }
        public Guid Id { get; set; }
        public int Grade { get; set; }
        public Models.Discipline.ViewBasic Discipline { get; set; }
        public Models.Teacher.ViewBasic Teacher { get; set; }
    }
}
