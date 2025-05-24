using BEPracticeUnitTesting.Models;

namespace BEPracticeUnitTesting.service
{
    public class StudentService : IStudentService
    {
        // In-memory list to simulate a database
        private List<Student> _students;
        public StudentService()
        {
            _students = new List<Student>
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
            Student? student = _students.FirstOrDefault(s => s.CI == id);
            if (student == null)
            {
                return null;
            }
            return student;
        }


        public Student? CreateStudent(Student student)
        {
            if (student == null)
            {
                return null;
            }
            if (_students.Any(s => s.CI == student.CI))
            {
                return null;
            }
            _students.Add(student);
            return student;
        }

        public Student? UpdateStudent(int id, Student updatedStudent)
        {
            var student = _students.FirstOrDefault(s => s.CI == id);
            if (student == null)
            {
                return null;
            }

            student.Name = updatedStudent.Name;
            student.Note = updatedStudent.Note;

            return student;
        }

        public Student? DeleteStudent(int id)
        {
            var student = _students.FirstOrDefault(s => s.CI == id);
            if (student == null)
            {
                return null;
            }

            _students.Remove(student);
            return student;
        }
        
        public bool HasApproved(int id)
        {
            var student = _students.FirstOrDefault(s => s.CI == id);
            if (student == null)
            {
                return false;
            }
            return student.Note >= 51;
        }
    }

}