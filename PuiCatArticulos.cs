using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DatSql;


namespace GAFE
{
    class PuiCatArticulos
    {
        private String CveArticulo;
        private String CodigoAlterno;
        private String CodigoBarra;
        private String CodigoSat;
        private DateTime Fecha_Alta;
        private String Descripcion;
        private int EsInventa;
        private int DispVenta;
        private int EsServicio;
        private int DispKit;
        private int EsKit;
        private string FecUltCompra;
        private String CveProveedorUlt;
        private Byte[] Foto;
        private String Observacion;
        private int Estatus;


        public PuiCatLineas Linea;
        public PuiCatImpuestos Impuesto;
       // public PuiCatMarcas Marca;
        public PuiCatClases Clase1;
        public PuiCatClases Clase2;
        public PuiCatClases Clase3;
        public PuiCatUMedidas UMedida1;
        public PuiCatUMedidas UMedida2;
        public PuiCatUMedidas UMedidaEquiv;
       //public PuiCatProveedor Proveedor;
        private String Modelo;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[22, 2];
        //private object[,] MatParam = new object[26, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatArticulos(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
            Linea = new PuiCatLineas(db);
            Impuesto = new PuiCatImpuestos(db);
            //Marca= new PuiCatMarcas(db);
            Clase1 = new PuiCatClases(db);
            Clase2 = new PuiCatClases(db);
            Clase3 = new PuiCatClases(db);
            UMedida1 = new PuiCatUMedidas(db);
            UMedida2=new PuiCatUMedidas(db);
            UMedidaEquiv=new PuiCatUMedidas(db);
        }


        #region Definicion de propiedades de la Articulo

