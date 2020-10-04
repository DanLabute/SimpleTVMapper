using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SimpleNameMapper.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleTVMapper
{
    public partial class MappingsEditor : Form
    {
        JArray mappingList;

        private JArray LoadMappingsFromJson()
        {
            using (StreamReader reader = File.OpenText(@"mappings.json"))
            {
                mappingList = (JArray)JToken.ReadFrom(new JsonTextReader(reader));
            }

            return mappingList;
        }

        public MappingsEditor()
        {
            InitializeComponent();
        }

        private void populateListbox()
        {
            mappingList = LoadMappingsFromJson();

            lstMappings.Items.Clear();

            foreach (JToken m in mappingList)
            {
                lstMappings.Items.Add(m["originalTitle"]);
            }
            lstMappings.Sorted = true;
        }

        private void MappingsEditor_Load(object sender, EventArgs e)
        {
            editorEnabledState(false);
            populateListbox();
        }

        private void lstMappings_SelectedIndexChanged(object sender, EventArgs e)
        {
            editorEnabledState(true);
            saveEnabledState(false);
            string origTitle = null;
            if (lstMappings.SelectedIndex > -1)
            {
                origTitle = lstMappings.SelectedItem.ToString();
                var mapping = mappingList.SelectToken("$.[?(@.originalTitle == '" + origTitle +  "')]");
                txtOriginalTitle.Text = (string)mapping["originalTitle"];
                txtNewTitle.Text = (string)mapping["newTitle"];
                txtNewSeason.Text = (string)mapping["newSeason"];
                txtEpisodeCountOffset.Text = (string)mapping["episodeCountOffset"];
                txtParentDirectory.Text = (string)mapping["parentPath"];
            }
        }

        private void editorEnabledState(bool enabledState)
        {
            txtOriginalTitle.Enabled = enabledState;
            txtNewTitle.Enabled = enabledState;
            txtNewSeason.Enabled = enabledState;
            txtEpisodeCountOffset.Enabled = enabledState;
            txtParentDirectory.Enabled = enabledState;
            btnBrowseParentDirectory.Enabled = enabledState;
        }

        private void saveEnabledState(bool enabledState)
        {
            btnSave.Enabled = enabledState;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lstMappings.ClearSelected();
            txtOriginalTitle.Clear();
            txtNewTitle.Clear();
            txtNewSeason.Clear();
            txtEpisodeCountOffset.Clear();
            txtParentDirectory.Clear();
            editorEnabledState(true);
            txtOriginalTitle.Focus();
        }

        private void checkInfoCompletion()
        {
            if (txtOriginalTitle.Text.Length > 0 && txtNewTitle.Text.Length > 0 && txtParentDirectory.Text.Length > 0)
            {
                saveEnabledState(true);
            }
            else
            {
                saveEnabledState(false);
            }
        }

        private void txtOriginalTitle_TextChanged(object sender, EventArgs e)
        {
            checkInfoCompletion();
        }

        private void txtNewTitle_TextChanged(object sender, EventArgs e)
        {
            checkInfoCompletion();
        }

        private void txtNewSeason_TextChanged(object sender, EventArgs e)
        {
            checkInfoCompletion();
        }

        private void txtEpisodeCountOffset_TextChanged(object sender, EventArgs e)
        {
            checkInfoCompletion();
        }

        private void txtParentDirectory_TextChanged(object sender, EventArgs e)
        {
            checkInfoCompletion();
        }

        private void btnBrowseParentDirectory_Click(object sender, EventArgs e)
        {
            if ( parentDirectoryBrowser.ShowDialog() == DialogResult.OK)
            {
                txtParentDirectory.Text = parentDirectoryBrowser.SelectedPath;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JObject newMapping = new JObject();
            newMapping["originalTitle"] = txtOriginalTitle.Text;
            newMapping["newTitle"] = txtNewTitle.Text;
            newMapping["newSeason"] = txtNewSeason.Text;
            newMapping["episodeCountOffset"] = txtEpisodeCountOffset.Text;
            newMapping["parentPath"] = txtParentDirectory.Text;

            mappingList.Add(newMapping);

            using (StreamWriter file = File.CreateText(@"mappings.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, mappingList);
            }

            populateListbox();
        }
    }
}
