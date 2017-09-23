using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManiacEditor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("ManiacEditor.Resources.objects_attributes.ini"))
            {
                RSDKv5.Objects.InitObjects(stream);
            }
            Application.Run(new Editor());
        }
    }
}
