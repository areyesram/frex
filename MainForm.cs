using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Aryes
{
    internal sealed partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private static MainForm _form;

        private void Form_Load(object sender, EventArgs e)
        {
            LoadConfig();
            UpdateEnabled();
            Core.FindRegX.FileProcessed += (file, failReason) =>
                                               {
                                                   _form.statusMatches.Text = Core.FindRegX.Matches.ToString();
                                                   _form.statusLabel.Text = file;
                                               };
            Core.FindRegX.FileSkipped += (file, failReason) => _form.statusLabel.Text = file;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                GoFind();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message + exception.StackTrace);
            }
        }

        private void GoFind()
        {
            if (!IsValid()) return;

            btnGo.Enabled = false;
            SaveConfig();

            Core.FindRegX.Pattern = cboMask.Text;
            Core.FindRegX.Recursive = chkSubfolders.Checked;
            Core.FindRegX.Regex = cboRegx.Text;
            Core.FindRegX.Replace = chkReplace.Checked ? cboReplace.Text : string.Empty;
            Core.FindRegX.Trim = chkTrim.Checked;
            statusLabel.Text = "Preparing scan...";
            statusLabel.Text = string.Empty;
            _form = this;
            Core.FindRegX.Start(cboPath.Text, chkClearResults.Checked);
            var array = Core.FindRegX.Results;
            Array.Sort(array);
            listBoxResults.DataSource = array;
            _form.statusLabel.Text = "done";

            LoadConfig();
            btnGo.Enabled = true;
        }


        private void LoadConfig()
        {
            //cboPath.Text = Settings.Default.Path.First().Value;
            LoadCombo(cboMask, Settings.Default.Mask);
            LoadCombo(cboRegx, Settings.Default.RegX);
            LoadCombo(cboReplace, Settings.Default.Replace);
            chkSubfolders.Checked = Settings.Default.Recurse;
            chkReplace.Checked = Settings.Default.CheckReplace;
            chkTrim.Checked = Settings.Default.CheckTrim;
        }

        private static void LoadCombo(ComboBox control, IEnumerable data)
        {
            control.DisplayMember = "Value";
            control.ValueMember = "Value";
            control.DataSource = data;
        }

        private void SaveConfig()
        {
            Settings.Default.Path = Helper.Config.AddRecent(Settings.Default.Path, cboPath.Text);
            Settings.Default.Mask = Helper.Config.AddRecent(Settings.Default.Mask, cboMask.Text);
            Settings.Default.RegX = Helper.Config.AddRecent(Settings.Default.RegX, cboRegx.Text);
            Settings.Default.Replace = Helper.Config.AddRecent(Settings.Default.Replace, cboReplace.Text);
            Settings.Default.Recurse = chkSubfolders.Checked;
            Settings.Default.CheckReplace = chkReplace.Checked;
            Settings.Default.CheckTrim = chkTrim.Checked;
            Settings.Default.Save();
        }

        private bool IsValid()
        {
            if (File.Exists(cboPath.Text))
            {
                cboMask.Text = Path.GetFileName(cboPath.Text);
                cboPath.Text = Path.GetDirectoryName(cboPath.Text);
            }
            else if (!Directory.Exists(cboPath.Text))
            {
                MessageBox.Show("Path does not exist");
                return false;
            }
            return true;
        }

        private void btnAdvanced_Click(object sender, EventArgs e)
        {
            new ReplaceForm().ShowDialog();
        }

        private void mnuResultSave_Click(object sender, EventArgs e)
        {
            PromptSaveResults(true);
        }

        private void PromptSaveResults(bool append)
        {
            var dialog = append ? (FileDialog)openFileDialog : saveFileDialog;
            dialog.DefaultExt = ".txt";
            dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (dialog.ShowDialog() != DialogResult.OK) return;
            if (listBoxResults.DataSource == null)
            {
                MessageBox.Show("No results to save.");
                return;
            }
            var file = dialog.FileName;
            SaveResults(file, append);
            Process.Start("notepad", file);
        }

        private void SaveResults(string fileName, bool append)
        {
            var sw = append ? File.AppendText(fileName) : File.CreateText(fileName);
            foreach (var s in (string[])listBoxResults.DataSource)
                sw.WriteLine(s);
            sw.Close();
        }

        private void mnuResultCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void CopyToClipboard()
        {
            var s = new StringBuilder();
            foreach (var str in (string[])listBoxResults.DataSource)
                s.AppendLine(str);
            Clipboard.SetText(s.ToString());
        }

        private void chkReplace_CheckedChanged(object sender, EventArgs e)
        {
            UpdateEnabled();
        }

        private void UpdateEnabled()
        {
            cboReplace.Enabled = chkReplace.Checked;
        }

        private void chkSubfolders_CheckedChanged(object sender, EventArgs e)
        {
            //cboPath.Recursive = chkSubfolders.Checked;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            //cboPath.BrowseForDirectory();
        }

        private void cboPath_Validating(object sender, CancelEventArgs e)
        {
            SplitFilename(cboPath.Text);
        }

        private void SplitFilename(string s)
        {
            if (!File.Exists(s)) return;
            cboMask.Text = Path.GetFileName(s);
            cboPath.Text = Path.GetDirectoryName(s);
            chkSubfolders.Checked = false;
        }

        private void cboPath_RecursiveChanged(object sender, EventArgs e)
        {
            //chkSubfolders.Checked = cboPath.Recursive;
        }

        private void chkSensitive_CheckedChanged(object sender, EventArgs e)
        {
            Core.FindRegX.CaseSensitive = chkSensitive.Checked;
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Find Regular Expressions\n\n{0}\n" + "Copyright © 2009-2012 Aryes",
                Assembly.GetExecutingAssembly().FullName),
                "FindRegX",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnScriptOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.DefaultExt = ".rgx";
            openFileDialog.Filter = "FindRegX scripts (*.rgx)|*.rgx|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != DialogResult.OK) return;
            using (var sr = File.OpenText(openFileDialog.FileName))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(s) || s.StartsWith("#")) continue;
                    var c = Parse(s);
                    switch (c.Operator)
                    {
                        case OpCodes.PATH:
                            //cboPath.SelectedIndex = -1;
                            cboPath.Text = c.Operand;
                            break;
                        case OpCodes.RECURSE:
                            chkSubfolders.Checked = OhItIsOn(c);
                            break;
                        case OpCodes.CLEAR:
                            chkClearResults.Checked = OhItIsOn(c);
                            break;
                        case OpCodes.MASK:
                            cboMask.SelectedIndex = -1;
                            cboMask.Text = c.Operand;
                            break;
                        case OpCodes.FIND:
                            cboRegx.SelectedIndex = -1;
                            cboRegx.Text = c.Operand;
                            break;
                        case OpCodes.REPLACE:
                            chkReplace.Checked = c.Operand != null;
                            cboReplace.SelectedIndex = -1;
                            cboReplace.Text = c.Operand;
                            break;
                        case OpCodes.TRIM:
                            chkTrim.Checked = OhItIsOn(c);
                            break;
                        case OpCodes.GO:
                            GoFind();
                            break;
                        default:
                            MessageBox.Show(string.Format("Unrecognized command: {0}", s));
                            return;
                    }
                    Application.DoEvents();
                }
            }
        }

        private static bool OhItIsOn(Command c)
        {
            return string.Compare(c.Operand, "ON", StringComparison.OrdinalIgnoreCase) == 0;
        }

        private readonly Regex reParse = new Regex(@"^(\w+) ?(.+)?$", RegexOptions.Compiled);

        private Command Parse(string s)
        {
            var m = reParse.Match(s);
            var oper = m.Groups[1].Value;
            foreach (var v in Enum.GetValues(typeof(OpCodes)))
            {
                if (string.Compare(oper, v.ToString(), StringComparison.OrdinalIgnoreCase) == 0)
                    return new Command
                    {
                        Operator = (OpCodes)v,
                        Operand = m.Groups[2].Value
                    };
            }
            return Command.Empty;
        }

        private struct Command
        {
            internal static readonly Command Empty = new Command { Operator = OpCodes.NONE };

            internal OpCodes Operator;
            internal string Operand;
        }

        private void btnScriptNew_Click(object sender, EventArgs e)
        {
            cboPath.Text = string.Empty;
            cboMask.SelectedIndex = -1;
            chkClearResults.Checked = true;
            cboRegx.SelectedIndex = -1;
            chkReplace.Checked = true;
            cboReplace.SelectedIndex = -1;
            chkReplace.Checked = false;
            chkSubfolders.Checked = true;
            chkTrim.Checked = false;
            listBoxResults.DataSource = null;
        }

        private void btnScriptSave_Click(object sender, EventArgs e)
        {
            PromptSaveScript();
        }

        private void PromptSaveScript()
        {
            saveFileDialog.DefaultExt = ".rgx";
            saveFileDialog.Filter = "FindRegX scripts (*.rgx)|*.rgx|All files (*.*)|*.*";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
            if (listBoxResults.DataSource == null)
            {
                MessageBox.Show("No results to save.");
                return;
            }
            SaveScript(saveFileDialog.FileName);
        }

        private void SaveScript(string file)
        {
            var sw = File.CreateText(file);
            sw.Emit(OpCodes.PATH, cboPath.Text);
            sw.Emit(OpCodes.RECURSE, chkSubfolders.Checked);
            sw.Emit(OpCodes.CLEAR, chkClearResults.Checked);
            sw.Emit(OpCodes.MASK, cboMask.Text);
            sw.Emit(OpCodes.FIND, cboRegx.Text);
            sw.Emit(OpCodes.REPLACE, chkReplace.Checked ? cboReplace.Text : null);
            sw.Emit(OpCodes.TRIM, chkTrim.Checked);
            sw.Emit(OpCodes.GO);
            GoFind();
            sw.Close();
        }

        private void btnResultCopy_Click(object sender, EventArgs e)
        {
            CopyToClipboard();
        }

        private void btnResultSave_Click(object sender, EventArgs e)
        {
            PromptSaveResults(false);
        }

        private void btnResultAppend_Click(object sender, EventArgs e)
        {
            PromptSaveResults(true);
        }
    }
}
