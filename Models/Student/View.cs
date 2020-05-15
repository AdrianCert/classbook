using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Models.Student
{
    public class View
    {
        public View()
        {
            Notes = new List<Models.Note.ViewBasic>();
        }
        public View(Data.Entities.Student student)
        {
            Id = student.Id;
            Name = student.Name;
            Email = student.Email;
            Image = student.Image;
            Notes = student.Notes.Select(a => new Models.Note.ViewBasic(a)).ToList();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
        public List<Models.Note.ViewBasic> Notes { get; set; }
    }
}
