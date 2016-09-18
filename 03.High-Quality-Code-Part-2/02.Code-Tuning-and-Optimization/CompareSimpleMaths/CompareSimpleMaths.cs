namespace CompareSimpleMaths
{
    using System;
    using System.Diagnostics;

    public class CompareSimpleMaths
    {
        public static void Main()
        {
            Console.WriteLine("Results for Integer");
            int resultInt = 0;
            ExecuteMathTests(resultInt);
            Console.WriteLine();

            Console.WriteLine("Results for Long");
            long resultLong = 0;
            ExecuteMathTests(resultLong);
            Console.WriteLine();

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

            Console.Write("Add: ");
            DisplayExecutionTime(() =>
            {
                a = a + 0;
                for (var i = 0; i < LoopCount; i++)
                {
                    a = a + 1;
                }
            });

            Console.Write("Subtract: ");
            DisplayExecutionTime(() =>
            {
                a = a + 10000000;
                for (var i = 0; i < LoopCount; i++)
                {
                    a = a - 1;
                }
            });

            Console.Write("Increment: ");
            DisplayExecutionTime(() =>
            {
                a = a + 0;
                for (var i = 0; i < LoopCount; i++)
                {
                    a++;
                }
            });

            Console.Write("Multiply: ");
            DisplayExecutionTime(() =>
            {
                a = a + 1;
                for (var i = 0; i < LoopCount; i++)
                {
                    a = a * 1;
                }
            });

            Console.Write("Divide: ");
            DisplayExecutionTime(() =>
            {
                a = a + 1;
                for (var i = 0; i < LoopCount; i++)
                {
                    a = a / 1;
                }
            });
        }
    }
}
