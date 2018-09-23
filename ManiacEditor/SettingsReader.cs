using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;


namespace ManiacEditor
{
    [Serializable]
    class SettingsReader
    {
        public static void exportSettings()
        {
            bool stillMore = true;
            int i = 0;
            int optionCount = 0;
            while (stillMore == true)
            {
                if (ConfigurationManager.AppSettings[i] != null)
                {
                    optionCount++;
                }
                else
                {
                    stillMore = false;
                }
                i++;
            }
            MessageBox.Show(optionCount.ToString(), "hey");

            /*for (int j = 0; j < optionCount; j++)
            {

            }*/


        }
        public static void importSettings()
        {

        }
    }

}
