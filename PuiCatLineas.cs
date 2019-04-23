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
    class PuiCatLineas
    {
        private string CveLinea;
        private string Descripcion;
        private string Estatus;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[3, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatLineas(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Linea

        public string keyCveLinea
        {
            get { return CveLinea; }
            set { CveLinea = value; }
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


        #endregion

        public int AgregarLinea()
        {
            CargaParametroMat();
            RegCatLinea OpRadd = new RegCatLinea(MatParam, db);
            return OpRadd.AddRegLinea();
        }

        public int ActualizaLinea()
        {
            CargaParametroMat();
            RegCatLinea OpUp = new RegCatLinea(MatParam, db);
            return OpUp.UpdateLinea();

        }

        public int EliminaLinea()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveLinea"; MatParam[0, 1] = CveLinea;
            RegCatLinea OpDel = new RegCatLinea(MatParam, db);
            return OpDel.DeleteLinea();
        }

        public SqlDataAdapter ListarLineas()
        {
            CargaParametroMat();
            RegCatLinea OpLst = new RegCatLinea(db);
            return OpLst.ListLineas();
        }

        public void EditarLinea()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveLinea"; MatParam[0, 1] = CveLinea;
            RegCatLinea OpEdit = new RegCatLinea(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveLinea = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            Estatus = ObjA[2].ToString();


        }

        public SqlDataAdapter BuscaLinea(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodLinea"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatLinea OpBsq = new RegCatLinea(MatParam);/
             */
            RegCatLinea OpBsq = new RegCatLinea(db);
            return OpBsq.BuscaLinea(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveLinea"; MatParam[0, 1] = CveLinea;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "Estatus"; MatParam[2, 1] = Estatus;
        }
    }
}
