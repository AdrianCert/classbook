using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Data.Entities;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.Database>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Context.Database context)
        {
            context.Admins.AddOrUpdate(new Admin {
                Id = Guid.Parse("0bf79443-6603-4c81-abf7-e51ba5498232"),
                Email = "admin@classbook.org",
                Name = "admin",
                PWS = "admin"
            });
        }
    }
}
