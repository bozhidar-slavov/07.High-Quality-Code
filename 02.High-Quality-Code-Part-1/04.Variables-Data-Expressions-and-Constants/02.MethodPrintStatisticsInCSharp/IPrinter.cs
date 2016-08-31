namespace MethodPrintStatisticsInCSharp
{
    public interface IPrinter
    {
        void PrintStatistics(double[] collection);

        void PrintNumber(string message, double number);
    }
}
