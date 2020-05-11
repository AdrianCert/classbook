using System;
using System.Data.Entity;
using System.Linq;
using Data.Entities;

namespace Data.Context
{
    public class AccountContext : DbContext
    {
        public AccountContext()
            : base("Server=.;Database=ClassBookSecurity;Trusted_Connection=True;")
        {
        }
        public virtual DbSet<UserAccount> Accounts { get; set; }
    }
}
