using Newtonsoft.Json;
using SimpleNameMapper.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SimpleTVMapper
{
    public partial class MainForm : Form
    {

        PathConfig pConfig = new PathConfig();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadAndPopulateListView();
        }

        private string sanitizeFileName(string fileName)
        {
            String sanitizedFilename = Regex.Replace(Path.GetFileNameWithoutExtension(fileName), @"\ \.", ".").Trim();
            sanitizedFilename = Regex.Replace(Path.GetFileNameWithoutExtension(fileName), @"\[(.*?)\]", "").Trim();
            return sanitizedFilename;
        }

        string determineSeason(string fileName)
        {
            Match seasonMatch = Regex.Match(fileName, @"[Ss](\d+)");
            String seasonString = "";
            if (seasonMatch.Success)
            {
                foreach (Group g in seasonMatch.Groups)
                {
                    string sanitizedSeasonVal = g.Value.Trim();
                    if (isNumeric(sanitizedSeasonVal))
                    {
                        if (sanitizedSeasonVal.Length < 2)
                        {
                            seasonString = "0" + sanitizedSeasonVal;
                        }
                        else
                        {
                            seasonString = sanitizedSeasonVal;
                        }
                        break;
                    } 
                }
            }
            else
            {
                seasonString = "01";
            }

            if (seasonString == "00")
            {
                seasonString = "Specials";
            }

            return seasonString;
        }

        string determineEpisode(string fileName)
        {
            Match episodeMatch = Regex.Match(fileName, @"[Ee](\d+)| - (\d+)");
            String episodeString = "";
            if (episodeMatch.Success)
            {
                foreach (Group g in episodeMatch.Groups)
                {
                    if (isNumeric(g.Value))
                    {
                        if (g.Value.Length < 2)
                        {
                            episodeString = "0" + g.Value;
                            break;
                        }
                        else
                        {
                            episodeString = g.Value;
                        }
                    }
                }
                return episodeString;
            }
            else
            {
                return "_";
            }
        }
            
        string determineTitle(string fileName)
        {
            Match showTitleMatch = null;

            showTitleMatch = Regex.Match(fileName, @"^(?<showNameAnime>.*?) - \d|^(?<showNameTV>.*?)[Ss]\d\d");

            if (showTitleMatch.Success)
            {
                string showTitle = "";
                if (showTitleMatch.Groups["showNameAnime"].Value != "")
                {
                    showTitle = showTitleMatch.Groups["showNameAnime"].Value.Replace(".", " ").Trim();
                }

                if (showTitleMatch.Groups["showNameTV"].Value != "")
                {
                    showTitle = showTitleMatch.Groups["showNameTV"].Value.Replace(".", " ").Trim();
                }
                return showTitle.ToUpper();
            }
            else
            {
                return "_";
            }
        }

        string determineExtension(string fileName)
        {
            return Path.GetExtension(fileName);
        }

        bool isNumeric(string value)
        {
            Regex isNumeric = new Regex(@"^\d+$");
            return isNumeric.IsMatch(value);
        }

        private void loadAndPopulateListView()
        {

            lstFiles.Items.Clear();

            //List all files in directory, exclude filtered extensions
            string[] fileList = pConfig.GetFileList(pConfig.SourcePath);

            List<FileMapping> mappingList = LoadMappingsFromJson();

            //List all files in directory, exclude filtered extensions
            foreach (string s in fileList)
            {
                if (Regex.Match(s, pConfig.allowedFileExtensions).Length > 0)
                {
                    string sanitizedFileName = sanitizeFileName(s);
                    string origSeason = determineSeason(sanitizedFileName);
                    string origEpisode = determineEpisode(sanitizedFileName);
                    string origTitle = determineTitle(sanitizedFileName);
                    string origExtension = determineExtension(s);
                    string newSeason = "";
                    string newEpisode = origEpisode;
                    string newTitle = "";
                    string newFilePath = "";
                    string newExtension = origExtension;

                    FileMapping m = mappingList.Find(x => x.originalTitle.Equals(origTitle));

                    string[] saLvwItem = new string[8];
                    saLvwItem[0] = s;
                    saLvwItem[1] = origTitle;
                    saLvwItem[2] = origSeason;
                    saLvwItem[3] = origEpisode;
                    saLvwItem[4] = "";
                    saLvwItem[5] = "";
                    saLvwItem[6] = "";
                    saLvwItem[7] = "";

                    if (m == null)
                    {
                        saLvwItem[4] = "NOMAPPING";
                    }
                    else
                    {
                        newTitle = m.newTitle;

                        if (m.newSeason == null)
                        {
                            newSeason = origSeason;
                        }
                        else
                        {
                            if (m.newSeason.Length == 1)
                            {
                                newSeason = "0" + m.newSeason;
                            }
                            else
                            {
                                newSeason = m.newSeason;
                            }
                        }

                        string seasonString = "";
                        string seasonNum = "";

                        if (newSeason == "Specials")
                        {
                            seasonString = newSeason;
                            seasonNum = "00";
                        }
                        else
                        {
                            seasonString = "Season " + newSeason;
                            seasonNum = newSeason;
                        }

                        if (m.episodeCountOffset != null)
                        {
                            newEpisode = (Int32.Parse(newEpisode) - Int32.Parse(m.episodeCountOffset)).ToString();
                            if (newEpisode.Length == 1)
                            {
                                newEpisode = "0" + newEpisode;
                            }
                        }

                        newFilePath = m.parentPath;

                        string plexifiedNewTitle = newTitle.Replace(' ', '.');
                        string newFileNameFullPath = newFilePath + @"\" + newTitle + @"\" + seasonString + @"\" + plexifiedNewTitle + ".S" + seasonNum + "E" + newEpisode + newExtension;
                        string newFilePathWithSubfolder = newFilePath + @"\" + newTitle + @"\" + "Season " + newSeason;

                        saLvwItem[4] = newFileNameFullPath;
                        saLvwItem[5] = newTitle;
                        saLvwItem[6] = seasonNum;
                        saLvwItem[7] = newEpisode;
                    }
                    ListViewItem lvi = new ListViewItem(saLvwItem);
                    lstFiles.Items.Add(lvi);
                }
            }

            for (int i = 0; i < lstFiles.Columns.Count; i++)
            {
                lstFiles.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
        }

        private List<FileMapping> LoadMappingsFromJson()
        {
            using (StreamReader r = new StreamReader("mappings.json"))
            {
                string json = r.ReadToEnd();
                List<FileMapping> mappings = JsonConvert.DeserializeObject<List<FileMapping>>(json);
                return mappings;
            }
        }

        private void cleanupLeftoverDirs()
        {
            // Get a listing of any subdirectories that remain after moving is complete
            string[] subDirList = Directory.GetDirectories(pConfig.SourcePath);

            foreach (string dir in subDirList)
            {
                if (Directory.Exists(dir))
                {
                    // Check if any files remain with types in allowlist
                    string[] fileList = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories);

                    // If no allowlist typed files remain, delete the directory
                    if (!fileList.Any(s => Regex.IsMatch(s, pConfig.allowedFileExtensions)))
                    {
                        Directory.Delete(dir, true);
                    }
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            loadAndPopulateListView();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            foreach ( ListViewItem lvi in lstFiles.Items)
            {
                if (lvi.SubItems[4].Text != "NOMAPPING")
                {
                    string newDir = Path.GetDirectoryName(@lvi.SubItems[4].Text);
                    if (!Directory.Exists(newDir))
                    {
                        System.IO.Directory.CreateDirectory(newDir);
                    }
                    if (!File.Exists(lvi.SubItems[4].Text))
                    {
                        System.IO.File.Move(lvi.SubItems[0].Text, lvi.SubItems[4].Text);
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            cleanupLeftoverDirs();

            this.Enabled = true;
            loadAndPopulateListView();
        }
    }
}
