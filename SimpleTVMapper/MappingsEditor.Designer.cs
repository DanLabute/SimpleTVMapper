namespace SimpleTVMapper
{
    partial class MappingsEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.layoutOuter = new System.Windows.Forms.TableLayoutPanel();
            this.layoutInner = new System.Windows.Forms.TableLayoutPanel();
            this.lstMappings = new System.Windows.Forms.ListBox();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.txtOriginalTitle = new System.Windows.Forms.TextBox();
            this.txtNewTitle = new System.Windows.Forms.TextBox();
            this.txtNewSeason = new System.Windows.Forms.TextBox();
            this.txtEpisodeCountOffset = new System.Windows.Forms.TextBox();
            this.txtParentDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBrowseParentDirectory = new System.Windows.Forms.Button();
            this.parentDirectoryBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.layoutOuter.SuspendLayout();
            this.layoutInner.SuspendLayout();
            this.grpEdit.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // layoutOuter
            // 
            this.layoutOuter.ColumnCount = 2;
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.35052F));
            this.layoutOuter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 71.64948F));
            this.layoutOuter.Controls.Add(this.layoutInner, 1, 0);
            this.layoutOuter.Controls.Add(this.lstMappings, 0, 0);
            this.layoutOuter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutOuter.Location = new System.Drawing.Point(0, 0);
            this.layoutOuter.Name = "layoutOuter";
            this.layoutOuter.RowCount = 1;
            this.layoutOuter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutOuter.Size = new System.Drawing.Size(800, 234);
            this.layoutOuter.TabIndex = 0;
            // 
            // layoutInner
            // 
            this.layoutInner.ColumnCount = 1;
            this.layoutInner.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.layoutInner.Controls.Add(this.grpEdit, 0, 0);
            this.layoutInner.Controls.Add(this.panel1, 0, 1);
            this.layoutInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutInner.Location = new System.Drawing.Point(229, 3);
            this.layoutInner.Name = "layoutInner";
            this.layoutInner.RowCount = 2;
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.21053F));
            this.layoutInner.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.78947F));
            this.layoutInner.Size = new System.Drawing.Size(568, 228);
            this.layoutInner.TabIndex = 0;
            // 
            // lstMappings
            // 
            this.lstMappings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstMappings.FormattingEnabled = true;
            this.lstMappings.Location = new System.Drawing.Point(3, 3);
            this.lstMappings.Name = "lstMappings";
            this.lstMappings.Size = new System.Drawing.Size(220, 228);
            this.lstMappings.TabIndex = 1;
            this.lstMappings.SelectedIndexChanged += new System.EventHandler(this.lstMappings_SelectedIndexChanged);
            // 
            // grpEdit
            // 
            this.grpEdit.Controls.Add(this.btnBrowseParentDirectory);
            this.grpEdit.Controls.Add(this.label5);
            this.grpEdit.Controls.Add(this.label4);
            this.grpEdit.Controls.Add(this.label3);
            this.grpEdit.Controls.Add(this.label2);
            this.grpEdit.Controls.Add(this.label1);
            this.grpEdit.Controls.Add(this.txtParentDirectory);
            this.grpEdit.Controls.Add(this.txtEpisodeCountOffset);
            this.grpEdit.Controls.Add(this.txtNewSeason);
            this.grpEdit.Controls.Add(this.txtNewTitle);
            this.grpEdit.Controls.Add(this.txtOriginalTitle);
            this.grpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpEdit.Location = new System.Drawing.Point(3, 3);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(562, 185);
            this.grpEdit.TabIndex = 0;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "Edit Mapping";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 194);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 31);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(481, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(400, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // txtOriginalTitle
            // 
            this.txtOriginalTitle.Location = new System.Drawing.Point(123, 22);
            this.txtOriginalTitle.Name = "txtOriginalTitle";
            this.txtOriginalTitle.Size = new System.Drawing.Size(376, 20);
            this.txtOriginalTitle.TabIndex = 0;
            this.txtOriginalTitle.TextChanged += new System.EventHandler(this.txtOriginalTitle_TextChanged);
            // 
            // txtNewTitle
            // 
            this.txtNewTitle.Location = new System.Drawing.Point(123, 48);
            this.txtNewTitle.Name = "txtNewTitle";
            this.txtNewTitle.Size = new System.Drawing.Size(376, 20);
            this.txtNewTitle.TabIndex = 1;
            this.txtNewTitle.TextChanged += new System.EventHandler(this.txtNewTitle_TextChanged);
            // 
            // txtNewSeason
            // 
            this.txtNewSeason.Location = new System.Drawing.Point(123, 75);
            this.txtNewSeason.Name = "txtNewSeason";
            this.txtNewSeason.Size = new System.Drawing.Size(376, 20);
            this.txtNewSeason.TabIndex = 2;
            this.txtNewSeason.TextChanged += new System.EventHandler(this.txtNewSeason_TextChanged);
            // 
            // txtEpisodeCountOffset
            // 
            this.txtEpisodeCountOffset.Location = new System.Drawing.Point(123, 102);
            this.txtEpisodeCountOffset.Name = "txtEpisodeCountOffset";
            this.txtEpisodeCountOffset.Size = new System.Drawing.Size(376, 20);
            this.txtEpisodeCountOffset.TabIndex = 3;
            this.txtEpisodeCountOffset.TextChanged += new System.EventHandler(this.txtEpisodeCountOffset_TextChanged);
            // 
            // txtParentDirectory
            // 
            this.txtParentDirectory.Location = new System.Drawing.Point(123, 129);
            this.txtParentDirectory.Name = "txtParentDirectory";
            this.txtParentDirectory.Size = new System.Drawing.Size(376, 20);
            this.txtParentDirectory.TabIndex = 4;
            this.txtParentDirectory.TextChanged += new System.EventHandler(this.txtParentDirectory_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Original Title:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "New Title:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "New Season:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Episode Count Offset:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Parent Directory:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnBrowseParentDirectory
            // 
            this.btnBrowseParentDirectory.Location = new System.Drawing.Point(424, 155);
            this.btnBrowseParentDirectory.Name = "btnBrowseParentDirectory";
            this.btnBrowseParentDirectory.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseParentDirectory.TabIndex = 10;
            this.btnBrowseParentDirectory.Text = "Browse";
            this.btnBrowseParentDirectory.UseVisualStyleBackColor = true;
            this.btnBrowseParentDirectory.Click += new System.EventHandler(this.btnBrowseParentDirectory_Click);
            // 
            // MappingsEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 234);
            this.Controls.Add(this.layoutOuter);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MappingsEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Mappings Editor";
            this.Load += new System.EventHandler(this.MappingsEditor_Load);
            this.layoutOuter.ResumeLayout(false);
            this.layoutInner.ResumeLayout(false);
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel layoutOuter;
        private System.Windows.Forms.TableLayoutPanel layoutInner;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox lstMappings;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtParentDirectory;
        private System.Windows.Forms.TextBox txtEpisodeCountOffset;
        private System.Windows.Forms.TextBox txtNewSeason;
        private System.Windows.Forms.TextBox txtNewTitle;
        private System.Windows.Forms.TextBox txtOriginalTitle;
        private System.Windows.Forms.Button btnBrowseParentDirectory;
        private System.Windows.Forms.FolderBrowserDialog parentDirectoryBrowser;
    }
}