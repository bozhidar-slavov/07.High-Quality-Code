namespace Methods
{
    using System;

    public class Methods
    {
        private const double AcceptableDifference = 0.000001;

        internal static double CalculateTriangleArea(double a, double b, double c)
        {
            bool isNegative = a <= 0 || b <= 0 || c <= 0;
            bool isInvalidTriangle = a >= b + c || b >= a + c || c >= a + b;

            if (isNegative)
            {
                throw new ArgumentOutOfRangeException("Sides must be positive numbers!");
            }

            if (isInvalidTriangle)
            {
                throw new ArgumentOutOfRangeException("These sides cannot form a triangle!");
            }

            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            return area;
        }

        internal static string ConvertDigitToWord(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentException("Must enter digits from 0 to 9!");
            }
        }

        internal static int FindMaxNumber(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentNullException("There are no input elements!");
            }

            int maxElement = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxElement)
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }

        internal static void PrintNumberWithTwoDigitsPrecision(double number)
        {
            Console.WriteLine("{0:F2}", number);
        }

        internal static void PrintNumberAsPercentage(double number)
        {
            Console.WriteLine("{0:P0}", number);
        }

        internal static void PrintNumberRightAlined(double number)
        {
            Console.WriteLine("{0,8}", number);
        }


        internal static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));
            return distance;
        }

        internal static bool IsLineHorizontal(double x1, double x2)
        {
            return Math.Abs(x1 - x2) < AcceptableDifference;
        }

        internal static bool IsLineVertical(double y1, double y2)
        {
            return Math.Abs(y1 - y2) < AcceptableDifference;
        }
    }
}
