using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.Student
{
    public class ViewCreate
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        [Required(ErrorMessage = "Please provide a valid email address")]
        public string Email { get; set; }

        public byte[] Image { get; set; }
    }
}
