using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navigateur_new
{

    public class webBrowserFunction : WebBrowser
    {
        TabPage tabpage = new TabPage();
        frmLibroSurf frmLibro = new frmLibroSurf();

        tabpage.Text = this.DocumentTitle;

    }
}
