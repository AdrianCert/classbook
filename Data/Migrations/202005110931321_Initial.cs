namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Image = c.Binary(),
                        PWS = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Teacher_Id = c.Guid(),
                        Teacher_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id1)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Teacher_Id1);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Image = c.Binary(),
                        PWS = c.String(),
                        Parent_Id = c.Guid(),
                        Class_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parents", t => t.Parent_Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .Index(t => t.Parent_Id)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Grade = c.Int(nullable: false),
                        Discipline_Id = c.Guid(),
                        Student_Id = c.Guid(),
                        Teacher_Id = c.Guid(),
                        Situation_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Situations", t => t.Situation_Id)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Situation_Id);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Teacher_Id = c.Guid(),
                        Topic_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Topics", t => t.Topic_Id)
                .Index(t => t.Teacher_Id)
                .Index(t => t.Topic_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Image = c.Binary(),
                        PWS = c.String(),
                        Class_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Classes", t => t.Class_Id)
                .Index(t => t.Class_Id);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        URI = c.String(),
                        ProfileYear_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProfileYears", t => t.ProfileYear_Id)
                .Index(t => t.ProfileYear_Id);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        Image = c.Binary(),
                        PWS = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        TotalYears = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileYears",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Profile_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Profiles", t => t.Profile_Id)
                .Index(t => t.Profile_Id);
            
            CreateTable(
                "dbo.Situations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Formula = c.String(),
                        MinimumQualificationStandard = c.String(),
                        Grade = c.Int(nullable: false),
                        FinalGrade = c.Boolean(nullable: false),
                        Student_Id = c.Guid(),
                        Teacher_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.TopicTeachers",
                c => new
                    {
                        Topic_Id = c.Guid(nullable: false),
                        Teacher_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.Topic_Id, t.Teacher_Id })
                .ForeignKey("dbo.Topics", t => t.Topic_Id, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .Index(t => t.Topic_Id)
                .Index(t => t.Teacher_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Situations", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Situations", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Notes", "Situation_Id", "dbo.Situations");
            DropForeignKey("dbo.ProfileYears", "Profile_Id", "dbo.Profiles");
            DropForeignKey("dbo.Topics", "ProfileYear_Id", "dbo.ProfileYears");
            DropForeignKey("dbo.Teachers", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Students", "Class_Id", "dbo.Classes");
            DropForeignKey("dbo.Students", "Parent_Id", "dbo.Parents");
            DropForeignKey("dbo.Notes", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Notes", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Disciplines", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Disciplines", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.TopicTeachers", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.TopicTeachers", "Topic_Id", "dbo.Topics");
            DropForeignKey("dbo.Classes", "Teacher_Id1", "dbo.Teachers");
            DropForeignKey("dbo.Classes", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Notes", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.TopicTeachers", new[] { "Teacher_Id" });
            DropIndex("dbo.TopicTeachers", new[] { "Topic_Id" });
            DropIndex("dbo.Situations", new[] { "Teacher_Id" });
            DropIndex("dbo.Situations", new[] { "Student_Id" });
            DropIndex("dbo.ProfileYears", new[] { "Profile_Id" });
            DropIndex("dbo.Topics", new[] { "ProfileYear_Id" });
            DropIndex("dbo.Teachers", new[] { "Class_Id" });
            DropIndex("dbo.Disciplines", new[] { "Topic_Id" });
            DropIndex("dbo.Disciplines", new[] { "Teacher_Id" });
            DropIndex("dbo.Notes", new[] { "Situation_Id" });
            DropIndex("dbo.Notes", new[] { "Teacher_Id" });
            DropIndex("dbo.Notes", new[] { "Student_Id" });
            DropIndex("dbo.Notes", new[] { "Discipline_Id" });
            DropIndex("dbo.Students", new[] { "Class_Id" });
            DropIndex("dbo.Students", new[] { "Parent_Id" });
            DropIndex("dbo.Classes", new[] { "Teacher_Id1" });
            DropIndex("dbo.Classes", new[] { "Teacher_Id" });
            DropTable("dbo.TopicTeachers");
            DropTable("dbo.Situations");
            DropTable("dbo.ProfileYears");
            DropTable("dbo.Profiles");
            DropTable("dbo.Parents");
            DropTable("dbo.Topics");
            DropTable("dbo.Teachers");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Notes");
            DropTable("dbo.Students");
            DropTable("dbo.Classes");
            DropTable("dbo.Admins");
        }
    }
}
