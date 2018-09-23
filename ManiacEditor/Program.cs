using System;
using System.IO;
using System.Reflection;
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

            bool allowedToLoad = false;
            try
            {
                using (var stream = GetObjectsIniResource())
                {
                    RSDKv5.Objects.InitObjects(stream);
                    allowedToLoad = true;
                }
            }
            catch (FileNotFoundException fnfe)
            {
                DisplayLoadFailure($@"{fnfe.Message}
Missing file: {fnfe.FileName}");
            }
            catch (Exception e)
            {
                DisplayLoadFailure(e.Message);
            }

            if (allowedToLoad)
            {
                new Editor().Run();
            }
        }

        private static void DisplayLoadFailure(string message)
        {
            MessageBox.Show(message,
                            "Unable to start.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        private static string GetExecutingDirectoryName()
        {
            string exeLocationUrl = Assembly.GetEntryAssembly().GetName().CodeBase;
            string exeLocation = new Uri(exeLocationUrl).LocalPath;
            return new FileInfo(exeLocation).Directory.FullName;
        }

        private static FileStream GetObjectsIniResource()
        {
            string executingDirectory = GetExecutingDirectoryName();
            string fullPathToIni = executingDirectory + @"\Resources\objects_attributes.ini";
            if (!File.Exists(fullPathToIni))
            {
                throw new FileNotFoundException("Unable to find the required file for naming objects and attributes.", 
                                                @"\Resources\objects_attributes.ini");
            }

            return new FileStream(fullPathToIni,
                                  FileMode.Open,
                                  FileAccess.Read,
                                  FileShare.Read);
        }
    }
}
