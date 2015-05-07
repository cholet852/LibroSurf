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

        //Creation d'objet utile
        private History his = new History();
        private fmProperties properties = new fmProperties();
        

        //Lors de la fermeture du navigateur on enregistre l'historique dans un txt
        private void frmLibroSurf_FormClosing(object sender, FormClosingEventArgs e)
        {

            foreach (string link in (his.lstHistory.Items))
            {
                File.WriteAllText("c:/LibroSurf/historique.txt", link + System.Environment.NewLine);
            }
            
        }


        //Chargement de la fenêtre
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.ScriptErrorsSuppressed = false;
            initSearchEngines();

            if (Properties.Settings.Default.HomePageOrBlankPage == 0)
            {
               webBrowser1.Navigate(Properties.Settings.Default.HomePage);
            }


        //Charge les url du fichier txt dans la listBox de l'historique
        //On affiche d'abord la fenetre de l'historique, puis on copie le txt et on rend invisible la fenetre
        //La fonction "try" sert à gérer les exception en cas d'erreur
         try
         {
             his.Show();

             foreach (string link in (File.ReadAllLines("c:/LibroSurf/historique.txt")))
             {
                     his.lstHistory.Items.Add(link.ToString());
             }

             his.Visible = false;
         }
          
         catch (Exception ex)
         {
         }


        }

#region SearchEngines

        //Gestion de la liste des moteurs de recherche
        private void SearchEnginesList()
        {
            cmbSearchEngines.Items.Add("Google");
            cmbSearchEngines.Items.Add("Youtube");
            cmbSearchEngines.Items.Add("Bing");

            cmbSearchEngines.SelectedIndex = 0;
        }

        //Gestion de recherche selon le moteur
        private void txtUrlSearchEngines_KeyUp(object sender, KeyEventArgs e)
        {
            switch(cmbSearchEngines.SelectedIndex)
            {
                case 0:
                    if (e.KeyCode == Keys.Enter)
                    webBrowser1.Navigate("https://www.google.fr/search?q=" + txtUrlSearchEngines.Text);
                    break;

                case 1:
                    if (e.KeyCode == Keys.Enter)
                        webBrowser1.Navigate("https://www.youtube.com/results?search_query=" + txtUrlSearchEngines.Text);
                    break;

                case 2:
                    if (e.KeyCode == Keys.Enter)
                        webBrowser1.Navigate("https://www.bing.com/search?q=" + txtUrlSearchEngines.Text);
                    break;
            }
        }

        //Initialisation des moteurs de recherche
        private void initSearchEngines()
        {
            SearchEnginesList();
        }

#endregion;

#region Navigation
        
        //Précédent
        private void btnBack_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        //Suivant
        private void btnForward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        //Actualiser
        private void btnReload_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        //Page home avec variable HomePage definit sur google
        private void btnHome_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Properties.Settings.Default.HomePage);
        }

        //Appui sur entrer valide l'adresse et la passe au webBrowers navigate
        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                webBrowser1.Navigate(txtUrl.Text);
            }
        }


        //Ajoute un favicon a l'onglet
        private void webIcons()
        {
            WebClient wc = new WebClient();
            Uri uri1 = new Uri(webBrowser1.Url.ToString());
            MemoryStream memorystream = new MemoryStream(wc.DownloadData("http://" + uri1.Host + "/favicon.ico"));
           
            try
            {
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
            catch (Exception e)
            {
            }

        }

        //Gestion de la navigation en cours
        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            txtUrl.Text = webBrowser1.Url.ToString();//Affiche l'url de txtUrl dans le webBrowers

            webIcons();//Charge la gestion des favicons

            tabControl1.SelectedTab.Text = webBrowser1.DocumentTitle.ToString();//Affiche le documenTitle dans l'onglet

           
        }

        //Lorsque la page est complétement chargé
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            int index = his.lstHistory.FindString(txtUrl.Text);

            if (index >=0)
            {
                his.lstHistory.Items.Remove(txtUrl.Text);
            }

            his.lstHistory.Items.Add(txtUrl.Text);
        }


#endregion


        //Affiche la fenêtre des proprietées
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            properties.Show();
        }


        //Affiche la fenêtre de l'historique
        private void historiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            his.Visible = true;
        }


        //Complete le debut d'une recherche avec les premiere lettre
        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            txtUrl.AutoCompleteCustomSource.Clear();

            for (int i = his.lstHistory.Items.Count - 1; i >= 0; i--)
            {
                    his.lstHistory.SetSelected(i, true);
                    txtUrl.AutoCompleteCustomSource.Add(his.lstHistory.Items[i].ToString());
            }
        }

        

      

     
    }
}
