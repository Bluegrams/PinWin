using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;

namespace PinWin
{
    public static class WinApi
    {
        private delegate bool EnumDelegate(IntPtr hWnd, int lParam);

        #region Win32 API methods

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumDelegate lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern IntPtr GetShellWindow();

        [DllImport("user32.dll")]
        private static extern long GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        #endregion

        public static Dictionary<IntPtr, string> GetWindowHandles()
        {
            IntPtr shellWindow = GetShellWindow();
            Dictionary<IntPtr, string> handles = new Dictionary<IntPtr, string>();
            EnumDelegate callback = (IntPtr hWnd, int lParam) =>
            {
                if (hWnd == shellWindow || !IsWindowVisible(hWnd)) return true;
                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;
                StringBuilder sb = new StringBuilder(length + 1);
                GetWindowText(hWnd, sb, sb.Capacity);
                var title = Regex.Replace(sb.ToString(), @"[\ue000-\uf8ff]", string.Empty);
                if (String.IsNullOrEmpty(title)) return true;
                handles.Add(hWnd, title);
                return true;
            };
            EnumWindows(callback, IntPtr.Zero);
            return handles;
        }

        public static bool GetWindowTopmost(IntPtr hWnd)
        {
            long val = GetWindowLong(hWnd, /* GWL_EXSTYLE */ -20);
            return (val & /* WS_EX_TOPMOST */ 0x8L) != 0;
        }

        public static bool SetWindowTopmost(IntPtr hWnd, bool topmost)
        {
            IntPtr mode = topmost ? /* HWND_TOPMOST */ (IntPtr)(-1) 
                                : /* HWND_NOTOPMOST */ (IntPtr)(-2);
            return SetWindowPos(hWnd, mode, 0, 0, 0, 0, /* SWP_NOMOVE | SWP_NOSIZE */ 0x1 | 0x2);
        }
    }
}
