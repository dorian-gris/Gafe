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
    class PuiCatMunicipios
    {
        private string CveMunicipio;
        private string Descripcion;
        private string CvePais;
        private string CveEstado;
        private string Estatus;

        //matriz para Almacenar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[5, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiCatMunicipios(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la Municipio

        public string keyCveMunicipio
        {
            get { return CveMunicipio; }
            set { CveMunicipio = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public string cmpCvePais
        {
            get { return CvePais; }
            set { CvePais = value; }
        }

        public string cmpCveEstado
        {
            get { return CveEstado; }
            set { CveEstado = value; }
        }

        public string cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }


        #endregion

        public int AgregarMunicipio()
        {
            CargaParametroMat();
            RegCatMunicipio OpRadd = new RegCatMunicipio(MatParam,db);
            return OpRadd.AddRegMunicipio();
        }

        public int ActualizaMunicipio()
        {
            CargaParametroMat();
            RegCatMunicipio OpUp = new RegCatMunicipio(MatParam,db);
            return OpUp.UpdateMunicipio();

        }

        public int EliminaMunicipio()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveMunicipio"; MatParam[0, 1] = CveMunicipio;
            RegCatMunicipio OpDel = new RegCatMunicipio(MatParam,db);
            return OpDel.DeleteMunicipio();
        }

        public SqlDataAdapter ListarMunicipios()
        {
            CargaParametroMat();
            RegCatMunicipio OpLst = new RegCatMunicipio(db);
            return OpLst.ListMunicipios();
        }

        public void EditarMunicipio()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveMunicipio"; MatParam[0, 1] = CveMunicipio;
            RegCatMunicipio OpEdit = new RegCatMunicipio(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveMunicipio = ObjA[0].ToString();
            Descripcion = ObjA[1].ToString();
            CvePais = ObjA[2].ToString();
            CveEstado = ObjA[3].ToString();
            Estatus = ObjA[4].ToString();


        }

        public SqlDataAdapter BuscaMunicipio(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodMunicipio"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatMunicipio OpBsq = new RegCatMunicipio(MatParam);/
             */
            RegCatMunicipio OpBsq = new RegCatMunicipio(db);
            return OpBsq.BuscaMunicipio(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveMunicipio"; MatParam[0, 1] = CveMunicipio;
            MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = Descripcion;
            MatParam[2, 0] = "CvePais"; MatParam[2, 1] = CvePais;
            MatParam[3, 0] = "CveEstado"; MatParam[3, 1] = CveEstado;
            MatParam[4, 0] = "Estatus"; MatParam[4, 1] = Estatus;
        }
    }
}
