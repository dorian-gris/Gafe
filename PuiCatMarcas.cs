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
    class PuiCatMarcas
    {
        private string CveMarca;
        private string Descripcion;
        private int Estatus;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[3, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;


        public PuiCatMarcas(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Linea

        public string keyCveMarca
        {
            get { return CveMarca; }
            set { CveMarca = value; }
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


        #endregion

        public int AgregarMarcas()
        {
            CargaParametroMat();
            RegCatMarcas OpRadd = new RegCatMarcas(MatParam, db);
            return OpRadd.AddRegMarcas();
        }

        public int ActualizaMarcas()
        {
            CargaParametroMat();
            RegCatMarcas OpUp = new RegCatMarcas(MatParam, db);
            return OpUp.UpdateMarcas();

        }

        public int EliminaMarcas()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveMarca"; MatParam[0, 1] = CveMarca;
            RegCatMarcas OpDel = new RegCatMarcas(MatParam, db);
            return OpDel.DeleteMarcas();
        }

        public SqlDataAdapter ListarMarcas()
        {
            CargaParametroMat();
            RegCatMarcas OpLst = new RegCatMarcas(db);
            return OpLst.ListMarcas();
        }

        public void EditarMarcas()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveMarca"; MatParam[0, 1] = CveMarca;
            RegCatMarcas OpEdit = new RegCatMarcas(MatParam, db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveMarca = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            Estatus = int.Parse(ObjA[2].ToString());


        }

        public SqlDataAdapter BuscaMarcas(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodLinea"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatMarcas OpBsq = new RegCatMarcas(MatParam);/
             */
            RegCatMarcas OpBsq = new RegCatMarcas(db);
            return OpBsq.BuscaMarcas(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveMarca"; MatParam[0, 1] = CveMarca;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "Estatus"; MatParam[2, 1] = Estatus;
        }
    }
}
