namespace MethodPrintStatisticsInCSharp
{
    using System;

    public class StatisticsPrinter : IPrinter
    {
        public void PrintStatistics(double[] collection)
        {
            double maxValue = double.MinValue;
            double minValue = double.MaxValue;
            double sum = 0;

            int collectionLength = collection.Length;
            for (int i = 0; i < collectionLength; i++)
            {
                maxValue = collection[i] > maxValue ? collection[i] : maxValue;
                minValue = collection[i] < minValue ? collection[i] : minValue;
                sum += collection[i];
            }

            PrintNumber("Max value: ", maxValue);
            PrintNumber("Min value: ", minValue);

            double averageSum = sum / collectionLength;
            PrintNumber("Average: ", averageSum);
        }

        public void PrintNumber(string message, double number)
        {
            Console.WriteLine($"{message} {number}");
        }
    }
}
