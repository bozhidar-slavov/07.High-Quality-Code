namespace MethodPrintStatisticsInCSharp
{
    public class Startup
    {
        public static void Main()
        {
            double[] collection = new double[] { 1.5, 2.5, 3.5, 10.2, 23.4 };

            IPrinter printer = new StatisticsPrinter();
            printer.PrintStatistics(collection);
        }
    }
}
