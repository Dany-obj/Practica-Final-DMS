using BEPracticeUnitTesting.Controller;
using BEPracticeUnitTesting.service;
using BEPracticeUnitTesting.Models;
using BEPracticeUnitTesting.Tests.stubs;
using Moq;
using System.Collections.Generic;

namespace BEPracticeUnitTesting.Tests.stubs
{


    public class StudentServiceStub : IStudentService
    {
        private List<Student> _students;

        public StudentServiceStub()
        {
            _students = new List<Student>()
            {
                new Student { CI = 1, Name = "John Doe", Note = 85 },
                new Student { CI = 2, Name = "Jane Smith", Note = 45 },
                new Student { CI = 3, Name = "Sam Brown", Note = 70 }
            };
        }

        public List<Student> GetStudents()
        {
            return _students;
        }

        public Student? GetStudent(int id)
        {
            return _students.FirstOrDefault(s => s.CI == id);
        }

        public Student? CreateStudent(Student student)
        {
            student.CI = _students.Max(s => s.CI) + 1;
            return student;
        }

        public Student? UpdateStudent(int id, Student updatedStudent)
        {
            return updatedStudent;
        }

        public Student? DeleteStudent(int id)
        {
            return _students[0];
        }

        public bool HasApproved(int id)
        {
            var student = GetStudent(id);
            return student != null && student.Note >= 6.0;
        }
    }
}
