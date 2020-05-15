using Data.Entities;
using Models.Student;
using System;
using ModelGrup = Models.Student;

namespace class_book.Controllers.API
{

    public class StudentsController :
        BaseApiController<Student, ModelGrup.View, ModelGrup.ViewCreate, ModelGrup.ViewEdit>
    {
        
       /* public Student SievingCreateModel(ModelGrup.ViewCreate view)
        {
            Student student = new Student
            {
                Id = Guid.NewGuid(),
                Email = view.Email,
                Name = view.Name,
                Image = view.Image
            };
            return student;
        }
        public Student SievingEditModel(ModelGrup.ViewEdit view)
        {
            Student student = new Data.Repositories.Repository<Student>().GetById(view.Id);
            if (student == null)
            {
                throw new InvalidOperationException($"Student with id {view.Id} not found.");
            }
            student.Email = view.Email;
            student.Name = view.Name;
            student.Image = view.Image;

            return student;
        }*/
            
        public StudentsController()
            :base(
                 (view) => {
                    Student student = new Student
                    {
                        Id = Guid.NewGuid(),
                        Email = view.Email,
                        Name = view.Name,
                        Image = view.Image
                    };
                    return student;
                 },
                 (view) => {
                    Student student = new Data.Repositories.Repository<Student>().GetById(view.Id);
                    if (student == null)
                    {
                        throw new InvalidOperationException($"Student with id {view.Id} not found.");
                    }
                    student.Email = view.Email;
                    student.Name = view.Name;
                    student.Image = view.Image;

                    return student;
                })
        {

        }
    }
}