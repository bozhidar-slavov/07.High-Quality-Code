namespace StudentsAndCourses.Tests
{
    using System;
    
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void StudentSchouldNotThrowException()
        {
            var student = new Student("Prokopi Prokopiev", 10000);
        }

        [TestMethod]
        public void StudentSchouldReturnExpectedName()
        {
            var student = new Student("Kiro Skalata", 10000);
            Assert.AreEqual("Kiro Skalata", student.Name);
        }

        [TestMethod]
        public void StudentSchouldReturnExpectedId()
        {
            var student = new Student("Kiro Skalata", 20000);
            Assert.AreEqual(20000, student.ID);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowNullReferenceExceptionForNullName()
        {
            var student = new Student(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowNullReferenceExceptionForEmptyName()
        {
            var student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowArgumentExceptionForInvalidId_Low()
        {
            var student = new Student("Kiro Skalata", 1000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentShouldThrowArgumentExceptionForInvalidId_High()
        {
            var student = new Student("Kiro Skalata", 10000000);
        }

        [TestMethod]
        public void StudentShouldNotThrowExceptionWhenAttendingCourse()
        {
            var student = new Student("Kiro Skalata", 10000);
            var course = new Course("Unit testing");
            student.AttendCourse(course);
        }

        [TestMethod]
        public void StudentShouldNotThrowExceptionWhenLeavesCourse()
        {
            var student = new Student("Kiro Skalata", 10000);
            var course = new Course("Unit testig");
            student.AttendCourse(course);
            student.LeaveCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowExceptionWhenAttendingNullCourse()
        {
            var student = new Student("Kiro Skalata", 10000);
            Course course = null;
            student.AttendCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentShouldThrowExceptionWhenLeavingNullCourse()
        {
            var student = new Student("Kiro Skalata", 10000);
            Course course = null;
            student.LeaveCourse(course);
        }
    }
}
