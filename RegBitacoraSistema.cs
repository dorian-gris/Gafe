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
    class RegBitacora
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegBitacora(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegBitacora(MsSql Odat) { db = Odat; }

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

        public int AddRegBitacora()
        {
            string sql = "Insert into sgBitacoraSistema (CodRegistro,Modulo,Operacion,Descripcion,Fecha,Hora,Usuario,Host,IP) " +
                         "values(@CodRegistro,@Modulo,@Operacion,@Descripcion,@Fecha,@Hora,@Usuario,@Host,@IP)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


      

        public SqlDataAdapter ListBitacoras()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodRegistro,Modulo,Operacion,Descripcion,Fecha,Hora,Usuario,Host,IP " +
                         "from sgBitacoraSistema";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CodRegistro,Modulo,Operacion,Descripcion,Fecha,Hora,Usuario,Host,IP " +
                          "from sgBitacoraSistema where idReg =@idReg";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaBitacora(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CodRegistro,Modulo,Operacion,Descripcion,Fecha,Hora,Usuario,Host,IP " +
               "from sgBitacoraSistema " +
               "where CodRegistro like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

    }
}
