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
    public partial class frm_Browser : Form
    {
        public frm_Browser()
        {
            InitializeComponent();
            navigateTo("www.google.fr");
        }

        private string _currentUrl;

        private from_Browser_Controller controller;



        /// <summary>
        /// 
        /// </summary>
        public string CurrentUrl
        {
            get { return _currentUrl; }
            set 
            { 
                _currentUrl = value;
                webBrowser1.Navigate(value);
            }
        }
        

        public void navigateTo(string url)
        {
            try 
        	{
                webBrowser1.Navigate(url);
                _currentUrl = url;
	        }
	        catch (Exception ex)
	        {
                MessageBox.Show(ex.Message);
		        
	        }
        }

        private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            controller.OnDocumentLoaded(e.Url.ToString());
        }


        /// <summary>
        /// Back
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            controller.GoBack();
        }

        /// <summary>
        /// fORWARD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            controller.GoForward();
        }



    }
}
