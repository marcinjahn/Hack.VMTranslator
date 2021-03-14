using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Hack.VMTranslator.Lib.Input
{
    public class VmDirectoryLoader
    {
        private readonly VmFileLoaderFactory _fileLoaderFactory;
        private readonly VmDirectoryLoaderOptions _options;

        private ICollection<FileInfo> _vmFiles;
        private int _index;

        public VmDirectoryLoader(VmFileLoaderFactory fileLoaderFactory, IOptions<VmDirectoryLoaderOptions> options)
        {
            _fileLoaderFactory = fileLoaderFactory ?? throw new ArgumentNullException(nameof(fileLoaderFactory));
            _options = options.Value;
            
            InitializeFilesList();
        }
        
        public async Task<IReadOnlyCollection<VmCodeLine>> LoadNextFile(CancellationToken cancellationToken)
        {
            var allFilesLoaded = _index >= _vmFiles.Count;
            if (allFilesLoaded)
            {
                return null;
            }

            var fileLoader = _fileLoaderFactory.Create(_vmFiles.ElementAt(_index++).FullName);
            return await fileLoader.Load(cancellationToken);
        }

        private void InitializeFilesList()
        {
            _vmFiles = _options.DirectoryPath.EnumerateFiles("*.vm").ToList();
        }
    }
}