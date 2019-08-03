using System;
using System.Drawing;
using System.Windows.Forms;

namespace PinWin
{
    public class TrayApplicationContext : ApplicationContext
    {
        public ContextMenuStrip ContextMenu { get; private set; }

        public NotifyIcon NotifyIcon { get; private set; }

        public TrayApplicationContext(Icon icon)
        {
            ContextMenu = new ContextMenuStrip();
            NotifyIcon = new NotifyIcon()
            {
                Text = Application.ProductName,
                Icon = icon,
                ContextMenuStrip = ContextMenu,
                Visible = true
            };
            NotifyIcon.MouseClick += NotifyIcon_MouseClick;
            NotifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            Application.ApplicationExit += Application_ApplicationExit;
        }

        protected virtual void OnNotifyIconClick(EventArgs e) { }

        protected virtual void OnNotifyIconDoubleClick(EventArgs e) { }

        protected virtual void OnApplicationExit(EventArgs e) { }


        private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu.Show(Cursor.Position, ToolStripDropDownDirection.AboveRight);
            }
            else OnNotifyIconClick(e);

        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnNotifyIconDoubleClick(e);
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            OnApplicationExit(e);
            if (ContextMenu != null)
                ContextMenu.Dispose();
            if (NotifyIcon != null)
            {
                NotifyIcon.Visible = false;
                NotifyIcon.Dispose();
            }
        }
    }
}
