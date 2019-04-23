using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatUMedida
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatUMedida(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatUMedida(MsSql Odat) { db = Odat; }

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

        public int AddRegUMedida()
        {
            string sql = "Insert into Inv_UMedidas (CveUMedida,Descripción,Estatus) " +
                         "values(@CveUMedida,@Descripcion,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateUMedida()
        {
            string sql = "Update Inv_UMedidas set Descripcion = @Descripcion, " +
                         "Estatus = @Estatus " +
                         "Where CveUMedida = @CveUMedida";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteUMedida()
        {
            string sql = "Delete from Inv_UMedidas where CveUMedida = @CveUMedida";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListUMedidas()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveUMedida,Descripcion " +
                         "from Inv_UMedidas";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveUMedida,Descripcion,Estatus " +
                          "from Inv_UMedidas where CveUMedida =@CveUMedida";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaUMedida(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveUMedida,Descripcion " +
               "from Inv_UMedidas " +
               "where CveUMedida like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

        public SqlDataAdapter ComboUMedida()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveUMedida as Clave,Descripcion " +
                         "from Inv_UMedidas where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
    }
}
