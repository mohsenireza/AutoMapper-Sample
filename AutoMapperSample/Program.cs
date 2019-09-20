using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace AutoMapperSample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure and create an instance for the mapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentViewModel>());
            var mapper = config.CreateMapper();

            // Map from the Student class to the StudentViewModel class
            var student = new Student
            {
                Id = 1,
                FirstName = "Reza",
                LastName = "Mohseni",
                Age = 20,
                RegisteredDateTime = DateTime.Now,
                Course = new Course
                {
                    Id = 1,
                    Name = "Math",
                    AddedDateTime = DateTime.Now
                }
            };

            var studentViewModel = mapper.Map<Student, StudentViewModel>(student);

            //Console.WriteLine(studentViewModel.CourseName);
            //Console.ReadLine();

            // Map from the List<Student> to the List<StudentViewModel>
            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Reza",
                    LastName = "Mohseni",
                    Age = 20,
                    RegisteredDateTime = DateTime.Now,
                    Course = new Course
                    {
                        Id = 1,
                        Name = "History",
                        AddedDateTime = DateTime.Now
                    }
                },
                new Student
                {
                    Id = 1,
                    FirstName = "Reza",
                    LastName = "Mohseni",
                    Age = 20,
                    RegisteredDateTime = DateTime.Now,
                    Course = new Course
                    {
                        Id = 1,
                        Name = "History",
                        AddedDateTime = DateTime.Now
                    }
                }
            };

            var studentViewModels = mapper.Map<List<Student>, List<StudentViewModel>>(students);

            Console.WriteLine(studentViewModels[0].FirstName);
            Console.ReadLine();
        }
    }

    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime AddedDateTime { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime RegisteredDateTime { get; set; }
        public Course Course { get; set; }
    }

    public class StudentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string CourseName { get; set; }
    }
}
