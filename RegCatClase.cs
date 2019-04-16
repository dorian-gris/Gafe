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
    class RegCatClase
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatClase(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatClase(MsSql Odat) { db = Odat; }

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

        public int AddRegClase()
        {           
            string sql = "Insert into Inv_Clases (CveClase,Descripción,Estatus) " +
                         "values(@CveClase,@Descripcion,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateClase()
        {
            string sql = "Update Inv_Clases set Descripcion = @Descripcion, " +
                         "Estatus = @Estatus " +
                         "Where CveClase = @CveClase";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteClase()
        {
            string sql = "Delete from Inv_Clases where CveClase = @CveClase";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListClases()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveClase,Descripcion " +
                         "from Inv_Clases";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveClase,Descripcion,Estatus " +
                          "from Inv_Clases where CveClase =@CveClase";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaClase(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveClase,Descripcion " +
               "from Inv_Clases " +
               "where CveClase like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

    }
}
