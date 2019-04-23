using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    public partial class frmRegInventarioMovtos : Form
    {
        private int opcion;
        private MsSql db = null;
        private int folMovto;


        public frmRegInventarioMovtos()
        {
            InitializeComponent();
        }

        public frmRegInventarioMovtos(MsSql Odat, int Op, String TipoDocInv)
        {
            InitializeComponent();
            opcion = Op;
            db = Odat;
            
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            pui.keyNoMovimiento = "1";
            pui.cmpFechaMovimiento = Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", DateTime.Now));
            pui.cmpCveTipoMov = "";
            pui.cmpEntSal = "";
            pui.cmpNoDoc = "";
            pui.cmpDocumento = "";
            pui.cmpCveAlmacenDes = "";
            pui.cmpCveTipoMovDest = "";
            pui.cmpEntSalDest = "";
            pui.cmpModulo = "";
            pui.cmpTipoDoc = "";
            pui.cmpSerieDoc = "";
            pui.cmpFolioDocOrigen = "";
            pui.cmpDescuento = 0;
            pui.cmpTotalDscto = 0;
            pui.cmpTIva = 0;
            pui.cmpSubTotal = 0;
            pui.cmpTotalDoc = 0;
            pui.cmpCveProveedor = "";
            pui.cmpCveCliente = "";
            pui.cmpCancelado = 1;
            pui.cmpCveUsarioCaptu = "";
            pui.cmpCveCentroCosto = "";
            pui.cmpNoMovtoTra = "";
            pui.cmpDocTra = "";


            pui.AgregarBlanco();

            LimpiarControles();
            OpcionControles(true);
            //LleCboClaseMov();
            switch (opcion)
            {
                case 1://Nuevo
                    OpcionControles(true);
                break;
                case 2://Edita
                    //get_Campos(Cod);
                    //txtClaveTipoMov.Enabled = false;
                break;
                case 3://Consulta
                    //get_Campos(Cod);
                    OpcionControles(false);
                    //cboTipoMovRel.Enabled = false;
                break;

            }
            
        }

        private void get_Campos(String Cod)
        {
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            //pui.keyCveTipoMov = Cod;
            //pui.EditarTipoMov();
/*
            txtClaveTipoMov.Text = pui.keyCveTipoMov;
            txtDescripcion.Text = pui.cmpDescripcion;
            txtDescCorta.Text = pui.cmpDescCorta;
            rdbEntrada.Checked = pui.cmpEntSal == "E" ? true : false;
            rdbSalida.Checked = pui.cmpEntSal == "S" ? true : false;
            //cboCveClsMov.SelectedIndex = GetCboSelectIndex(cboCveClsMov, pui.cmpCveClsMov);
            cboCveClsMov.SelectedValue = pui.cmpCveClsMov;
            cboTipoMovRel.SelectedValue = pui.cmpTipoMovRel; 
            txtFoliador.Text = pui.cmpFoliador;
            chkEditaFoli.Checked = pui.cmpEditaFoli == 1 ? true : false;
            chkEstraspaso.Checked = pui.cmpEsTraspaso == 1 ? true : false;
            txtFmtoImpresion.Text = pui.cmpFmtoImpresion;
            chkAfectaCosto.Checked = pui.cmpAfectaCosto == 1 ? true : false;
            chkSugiereCosto.Checked = pui.cmpSugiereCosto == 1 ? true : false;
            chkMuestraCosto.Checked = pui.cmpMuestraCosto == 1 ? true : false;
            chkEditaCosto.Checked = pui.cmpEditaCosto == 1 ? true : false;

            chkSolicitaCosto.Checked = pui.cmpSolicitaCosto == 1 ? true : false;
            chkCalculaIva.Checked = pui.cmpCalculaIva == 1 ? true : false;
            //chkEditaCosto.Checked = pui.cmpPideCentroCosto == 1 ? true : false;
            chkEstatus.Checked = pui.cmpEstatus == 1 ? true : false;
            */
        }


        private void frmRegInventarioMovtos_KeyDown(object sender, KeyEventArgs e)
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
                case 3: this.Close(); break;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            OpcionControles(true);
            this.Close();
        }

        private void Agregar()
        {
            if (Validar())
            {
                //PuiCatInventarioMov pui = new PuiCatInventarioMov(db);

                //if (pui.AgregarTipoMov() >= 1)
                if (set_Campos() >= 1)
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
                    //if (pui.ActualizaTipoMov() >= 0)
                    if (set_Campos() >= 0)
                    {
                        MessageBox.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tienes que seleccionar un registro \n" + ex.Message + " " + ex.StackTrace.ToString(),
                    "Error al editar", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        public int set_Campos()
        {
            /*
            string _tipomovrel = (cboCveClsMov.Text == "TRASPASO") ? Convert.ToString(cboTipoMovRel.SelectedValue) : "";
            PuiCatInventarioMov pui = new PuiCatInventarioMov(db);
            pui.keyCveTipoMov = txtClaveTipoMov.Text;
            pui.cmpDescripcion = txtDescripcion.Text;
            pui.cmpDescCorta = txtDescCorta.Text;
            pui.cmpEntSal = rdbEntrada.Checked ? "E" : "S";
            pui.cmpCveClsMov =  Convert.ToString(cboCveClsMov.SelectedValue);
            pui.cmpTipoMovRel = _tipomovrel;
            pui.cmpFoliador = txtFoliador.Text;
            pui.cmpEditaFoli = chkEditaFoli.Checked ? 1 : 0;
            pui.cmpEsTraspaso = chkEstraspaso.Checked ? 1 : 0;
            pui.cmpFmtoImpresion = txtFmtoImpresion.Text;
            pui.cmpAfectaCosto = chkAfectaCosto.Checked ? 1 : 0;
            pui.cmpSugiereCosto = chkSugiereCosto.Checked ? 1 : 0;
            pui.cmpMuestraCosto = chkMuestraCosto.Checked ? 1 : 0;
            pui.cmpEditaCosto = chkEditaCosto.Checked ? 1 : 0;
            pui.cmpSolicitaCosto = chkSolicitaCosto.Checked ? 1 : 0;
            pui.cmpCalculaIva = chkCalculaIva.Checked ? 1 : 0;
            pui.cmpPideCentroCosto = 0;
            pui.cmpEstatus = chkEstatus.Checked ? 1 : 0;

            return opcion == 1 ? pui.AgregarTipoMov() : pui.ActualizaTipoMov();
            -*/
            return 1;
        }


        private Boolean Validar()
        {
            Boolean dv = true;
            ClsUtilerias Util = new ClsUtilerias();
            

            return dv;
        }



        private void OpcionControles(Boolean Op)
        {
            /*
            txtClaveTipoMov.Enabled = Op;
            txtDescripcion.Enabled = Op;

            txtDescCorta.Enabled = Op;
            rdbEntrada.Enabled = Op;
            rdbSalida.Enabled = Op;
            cboCveClsMov.Enabled = Op;
            txtFoliador.Enabled = Op;
            chkEditaFoli.Enabled = Op;
            chkEstraspaso.Enabled = Op;
            //txtTipoMovRel.Text = pui.cmpTipoMovRel;
            txtFmtoImpresion.Enabled = Op;
            chkAfectaCosto.Enabled = Op;
            chkSugiereCosto.Enabled = Op;
            chkMuestraCosto.Enabled = Op;
            chkEditaCosto.Enabled = Op;

            chkSolicitaCosto.Enabled = Op;
            chkCalculaIva.Enabled = Op;
            //chkEditaCosto.Enabled = Op;
            chkEstatus.Enabled = Op;
            */
        }

        private void LimpiarControles()
        {
            /*
            txtClaveTipoMov.Text = "";
            txtDescripcion.Text = "";
            */
        }

        private void cmdCancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        /*
        private void LleCboClaseMov()
        {
            
            PuiCatInventarioMov lin = new PuiCatInventarioMov(db);
            cboCveClsMov.DataSource = lin.CboLstClaseMov();
            cboCveClsMov.ValueMember = "CveClsMov";
            cboCveClsMov.DisplayMember = "Descripcion";
        }

        private void LleCboMovRel()
        {
            PuiCatInventarioMov lin = new PuiCatInventarioMov(db);
            cboTipoMovRel.DataSource = lin.CboLstMovRel();
            cboTipoMovRel.ValueMember = "CveTipoMov";
            cboTipoMovRel.DisplayMember = "Descripcion";

        }

        private void cboCveClsMov_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboCveClsMov.Text == "TRASPASO")
            {
                cboTipoMovRel.Enabled = true;
                LleCboMovRel();
            }
            else
            {
                cboTipoMovRel.Enabled = false;
                cboTipoMovRel.Text = "";
            }

        }
        */

        /*Recorre un cbo y retorna el index
         * 
        private static int GetCboSelectIndex(ComboBox combobx, string value)
        {
            for (int i = 0; i <= combobx.Items.Count - 1; i++)
            {
                DataRowView cb = (DataRowView)combobx.Items[i];
                MessageBox.Show("Registro " + cb.Row.ItemArray[0].ToString(), "Confirmacion", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                if (cb.Row.ItemArray[0].ToString() == value)
                    return i;
            }
            return -1;
        }
        */
    }
}
