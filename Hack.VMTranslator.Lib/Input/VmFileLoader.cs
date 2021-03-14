using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.Lib.Input
{
    public class VmFileLoader
    {
        private readonly VmCodeLoaderOptions _options;
        private readonly InputCodeLineFactory _factory;

        public VmFileLoader(IOptions<VmCodeLoaderOptions> options, InputCodeLineFactory factory)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _options = options.Value;
        }

        public async Task<IReadOnlyCollection<VmCodeLine>> Load(CancellationToken cancellationToken)
        {
            var rawLines = await File.ReadAllLinesAsync(_options.InputPath, cancellationToken);
            var cleanLines = Clean(rawLines, new FileInfo(_options.InputPath).Name);
            
            var result = new List<VmCodeLine>();
            foreach (var line in cleanLines)
            {
                line.AddTo(result);
            }

            return result;
        }
        
        private IEnumerable<IInputCodeLine> Clean(IEnumerable<string> lines, string fileName)
        {
            return lines.Select(line => _factory.GetCodeLine(line, fileName));
        }
    }
}