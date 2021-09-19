using System;
using System.IO;
using System.Threading.Tasks;

namespace Copy_Binary_File
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (FileStream stream = new FileStream("copyMe.png", FileMode.Open))
            {
                using (FileStream copy = new FileStream("copied.png", FileMode.Create))
                {
                    byte[] buffer = new byte[stream.Length];
                    await stream.ReadAsync(buffer, 0, (int)stream.Length);
                    await copy.WriteAsync(buffer, 0, (int)stream.Length);

                }
            }
        }
    }
}
