using BEPracticeUnitTesting.Controller;
using BEPracticeUnitTesting.service;
using BEPracticeUnitTesting.Models;
using BEPracticeUnitTesting.Tests.stubs;
using Moq;
using System.Collections.Generic;

namespace BEPracticeUnitTesting.Tests
{
    public class StudentControllerTests
    {
        [Fact]
        public void Student_withValidId_isApproved()
        {
            // Arrange
            int studentId = 1;
            var studentService = new Mock<IStudentService>();
            studentService.Setup(s => s.HasApproved(studentId)).Returns(true);
            StudentController studentController = new StudentController(studentService.Object);

            // Act
            var result = studentController.HasApproved(studentId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void Student_withValidId_isNotApproved()
        {
            // Arrange
            int studentId = 2;
            var studentService = new Mock<IStudentService>();
            studentService.Setup(s => s.HasApproved(studentId)).Returns(false);
            StudentController studentController = new StudentController(studentService.Object);

            // Act
            var result = studentController.HasApproved(studentId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetAll_ExistingStudents_WithValidNames()
        {
            // Arrange
            StudentController studentController = new StudentController(new StudentServiceStub());
            List<Student> expected = new List<Student>
            {
                new Student { CI = 1, Name = "John Doe", Note = 85 },
                new Student { CI = 2, Name = "Jane Smith", Note = 45 },
                new Student { CI = 3, Name = "Sam Brown", Note = 70 }
            };

            // Act
            var result = studentController.GetStudents();


            // Assert
            Assert.Equal(expected[0].Name, result[0].Name);
            Assert.Equal(expected[1].Name, result[1].Name);
            Assert.Equal(expected[2].Name, result[2].Name);
        }

        [Fact]
        public void GetById_ExistingId_ReturnsStudent()
        {
            // Arrange
            StudentController studentController = new StudentController(new StudentServiceStub());
            int studentCi = 1;


            // Act
            var result = studentController.GetStudent(studentCi);


            // Assert
            Assert.NotNull(result);
            Assert.Equal(studentCi, result.CI);
        }
    }
}


