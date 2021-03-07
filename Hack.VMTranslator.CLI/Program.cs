using System;
using System.IO;
using System.Threading.Tasks;
using Hack.VMTranslator.Lib.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Hack.VMTranslator.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                VerifyArgs(args);
                var builder = GetHostBuilder(args);
                await builder.RunConsoleAsync(options => options.SuppressStatusMessages = true);
            }
            catch (Exception e)
            {
                Console.WriteLine("Program run into an exception");
                Console.WriteLine(e.Message);
            }
        }
        
        private static IHostBuilder GetHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddCoreServices(GetInputFileName(args));
                    services.AddInputSupport(args[0]);
                    services.AddOutputSupport();
                    services.AddHostedService<HostedService>();
                    services.Configure<HostedServiceOptions>(o =>
                        o.OutputPath = GetOutputPath(args));
                });
        }

        private static string GetInputFileName(string[] args)
        {
            return new FileInfo(args[0]).Name;
        }
        
        private static string GetOutputPath(string[] args)
        {
            if (!args[0].EndsWith(".vm"))
            {
                throw new Exception("Input file needs to have '.vm' extension");
            }
            return args[0].Replace(".vm", ".asm");
        }

        private static void VerifyArgs(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception("Wrong input");
            }

            if (!File.Exists(args[0]))
            {
                throw new Exception("File does not exist");
            }
        }
    }
}