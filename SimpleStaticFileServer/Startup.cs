using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.FileSystems;
using Microsoft.Owin.StaticFiles;
using System.IO;

namespace SimpleStaticFileServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Console.WriteLine();
            app.Use(async (context, next) =>
            {
                Console.WriteLine("[" + context.Response.StatusCode + "] " + context.Request.Uri);

                await next();
            });

            if (!Directory.Exists(Program.WebRoot))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The directory '" + Program.WebRoot + "' not found!");
                Console.ResetColor();

                Console.WriteLine();

                return;
            }

            var root = Program.WebRoot;

            var fileSystem = new PhysicalFileSystem(root);

            var fileServerOptions = new FileServerOptions()
            {
                FileSystem = fileSystem,
                EnableDefaultFiles = true,
                EnableDirectoryBrowsing = true,
            };

            app.UseFileServer(fileServerOptions);

        }
    }
}
