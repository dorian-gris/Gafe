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
using System.Xml;
using System.IO;


namespace GAFE
{
    public partial class frmCatArticulos : Form
    {
        private int _Opcion;
        private String _KeyCampo;

        private SqlDataAdapter DatosTbl;
        private int opcion;
        private int idxG;

        private MsSql db = null;

        PuiCatArticulos Art;
        //private string Perfil;
        //private clsUtil uT;

        private string path;

        private string Id;
        private string Empresa;
        private string Servidor;
        private string Datos;
        private string Usuario;
        private string Password;

        public frmCatArticulos(MsSql Odat, string perfil,int op=1, String Key="" )
        {
            InitializeComponent();
            _Opcion = op;
            _KeyCampo = Key;
            db = Odat;
            switch (op)
            {
                case 1:
                    this.Text = "Agregando nuevo Articulo...";
                    cmdAceptar.Text = "Guardar";
                    break;
                case 2:
                    this.Text = "Modificando el Articulo con Clave: " + _KeyCampo;
                    cmdAceptar.Text = "Actualizar";
                    break;
                default:
                    this.Text = "Datos del Articulo con Clave: " + _KeyCampo;
                    cmdAceptar.Text = "Aceptar";
                    break;

            }            
        }

        private void frmCatArticulos_Load(object sender, EventArgs e)
        {
            path = Directory.GetCurrentDirectory();
            CargaDatosConexion();
            db = new DatSql.MsSql(Servidor, Datos, Usuario, Password);
            Art = new PuiCatArticulos(db);
            if (db.Conectar() < 1)
            {
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            // Combos
            PuiCatLineas lin = new PuiCatLineas(db);
            cboLinea.DataSource = lin.CboLinea();
            PuiCatUMedidas UM = new PuiCatUMedidas(db);
            cboUMedida1.DataSource = UM.CboUMedida();            
            cboUMedida2.DataSource = UM.CboUMedida();            
            cboUMedidaEquival.DataSource = UM.CboUMedida();
            cboClase1.DataSource = Art.CboClase();
            cboClase2.DataSource = Art.CboClase();
            cboClase3.DataSource = Art.CboClase();
            cboImpuesto.DataSource = Art.CboImpuesto();



            //Combos
            if (_Opcion>=2)
            {
                
                Art.keyCveArticulo = _KeyCampo;
                Art.EditarArticulo();
                LlenarDatos();
                txtClaveArticulo.Enabled = false;
                if (_Opcion == 3)
                    OpcionControles(false);
            }

        }



        private Boolean Validar()
        {
            Boolean dv = true;
            ClsUtilerias Util = new ClsUtilerias();
            if (String.IsNullOrEmpty(txtClaveArticulo.Text))
            {
                MessageBox.Show("Código: No puede ir vacío.", "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtClaveArticulo.Text))
                {
                    MessageBox.Show("Código: Contiene caracteres no validos.", "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtCodigoBarras.Text))
            {
                MessageBox.Show("Código: No puede ir vacío.", "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtCodigoBarras.Text))
                {
                    MessageBox.Show("Código: Contiene caracteres no validos.", "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtCodigoSAT.Text))
            {
                MessageBox.Show("Código: No puede ir vacío.", "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNum(txtCodigoSAT.Text))
                {
                    MessageBox.Show("Código: Contiene caracteres no validos.", "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }

            if (String.IsNullOrEmpty(txtDescripcion.Text))
            {
                MessageBox.Show("Descripción: No puede ir vacío.", "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dv = false;
            }
            else
            {
                if (!Util.LetrasNumSpa(txtDescripcion.Text))
                {
                    MessageBox.Show("Descripción: Contiene caracteres no validos.", "CatArticulos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dv = false;
                }
            }


            return dv;
        }

        private void LlenarDatos()
        {
            txtClaveArticulo.Text = Art.keyCveArticulo;
            txtDescripcion.Text = Art.cmpDescripcion;
            txtCodigoBarras.Text = Art.cmpCodigoBarra;
            txtCodigoAlterno.Text = Art.cmpCodigoAlterno;
            txtCodigoSAT.Text = Art.cmpCodigoSat;
            dtFechaAlta.Value = Art.cmpFecha_Alta;
            cboLinea.SelectedValue = Art.Linea.keyCveLinea;
            cboClase3.SelectedValue = Art.Clase3.keyCveClase;
            cboClase2.SelectedValue = Art.Clase2.keyCveClase;
            cboClase1.SelectedValue = Art.Clase1.keyCveClase;
            cboImpuesto.SelectedValue = Art.Impuesto.keyCveImpuesto;
            //Art.= cmdMarca.SelectedValue.ToString();
            //Art.= cmdModelo.SelectedValue.ToString();
            cboUMedida1.SelectedValue = Art.UMedida1.keyCveUMedida;
            cboUMedida2.SelectedValue = Art.UMedida2.keyCveUMedida;
            cboUMedidaEquival.SelectedValue = Art.UMedidaEquiv.keyCveUMedida;
            chkEsInventa.Checked = Art.cmpEsInventa;
            chkEsKit.Checked = Art.cmpEsKit;
            chkDispKit.Checked = Art.cmpDispKit;
            chkEsServicio.Checked = Art.cmpEsServicio;
            chkDispVenta.Checked = Art.cmpDispVenta;
            txtObservaciones.Text = Art.cmpObservacion;
            chkEstatus.Checked = Art.cmpEstatus;
            txtUltimaCompra.Text = Art.cmpFecUltCompra;
            if (Art.cmpFoto.Length > 0)
            {
                MemoryStream Mf = new MemoryStream(Art.cmpFoto);
                Mf.Write(Art.cmpFoto, 0, Art.cmpFoto.Length);
                pbArticulo.Image = Image.FromStream(Mf);
            }
        }


        private void LlenarArticulo()
        {
            Art = new PuiCatArticulos(db);
            Art.keyCveArticulo = txtClaveArticulo.Text;
            Art.cmpDescripcion= txtDescripcion.Text;            
            Art.cmpCodigoBarra= txtCodigoBarras.Text;
            Art.cmpCodigoAlterno= txtCodigoAlterno.Text;
            Art.cmpCodigoSat= txtCodigoSAT.Text;
            Art.cmpFecha_Alta = dtFechaAlta.Value;// Convert.ToDateTime(String.Format("{0:yyyy-MM-dd}", dtFechaAlta.Value));
            Art.Linea.keyCveLinea= cboLinea.SelectedValue.ToString();
            if (cboClase3.SelectedValue!=null)
                Art.Clase3.keyCveClase = cboClase3.SelectedValue.ToString();
            if (cboClase2.SelectedValue != null)
                Art.Clase2.keyCveClase = cboClase2.SelectedValue.ToString();
            if (cboClase1.SelectedValue != null)
                Art.Clase1.keyCveClase = cboClase1.SelectedValue.ToString();
            if (cboImpuesto.SelectedValue != null)
                Art.Impuesto.keyCveImpuesto = cboImpuesto.SelectedValue.ToString();
            //Art.= cmdMarca.SelectedValue.ToString();
            //Art.= cmdModelo.SelectedValue.ToString();
            if (cboUMedida1.SelectedValue != null)
                Art.UMedida1.keyCveUMedida = cboUMedida1.SelectedValue.ToString();
            if (cboUMedida2.SelectedValue != null)
                Art.UMedida2.keyCveUMedida = cboUMedida2.SelectedValue.ToString();
            if (cboUMedidaEquival.SelectedValue != null)
                Art.UMedidaEquiv.keyCveUMedida = cboUMedidaEquival.SelectedValue.ToString();
            Art.cmpEsInventa= chkEsInventa.Checked;
            Art.cmpEsKit= chkEsKit.Checked;
            Art.cmpDispKit= chkDispKit.Checked;
            Art.cmpEsServicio= chkEsServicio.Checked;
            Art.cmpDispVenta= chkDispVenta.Checked;
            Art.cmpObservacion= txtObservaciones.Text;
            Art.cmpEstatus= chkEstatus.Checked;          

            if (pbArticulo.Image != null)
            {
                MemoryStream ms1 = new MemoryStream();
                // Se guarda la imagen en el buffer            
                pbArticulo.Image.Save(ms1, System.Drawing.Imaging.ImageFormat.Jpeg);

                // Se extraen los bytes del buffer para asignarlos como valor para el 
                // parámetro.
                Art.cmpFoto = ms1.GetBuffer();
            }
        }




        private void OpcionControles(Boolean Op)
        {
            txtDescripcion.Enabled = Op;
            txtCodigoBarras.Enabled = Op;
            txtCodigoAlterno.Enabled = Op;
            txtCodigoSAT.Enabled = Op;
            dtFechaAlta.Enabled = Op;
            cboLinea.Enabled = Op;
            cboClase3.Enabled = Op;
            cboClase2.Enabled = Op;
            cboClase1.Enabled = Op;
            cboImpuesto.Enabled = Op;
            cmdMarca.Enabled = Op;
            cmdModelo.Enabled = Op;
            cboUMedida1.Enabled = Op;
            cboUMedida2.Enabled = Op;
            cboUMedidaEquival.Enabled = Op;
            chkEsInventa.Enabled = Op;
            chkEsKit.Enabled = Op;
            chkDispKit.Enabled = Op;
            chkEsServicio.Enabled = Op;
            chkDispVenta.Enabled = Op;
            txtObservaciones.Enabled = Op;
            chkEstatus.Enabled = Op;
            cmdFoto.Enabled = Op;
        }

        private void CargaDatosConexion()
        {
            System.Xml.XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path + "\\SrvConfig.xml");
            XmlNodeList servidores = xDoc.GetElementsByTagName("Servidores");

            XmlNodeList lista =
            ((XmlElement)servidores[0]).GetElementsByTagName("Servidor");

            foreach (XmlElement nodo in lista)
            {
                int i = 0;
                XmlNodeList nId = nodo.GetElementsByTagName("Id");
                XmlNodeList nEmpresa = nodo.GetElementsByTagName("Empresa");
                XmlNodeList nNombre = nodo.GetElementsByTagName("Nombre");
                XmlNodeList nDatos = nodo.GetElementsByTagName("Datos");
                XmlNodeList nUsuario = nodo.GetElementsByTagName("Usuario");
                XmlNodeList nPassword = nodo.GetElementsByTagName("Password");

                Id = nId[i].InnerText;
                Empresa = nEmpresa[i].InnerText;
                Servidor = nNombre[i].InnerText;
                Datos = nDatos[i].InnerText;
                Usuario = nUsuario[i].InnerText;
                Password = nPassword[i++].InnerText;
            }
        }

        private void cmdCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                LlenarArticulo();
                if (_Opcion == 1)
                {
                    if (Art.AgregarArticulo() >= 1)
                    {
                        MessageBox.Show("Registro agregado", "Confirmacion", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }
                }
                else if (_Opcion == 2)
                    if (Art.ActualizaArticulo() >= 1)
                    {
                        MessageBox.Show("Registro Actualizado", "Confirmacion", MessageBoxButtons.OK,
                                       MessageBoxIcon.Information);
                    }
                this.Close();
            }
        }

        private void cmdFoto_Click(object sender, EventArgs e)
        {
            
            if (opfFoto.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                pbArticulo.Image= Image.FromFile(opfFoto.FileName);

                //Read the contents of the file into a stream

               
                
                
            }
        }
    }
}
