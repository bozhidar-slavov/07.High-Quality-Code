namespace Student
{
    using System;

    internal class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName, DateTime dateOfBirth, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.ValidateName(value);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                Validator.ValidateName(value);

                this.lastName = value;
            }
        }

        public string OtherInfo { get; set; }

        public DateTime DateOfBirth { get; set; }

        public bool IsOlderThan(Student otherStudent)
        {
            DateTime firstDate = this.DateOfBirth;
            DateTime secondDate = otherStudent.DateOfBirth;

            return firstDate < secondDate;
        }
    }
}
