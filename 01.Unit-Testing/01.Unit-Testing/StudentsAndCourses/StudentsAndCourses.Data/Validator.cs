namespace StudentsAndCourses
{
    using System;

    public static class Validator
    {
        public static void ValidateNull(object value, string message)
        {
            if (value == null)
            {
                throw new ArgumentNullException(message);
            }

            if (string.IsNullOrEmpty(value.ToString()))
            {
                throw new ArgumentNullException(message);
            }
        }
    }
}