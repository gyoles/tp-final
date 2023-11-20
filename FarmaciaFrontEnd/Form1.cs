using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciaFrontEnd
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEditArticulos FrmAltaArt = new FrmEditArticulos();
            FrmAltaArt.ShowDialog();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsultarArt().ShowDialog();
        }
    }
}
