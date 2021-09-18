using System;
using System.IO;
using System.Threading.Tasks;

namespace Folder_Size
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string[] fileNames = Directory.GetFiles("TestFolder");
            double totalSize = 0;

            foreach (var fileName in fileNames)
            {
                FileInfo info = new FileInfo(fileName);
                totalSize += (double)info.Length / 1024 / 1024;
            }

            await File.WriteAllTextAsync("Output.txt", totalSize.ToString());
        }
    }
}
