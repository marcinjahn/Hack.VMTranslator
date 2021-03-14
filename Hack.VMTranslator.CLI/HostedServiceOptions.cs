using System.IO;

namespace Hack.VMTranslator.CLI
{
    public class HostedServiceOptions
    {
        public FileSystemInfo InputPath { get; set; }
        public string OutputPath { get; set; }
    }
}