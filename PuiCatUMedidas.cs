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
    class PuiCatUMedidas
    {
        private string CveUMedida;
        private string Descripcion;
        private string Estatus;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[3, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatUMedidas(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la UMedida

        public string keyCveUMedida
        {
            get { return CveUMedida; }
            set { CveUMedida = value; }
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

        public int AgregarUMedida()
        {
            CargaParametroMat();
            RegCatUMedida OpRadd = new RegCatUMedida(MatParam, db);
            return OpRadd.AddRegUMedida();
        }

        public int ActualizaUMedida()
        {
            CargaParametroMat();
            RegCatUMedida OpUp = new RegCatUMedida(MatParam, db);
            return OpUp.UpdateUMedida();

        }

        public int EliminaUMedida()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveUMedida"; MatParam[0, 1] = CveUMedida;
            RegCatUMedida OpDel = new RegCatUMedida(MatParam, db);
            return OpDel.DeleteUMedida();
        }

        public SqlDataAdapter ListarUMedidas()
        {
            CargaParametroMat();
            RegCatUMedida OpLst = new RegCatUMedida(db);
            return OpLst.ListUMedidas();
        }

        public void EditarUMedida()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveUMedida"; MatParam[0, 1] = CveUMedida;
            RegCatUMedida OpEdit = new RegCatUMedida(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveUMedida = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            Estatus = ObjA[2].ToString();


        }

        public SqlDataAdapter BuscaUMedida(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodUMedida"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatUMedida OpBsq = new RegCatUMedida(MatParam);/
             */
            RegCatUMedida OpBsq = new RegCatUMedida(db);
            return OpBsq.BuscaUMedida(buscar);
        }

        public DataTable CboUMedida()
        {
            CargaParametroMat();
            RegCatUMedida OpLst = new RegCatUMedida(db);
            DataSet Cbo = new DataSet();
            OpLst.ComboUMedida().Fill(Cbo);
            return Cbo.Tables[0];
        }

        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveUMedida"; MatParam[0, 1] = CveUMedida;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "Estatus"; MatParam[2, 1] = Estatus;
        }
    }
}
