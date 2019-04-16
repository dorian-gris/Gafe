using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatLinea
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatLinea(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatLinea(MsSql Odat) { db = Odat; }

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

        public int AddRegLinea()
        {
            string sql = "Insert into Inv_Lineas (CveLinea,Descripción,Estatus) " +
                         "values(@CveLinea,@Descripcion,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateLinea()
        {
            string sql = "Update Inv_Lineas set Descripcion = @Descripcion, " +
                         "Estatus = @Estatus " +
                         "Where CveLinea = @CveLinea";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteLinea()
        {
            string sql = "Delete from Inv_Lineas where CveLinea = @CveLinea";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListLineas()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveLinea,Descripcion " +
                         "from Inv_Lineas";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveLinea,Descripcion,Estatus " +
                          "from Inv_Lineas where CveLinea =@CveLinea";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaLinea(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveLinea,Descripcion " +
               "from Inv_Lineas " +
               "where CveLinea like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }
    }
}
