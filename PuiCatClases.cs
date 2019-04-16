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
    class PuiCatClases
    {
        private string CveClase;
        private string Descripcion;        
        private string Estatus;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[3, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiCatClases(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keyCveClase
        {
            get { return CveClase; }
            set { CveClase = value; }
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

        public int AgregarClase()
        {
            CargaParametroMat();
            RegCatClase OpRadd = new RegCatClase(MatParam,db);
            return OpRadd.AddRegClase();
        }

        public int ActualizaClase()
        {
            CargaParametroMat();
            RegCatClase OpUp = new RegCatClase(MatParam,db);
            return OpUp.UpdateClase();

        }

        public int EliminaClase()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveClase"; MatParam[0, 1] = CveClase;
            RegCatClase OpDel = new RegCatClase(MatParam,db);
            return OpDel.DeleteClase();
        }

        public SqlDataAdapter ListarClases()
        {
            CargaParametroMat();
            RegCatClase OpLst = new RegCatClase(db);
            return OpLst.ListClases();
        }

        public void EditarClase()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveClase"; MatParam[0, 1] = CveClase;
            RegCatClase OpEdit = new RegCatClase(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveClase = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            Estatus = ObjA[2].ToString();


        }

        public SqlDataAdapter BuscaClase(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodClase"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatClase OpBsq = new RegCatClase(MatParam);/
             */
            RegCatClase OpBsq = new RegCatClase(db);
            return OpBsq.BuscaClase(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveClase"; MatParam[0, 1] = CveClase;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "Estatus"; MatParam[2, 1] = Estatus;
        }
    }
}
