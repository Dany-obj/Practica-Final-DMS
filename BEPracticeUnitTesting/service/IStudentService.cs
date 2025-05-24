using System.Collections.Generic;
using BEPracticeUnitTesting.Models;

namespace BEPracticeUnitTesting.service
{
    public interface IStudentService
    {
        List<Student> GetStudents();
        Student? GetStudent(int id);
        Student? CreateStudent(Student student);
        Student? UpdateStudent(int id, Student student);
        Student? DeleteStudent(int id);
        bool HasApproved(int id);
    }
}