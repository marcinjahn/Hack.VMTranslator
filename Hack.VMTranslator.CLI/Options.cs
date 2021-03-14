using System;
using System.IO;

namespace Hack.VMTranslator.CLI
{
    public class Options
    {
        public Options(FileSystemInfo inputPath, FileInfo outputFile, bool includeBootstrap)
        {
            InputPath = inputPath ?? throw new ArgumentNullException(nameof(inputPath));
            OutputFile = outputFile ?? throw new ArgumentNullException(nameof(outputFile));
            IncludeBootstrap = includeBootstrap;
        }

        public FileSystemInfo InputPath { get; set; }
        public FileInfo OutputFile { get; set; }
        public bool IncludeBootstrap { get; set; }
    }
}