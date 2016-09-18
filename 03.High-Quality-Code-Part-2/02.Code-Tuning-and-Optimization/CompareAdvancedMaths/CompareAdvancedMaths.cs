namespace CompareAdvancedMaths
{
    using System;
    using System.Diagnostics;

    public class CompareAdvancedMaths
    {
        public static void Main()
        {
            Console.WriteLine("Results for Float");
            float resultFloat = 0.0F;
            ExecuteMathTests(resultFloat);
            Console.WriteLine();

            Console.WriteLine("Results for Double");
            double resultDouble = 0.0;
            ExecuteMathTests(resultDouble);
            Console.WriteLine();

            Console.WriteLine("Results for Decimal");
            decimal resultDecimal = 0.0M;
            ExecuteMathTests(resultDecimal);
        }

        private static void DisplayExecutionTime(Action action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.Elapsed);
        }

        private static void ExecuteMathTests(dynamic a)
        {
            const int LoopCount = 10000000;
            a = a + 1;

            Console.Write("Square Root: ");
            DisplayExecutionTime(() =>
            {
                for (var i = 0; i < LoopCount; i++)
                {
                    Math.Sqrt((double)a);
                }
            });

            Console.Write("Natural algorithm: ");
            DisplayExecutionTime(() =>
            {
                for (var i = 0; i < LoopCount; i++)
                {
                    Math.Log((double)a);
                }
            });

            Console.Write("Sinus: ");
            DisplayExecutionTime(() =>
            {
                for (var i = 0; i < LoopCount; i++)
                {
                    Math.Sin((double)a);
                }
            });
        }
    }
}
