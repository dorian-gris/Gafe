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
    class PuiCatAlmacenes
    {
        private string ClaveAlmacen;
        private string Descripcion;        
        private string Estatus;
        private int EsDeCompra;
        private int EsDeVenta;
        private int EsDeConsigna;
        private int NumRojo;
        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[7, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiCatAlmacenes(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keyClaveAlmacen
        {
            get { return ClaveAlmacen; }
            set { ClaveAlmacen = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        public int cmpEsDeCompra
        {
            get { return EsDeCompra; }
            set { EsDeCompra = value; }
        }

        public int cmpEsDeVenta
        {
            get { return EsDeVenta; }
            set { EsDeVenta = value; }
        }

        public int cmpEsDeConsigna
        {
            get { return EsDeConsigna; }
            set { EsDeConsigna = value; }
        }

        public int cmpNumRojo
        {
            get { return NumRojo; }
            set { NumRojo = value; }
        }

        #endregion

        public int AgregarAlmacen()
        {
            CargaParametroMat();
            RegCatAlmacen OpRadd = new RegCatAlmacen(MatParam,db);
            return OpRadd.AddRegAlmacen();
        }

        public int ActualizaAlmacen()
        {
            CargaParametroMat();
            RegCatAlmacen OpUp = new RegCatAlmacen(MatParam,db);
            return OpUp.UpdateAlmacen();

        }

        public int EliminaAlmacen()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "ClaveAlmacen"; MatParam[0, 1] = ClaveAlmacen;
            RegCatAlmacen OpDel = new RegCatAlmacen(MatParam,db);
            return OpDel.DeleteAlmacen();
        }

        public SqlDataAdapter ListarAlmacenes()
        {
            CargaParametroMat();
            RegCatAlmacen OpLst = new RegCatAlmacen(db);
            return OpLst.ListAlmacenes();
        }

        public void EditarAlmacen()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "ClaveAlmacen"; MatParam[0, 1] = ClaveAlmacen;
            RegCatAlmacen OpEdit = new RegCatAlmacen(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            ClaveAlmacen = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            Estatus = ObjA[2].ToString();
            EsDeCompra = Convert.ToInt32(ObjA[3]);
            EsDeVenta = Convert.ToInt32(ObjA[4]);
            EsDeConsigna = Convert.ToInt32(ObjA[5]);
            NumRojo = Convert.ToInt32(ObjA[6]);


        }

        public SqlDataAdapter BuscaAlmacen(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodAlmacen"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatAlmacen OpBsq = new RegCatAlmacen(MatParam);/
             */
            RegCatAlmacen OpBsq = new RegCatAlmacen(db);
            return OpBsq.BuscaAlmacen(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "ClaveAlmacen"; MatParam[0, 1] = ClaveAlmacen;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "Estatus"; MatParam[2, 1] = Estatus;
            MatParam[3, 0] = "EsDeCompra"; MatParam[3, 1] = EsDeCompra;
            MatParam[4, 0] = "EsDeVenta"; MatParam[4, 1] = EsDeVenta;
            MatParam[5, 0] = "EsDeConsigna"; MatParam[5, 1] = EsDeConsigna;
            MatParam[6, 0] = "NumRojo"; MatParam[6, 1] = NumRojo;
        }
    }
}
