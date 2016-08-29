namespace MethodPrintStatisticsInCSharp
{
    using System;

    public static class StatisticsPrinter
    {
        public static void PrintStatistics(double[] collection, int elementsCount)
        {
            double maxValue = double.MinValue;
            double minValue = double.MaxValue;
            double sum = 0;

            for (int i = 0; i < elementsCount; i++)
            {
                if (collection[i] > maxValue)
                {
                    maxValue = collection[i];
                }

                if (collection[i] < minValue)
                {
                    minValue = collection[i];
                }

                sum += collection[i];
            }

            PrintNumber("Max value: ", maxValue);
            PrintNumber("Min value: ", minValue);

            double averageSum = sum / elementsCount;
            PrintNumber("Average: ", averageSum);
        }

        public static void PrintNumber(string message, double number)
        {
            Console.WriteLine($"{message} {number}");
        }
    }
}
