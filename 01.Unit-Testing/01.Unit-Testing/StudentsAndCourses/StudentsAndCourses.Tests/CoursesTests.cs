namespace StudentsAndCourses.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoursesTests
    {
        [TestMethod]
        public void CourseShouldNotThrowException()
        {
            var course = new Course("Unit testing");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWhenNameIsNull()
        {
            var course = new Course(null);
        }

        [TestMethod]
        public void CourseShoulReturnNameCorrectly()
        {
            var course = new Course("Unit testing");
            Assert.AreEqual("Unit testing", course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWithEmptyName()
        {
            var course = new Course(string.Empty);
        }


        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenMoreThanPossibleStudentsAdded()
        {
            var course = new Course("Unit testing");

            for (int i = 0; i < 35; i++)
            {
                course.AddStudent(new Student(i.ToString(), 10000 + 1));
            }
        }

        [TestMethod]
        public void CourseShouldAddStudentCorrectly()
        {
            var course = new Course("Unit testing");
            var student = new Student("Kiro Skalata", 10000);
            course.AddStudent(student);

            Assert.AreSame(student, course.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWhenNullStudentAdded()
        {
            var course = new Course("Unit testing");
            Student student = null;
            course.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenExistingStudentAdded()
        {
            var course = new Course("Unit testing");
            Student student = new Student("Kiro Skalata", 10000);
            course.AddStudent(student);
            course.AddStudent(student);
        }

        [TestMethod]
        public void CourseShouldRemoveStudentCorrectly()
        {
            var course = new Course("Unit testing");
            var student = new Student("Kiro Skalata", 10000);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(0, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CourseShouldThrowExceptionWhenRemovingUnexistingStudent()
        {
            var course = new Course("Unit testing");
            Student student = new Student("Joro Paveto", 10000);
            course.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseShouldThrowExceptionWhenRemovingNullStudent()
        {
            var course = new Course("Unit testing");
            Student student = null;
            course.RemoveStudent(student);
        }
    }
}
