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
    public partial class fmProperties : Form
    {
        public fmProperties()
        {
            InitializeComponent();
        }

       
        private void fmProperties_Load(object sender, EventArgs e)
        {
            txtHomePage.Text = Properties.Settings.Default.HomePage;

            if(Properties.Settings.Default.HomePageOrBlankPage == 0)
            {
                cmbStartUp.SelectedIndex = 0;
            }
            else if (Properties.Settings.Default.HomePageOrBlankPage == 1)
            {
                cmbStartUp.SelectedIndex = 1;
            }

          //  Properties.Settings.Default.HomePageOrBlankPage = cmbStartUp.SelectedIndex.ToString();
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.HomePage = txtHomePage.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
    }
}
