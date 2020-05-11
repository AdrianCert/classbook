using System;
using System.Collections.Generic;

namespace Data.Entities
{
    public class UserAccount
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string GivenName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Identifier { get; set; }
        public bool IsActive { get; set; }
    }
}
