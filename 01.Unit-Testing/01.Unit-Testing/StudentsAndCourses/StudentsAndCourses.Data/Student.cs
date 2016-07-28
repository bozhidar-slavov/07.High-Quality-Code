namespace StudentsAndCourses
{
    using System;

    public class Student
    {
        private const uint MinValidIdValue = 10000;
        private const uint MaxValidIdValue = 99999;

        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                Validator.ValidateNull(value, "Student name cannot be null!");

                this.name = value;
            }
        }

        public int ID
        {
            get { return this.id; }

            private set
            {
                if (value < MinValidIdValue || value > MaxValidIdValue)
                {
                    throw new ArgumentException(string.Format("Student ID must be in range [{0} - {1}]", MinValidIdValue, MaxValidIdValue));
                }

                this.id = value;
            }
        }

        public void AttendCourse(Course course)
        {
            Validator.ValidateNull(course, "Course cannot be null!");

            course.AddStudent(this);
        }

        public void LeaveCourse(Course course)
        {
            Validator.ValidateNull(course, "Course cannot be null!");

            course.RemoveStudent(this); 
        }
    }
}
