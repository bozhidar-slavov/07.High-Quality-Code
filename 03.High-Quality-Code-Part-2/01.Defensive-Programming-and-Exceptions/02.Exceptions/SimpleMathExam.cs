using System;

public class SimpleMathExam : Exam
{
    private const int MinProblemsSolved = 0;
    private const int MaxProblemsSolved = 2;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MinProblemsSolved || value > MaxProblemsSolved)
            {
                throw new ArgumentOutOfRangeException("Solved problems must be in range[0, 2]");
            }

            this.problemsSolved = value;
        }
    }

    public override ExamResult Check()
    {
        switch (this.ProblemsSolved)
        {
            case 0:
                return new ExamResult(2, 2, 6, "Bad result: nothing done.");
            case 1:
                return new ExamResult(4, 2, 6, "Average result: Half done.");
            case 2:
                return new ExamResult(6, 2, 6, "Excellent result: Everything done.");
            default:
                throw new ArgumentOutOfRangeException("Problems solved must be in range[0, 2]");
        }
    }
}
