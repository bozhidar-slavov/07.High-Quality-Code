namespace Methods
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            Console.WriteLine(Methods.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(Methods.ConvertDigitToWord(5));

            Console.WriteLine(Methods.FindMaxNumber(5, -1, 3, 2, 14, 2, 3));

            Methods.PrintNumberWithTwoDigitsPrecision(1.3);
            Methods.PrintNumberAsPercentage(0.75);
            Methods.PrintNumberRightAlined(2.30);

            Console.WriteLine(Methods.CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Is the line horizontal? " + Methods.IsLineHorizontal(3, -1));
            Console.WriteLine("Is the line vertical? " + Methods.IsLineVertical(3, 2.5));
        }
    }
}
