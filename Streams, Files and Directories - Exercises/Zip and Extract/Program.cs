using System;
using System.IO;
using System.IO.Compression;

namespace Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            var zip = @"C:\Users\Tolev\Desktop\testZip.zip";

            using (ZipArchive archive = ZipFile.Open(zip, ZipArchiveMode.Create))
            {
                archive.CreateEntryFromFile("copyMe.png", Path.GetFileName("copyMe.png"));
            }

        }
    }
}
