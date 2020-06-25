using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNameMapper.Classes
{
    class FileLibrary
    {
        public string Name { get; set; }

        public string SourcePath { get; set; }

        public string DestinationPath { get; set; }

        public string[] GetLibraryFileList(string path)
        {
            String[] directoryList = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            return directoryList;
        }
    }
}
