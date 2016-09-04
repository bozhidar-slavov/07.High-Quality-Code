namespace Student
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Student peter = new Student("Peter", "Ivanov", new DateTime(1992, 3, 17), "From Sofia");
            Student stella = new Student("Stella", "Markova", new DateTime(1993, 11, 3), "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
