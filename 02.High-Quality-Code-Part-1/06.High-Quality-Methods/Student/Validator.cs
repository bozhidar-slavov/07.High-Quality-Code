namespace Student
{
    using System;

    internal static class Validator
    {
        internal static void ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("Name cannot be null or empty!");
            }

            if (name.Length < 3 || name.Length > 30)
            {
                throw new ArgumentException("Invalid name length!");
            }
        }
    }
}
