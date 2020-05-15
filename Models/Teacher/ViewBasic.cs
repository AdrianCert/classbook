using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Teacher
{
    public class ViewBasic
    {
        public ViewBasic(Data.Entities.Teacher teacher)
        {
            Id = teacher.Id;
            Name = teacher.Name;
            Email = teacher.Email;
            Image = teacher.Image;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public byte[] Image { get; set; }
    }
}
