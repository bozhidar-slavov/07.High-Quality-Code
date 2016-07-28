namespace StudentsAndCourses.Tests
{
    using System;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsAndCourses;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void SchoolShouldNotThrowException()
        {
            var school = new School("Ivan Vazov");
        }

        [TestMethod]
        public void SchoolShouldReturnNameCorrectly()
        {
            var school = new School("Ivan Vazov");
            Assert.AreEqual("Ivan Vazov", school.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNameIsNull()
        {
            var school = new School(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNameIsEmpty()
        {
            var school = new School(string.Empty);
        }

        [TestMethod]
        public void SchoolShouldAddStudentCorrectly()
        {
            var school = new School("Ivan Vazov");
            var student = new Student("Dimo Padalski", 10000);
            school.AddStudent(student);
            Assert.AreSame(student, school.Students.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNullStudentAdded()
        {
            var school = new School("Ivan Vazov");
            Student student = null;
            school.AddStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenAddingExistingStudent()
        {
            var school = new School("Ivan Vazov");
            var student = new Student("Kiril Valchev", 10000);
            school.AddStudent(student);
            school.AddStudent(student);
        }

        [TestMethod]
        public void SchoolShouldAddCourseCorrectly()
        {
            var school = new School("Telerik Academy");
            var course = new Course("Unit testing");
            school.AddCourse(course);
            Assert.AreSame(course, school.Courses.First());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenNullCourseAdded()
        {
            var school = new School("Ivan Vazov");
            Course course = null;
            school.AddCourse(course);
        }

        [TestMethod]
        public void SchoolShouldRemoveStudentCorrectly()
        {
            var school = new School("Ivan Vazov");
            var student = new Student("Toncho Tokmakchiev", 10000);
            school.AddStudent(student);
            school.RemoveStudent(student);
            Assert.IsTrue(school.Students.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenRemovingNullStudent()
        {
            var school = new School("Ivan Vazov");
            Student student = null;
            school.RemoveStudent(student);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenRemovingNotExistingStudent()
        {
            var school = new School("Ivan Vazov");
            var student = new Student("Dimcho Delev", 10000);
            school.RemoveStudent(student);
        }

        [TestMethod]
        public void SchoolShouldRemoveCourseCorrectly()
        {
            var school = new School("Telerik Academy");
            var course = new Course("OOP");
            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.IsTrue(school.Courses.Count == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolShouldThrowExceptionWhenRemovingNullCourse()
        {
            var school = new School("Ivan Vazov");
            Course course = null;
            school.RemoveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SchoolShouldThrowExceptionWhenRemovingNotExistingCourse()
        {
            var school = new School("Telerik Academy");
            var course = new Course("DSA");
            school.RemoveCourse(course);
        }
    }
}
