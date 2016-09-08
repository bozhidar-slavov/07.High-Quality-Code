namespace RefactorIfStatements
{
    using System;

    public class RefactorIfStatements
    {
        public static void Main()
        {
            // First refactoring

            Potato potato = new Potato();

            if (potato == null)
            {
                throw new ArgumentNullException("Potato cannot be null!");
            }

            bool isPeeled = potato.IsPeeled();
            bool isRotten = potato.IsRotten();

            if (isPeeled && !isRotten)
            {
                potato.Cook();
            }

            // Second refactoring

            const int MinX = 5;
            const int MaxX = 15;
            const int MinY = 5;
            const int MaxY = 15;

            int x = 7;
            int y = 8;

            bool shouldVisitCell = true;

            if (shouldVisitCell && IsInRange(x, MinX, MaxX) && IsInRange(y, MinY, MaxY))
            {
                VisitCell();
            }
        }

        public static void VisitCell()
        {
            Console.WriteLine("Visited");
        }

        public static bool IsInRange(int value, int min, int max)
        {
            bool isInRange = value >= min && value <= max;

            return isInRange;
        }
    }
}
