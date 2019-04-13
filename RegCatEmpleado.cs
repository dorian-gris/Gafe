using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using DatSql;
using System.Windows.Forms;



namespace GAFE
{
    class RegCatEmpleado
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatEmpleado(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatEmpleado(MsSql Odat) { db = Odat; }

        /*
        public void Conn()
        {
            /*db = new DatSql.MsSql(
                   ConfigurationSettings.AppSettings.Get("Servidor"),
                   ConfigurationSettings.AppSettings.Get("Datos"),
                   ConfigurationSettings.AppSettings.Get("Usuario"),
                   ConfigurationSettings.AppSettings.Get("Password")
                   );
            
            db = new DatSql.MsSql("SIGMA6\\SQL14", "CtrlAcceso", "sa", "Remolachas1");
                   
            if (db.Conectar() < 1)
                MessageBox.Show(db.ErrorDat, "Error conn", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    */

        public int AddRegEmpleado()
        {
            string sql = "Insert into CatEmpleados (CodEmpleado,Nombre,Telefono,Estatus) " +
                         "values(@CodEmpleado,@Nombre,@Telefono,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateEmpleado()
        {
            string sql = "Update CatEmpleados set Nombre = @Nombre, " +
                         "Telefono = @Telefono, " +
                         "Estatus = @Estatus " +
                         "Where CodEmpleado = @CodEmpleado";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteEmpleado()
        {
            string sql = "Delete from CatEmpleados where CodEmpleado = @CodEmpleado";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListEmpleados()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodEmpleado,Nombre " +
                         "from CatEmpleados";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodEmpleado,Nombre,Telefono,Estatus " +
                          "from CatEmpleados where CodEmpleado =@CodEmpleado";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaEmpleado(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CodEmpleado,Nombre " +
               "from CatEmpleados " +
               "where CodEmpleado like '%" + bsq + "%' OR " +
               "Nombre like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

    }
}
