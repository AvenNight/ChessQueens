using System;
using Extensions;

namespace ChessQueens
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("\nНайти все мирные расстановки ферзей на шахматной доске N на N.");
            int n = Read.ReadIntNumber("Введите размер стороны доски N:", 0);

            int maxQueens = 0;
            int boardNum = 0;
            bool[,] maxQueensBoard = new bool[n, n];
            bool[,] queens = new bool[n, n];
            bool[,] safePlaces = new bool[n, n];
            safePlaces.Reset(true);

            for (int y = 0; y < n; y++)
                for (int x = 0; x < n; x++)
                {
                    queens.Reset();
                    safePlaces.Reset(true);
                    CheckPlaces(queens, safePlaces, x, y);
                    int curQueens = QueenCount(queens);
                    if (maxQueens < curQueens)
                    {
                        maxQueens = curQueens;
                        boardNum = x + 1 + y * n;
                        Array.Copy(queens, maxQueensBoard, n*n);
                    }
                    DrawBoard(queens, safePlaces, x + 1 + y * n);
                }

            Console.WriteLine($"\nМаксимальное кол-во ферзей на доске: {maxQueens}");
            DrawBoard(maxQueensBoard, safePlaces, boardNum);

            Main();
        }

        static void CheckPlaces(bool[,] queens, bool[,] safePlaces, int x = 0, int y = 0)
        {
            (int x, int y) boardSize = (queens.GetLength(0), queens.GetLength(1));

            if (x >= boardSize.x)
            {
                CheckPlaces(queens, safePlaces, 0, y + 1);
                return;
            }
            if (y >= boardSize.y)
                return;

            if (safePlaces[x, y])
            {
                SetQueenTo(queens, safePlaces, x, y);
                x = 0; y = 0;
            }

            CheckPlaces(queens, safePlaces, x + 1, y);
        }

        static void SetQueenTo(bool[,] queens, bool[,] safePlaces, int x = 0, int y = 0)
        {
            queens[x, y] = true;
            SetQueenTo(safePlaces, 0, y, 0);
            SetQueenTo(safePlaces, x, 0, 1);
            for (int i = 2; i <= 5; i++)
                SetQueenTo(safePlaces, x, y, i);
        }

        static void SetQueenTo(bool[,] safePlaces, int x = 0, int y = 0, int stage = 0)
        {
            if (x < 0 || x >= safePlaces.GetLength(0) ||
                y < 0 || y >= safePlaces.GetLength(1))
                return;

            safePlaces[x, y] = false;

            switch (stage)
            {
                case 0:
                    SetQueenTo(safePlaces, x + 1, y, stage);
                    break;
                case 1:
                    SetQueenTo(safePlaces, x, y + 1, stage);
                    break;
                case 2:
                    SetQueenTo(safePlaces, x + 1, y + 1, stage);
                    break;
                case 3:
                    SetQueenTo(safePlaces, x - 1, y - 1, stage);
                    break;
                case 4:
                    SetQueenTo(safePlaces, x + 1, y - 1, stage);
                    break;
                case 5:
                    SetQueenTo(safePlaces, x - 1, y + 1, stage);
                    break;
                default:
                    SetQueenTo(safePlaces, x + 1, y, 0);
                    break;
            }
        }

        static int QueenCount(bool[,] queens)
        {
            (int x, int y) boardSize = (queens.GetLength(0), queens.GetLength(1));
            int count = 0;
            for (int y = 0; y < boardSize.y; y++)
                for (int x = 0; x < boardSize.x; x++)
                    if (queens[x, y])
                        count++;
            return count;
        }

        static void DrawBoard(bool[,] queens, bool[,] safePlaces, int number=-1)
        {
            if (number!=-1)
                Console.WriteLine($"{number})");

            (int x, int y) boardSize = (safePlaces.GetLength(0), safePlaces.GetLength(1));

            for (int y = 0; y < boardSize.y; y++)
                for (int x = 0; x < boardSize.x; x++)
                {
                    if (queens[x, y])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" ▄");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write((safePlaces[x, y] ? "  " : " ▄"));
                    }
                    if (x == boardSize.y - 1)
                        Console.WriteLine();
                }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
