using System;

namespace Pawn_Wars
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] chessboard = new char[8, 8];
            int blackRow = -1;
            int blackCol = -1;
            int whiteRow = -1;
            int whiteCol = -1;
            FillMatrix(chessboard, ref blackRow, ref blackCol, ref whiteRow, ref whiteCol);
            int count = 0;

            while (true)
            {
                if (count % 2 == 0)
                {
                    bool gameOver = false;
                    if (whiteRow - 1 >= 0 && whiteCol - 1 >= 0 && chessboard[whiteRow - 1, whiteCol - 1] == 'b')
                    {
                        chessboard[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        whiteCol--;
                        gameOver = true;
                    }
                    else if (whiteRow - 1 >= 0 && whiteCol + 1 < 8 && chessboard[whiteRow - 1, whiteCol + 1] == 'b')
                    {
                        chessboard[whiteRow, whiteCol] = '-';
                        whiteRow--;
                        whiteCol++;
                        gameOver = true;
                    }
                    if (gameOver)
                    {
                        chessboard[whiteRow, whiteCol] = 'w';
                        Console.WriteLine($"Game over! White capture on {ChessCol(whiteCol)}{8 - whiteRow}.");
                        return;
                    }
                    chessboard[whiteRow, whiteCol] = '-';
                    whiteRow--;
                    chessboard[whiteRow, whiteCol] = 'w';

                }
                else
                {
                    bool gameOver = false;
                    if (blackRow + 1 < 8 && blackCol - 1 >= 0 && chessboard[blackRow + 1, blackCol - 1] == 'w')
                    {
                        chessboard[whiteRow, whiteCol] = '-';
                        blackRow++;
                        blackCol--;
                        gameOver = true;
                    }
                    else if (blackRow + 1 < 8 && blackCol + 1 < 8 && chessboard[blackRow + 1, blackCol + 1] == 'w')
                    {
                        chessboard[whiteRow, whiteCol] = '-';
                        blackRow++;
                        blackCol++;
                        gameOver = true;
                    }
                    if (gameOver)
                    {
                        chessboard[blackRow, blackCol] = 'b';
                        Console.WriteLine($"Game over! Black capture on {ChessCol(blackCol)}{8 - blackRow}.");
                        return;
                    }
                    chessboard[blackRow, blackCol] = '-';
                    blackRow++;
                    chessboard[blackRow, blackCol] = 'b';

                }

                if (whiteRow == 0)
                {
                    char col = ChessCol(whiteCol);
                    Console.WriteLine($"Game over! White pawn is promoted to a queen at {col}8.");
                    break;
                }
                if (blackRow == 7)
                {
                    char col = ChessCol(blackCol);
                    Console.WriteLine($"Game over! Black pawn is promoted to a queen at {col}1.");
                    break;
                }
                count++;
            }
        }
        private static void FillMatrix(char[,] chessboard, ref int blackRow, ref int blackCol, ref int whiteRow, ref int whiteCol)
        {
            for (int row = 0; row < 8; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                for (int col = 0; col < 8; col++)
                {
                    chessboard[row, col] = input[col];
                    if (input[col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                    else if (input[col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }
                }
            }
        }
        private static char ChessCol(int x)
        {
            char col = ' ';
            switch (x)
            {
                case 0:
                    col = 'a';
                    break;
                case 1:
                    col = 'b';
                    break;
                case 2:
                    col = 'c';
                    break;
                case 3:
                    col = 'd';
                    break;
                case 4:
                    col = 'e';
                    break;
                case 5:
                    col = 'f';
                    break;
                case 6:
                    col = 'g';
                    break;
                case 7:
                    col = 'h';
                    break;
            }
            return col;
        }
    }
}
