using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatSql;

namespace GAFE
{
    public partial class frmRegTipoMovtos : Form
    {
        private int opcion;
        private MsSql db = null;


        public frmRegTipoMovtos()
        {
            InitializeComponent();
        }

        public frmRegTipoMovtos(MsSql Odat, int Op, String Cod="")
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;
            PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);
            LimpiarControles();
            OpcionControles(true);
            switch (opcion)
            {
                case 1:
                    OpcionControles(true);
                break;
                case 2:
                    pui.keyCveTipoMov = Cod;
                    pui.EditarTipoMov();
                    txtClaveTipoMov.Text = pui.keyCveTipoMov;
                    txtDescripcion.Text = pui.cmpDescripcion;
                    txtClaveTipoMov.Enabled = false;
                break;
                case 3:
                    pui.keyCveTipoMov = Cod;
                    pui.EditarTipoMov();
                    txtClaveTipoMov.Text = pui.keyCveTipoMov;
                    txtDescripcion.Text = pui.cmpDescripcion;

                    OpcionControles(false);
                break;

            }

        }

        private void frmRegTipoMovtos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            switch (opcion)
            {
                case 1: Agregar(); break;
                case 2: Editar(); break;
                case 3: this.Size = this.MinimumSize; break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Size = this.MinimumSize;
            LimpiarControles();
            OpcionControles(true);
        }

        private void Agregar()
        {
            if (Validar())
            {
                PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);

                pui.keyCveTipoMov = txtClaveTipoMov.Text;
                pui.cmpDescripcion = txtDescripcion.Text;


                if (pui.AgregarTipoMov() >= 1)
                {
                    MessageBox.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.Close();
                }

            }
        }

        private void Editar()
        {
            try
            {
                if (Validar())
                {
                    PuiCatTipoMovtos pui = new PuiCatTipoMovtos(db);

                    pui.keyCveTipoMov = txtClaveTipoMov.Text;
                    pui.cmpDescripcion = txtDescripcion.Text;

                    if (pui.ActualizaTipoMov() >= 0)
                    {
                        MessageBox.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Size = this.MinimumSize;
                    }
                    //grdView.CurrentRow.Index = idxG;  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        private Boolean Validar()
        {
            Boolean dv = true;
            ClsUtilerias Util = new ClsUtilerias();
            if (String.IsNullOrEmpty(txtClaveTipoMov.Text))
            {
                MessageBox.Show("Código: No puede ir vacío.", "CatTipoMoves", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveTipoMov.Text))
                {
                    MessageBox.Show("Código: Contiene caracteres no validos.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Descripción: No puede ir vacío.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBox.Show("Descripción: Contiene caracteres no validos.", "CatTipoMovtos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            return dv;
        }



        private void OpcionControles(Boolean Op)
        {
            txtClaveTipoMov.Enabled = Op;
            txtDescripcion.Enabled = Op;
        }

        private void LimpiarControles()
        {
            txtClaveTipoMov.Text = "";
            txtDescripcion.Text = "";
        }

    }
}
