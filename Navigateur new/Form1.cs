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

        int i;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Ajouts moteur de recherche dans le SearchEngines
            cmbSearchEngines.Items.Add("Google");
            cmbSearchEngines.Items.Add("Youtube");
            cmbSearchEngines.Items.Add("Wikipedia");
            cmbSearchEngines.Items.Add("Bing");

            cmbSearchEngines.SelectedIndex = 0;//On selectionne l'index 0 du SearchEngines

            webBrowser1.Navigate("www.google.fr");//On attribut "Google.fr" au webBrowers

           
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();//precedent
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
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

            Uri uri1 = new Uri(webBrowser1.Url.ToString());

            MemoryStream memorystream = new MemoryStream(wc.DownloadData("http://" + uri1.Host + "/favicon.ico"));

            Icon icon = new Icon(memorystream);

            if (imageList1.Images.Count == -1)
            {
                imageList1.Images.Add(icon.ToBitmap());
                tabControl1.SelectedTab.ImageIndex = 0;
            }
            else
            {
                imageList1.Images.Clear();
                imageList1.Images.Add(icon.ToBitmap());
                tabControl1.SelectedTab.ImageIndex = 0;
            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtUrl.Text = webBrowser1.Url.ToString();
            webIcons();
        }


        private void addTab()
        {
            WebBrowser browser = new WebBrowser();
            TabPage tab = new TabPage();
            browser.Tag = tab;
            tab.Tag = browser;
            tabControl1.TabPages.Add(tab);
            tab.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            browser.Navigate("www.google.fr");
            tabControl1.SelectedTab = tab;
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            addTab();
            txtUrl.Text = webBrowser1.Url.ToString();
            webIcons();
           
        }

        private void txtUrlSearchEngines_KeyUp(object sender, KeyEventArgs e)
        {
            switch (cmbSearchEngines.SelectedIndex)
            {
            
                case 0:
                    if (e.KeyCode == Keys.Enter)
                    {
                        webBrowser1.Navigate("https://www.google.fr/webhp?hl=fr#hl=fr&q=" + txtUrlSearchEngines.Text);
                    }
                    break;

                case 1:
                    if (e.KeyCode == Keys.Enter)
                    {
                        webBrowser1.Navigate("https://www.youtube.com/?hl=fr&gl=FR" + txtUrlSearchEngines.Text);
                    }
                    break;

                case 2:
                    if (e.KeyCode == Keys.Enter)
                    {
                        webBrowser1.Navigate("https://fr.wikipedia.org/wiki/Wikip%C3%A9dia:Accueil_principal" + txtUrlSearchEngines.Text);
                    }
                    break;
            }
        }



    }
}
