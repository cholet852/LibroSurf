using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Navigateur_new
{
    public partial class frmLibroSurf : Form
    {
        public frmLibroSurf()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbSearchEngines.Items.Add("Google");
            cmbSearchEngines.Items.Add("Youtube");
            cmbSearchEngines.Items.Add("Wikipedia");
            cmbSearchEngines.Items.Add("Bing");

            cmbSearchEngines.SelectedIndex = 0;

            webBrowser1.Navigate("www.google.fr");

            if(cmbSearchEngines.SelectedIndex == 0)
            {
                webBrowser1.Navigate("www.google.fr");
            }
            else if(cmbSearchEngines.SelectedIndex == 1)
            {
                webBrowser1.Navigate("www.youtube.fr");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtUrl.Text = webBrowser1.Url.ToString();
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(txtUrl.Text);
            }
        }

        private void webIcons()
        {
            WebClient wc = new WebClient();
            MemoryStream memorystream = new MemoryStream(wc.DownloadData("http://" & new Uri(webBrowser1.Url.ToString).Host & "/icons.ico"));
            Icon icon = new Icon(memorystream);
        }


    }
}
