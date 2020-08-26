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
    class FileMapping
    {
        public string originalTitle { get; set; }

        public string newTitle { get; set; }

        public string originalSeason { get; set; }

        public string newSeason { get; set; }

        public string originalEpisode { get; set; }

        public string newEpisode { get; set; }

        public string parentPath { get; set; }

        public string episodeCountOffset { get; set; }

        
    }
}
