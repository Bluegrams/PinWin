using System;
using System.Reflection;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using PinWin.Properties;
using Bluegrams.Windows.Tools;
using Bluegrams.Application.WinForms;
using Bluegrams.Application;

namespace PinWin
{
    public class MainApplicationContext : TrayApplicationContext
    {
        private bool notify = true;
        private IUpdateChecker updateChecker;

        public GlobalHotKey HotKey { get; private set; }

        public MainApplicationContext() : base(Resources.PinWinIconWhite)
        {
            ContextMenu.Opening += ContextMenu_Opening;
            if (!String.IsNullOrWhiteSpace(Settings.Default.HotKey))
            {
                var keyConv = new KeysConverter();
                Keys keys = (Keys)keyConv.ConvertFromInvariantString(Settings.Default.HotKey);
                SetHotKey((KeyCombination)keys);
            }
            Application.ApplicationExit += Application_ApplicationExit;
            updateChecker = new WinFormsUpdateChecker(Program.UpdateCheckUrl);
            if (Settings.Default.AlwaysCheckForUpdates)
                updateChecker.CheckForUpdates();
        }

        public bool SetHotKey(KeyCombination keyCombination)
        {
            HotKey?.Dispose();
            HotKey = null;
            if (keyCombination == KeyCombination.None) return true;
            HotKey = new GlobalHotKey(keyCombination, onHotKeyPressed);
            if (!HotKey.Register())
            {
                MessageBox.Show("Failed to register global shortcut.\nThis may happen if the defined shortcut is already in use.", "PinWin - Error");
                return false;
            }
            return true;
        }

        protected override void OnNotifyIconClick(EventArgs e)
        {
            // this somehow lets the context menu behave correctly
            MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
            mi.Invoke(NotifyIcon, null);
            ContextMenu.Show(Cursor.Position, ToolStripDropDownDirection.AboveRight);
        }

        private void onHotKeyPressed(GlobalHotKey _) => selectWindowFromScreen();

        private void selectWindowFromScreen()
        {
            if (notify)
            {
                NotifyIcon.BalloonTipText = "Select a window from screen to pin it on top. Press 'Esc' to exit.";
                NotifyIcon.ShowBalloonTip(1);
                notify = false;
            }
            var overlay = new OverlayForm();
            overlay.TopMost = true;
            if (overlay.ShowDialog() == DialogResult.OK)
            {
                WinApi.SetWindowTopmost(overlay.SelectionHandle, true);
            }
        }

        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            ContextMenu.Items.Clear();

            var windowsItems = new List<ToolStripMenuItem>();
            foreach (var kv in WinApi.GetWindowHandles())
            {
                bool topmost = WinApi.GetWindowTopmost(kv.Key);
                string truncated = kv.Value.Substring(0, Math.Min(kv.Value.Length, Settings.Default.TitleLengthLimit));
                windowsItems.Add(new ToolStripMenuItem(truncated, null,
                    (o, args) => WinApi.SetWindowTopmost(kv.Key, !topmost))
                {
                    Checked = topmost,
                    ToolTipText = kv.Value
                });
            };

            var generalItems = new List<ToolStripMenuItem>()
            {
                new ToolStripMenuItem("Select Window From Screen", Resources.TargetIcon, onSelectWindowClicked),
                new ToolStripMenuItem("Unpin All Windows", Resources.DeleteIcon, onUnpinAllClicked),
                new ToolStripMenuItem("Options", Resources.OptionsIcon, onOptionsClicked),
                new ToolStripMenuItem("About", Resources.AboutIcon, onAboutClicked),
                new ToolStripMenuItem("Exit", null, onExitClicked),
            };

            if (Settings.Default.WindowsListAtEnd)
            {
                ContextMenu.Items.AddRange(generalItems.ToArray());
                ContextMenu.Items.Add(new ToolStripSeparator());
                ContextMenu.Items.AddRange(windowsItems.ToArray());
            }
            else
            {
                ContextMenu.Items.AddRange(windowsItems.ToArray());
                ContextMenu.Items.Add(new ToolStripSeparator());
                ContextMenu.Items.AddRange(generalItems.ToArray());
            }

            e.Cancel = false;
        }

        private void onSelectWindowClicked(object sender, EventArgs e) => selectWindowFromScreen();

        private void onUnpinAllClicked(object sender, EventArgs e)
        {
            foreach (var kv in WinApi.GetWindowHandles())
            {
                WinApi.SetWindowTopmost(kv.Key, false);
            }
        }

        private void onOptionsClicked(object sender, EventArgs e)
        {
            var optionsForm = new OptionsForm(this);
            optionsForm.ShowDialog();
        }

        private void onAboutClicked(object sender, EventArgs e)
        {
            var aboutForm = new AboutForm(Resources.PinWinIconBlack.ToBitmap());
            aboutForm.HighlightColor = Color.Black;
            aboutForm.UpdateChecker = updateChecker;
            aboutForm.StartPosition = FormStartPosition.CenterScreen;
            aboutForm.ShowDialog();
        }

        private void onExitClicked(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (HotKey != null)
            {
                KeysConverter keyConv = new KeysConverter();
                Settings.Default.HotKey = keyConv.ConvertToInvariantString((Keys)HotKey?.KeyCombination);
            }
            else Settings.Default.HotKey = null;
            Settings.Default.Save();
            HotKey?.Dispose();
        }
    }
}
