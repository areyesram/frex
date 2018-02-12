using System.ComponentModel;
using System.Windows.Forms;

namespace Aryes
{
    partial class MainForm
    {
        private ComboBox cboRegx;
        private IContainer components;
        private ContextMenuStrip contextMenuStrip;
        private Label label1;
        private Label label2;
        private Label label3;
        private ListBox listBoxResults;
        private ToolStripMenuItem mnuResultSave;
        private SaveFileDialog saveFileDialog;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel statusMatches;
        private StatusStrip statusStrip;
        private TextBox cboPath;
        private ComboBox cboMask;
        private ComboBox cboReplace;
        private CheckBox chkReplace;
        private CheckBox chkTrim;
        private CheckBox chkSubfolders;
        private Button btnFolder;
        private OpenFileDialog openFileDialog;
        private ToolTip toolTip;
        private ToolStripMenuItem mnuResultCopy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cboRegx = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboMask = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listBoxResults = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuResultCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuResultSave = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusMatches = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.cboReplace = new System.Windows.Forms.ComboBox();
            this.chkReplace = new System.Windows.Forms.CheckBox();
            this.chkTrim = new System.Windows.Forms.CheckBox();
            this.chkSubfolders = new System.Windows.Forms.CheckBox();
            this.btnFolder = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.cboPath = new TextBox();
            this.chkSensitive = new System.Windows.Forms.CheckBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnScriptNew = new System.Windows.Forms.ToolStripButton();
            this.btnScriptOpen = new System.Windows.Forms.ToolStripButton();
            this.btnScriptSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnResultCopy = new System.Windows.Forms.ToolStripButton();
            this.btnResultSave = new System.Windows.Forms.ToolStripButton();
            this.btnResultAppend = new System.Windows.Forms.ToolStripButton();
            this.btnAbout = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdvanced = new System.Windows.Forms.ToolStripButton();
            this.chkClearResults = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboRegx
            // 
            this.cboRegx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboRegx.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboRegx.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboRegx.DisplayMember = "Value";
            this.cboRegx.Location = new System.Drawing.Point(92, 127);
            this.cboRegx.Name = "cboRegx";
            this.cboRegx.Size = new System.Drawing.Size(218, 25);
            this.cboRegx.TabIndex = 2;
            this.cboRegx.ValueMember = "Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "File mask";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Folder";
            // 
            // cboMask
            // 
            this.cboMask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboMask.DisplayMember = "Value";
            this.cboMask.Location = new System.Drawing.Point(92, 97);
            this.cboMask.Name = "cboMask";
            this.cboMask.Size = new System.Drawing.Size(218, 25);
            this.cboMask.TabIndex = 1;
            this.cboMask.Text = "*";
            this.cboMask.ValueMember = "Value";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Find pattern";
            // 
            // listBoxResults
            // 
            this.listBoxResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxResults.ContextMenuStrip = this.contextMenuStrip;
            this.listBoxResults.FormattingEnabled = true;
            this.listBoxResults.IntegralHeight = false;
            this.listBoxResults.ItemHeight = 17;
            this.listBoxResults.Location = new System.Drawing.Point(13, 185);
            this.listBoxResults.Name = "listBoxResults";
            this.listBoxResults.Size = new System.Drawing.Size(400, 183);
            this.listBoxResults.TabIndex = 6;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuResultCopy,
            this.mnuResultSave});
            this.contextMenuStrip.Name = "contextMenuStrip2";
            this.contextMenuStrip.Size = new System.Drawing.Size(122, 48);
            // 
            // mnuResultCopy
            // 
            this.mnuResultCopy.Name = "mnuResultCopy";
            this.mnuResultCopy.Size = new System.Drawing.Size(121, 22);
            this.mnuResultCopy.Text = "Copy";
            this.mnuResultCopy.Click += new System.EventHandler(this.mnuResultCopy_Click);
            // 
            // mnuResultSave
            // 
            this.mnuResultSave.Name = "mnuResultSave";
            this.mnuResultSave.Size = new System.Drawing.Size(121, 22);
            this.mnuResultSave.Text = "Save as...";
            this.mnuResultSave.Click += new System.EventHandler(this.mnuResultSave_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusMatches,
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 380);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(424, 22);
            this.statusStrip.TabIndex = 7;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusMatches
            // 
            this.statusMatches.AutoSize = false;
            this.statusMatches.Name = "statusMatches";
            this.statusMatches.Size = new System.Drawing.Size(60, 17);
            this.statusMatches.Text = "0";
            // 
            // statusLabel
            // 
            this.statusLabel.AutoToolTip = true;
            this.statusLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(349, 17);
            this.statusLabel.Spring = true;
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // cboReplace
            // 
            this.cboReplace.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboReplace.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboReplace.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboReplace.DisplayMember = "Value";
            this.cboReplace.Location = new System.Drawing.Point(92, 154);
            this.cboReplace.Name = "cboReplace";
            this.cboReplace.Size = new System.Drawing.Size(218, 25);
            this.cboReplace.TabIndex = 3;
            this.cboReplace.ValueMember = "Value";
            // 
            // chkReplace
            // 
            this.chkReplace.AutoSize = true;
            this.chkReplace.Location = new System.Drawing.Point(20, 156);
            this.chkReplace.Name = "chkReplace";
            this.chkReplace.Size = new System.Drawing.Size(73, 21);
            this.chkReplace.TabIndex = 11;
            this.chkReplace.Text = "Replace";
            this.chkReplace.UseVisualStyleBackColor = true;
            this.chkReplace.CheckedChanged += new System.EventHandler(this.chkReplace_CheckedChanged);
            // 
            // chkTrim
            // 
            this.chkTrim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTrim.AutoSize = true;
            this.chkTrim.Location = new System.Drawing.Point(316, 156);
            this.chkTrim.Name = "chkTrim";
            this.chkTrim.Size = new System.Drawing.Size(53, 21);
            this.chkTrim.TabIndex = 11;
            this.chkTrim.Text = "Trim";
            this.chkTrim.UseVisualStyleBackColor = true;
            // 
            // chkSubfolders
            // 
            this.chkSubfolders.AutoSize = true;
            this.chkSubfolders.Location = new System.Drawing.Point(92, 72);
            this.chkSubfolders.Name = "chkSubfolders";
            this.chkSubfolders.Size = new System.Drawing.Size(132, 21);
            this.chkSubfolders.TabIndex = 12;
            this.chkSubfolders.Text = "Search subfolders";
            this.chkSubfolders.UseVisualStyleBackColor = true;
            this.chkSubfolders.CheckedChanged += new System.EventHandler(this.chkSubfolders_CheckedChanged);
            // 
            // btnFolder
            // 
            this.btnFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFolder.FlatAppearance.BorderSize = 0;
            this.btnFolder.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark;
            this.btnFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolder.Image = ((System.Drawing.Image)(resources.GetObject("btnFolder.Image")));
            this.btnFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFolder.Location = new System.Drawing.Point(310, 47);
            this.btnFolder.Name = "btnFolder";
            this.btnFolder.Size = new System.Drawing.Size(75, 25);
            this.btnFolder.TabIndex = 13;
            this.btnFolder.TabStop = false;
            this.btnFolder.Text = "Browse";
            this.btnFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip.SetToolTip(this.btnFolder, "Browse for folder");
            this.btnFolder.UseVisualStyleBackColor = true;
            this.btnFolder.Click += new System.EventHandler(this.btnFolder_Click);
            // 
            // cboPath
            // 
            this.cboPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.cboPath.Location = new System.Drawing.Point(92, 47);
            this.cboPath.Name = "cboPath";
            this.cboPath.Size = new System.Drawing.Size(218, 25);
            this.cboPath.TabIndex = 0;
            this.cboPath.Validating += new System.ComponentModel.CancelEventHandler(this.cboPath_Validating);
            // 
            // chkSensitive
            // 
            this.chkSensitive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkSensitive.AutoSize = true;
            this.chkSensitive.Location = new System.Drawing.Point(316, 131);
            this.chkSensitive.Name = "chkSensitive";
            this.chkSensitive.Size = new System.Drawing.Size(108, 21);
            this.chkSensitive.TabIndex = 15;
            this.chkSensitive.Text = "Case sensitive";
            this.chkSensitive.UseVisualStyleBackColor = true;
            this.chkSensitive.CheckedChanged += new System.EventHandler(this.chkSensitive_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGo,
            this.toolStripSeparator2,
            this.btnScriptNew,
            this.btnScriptOpen,
            this.btnScriptSave,
            this.toolStripSeparator,
            this.btnResultCopy,
            this.btnResultSave,
            this.btnResultAppend,
            this.btnAbout,
            this.toolStripSeparator1,
            this.btnAdvanced});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(424, 39);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGo
            // 
            this.btnGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnGo.Image = ((System.Drawing.Image)(resources.GetObject("btnGo.Image")));
            this.btnGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(36, 36);
            this.btnGo.Text = "Run Search";
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.AutoSize = false;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(16, 31);
            // 
            // btnScriptNew
            // 
            this.btnScriptNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnScriptNew.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptNew.Image")));
            this.btnScriptNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScriptNew.Name = "btnScriptNew";
            this.btnScriptNew.Size = new System.Drawing.Size(36, 36);
            this.btnScriptNew.Text = "Clear options";
            this.btnScriptNew.Click += new System.EventHandler(this.btnScriptNew_Click);
            // 
            // btnScriptOpen
            // 
            this.btnScriptOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnScriptOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptOpen.Image")));
            this.btnScriptOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScriptOpen.Name = "btnScriptOpen";
            this.btnScriptOpen.Size = new System.Drawing.Size(36, 36);
            this.btnScriptOpen.Text = "Load and Run Script";
            this.btnScriptOpen.Click += new System.EventHandler(this.btnScriptOpen_Click);
            // 
            // btnScriptSave
            // 
            this.btnScriptSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnScriptSave.Image = ((System.Drawing.Image)(resources.GetObject("btnScriptSave.Image")));
            this.btnScriptSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnScriptSave.Name = "btnScriptSave";
            this.btnScriptSave.Size = new System.Drawing.Size(36, 36);
            this.btnScriptSave.Text = "Save Script";
            this.btnScriptSave.Click += new System.EventHandler(this.btnScriptSave_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 39);
            // 
            // btnResultCopy
            // 
            this.btnResultCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResultCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnResultCopy.Image")));
            this.btnResultCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResultCopy.Name = "btnResultCopy";
            this.btnResultCopy.Size = new System.Drawing.Size(36, 36);
            this.btnResultCopy.Text = "Copy Results to Clipboard";
            this.btnResultCopy.Click += new System.EventHandler(this.btnResultCopy_Click);
            // 
            // btnResultSave
            // 
            this.btnResultSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResultSave.Image = ((System.Drawing.Image)(resources.GetObject("btnResultSave.Image")));
            this.btnResultSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResultSave.Name = "btnResultSave";
            this.btnResultSave.Size = new System.Drawing.Size(36, 36);
            this.btnResultSave.Text = "Save Results to File";
            this.btnResultSave.Click += new System.EventHandler(this.btnResultSave_Click);
            // 
            // btnResultAppend
            // 
            this.btnResultAppend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnResultAppend.Image = ((System.Drawing.Image)(resources.GetObject("btnResultAppend.Image")));
            this.btnResultAppend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnResultAppend.Name = "btnResultAppend";
            this.btnResultAppend.Size = new System.Drawing.Size(36, 36);
            this.btnResultAppend.Text = "Append Results to File";
            this.btnResultAppend.Click += new System.EventHandler(this.btnResultAppend_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(36, 36);
            this.btnAbout.Text = "He&lp";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.AutoSize = false;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(16, 31);
            // 
            // btnAdvanced
            // 
            this.btnAdvanced.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAdvanced.Image = ((System.Drawing.Image)(resources.GetObject("btnAdvanced.Image")));
            this.btnAdvanced.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdvanced.Name = "btnAdvanced";
            this.btnAdvanced.Size = new System.Drawing.Size(36, 36);
            this.btnAdvanced.Click += new System.EventHandler(this.btnAdvanced_Click);
            // 
            // chkClearResults
            // 
            this.chkClearResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkClearResults.AutoSize = true;
            this.chkClearResults.Checked = true;
            this.chkClearResults.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClearResults.Location = new System.Drawing.Point(316, 99);
            this.chkClearResults.Name = "chkClearResults";
            this.chkClearResults.Size = new System.Drawing.Size(99, 21);
            this.chkClearResults.TabIndex = 15;
            this.chkClearResults.Text = "Clear results";
            this.chkClearResults.UseVisualStyleBackColor = true;
            this.chkClearResults.CheckedChanged += new System.EventHandler(this.chkSensitive_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 18);
            this.ClientSize = new System.Drawing.Size(424, 402);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.cboPath);
            this.Controls.Add(this.btnFolder);
            this.Controls.Add(this.listBoxResults);
            this.Controls.Add(this.chkSensitive);
            this.Controls.Add(this.chkSubfolders);
            this.Controls.Add(this.chkClearResults);
            this.Controls.Add(this.chkReplace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkTrim);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboReplace);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboRegx);
            this.Controls.Add(this.cboMask);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(440, 440);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find RegX";
            this.Load += new System.EventHandler(this.Form_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private CheckBox chkSensitive;
        private ToolStrip toolStrip1;
        private ToolStripButton btnScriptNew;
        private ToolStripButton btnScriptOpen;
        private ToolStripButton btnScriptSave;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton btnResultCopy;
        private ToolStripButton btnAbout;
        private ToolStripButton btnResultSave;
        private ToolStripButton btnResultAppend;
        private ToolStripButton btnGo;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnAdvanced;
        private CheckBox chkClearResults;
    }
}
