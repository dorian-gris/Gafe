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
    class PuiBitacoraSistema
    {
        private long idReg;
        private string CodRegistro;
        private string Modulo;
        private string Operacion;
        private string Descripcion;
        private DateTime Fecha;
        private DateTime Hora;
        private string Usuario;
	    private string Host;
	    private string IP;

        //matriz para Empleadoar el contenido de la tabla (NomParam,ValorParam)
        private object[,] MatParam = new object[10, 2];
        private SqlDataAdapter Datos;

        private MsSql db = null;

           
        public PuiBitacoraSistema(MsSql Odat)
        {
            //MatParam = new object[9,2]; 
            db = Odat;
        }


        #region Definicion de propiedades de la clase

        public long keyidReg
        {
            get { return idReg; }
            set { idReg = value; }
        }

        public string cmpCodRegistro
        {
            get { return CodRegistro; }
            set { CodRegistro = value; }
        }

        public string cmpModulo
        {
            get { return Modulo; }
            set { Modulo = value; }
        }

        public string cmpOperacion
        {
            get { return Operacion; }
            set { Operacion = value; }
        }

        public string cmpDescripcion
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }

        public DateTime cmpFecha
        {
            get { return Fecha; }
            set { Fecha = value; }
        }

        public DateTime cmpHora
        {
            get { return Hora; }
            set { Hora = value; }
        }

        public string cmpUsuario
        {
            get { return Usuario; }
            set { Usuario = value; }
        }

        public string cmpHost
        {
            get { return Host; }
            set { Host = value; }
        }

        public string cmpIP
        {
            get { return IP; }
            set { IP = value; }
        }

        #endregion

        public int AgregarBitacora()
        {
            CargaParametroMat();
            RegBitacora OpRadd = new RegBitacora(MatParam,db);
            return OpRadd.AddRegBitacora();
        }

        

        public SqlDataAdapter ListarBitacora()
        {
            CargaParametroMat();
            RegCatEmpleado OpLst = new RegCatEmpleado(db);
            return OpLst.ListEmpleados();
        }

       

        public SqlDataAdapter BuscaBitacora(string buscar)
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
            MatParam[0, 0] = "idReg"; MatParam[0, 1] = idReg;
            MatParam[1, 0] = "CodRegistro"; MatParam[1, 1] = CodRegistro;
            MatParam[2, 0] = "Modulo"; MatParam[2, 1] = Modulo;
            MatParam[3, 0] = "Operacion"; MatParam[3, 1] = Operacion;
            MatParam[4, 0] = "Descripcion"; MatParam[4, 1] = Descripcion;
            MatParam[5, 0] = "Fecha"; MatParam[5, 1] = Fecha;
            MatParam[6, 0] = "Hora"; MatParam[6, 1] = Hora;
            MatParam[7, 0] = "Usuario"; MatParam[7, 1] = Usuario;
            MatParam[8, 0] = "Host"; MatParam[8, 1] = Host;
            MatParam[9, 0] = "IP"; MatParam[9, 1] = IP;
       }
    }
}
