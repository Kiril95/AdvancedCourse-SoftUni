using System;
using System.IO;
using System.Threading.Tasks;

namespace Slice_a_File
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (FileStream stream = new FileStream("sliceMe.txt", FileMode.Open))
            {
                int partSize = (int) Math.Ceiling((double) stream.Length / 4);
                byte[] buffer = new byte[partSize];

                for (int i = 1; i <= 4; i++)
                {
                    using (var outputFile = new FileStream($"Part-{i}.txt", FileMode.Create))
                    {
                        int readBytes = stream.Read(buffer, 0, partSize);
                        await outputFile.WriteAsync(buffer, 0, readBytes);
                    }
                }

            }
        }
    }
}
