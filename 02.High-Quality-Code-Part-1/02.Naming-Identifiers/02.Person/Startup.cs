namespace Person
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var firstPerson = Person.CreatePerson(20);
            var secondPerson = Person.CreatePerson(21);

            Console.WriteLine(firstPerson.Name);
            Console.WriteLine(secondPerson.Name);
        }
    }
}
