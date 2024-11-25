using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OctagonHelpdesk.Reportes
{
    public partial class RptVistaPrevia : Form
    {
        public RptVistaPrevia()
        {
            InitializeComponent();
        }

        private void RptVistaPrevia_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
