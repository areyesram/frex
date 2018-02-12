using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Aryes
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ReplaceForm : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public List<BE.ReplacementInfo> repl;

        private void buttonOk_Click(object sender, EventArgs e)
        {
            Core.FindRegX.Replacements = repl.ToArray();
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            var sel = grid.SelectedRows;
            if (sel.Count != 0)
                repl.RemoveAt(sel[0].Index);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxFind.Text.Length == 0) return;
            repl.Add(new BE.ReplacementInfo
            {
                TextToFind = textBoxFind.Text,
                ReplaceWith = textBoxReplace.Text
            });
            grid.DataSource = repl;
            textBoxFind.Text = string.Empty;
            textBoxReplace.Text = string.Empty;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            repl.Clear();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //TODO:
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //TODO:
        }

        private void ReplaceForm_Load(object sender, EventArgs e)
        {
            repl = new List<BE.ReplacementInfo>(Core.FindRegX.Replacements);
            grid.DataSource = repl;
        }
    }
}