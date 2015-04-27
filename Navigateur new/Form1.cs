using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        


    }
}
