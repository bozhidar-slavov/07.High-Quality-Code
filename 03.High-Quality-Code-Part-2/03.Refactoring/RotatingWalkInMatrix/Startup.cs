namespace RotatingWalkInMatrix
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            var matrixGenerator = new MatrixGenerator(5);
            Console.WriteLine(matrixGenerator);
        }
    }
}
