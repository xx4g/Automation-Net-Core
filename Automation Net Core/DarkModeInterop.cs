using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Net_Core
{
    internal class DarkModeInterop
    {

        [System.Runtime.InteropServices.DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        const int DWWMA_CAPTION_COLOR = 35;

        const int DWWMA_BORDER_COLOR = 34;
        const int DWMWA_TEXT_COLOR = 36;

        internal static bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            try
            {
                int[] colorstr = new int[] { 000000 };
                int[] lighterGreen = new int[] { 0x00BBAA00 };
                //uint newBorderColor = 0x00FF00; // Light green border color
                DwmSetWindowAttribute(handle, DWWMA_CAPTION_COLOR, colorstr, 4);
                DwmSetWindowAttribute(handle, DWWMA_BORDER_COLOR, lighterGreen, 4);
                DwmSetWindowAttribute(handle, DWMWA_TEXT_COLOR, lighterGreen, 4);
            }
            catch (Exception ex)
            {

                // System.Windows.Forms.MessageBox.Show( "error assigning hwnd == " + ex.ToString());
            }

            return false;
        }

        private static bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }
    }
}
