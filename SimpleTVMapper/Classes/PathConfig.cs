using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleNameMapper.Classes
{
    class PathConfig
    {
        public string SourcePath = @"\\192.168.0.100\Torrents";

        public string allowedFileExtensions = @".*[.mkv, .mp4, .avi]$";

        public string[] GetFileList(string path)
        {
            String[] directoryList = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            return directoryList;
        }
    }
}
