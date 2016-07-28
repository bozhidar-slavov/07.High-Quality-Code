namespace StudentsAndCourses
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private const int MaxStudentsCount = 30;
        private string name;
        private ICollection<Student> students;

        public Course(string name)
        {
            this.Name = name;
            this.students = new List<Student>();
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                Validator.ValidateNull(value, "Course name cannot be null!");

                this.name = value;
            }
        }

        public ICollection<Student> Students
        {
            get
            {
                return new List<Student>(this.students);
            }
        }

        public void AddStudent(Student student)
        {
            Validator.ValidateNull(student, "Student cannot be null!");

            if (this.students.Count + 1 > MaxStudentsCount)
            {
                throw new InvalidOperationException("Student list is full!");
            }

            if (this.students.Contains(student))
            {
                throw new InvalidOperationException("This student has already joined the class!");
            }

            this.students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            Validator.ValidateNull(student, "Student cannot be null!");

            if (!this.students.Contains(student))
            {
                throw new InvalidOperationException("The student does not attend this class!");
            }

            this.students.Remove(student);
        }
    }
}
