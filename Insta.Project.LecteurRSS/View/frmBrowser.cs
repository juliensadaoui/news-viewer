using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Insta.Project.LecteurRSS
{
    public partial class frmBrowser : Form
    {
        public frmBrowser()
        {
            InitializeComponent();
            
        }

        private void OnFormResize(object sender, EventArgs e)
        {
            toolStripUrlBox.Width = this.Width - 80;
            toolStripUrlBox.Text = "http://www.google.fr";
        }

        private void OnLoad(object sender, EventArgs e)
        {
            OnFormResize(this, null);

            
            Browser.Navigated += new WebBrowserNavigatedEventHandler(OnPageComplete);
            Browser.Navigate(toolStripUrlBox.Text);
        }

        private void OnPageComplete(object sender, WebBrowserNavigatedEventArgs e)
        {
            toolStripUrlBox.Text = e.Url.ToString();
        }


        public void NavigateTo(string url)
        {
            Browser.Navigate(url);
            
        }

        public void GoBack()
        {

        }
    }
}
