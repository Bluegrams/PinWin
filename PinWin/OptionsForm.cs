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
            numLimit.Enabled = chkTruncateTitle.Checked;
            if (chkTruncateTitle.Checked)
            {
                numLimit.Value = Settings.Default.TitleLengthLimit;
            }
            chkWindowsAtEnd.Checked = Settings.Default.WindowsListAtEnd;
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
            // remove current shortcut during key selection
            main.SetHotKey(KeyCombination.None);
            HotKeyInputForm hkForm = new HotKeyInputForm((Keys)selectedKeys);
            if (hkForm.ShowDialog(this) == DialogResult.OK)
            {
                selectedKeys = (KeyCombination)hkForm.SelectedKeys;
                txtHotKey.Text = selectedKeys.ToString();
            }
            // restores previous shortcut
            main.SetHotKey(selectedKeys);
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
            Settings.Default.WindowsListAtEnd = chkWindowsAtEnd.Checked;
            // --- Application section
            Settings.Default.AlwaysCheckForUpdates = chkUpdates.Checked;
            this.Close();
        }
    }
}
