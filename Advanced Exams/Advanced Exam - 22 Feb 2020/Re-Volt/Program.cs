using System;

namespace Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int times = int.Parse(Console.ReadLine());
            char[][] field = new char[size][];
            int startRow = -1;
            int startCol = -1;
            bool reachedFinish = false;
            FillMatrix(field, size, ref startRow, ref startCol);
            string direction = Console.ReadLine();

            field[startRow][startCol] = '-';
            for (int i = 0; i < times; i++)
            {
                if (direction == "up")
                {
                    startRow--;
                    if (startRow < 0)
                    {
                        startRow = field.Length - 1;
                    }
                }
                else if (direction == "down")
                {
                    startRow++;
                    if (startRow > field.Length - 1)
                    {
                        startRow = 0;
                    }
                }
                else if (direction == "left")
                {
                    startCol--;
                    if (startCol < 0)
                    {
                        startCol = field.Length - 1;
                    }
                }
                else if (direction == "right")
                {
                    startCol++;
                    if (startCol > field.Length - 1)
                    {
                        startCol = 0;
                    }
                }

                if (field[startRow][startCol] == 'F')
                {
                    reachedFinish = true;
                    break;
                }
                else if (field[startRow][startCol] == 'B')
                {
                    i--;
                    continue;
                }
                else if (field[startRow][startCol] == 'T')
                {
                    MoveBack(ref startRow, ref startCol, direction);
                }

                direction = Console.ReadLine();
                
            }
            field[startRow][startCol] = 'f';

            Console.WriteLine(reachedFinish ? "Player won!" : "Player lost!");
            PrintMatrix(field);

        }
        private static void MoveBack(ref int startRow, ref int startCol, string direction)
        {
            if (direction == "up")
            {
                startRow++;
            }
            else if (direction == "down")
            {
                startRow--;
            }
            else if (direction == "left")
            {
                startCol++;
            }
            else if (direction == "right")
            {
                startCol--;
            }
        }
        private static void FillMatrix(char[][] field, int size, ref int startRow, ref int startCol)
        {
            for (int row = 0; row < field.Length; row++)
            {
                char[] line = Console.ReadLine().ToCharArray();
                field[row] = line;
                for (int col = 0; col < field[row].Length; col++)
                {
                    if (field[row][col] == 'f')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
        }
        private static void PrintMatrix(char[][] field)
        {
            foreach (var row in field)
            {
                Console.WriteLine(string.Join("", row));
            }
        }
    }
}
