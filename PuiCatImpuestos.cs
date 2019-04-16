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
    class PuiCatImpuestos
    {
        private string CveImpuesto;
        private string Tipo;        
        private string Estatus;
        private double Valor;

        //matriz para Impuestoar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[4, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiCatImpuestos(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public string keyCveImpuesto
        {
            get { return CveImpuesto; }
            set { CveImpuesto = value; }
        }

        public string cmpTipo
        {
            get { return Tipo; }
            set { Tipo = value; }
        }

        public Double cmpValor
        {
            get { return Valor; }
            set { Valor = value; }
        }

        public string cmpEstatus
        {
            get { return Estatus; }
            set { Estatus = value; }
        }

        

        #endregion

        public int AgregarImpuesto()
        {
            CargaParametroMat();
            RegCatImpuesto OpRadd = new RegCatImpuesto(MatParam,db);
            return OpRadd.AddRegImpuesto();
        }

        public int ActualizaImpuesto()
        {
            CargaParametroMat();
            RegCatImpuesto OpUp = new RegCatImpuesto(MatParam,db);
            return OpUp.UpdateImpuesto();

        }

        public int EliminaImpuesto()
        {
            //CargaParametroMat();
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveImpuesto"; MatParam[0, 1] = CveImpuesto;
            RegCatImpuesto OpDel = new RegCatImpuesto(MatParam,db);
            return OpDel.DeleteImpuesto();
        }

        public SqlDataAdapter ListarImpuestos()
        {
            CargaParametroMat();
            RegCatImpuesto OpLst = new RegCatImpuesto(db);
            return OpLst.ListImpuestos();
        }

        public void EditarImpuesto()
        {
            MatParam = new object[1, 2];
            MatParam[0, 0] = "CveImpuesto"; MatParam[0, 1] = CveImpuesto;
            RegCatImpuesto OpEdit = new RegCatImpuesto(MatParam,db);
            Datos = OpEdit.RegistroActivo();
            DataSet Ds = new DataSet();
            Datos.Fill(Ds);
            object[] ObjA = Ds.Tables[0].Rows[0].ItemArray;

            CveImpuesto = ObjA[0].ToString();
            Tipo = ObjA[1].ToString();
            Valor = Convert.ToDouble(ObjA[2].ToString());
            Estatus = ObjA[3].ToString();

        }

        public SqlDataAdapter BuscaImpuesto(string buscar)
        {
            /* MatParam = new object[4, 2];
             MatParam[0, 0] = "CodImpuesto"; MatParam[0, 1] = buscar;
             MatParam[1, 0] = "Tipo"; MatParam[1, 1] = buscar;
             MatParam[2, 0] = "Ubicacion"; MatParam[2, 1] = buscar;
             MatParam[3, 0] = "Encargado"; MatParam[3, 1] = buscar;
             RegCatImpuesto OpBsq = new RegCatImpuesto(MatParam);/
             */
            RegCatImpuesto OpBsq = new RegCatImpuesto(db);
            return OpBsq.BuscaImpuesto(buscar);
        }


        private void CargaParametroMat()
        {
            MatParam[0, 0] = "CveImpuesto"; MatParam[0, 1] = CveImpuesto;
            MatParam[1, 0] = "Tipo"; MatParam[1, 1] = Tipo;
            MatParam[2, 0] = "Valor"; MatParam[2, 1] = Valor;
            MatParam[3, 0] = "Estatus"; MatParam[3, 1] = Estatus;
        }
    }
}
