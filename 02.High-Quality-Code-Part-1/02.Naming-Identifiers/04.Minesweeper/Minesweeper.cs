namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private static void Main()
        {
            const int MaxScore = 35;
            string command = string.Empty;
            char[,] field = CreateGameField();
            char[,] mines = SetMines();
            int counter = 0;
            bool isMine = false;
            List<Player> highScores = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool inGame = true;
            bool maxResultAchieved = false;

            do
            {
                if (inGame)
                {
                    Console.WriteLine("Lets play minesweeper. Try your luck to find all the fields without mines" +
                    " Command 'top' shows the current standings, 'restart' starts a new game, 'exit' quits the game!");
                    GeneratePlayField(field);
                    inGame = false;
                }

                Console.Write("Enter row and column : ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out col) &&
                        row <= field.GetLength(0) && col <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        PrintHighScore(highScores);
                        break;

                    case "restart":
                        field = CreateGameField();
                        mines = SetMines();
                        GeneratePlayField(field);
                        isMine = false;
                        inGame = false;
                        break;

                    case "exit":
                        Console.WriteLine("Bye, bye!");
                        break;

                    case "turn":
                        if (mines[row, col] != '*')
                        {
                            if (mines[row, col] == '-')
                            {
                                MakeMove(field, mines, row, col);
                                counter++;
                            }

                            if (MaxScore == counter)
                            {
                                maxResultAchieved = true;
                            }
                            else
                            {
                                GeneratePlayField(field);
                            }
                        }
                        else
                        {
                            isMine = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (isMine)
                {
                    GeneratePlayField(mines);
                    Console.Write("\nBoom! Game over with {0} points. Enter your nickname:  ", counter);
                    string nickname = Console.ReadLine();
                    var playersPoints = new Player(nickname, counter);

                    if (highScores.Count < 5)
                    {
                        highScores.Add(playersPoints);
                    }
                    else
                    {
                        for (int i = 0; i < highScores.Count; i++)
                        {
                            if (highScores[i].Points < playersPoints.Points)
                            {
                                highScores.Insert(i, playersPoints);
                                highScores.RemoveAt(highScores.Count - 1);
                                break;
                            }
                        }
                    }

                    highScores.Sort((Player firstResult, Player secondResult) => secondResult.Name.CompareTo(firstResult.Name));
                    highScores.Sort((Player firstResult, Player secondResult) => secondResult.Points.CompareTo(firstResult.Points));
                    PrintHighScore(highScores);

                    field = CreateGameField();
                    mines = SetMines();
                    counter = 0;
                    isMine = false;
                    inGame = true;
                }

                if (maxResultAchieved)
                {
                    Console.WriteLine("\nCongratulations! You opened 35 cells! :)");
                    GeneratePlayField(mines);
                    Console.WriteLine("Enter your nickname: ");
                    string name = Console.ReadLine();
                    var playerPoints = new Player(name, counter);
                    highScores.Add(playerPoints);
                    PrintHighScore(highScores);
                    field = CreateGameField();
                    mines = SetMines();
                    counter = 0;
                    maxResultAchieved = false;
                    inGame = true;
                }
            }
            while (command != "exit");
            {
                Console.WriteLine("Made in Bulgaria");
                Console.Read();
            }
        }

        private static void PrintHighScore(List<Player> playerPoints)
        {
            Console.WriteLine("\nPoints:");
            if (playerPoints.Count > 0)
            {
                for (int i = 0; i < playerPoints.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} boxes", i + 1, playerPoints[i].Name, playerPoints[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranklist!\n");
            }
        }

        private static void MakeMove(char[,] field, char[,] mines, int row, int col)
        {
            char minesCount = CountAdjacentMines(mines, row, col);
            mines[row, col] = minesCount;
            field[row, col] = minesCount;
        }

        private static void GeneratePlayField(char[,] board)
        {
            int rows = board.GetLength(0);
            int columns = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] CreateGameField()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] SetMines()
        {
            int rows = 5;
            int cols = 10;
            char[,] gameField = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> randomIntegers = new List<int>();
            while (randomIntegers.Count < 15)
            {
                Random random = new Random();
                int asfd = random.Next(50);
                if (!randomIntegers.Contains(asfd))
                {
                    randomIntegers.Add(asfd);
                }
            }

            foreach (int random in randomIntegers)
            {
                int col = (random / cols);
                int row = (random % cols);
                if (row == 0 && random != 0)
                {
                    col--;
                    row = cols;
                }
                else
                {
                    row++;
                }

                gameField[col, row - 1] = '*';
            }

            return gameField;
        }

        private static void RevealMinefield(char[,] mineField)
        {
            int row = mineField.GetLength(0);
            int col = mineField.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (mineField[i, j] != '*')
                    {
                        char minesCount = CountAdjacentMines(mineField, i, j);
                        mineField[i, j] = minesCount;
                    }
                }
            }
        }

        private static char CountAdjacentMines(char[,] field, int row, int col)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cols = field.GetLength(1);

            if (row - 1 >= 0)
            {
                if (field[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (field[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (field[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (field[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (field[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (field[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (field[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (field[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}
