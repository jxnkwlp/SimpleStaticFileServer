using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SimpleStaticFileServer
{
    class Program
    {
        public static string WebRoot;

        static void Main(string[] args)
        {
            string root = GetEnterDirectory();

            while (true)
            {
                if (Directory.Exists(root))
                {
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The directory not found! ");
                    Console.ResetColor();

                    Console.WriteLine();

                    root = GetEnterDirectory();
                }
            }

            WebRoot = root;

            var port = RandPort();

            string url = string.Format("{0}:{1}", "http://127.0.0.1", port);

            Console.WriteLine("Http Listener: " + url);
            Console.WriteLine("Open it on you brower. ");

            WebApp.Start(new StartOptions(url));

            Console.ReadLine();

        }

        static string GetEnterDirectory()
        {
            Console.Write("Enter you web root directory: ");

            var enter = Console.ReadLine();

            return enter;
        }

        static int RandPort()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());

            return rand.Next(10000, 20000);
        }
    }
}
