using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ManiacEditor
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            Text = String.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            llAbout.Links.Clear();
            var koolkdevLink = new LinkLabel.Link(136, 8, "https://github.com/koolkdev/ManiacEditor") { Description = "koolkdev's GitHub page." };
            var otherworldbobLink = new LinkLabel.Link(197, 13, "https://github.com/OtherworldBob/ManiacEditor") { Description = "OtherworldBob's GitHub page." };
            var thesupersonic16Link = new LinkLabel.Link(215, 12, "https://github.com/thesupersonic16") { Description = "SuperSonic16's GitHub page." };

            llAbout.Links.Add(koolkdevLink);
            llAbout.Links.Add(otherworldbobLink);
            llAbout.Links.Add(thesupersonic16Link);
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }
        #endregion

        private void llAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(e.Link.LinkData.ToString());
                e.Link.Visited = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open the link. " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