        public string keyCveArticulo
        {
            get { return CveArticulo; }
            set { CveArticulo = value; }
        }
        public String cmpCodigoAlterno
        {
            get { return CodigoAlterno; }
            set { CodigoAlterno = value; }
        }
        public String cmpCodigoBarra
        {
            get { return CodigoBarra; }
            set { CodigoBarra = value; }
        }
        public String cmpCodigoSat
        {
            get { return CodigoSat; }
            set { CodigoSat = value; }
        }
        public DateTime cmpFecha_Alta
        {
            get { return Fecha_Alta; }
            set { Fecha_Alta = value; }
        }
        public String cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }
        public String cmpModelo
        {
            get { return Modelo; }
            set { Modelo = value; }
        }
        public Boolean cmpEsInventa
        {   
            get
            {
                if (EsInventa == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    EsInventa = 1;
                else
                    EsInventa = 0;
            }
        }
        public Boolean cmpDispVenta
        {
            
            get
            {
                if (DispVenta == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    DispVenta = 1;
                else
                    DispVenta = 0;
            }
        }
        public Boolean cmpEsServicio
        {
            get
            {
                if (EsServicio == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    EsServicio = 1;
                else
                    EsServicio = 0;
            }
        }
        public Boolean cmpDispKit
        {   
            get
            {
                if (DispKit == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    DispKit = 1;
                else
                    DispKit = 0;
            }
        }
        public Boolean cmpEsKit
        {
            get
            {
                if (EsKit == 1)
                    return true;
                else
                    return false;
            }
            set
            {
                if (value)
                    EsKit = 1;
                else
                    EsKit = 0;
            }
        }
        public String cmpFecUltCompra
        {
            get { return FecUltCompra; }
            set { FecUltCompra = value; }
        }
        public String cmpCveProveedorUlt
        {
            get { return CveProveedorUlt; }
            set { CveProveedorUlt = value; }
        }
        public Byte[] cmpFoto
        {
            get { return Foto; }
            set { Foto = value; }
        }
        public String cmpObservacion
        {
            get { return Observacion; }
            set { Observacion = value; }
        }
        public Boolean cmpEstatus
        {
            get { if (Estatus == 1)
                    return true;
                else
                    return false;
            }
            set { if(value)
                    Estatus=1;
                  else
                    Estatus = 0;
            }
        }


        #endregion

        public int AgregarArticulo()
        {
            CargaParametroMat();
            RegCatArticulo OpRadd = new RegCatArticulo(MatParam, db);
            return OpRadd.AddRegArticulo();
        }

        public int ActualizaArticulo()
        {
            CargaParametroMat();
            RegCatArticulo OpUp = new RegCatArticulo(MatParam, db);
            return OpUp.UpdateArticulo();

        }

        public int EliminaArticulo()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveArticulo;
            RegCatArticulo OpDel = new RegCatArticulo(MatParam, db);
            return OpDel.DeleteArticulo();
        }

        public SqlDataAdapter ListarArticulos()
        {
            CargaParametroMat();
            RegCatArticulo OpLst = new RegCatArticulo(db);
            return OpLst.ListArticulos();
        }

        public void EditarArticulo()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveArticulo;
            RegCatArticulo OpEdit = new RegCatArticulo(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] objA = Ds.Tables[0].Rows[0].ItemArray;

            CveArticulo = objA[0].ToString();
            CodigoAlterno = objA[1].ToString();
            CodigoBarra = objA[2].ToString();
            CodigoSat = objA[3].ToString();
            Fecha_Alta = DateTime.Parse(objA[4].ToString());
            Descripcion = objA[5].ToString();
            Modelo = objA[6].ToString();
            this.Linea.keyCveLinea = objA[7].ToString();
            //this.Marca.keyClaveMarca = objA[8].ToString();
            this.Clase1.keyCveClase = objA[9].ToString();
            this.Clase2.keyCveClase = objA[10].ToString();
            this.Clase3.keyCveClase = objA[11].ToString();
            this.Impuesto.keyCveImpuesto  = objA[12].ToString();
            this.UMedida1.keyCveUMedida = objA[13].ToString();
            this.UMedida2.keyCveUMedida  = objA[14].ToString();
            this.UMedidaEquiv.keyCveUMedida  = objA[15].ToString();
            EsInventa = int.Parse(objA[16].ToString());
            DispVenta = int.Parse(objA[17].ToString());
            EsServicio = int.Parse(objA[18].ToString());
            DispKit = int.Parse(objA[19].ToString());
            EsKit = int.Parse(objA[20].ToString());
            FecUltCompra = objA[21].ToString();
            CveProveedorUlt = objA[22].ToString();
            Foto = (byte[])objA[23];
            Observacion = objA[24].ToString();
            Estatus = int.Parse(objA[25].ToString());
        }

        public SqlDataAdapter BuscaArticulo(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodArticulo"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatArticulo OpBsq = new RegCatArticulo(MatParam);/
             */
            RegCatArticulo OpBsq = new RegCatArticulo(db);
            return OpBsq.BuscaArticulo(buscar);
        }
        public DataTable CboImpuesto()
        {
            CargaParametroMat();
            RegCatArticulo OpLst = new RegCatArticulo(db);
            DataSet Cbo = new DataSet();
            OpLst.ComboImpuesto().Fill(Cbo);
            return Cbo.Tables[0];
        }
        public DataTable CboClase()
        {
            CargaParametroMat();
            RegCatArticulo OpLst = new RegCatArticulo(db);
            DataSet Cbo = new DataSet();
            OpLst.ComboClase().Fill(Cbo);
            return Cbo.Tables[0];
        }
        public DataTable CboMarca()
        {
            CargaParametroMat();
            RegCatArticulo OpLst = new RegCatArticulo(db);
            DataSet Cbo = new DataSet();
            OpLst.ComboMarca().Fill(Cbo);
            return Cbo.Tables[0];
        }
        private void CargaParametroMat()
        {

            MatParam[0, 0] = "CveArticulo"; MatParam[0, 1] = CveArticulo;
            MatParam[1, 0] = "CodigoAlterno"; MatParam[1, 1] = CodigoAlterno;
            MatParam[2, 0] = "CodigoBarra"; MatParam[2, 1] = CodigoBarra;
            MatParam[3, 0] = "CodigoSat";   MatParam[3, 1] = CodigoSat;
            MatParam[4, 0] = "Fecha_Alta";  MatParam[4, 1] = Fecha_Alta;
            MatParam[5, 0] = "Descripcion"; MatParam[5, 1] = Descripcion;
            MatParam[6, 0] = "CveLinea";    MatParam[6, 1] = Linea.keyCveLinea;
            MatParam[7, 0] = "CveUMedida1"; MatParam[7, 1] = UMedida1.keyCveUMedida;
            MatParam[8, 0] = "CveUMedida2"; MatParam[8, 1] = UMedida2.keyCveUMedida;
            MatParam[9, 0] = "UMedidaEquiv2"; MatParam[9, 1] = UMedidaEquiv.keyCveUMedida;
            MatParam[10, 0] = "EsInventa";  MatParam[10, 1] = EsInventa;
            MatParam[11, 0] = "DispVenta";  MatParam[11, 1] = DispVenta;
            MatParam[12, 0] = "EsServicio"; MatParam[12, 1] = EsServicio;
            MatParam[13, 0] = "DispKit";    MatParam[13, 1] = DispKit;
            MatParam[14, 0] = "EsKit";      MatParam[14, 1] = EsKit;
            MatParam[15, 0] = "Observacion";MatParam[15, 1] = Observacion;
            MatParam[16, 0] = "Estatus";    MatParam[16, 1] = Estatus;
            MatParam[17, 0] = "CveImpuesto"; MatParam[17, 1] = Impuesto.keyCveImpuesto;
            MatParam[18, 0] = "CveClase1";   MatParam[18, 1] = Clase1.keyCveClase;
            MatParam[19, 0] = "CveClase2";   MatParam[19, 1] = Clase2.keyCveClase;
            MatParam[20, 0] = "CveClase3";   MatParam[20, 1] = Clase3.keyCveClase;
            MatParam[21, 0] = "Foto"; MatParam[21, 1] = Foto;
            if (Foto==null)
                MatParam[21, 1] = DBNull.Value;
            //MatParam[22, 0] = "Modelo"; MatParam[22, 1] = Modelo;
            //MatParam[23, 0] = "CveMarca"; MatParam[23, 1] = CveMarca;
            //MatParam[24, 0] = "FecUltCompra"; MatParam[24, 1] = FecUltCompra;
            //MatParam[25, 0] = "CveProveedorUlt"; MatParam[25, 1] = CveProveedorUlt;

        }
    }
}
