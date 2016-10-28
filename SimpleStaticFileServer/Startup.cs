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
            //app.UseStaticFiles(new StaticFileOptions() { FileSystem = fileSystem });


            Console.WriteLine();
            app.Use(async (context, next) =>
            {
                Console.WriteLine("[" + context.Request.Method + "] " + context.Request.Uri);

                await next();
            });
        }
    }
}
