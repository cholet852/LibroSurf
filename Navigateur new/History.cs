using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Navigateur_new
{
    public partial class History : Form
    {
        public History()
        {
            InitializeComponent();
        }

        private void History_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;

        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            lstHistory.Items.Clear();
            File.Delete("c:/LibroSurf/historique.txt");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
