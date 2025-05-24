using BEPracticeUnitTesting.Models;
using BEPracticeUnitTesting.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BEPracticeUnitTesting.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        // GET: api/Student
        [HttpGet]
        public List<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }

        // GET: api/Student/{id}
        [HttpGet("{id}")]
        public Student? GetStudent(int id)
        {
            return _studentService.GetStudent(id);
        }

        // POST: api/Student
        [HttpPost]
        public Student? CreateStudent([FromBody] Student student)
        {
            return _studentService.CreateStudent(student);
        }

        // PUT: api/Student/{id}
        [HttpPut("{id}")]
        public Student? UpdateStudent(int id, [FromBody] Student updatedStudent)
        {
            return _studentService.UpdateStudent(id, updatedStudent);
        }

        // DELETE: api/Student/{id}
        [HttpDelete("{id}")]
        public Student? DeleteStudent(int id)
        {
            return _studentService.DeleteStudent(id);
        }

        // GET: api/has-approved/{id}
        [HttpGet("/has-approved/{id}")]
        public bool HasApproved(int id)
        {
            return _studentService.HasApproved(id);
        }
    }

}