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
    class RegCatMunicipio
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatMunicipio(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatMunicipio(MsSql Odat) { db = Odat; }

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

        public int AddRegMunicipio()
        {           
            string sql = "Insert into CatMunicipios (CveMunicipio,Descripción,CvePais,CveEstado,Estatus) " +
                         "values(@CveMunicipio,@Descripcion,@CvePais,@CveEstado,@Estatus)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateMunicipio()
        {
            string sql = "Update CatMunicipios set Descripcion = @Descripcion, " +
                         "CvePais = @CvePais, " +
                         "CveEstado = @CveEstado, " +
                         "Estatus = @Estatus " +
                         "Where CveMunicipio = @CveMunicipio";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteMunicipio()
        {
            string sql = "Delete from CatMunicipios where CveMunicipio = @CveMunicipio";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListMunicipios()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveMunicipio,Descripcion " +
                         "from CatMunicipios";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveMunicipio,Descripcion,CvePais, CveEstado,Estatus " +
                          "from CatMunicipios where CveMunicipio =@CveMunicipio";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaMunicipio(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveMunicipio,Descripcion,CvePais, CveEstado " +
               "from CatMunicipios " +
               "where CveMunicipio like '%" + bsq + "%' OR " +
               "Descripcion like '%" + bsq + "%' ";

            dt = db.SelectDA(sql);
            return dt;
        }

    }
}
