using System;
using System.Data.Entity;
using System.Linq;
using Data.Entities;

namespace Data.Context
{

    public class Database : DbContext
    {
        public Database()
            : base("Server=.;Database=ClassBook;Trusted_Connection=True;")
        {
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Discipline> Disciplines  { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Parent> Parents { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<ProfileYear> ProfileYears { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Situation> Situations { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

    }
}