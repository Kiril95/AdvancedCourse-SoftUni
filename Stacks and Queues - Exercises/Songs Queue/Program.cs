using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string command = Console.ReadLine();
            Queue<string> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                //string[] operations = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (command == "Play")
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    //string song = operations[1];
                    string song = command.Substring(4);

                    if (songs.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(song);
                    }
                }
                else
                {
                    Console.WriteLine(string.Join(", ", songs));
                }

                command = Console.ReadLine();
            }

            Console.WriteLine("No more songs!");
        }
    }
}
