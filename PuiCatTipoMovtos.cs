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
    class PuiCatTipoMovtos
    {

        private string CveTipoMov;
        private string Descripcion;
        private string DescCorta;
        private string EntSal;
        private string CveClsMov;
        private string Foliador;
        private int    EditaFoli;
        private int    EsTraspaso;
        private string TipoMovRel;
        private string FmtoImpresion;
        private int    AfectaCosto;
        private int    SugiereCosto;
        private int    MuestraCosto;
        private int    EditaCosto;
        private int    SolicitaCosto;
        private int    PideCentroCosto;
        private int    CalculaIva;
        private int    Estatus;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[18, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiCatTipoMovtos(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la TipoMov

        public string keyCveTipoMov
        {
            get { return CveTipoMov; }
            set { CveTipoMov = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public int cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public string cmpDescCorta
        {
            get { return DescCorta; }
            set { DescCorta = value; }
        }

        public string cmpEntSal
        {
            get { return EntSal; }
            set { EntSal = value; }
        }

        public string cmpCveClsMov
        {
            get { return CveClsMov; }
            set { CveClsMov = value; }
        }

        public string cmpFoliador
        {
            get { return Foliador; }
            set { Foliador = value; }
        }

        public int cmpEditaFoli
        {
            get { return EditaFoli; }
            set { EditaFoli = value; }
        }

        public int cmpEsTraspaso
        {
            get { return EsTraspaso; }
            set { EsTraspaso = value; }
        }

        public string cmpTipoMovRel
        {
            get { return TipoMovRel; }
            set { TipoMovRel = value; }
        }

        public string cmpFmtoImpresion
        {
            get { return FmtoImpresion; }
            set { FmtoImpresion = value; }
        }

        public int cmpAfectaCosto
        {
            get { return AfectaCosto; }
            set { AfectaCosto = value; }
        }

        public int cmpSugiereCosto
        {
            get { return SugiereCosto; }
            set { SugiereCosto = value; }
        }

        public int cmpMuestraCosto
        {
            get { return MuestraCosto; }
            set { MuestraCosto = value; }
        }

        public int cmpEditaCosto
        {
            get { return EditaCosto; }
            set { EditaCosto = value; }
        }

        public int cmpSolicitaCosto
        {
            get { return SolicitaCosto; }
            set { SolicitaCosto = value; }
        }

        public int cmpPideCentroCosto
        {
            get { return PideCentroCosto; }
            set { PideCentroCosto = value; }
        }

        public int cmpCalculaIva
        {
            get { return CalculaIva; }
            set { CalculaIva = value; }
        }



        #endregion

        public int AgregarTipoMov()
        {
            CargaParametroMat();
            RegCatTipoMov OpRadd = new RegCatTipoMov(MatParam,db);
            return OpRadd.AddRegTipoMov();
        }

        public int ActualizaTipoMov()
        {
            CargaParametroMat();
            RegCatTipoMov OpUp = new RegCatTipoMov(MatParam,db);
            return OpUp.UpdateTipoMov();

        }

        public int EliminaTipoMov()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveTipoMov"; MatParam[0, 1] = CveTipoMov;
            RegCatTipoMov OpDel = new RegCatTipoMov(MatParam,db);
            return OpDel.DeleteTipoMov();
        }

        public SqlDataAdapter ListarTipoMovtos()
        {
            CargaParametroMat();
            RegCatTipoMov OpLst = new RegCatTipoMov(db);
            return OpLst.ListTipoMovtos();
        }

        public DataTable CboLstClaseMov()
        {
            //CargaParametroMat();
            RegCatTipoMov OpLst = new RegCatTipoMov(db);
            DataSet Cbo = new DataSet();
            OpLst.CboLstClaseMov().Fill(Cbo);
            return Cbo.Tables[0];
        }

        public DataTable CboLstMovRel()
        {
            //CargaParametroMat();
            RegCatTipoMov OpLst = new RegCatTipoMov(db);
            DataSet Cbo = new DataSet();
            OpLst.CboLstMovRel().Fill(Cbo);
            return Cbo.Tables[0];
        }

        public void EditarTipoMov()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveTipoMov"; MatParam[0, 1] = CveTipoMov;
            RegCatTipoMov OpEdit = new RegCatTipoMov(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;


            CveTipoMov  = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            DescCorta = ObjA[2].ToString();
            EntSal = ObjA[3].ToString();
            CveClsMov = ObjA[4].ToString();
            Foliador = ObjA[5].ToString();
            EditaFoli = int.Parse(ObjA[6].ToString());
            EsTraspaso = int.Parse(ObjA[7].ToString());
            TipoMovRel = ObjA[8].ToString();
            FmtoImpresion = ObjA[9].ToString();
            AfectaCosto = int.Parse(ObjA[10].ToString());
            SugiereCosto = int.Parse(ObjA[11].ToString());
            MuestraCosto = int.Parse(ObjA[12].ToString());
            EditaCosto = int.Parse(ObjA[13].ToString());
            SolicitaCosto = int.Parse(ObjA[14].ToString());
            PideCentroCosto = int.Parse(ObjA[15].ToString());
            CalculaIva = int.Parse(ObjA[16].ToString());
            Estatus = int.Parse(ObjA[17].ToString());
        }

        public SqlDataAdapter BuscaTipoMov(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodTipoMov"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatTipoMov OpBsq = new RegCatTipoMov(MatParam);/
             */
            RegCatTipoMov OpBsq = new RegCatTipoMov(db);
            return OpBsq.BuscaTipoMov(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveTipoMov"; MatParam[0, 1] = CveTipoMov;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "DescCorta"; MatParam[2, 1] = DescCorta;
            MatParam[3, 0] = "EntSal"; MatParam[3, 1] = EntSal;
            MatParam[4, 0] = "CveClsMov"; MatParam[4, 1] = CveClsMov;
            MatParam[5, 0] = "Foliador"; MatParam[5, 1] = Foliador;
            MatParam[6, 0] = "EditaFoli"; MatParam[6, 1] = EditaFoli;
            MatParam[7, 0] = "EsTraspaso"; MatParam[7, 1] = EsTraspaso;
            MatParam[8, 0] = "TipoMovRel"; MatParam[8, 1] = TipoMovRel;
            MatParam[9, 0] = "FmtoImpresion"; MatParam[9, 1] = FmtoImpresion;
            MatParam[10, 0] = "AfectaCosto"; MatParam[10, 1] = AfectaCosto;
            MatParam[11, 0] = "SugiereCosto"; MatParam[11, 1] = SugiereCosto;
            MatParam[12, 0] = "MuestraCosto"; MatParam[12, 1] = MuestraCosto;
            MatParam[13, 0] = "EditaCosto"; MatParam[13, 1] = EditaCosto;
            MatParam[14, 0] = "SolicitaCosto"; MatParam[14, 1] = SolicitaCosto;
            MatParam[15, 0] = "PideCentroCosto"; MatParam[15, 1] = PideCentroCosto;
            MatParam[16, 0] = "CalculaIva"; MatParam[16, 1] = CalculaIva;
            MatParam[17, 0] = "Estatus"; MatParam[17, 1] = Estatus;

        }
    }
}
