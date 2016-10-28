using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using SimpleStaticFileServer.Properties;

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

            if (!root.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                root += Path.DirectorySeparatorChar;
            }


            WebRoot = root;

            int port = GetPort(root);

            if (port == 0)
                port = RandPort();

            string url = string.Format("{0}:{1}", "http://127.0.0.1", port);

            Console.WriteLine("Http Listener: " + url);
            Console.WriteLine("Open it on you brower. ");

            WebApp.Start(new StartOptions(url));

            //调用系统默认的浏览器
            Console.WriteLine("Try to open ... ");
            System.Diagnostics.Process.Start(url);

            Save(port, root);

            Console.ReadLine();

        }

        // {path}:{port}
        static int GetPort(string path)
        {
            var all = GetAllMaps();

            if (all.ContainsKey(path))
                return all[path];

            return 0;
        }

        static void Save(int port, string path)
        {
            var all = GetAllMaps();

            all[path] = port;

            foreach (var item in all)
            {
                var str = string.Format("{0}|{1}", item.Key, item.Value);

                if (Settings.Default.DirectoryMapps == null)
                {
                    Settings.Default.DirectoryMapps = new System.Collections.Specialized.StringCollection();
                }

                if (!Settings.Default.DirectoryMapps.Contains(str))
                {
                    Settings.Default.DirectoryMapps.Add(str);
                }
            }

            Settings.Default.Save();
        }

        static IDictionary<string, int> GetAllMaps()
        {
            Dictionary<string, int> maps = new Dictionary<string, int>();

            var all = Settings.Default.DirectoryMapps;

            if (all == null)
                return maps;

            foreach (var item in all)
            {
                var map = ParseItem(item);

                if (map != null)
                    maps.Add(map[0], int.Parse(map[1]));

            }

            return maps;
        }

        static string[] ParseItem(string str)
        {
            if (string.IsNullOrEmpty(str))
                return null;

            var i = str.IndexOf("|");
            if (i <= 0)
                return null;


            return str.Split('|');
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
