using System;
using System.Windows.Forms;
using Bluegrams.Windows.Tools;
using PinWin.Properties;

namespace PinWin
{
    public partial class OptionsForm : Form
    {
        private MainApplicationContext main;
        private KeyCombination selectedKeys;

        public OptionsForm(MainApplicationContext main)
        {
            this.main = main;
            this.selectedKeys = main.HotKey?.KeyCombination ?? KeyCombination.None;
            InitializeComponent();
            // --- General section ---
            chkTruncateTitle.Checked = Settings.Default.TitleLengthLimit < int.MaxValue;
            numLimit.Value = Settings.Default.TitleLengthLimit;
            chkHotKey.Checked = main.HotKey != null;
            panHotKey.Enabled = chkHotKey.Checked;
            txtHotKey.Text = selectedKeys.ToString();
            // --- Application section ---
            chkUpdates.Checked = Settings.Default.AlwaysCheckForUpdates;
        }

        private void chkTruncateTitle_CheckedChanged(object sender, EventArgs e)
        {
            numLimit.Enabled = chkTruncateTitle.Checked;
        }

        private void chkHotKey_CheckedChanged(object sender, EventArgs e)
        {
            panHotKey.Enabled = chkHotKey.Checked;
        }

        private void butHotKey_Click(object sender, EventArgs e)
        {
            HotKeyInputForm hkForm = new HotKeyInputForm();
            hkForm.TopMost = this.TopMost;
            if (hkForm.ShowDialog() == DialogResult.OK)
            {
                selectedKeys = (KeyCombination)hkForm.SelectedKeys;
                txtHotKey.Text = selectedKeys.ToString();
            }
        }

        private void butSubmit_Click(object sender, EventArgs e)
        {
            // --- General section ---
            if (chkHotKey.Checked)
            {
                if (!main.SetHotKey(selectedKeys)) return;
            }
            else main.SetHotKey(KeyCombination.None);
            if (chkTruncateTitle.Checked)
                Settings.Default.TitleLengthLimit = (int)numLimit.Value;
            else Settings.Default.TitleLengthLimit = int.MaxValue;
            // --- Application section
            Settings.Default.AlwaysCheckForUpdates = chkUpdates.Checked;
            this.Close();
        }
    }
}
