using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GAFE
{
    public partial class frmMenuCatalogos : Form
    {
        public frmMenuCatalogos()
        {
            int wi;
            InitializeComponent();
            wi = this.Size.Width;
            Point tmplocation = new Point(wi, 0);
            cmdCerrar.Location = tmplocation;
        }

        private void Nav(Form form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void cmdCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void cmdClases_Click(object sender, EventArgs e)
        {
            lblCabeza.Text = "Catalogo de Clases";
            BarraSidePanel.Height = btnMenClases.Height;
            BarraSidePanel.Top = btnMenClases.Top;
            frmCatClases22 home = new frmCatClases22();
            Nav(home, PanContenido);
            txtError.Text = "Bienvenido...";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
