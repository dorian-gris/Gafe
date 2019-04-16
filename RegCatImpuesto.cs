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
    class RegCatImpuesto
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatImpuesto(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatImpuesto(MsSql Odat) { db = Odat; }

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

        public int AddRegImpuesto()
        {
            string sql = "Insert into [Inv_Impuestos] (CveImpuesto,Tipo,Valor,Estatus) " +
                         "values(@CveImpuesto,@Tipo,@Valor,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateImpuesto()
        {
            string sql = "Update [Inv_Impuestos] set Tipo = @Tipo, " +
                        "Valor = @Valor, " +
                        "Estatus = @Estatus " +
                         "Where CveImpuesto = @CveImpuesto";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteImpuesto()
        {
            string sql = "Delete from [Inv_Impuestos] where CveImpuesto = @CveImpuesto";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListImpuestos()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveImpuesto,Tipo " +
                         "from [Inv_Impuestos]";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveImpuesto,Tipo, Valor,Estatus " +
                          "from [Inv_Impuestos] where CveImpuesto =@CveImpuesto";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaImpuesto(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveImpuesto,Tipo, Valor " +
               "from [Inv_Impuestos] " +
               "where CveImpuesto like '%" + bsq + "%' OR " +
               "Tipo like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

    }
}
