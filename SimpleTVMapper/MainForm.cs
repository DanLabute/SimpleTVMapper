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
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadAndPopulateListView();
        }

        private void loadAndPopulateListView()
        {
            lstFiles.Items.Clear();
            List<FileLibrary> libraries = LoadLibrariesFromJson();
            List<FileMapping> mappingList = LoadMappingsFromJson();

            foreach (var library in libraries)
            {
                //List all files in directory, exclude filtered extensions
                string[] libraryFileList = library.GetLibraryFileList(library.SourcePath);

                foreach (string s in libraryFileList)
                {
                    string origSeason = DetermineSeason(s);
                    string origEpisode = DetermineEpisode(s);
                    string origTitle = DetermineTitle(s);
                    string origExtension = Path.GetExtension(s);
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
                            newSeason = "01";
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

                        newFilePath = library.DestinationPath;

                        string plexifiedNewTitle = newTitle.Replace(' ', '.');
                        string newFileNameFullPath = newFilePath + @"\" + newTitle + @"\" + "Season " + newSeason + @"\" + plexifiedNewTitle + ".S" + newSeason + "E" + newEpisode + newExtension;
                        string newFilePathWithSubfolder = newFilePath + @"\" + newTitle + @"\" + "Season " + newSeason;

                        saLvwItem[4] = newFileNameFullPath;
                        saLvwItem[5] = newTitle;
                        saLvwItem[6] = newSeason;
                        saLvwItem[7] = newEpisode;
                    }
                    ListViewItem lvi = new ListViewItem(saLvwItem);
                    lstFiles.Items.Add(lvi);
                    for (int i = 0; i < lstFiles.Columns.Count; i++)
                    {
                        lstFiles.Columns[i].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    }
                }
            }
        }

        private static string DetermineSeason(string filename)
        {
            String sanitizedFilename = Regex.Replace(Path.GetFileNameWithoutExtension(filename), "\\[(.*?)\\]", "").Trim();
            Regex isNumeric = new Regex("^\\d+$");
            Match seasonMatch = Regex.Match(sanitizedFilename, ".*(?=([Ss](\\d+)))");
            String seasonString = "";
            if (seasonMatch.Success)
            {
                foreach (Group g in seasonMatch.Groups)
                {
                    if (isNumeric.IsMatch(g.Value))
                    {
                        if (g.Value.Length < 2)
                        {
                            seasonString = "0" + g.Value;
                        }
                        else
                        {
                            seasonString = g.Value;
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

        private static string DetermineEpisode(string filename)
        {
            String sanitizedFilename = Regex.Replace(Path.GetFileNameWithoutExtension(filename), "\\[(.*?)\\]", "").Trim();
            Regex isNumeric = new Regex("^\\d+$");
            Match episodeMatch = Regex.Match(sanitizedFilename, ".*(?=([Ee](\\d+))|( - (\\d+)))");
            String episodeString = "";
            if (episodeMatch.Success)
            {
                foreach (Group g in episodeMatch.Groups)
                {
                    if (isNumeric.IsMatch(g.Value))
                    {
                        episodeString = g.Value;
                        break;
                    }
                }
                return episodeString;
            }
            else
            {
                return "_";
            }
        }

        private static string DetermineTitle(string filename)
        {
            String sanitizedFilename = Regex.Replace(Path.GetFileNameWithoutExtension(filename), "\\[(.*?)\\]", "").Trim();
            Match showTitleMatch;
            showTitleMatch = Regex.Match(sanitizedFilename, ".*(?=( - ))");

            if (showTitleMatch.Success)
            {
                return showTitleMatch.Groups[0].Value.Replace(".", " ").Replace(" - ", ": ").Trim();
            }
            else
            {
                return "_";
            }
        }

        private List<FileLibrary> LoadLibrariesFromJson()
        {
            using (StreamReader r = new StreamReader("config/libraries.json"))
            {
                string json = r.ReadToEnd();
                List<FileLibrary> libraries = JsonConvert.DeserializeObject<List<FileLibrary>>(json);
                return libraries;
            }
        }

        private List<FileMapping> LoadMappingsFromJson()
        {
            using (StreamReader r = new StreamReader("config/mappings.json"))
            {
                string json = r.ReadToEnd();
                List<FileMapping> mappings = JsonConvert.DeserializeObject<List<FileMapping>>(json);
                return mappings;
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
            this.Enabled = true;
            loadAndPopulateListView();
        }
    }
}
