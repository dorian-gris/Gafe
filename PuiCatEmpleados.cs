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
    class PuiCatEmpleados
    {
        private string CodEmpleado;
        private string Nombre;
        private string Telefono;
        private string Estatus;
        //matriz para Empleadoar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[4, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiCatEmpleados(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keyCatEmpleado
        {
            get { return CodEmpleado; }
            set { CodEmpleado = value; }
        }

        public string cmpNombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string cmpTelefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        public string cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        #endregion

        public int AgregarEmpleado()
        {
            CargaParametroMat();
            RegCatEmpleado OpRadd = new RegCatEmpleado(MatParam,db);
            return OpRadd.AddRegEmpleado();
        }

        public int ActualizaEmpleado()
        {
            CargaParametroMat();
            RegCatEmpleado OpUp = new RegCatEmpleado(MatParam,db);
            return OpUp.UpdateEmpleado();

        }

        public int EliminaEmpleado()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodEmpleado"; MatParam[0, 1] = CodEmpleado;
            RegCatEmpleado OpDel = new RegCatEmpleado(MatParam,db);
            return OpDel.DeleteEmpleado();
        }

        public SqlDataAdapter ListarEmpleados()
        {
            CargaParametroMat();
            RegCatEmpleado OpLst = new RegCatEmpleado(db);
            return OpLst.ListEmpleados();
        }

        public void EditarEmpleado()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CodEmpleado"; MatParam[0, 1] = CodEmpleado;
            RegCatEmpleado OpEdit = new RegCatEmpleado(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CodEmpleado = ObjA[0].ToString();
            Nombre = ObjA[1].ToString();
            Telefono = ObjA[2].ToString();
            Estatus = ObjA[3].ToString();
        }

        public SqlDataAdapter BuscaEmpleado(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodEmpleado"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Descripcion"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatEmpleado OpBsq = new RegCatEmpleado(MatParam);/
             */
            RegCatEmpleado OpBsq = new RegCatEmpleado(db);
            return OpBsq.BuscaEmpleado(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CodEmpleado"; MatParam[0, 1] = CodEmpleado;
            MatParam[1, 0] = "Nombre"; MatParam[1, 1] = Nombre;
            MatParam[2, 0] = "Telefono"; MatParam[2, 1] = Telefono;
            MatParam[3, 0] = "Estatus"; MatParam[3, 1] = Estatus;
        }
    }
}
