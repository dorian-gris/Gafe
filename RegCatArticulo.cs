using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DatSql;

namespace GAFE
{
    class RegCatArticulo
    {
        private MsSql db = null;
        private SqlParameter[] ArrParametros;
        //private string ClaveReg;

        public RegCatArticulo(object[,] Param, MsSql Odat)
        {
            ArrParametros = new SqlParameter[Param.GetUpperBound(0) + 1];
            for (int j = 0; j < Param.GetUpperBound(0) + 1; j++)
                ArrParametros[j] = new SqlParameter(Param[j, 0].ToString(), Param[j, 1]);
            //Conn();
            db = Odat;
        }

        public RegCatArticulo(MsSql Odat) { db = Odat; }

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

        public int AddRegArticulo()
        {
            string sql = "INSERT INTO inv_CatArticulos (CveArticulo,  CodigoAlterno,  CodigoBarra,  CodigoSat,  Fecha_Alta,  Descripcion,  CveLinea, " +
                "CveUMedida1,  CveUMedida2,  UMedidaEquiv2,  EsInventa,  DispVenta,  EsServicio,  DispKit,  EsKit,    Observacion,  Estatus," +
                "  CveImpuesto, CveClase1,  CveClase2,  CveClase3, Foto) " +
                // "Modelo, FecUltCompra,  CveProveedorUlt, CveMarca)" +
                "VALUES ( @CveArticulo,  @CodigoAlterno,  @CodigoBarra,  @CodigoSat,  @Fecha_Alta,  @Descripcion,  @CveLinea, " +
                "@CveUMedida1,  @CveUMedida2, @UMedidaEquiv2,  @EsInventa,  @DispVenta,  @EsServicio,  @DispKit,  @EsKit,   @Observacion,  @Estatus,"+
                "@CveImpuesto, @CveClase1,  @CveClase2,  @CveClase3, @Foto) ";

            //"@Modelo, @FecUltCompra,  @CveProveedorUlt,@CveMarca )";
            return db.InsertarRegistro(sql, ArrParametros);
        }
        public int AddRegExistencias()
        {
            string sql = "Insert into Inv_CatAlmacenes (ClaveArticulo, ClaveAlmacen) values(@CveArticulo,@ClaveAlmacen)";
            return db.InsertarRegistro(sql, ArrParametros);
        }


        public int UpdateArticulo()
        {
            string sql = "Update inv_CatArticulos set " +
                        "CveArticulo=@CveArticulo,  " +
                        "CodigoAlterno=@CodigoAlterno,  " +
                        "CodigoBarra=@CodigoBarra,  " +
                        "CodigoSat=@CodigoSat,  " +
                        "Fecha_Alta=@Fecha_Alta,  " +
                        "Descripcion=@Descripcion,  " +                        
                        "CveLinea=@CveLinea,  " +
                        "CveUMedida1=@CveUMedida1,  " +
                        "CveUMedida2=@CveUMedida2,  " +
                        "UMedidaEquiv2=@UMedidaEquiv2,  " +
                        "EsInventa=@EsInventa,  " +
                        "DispVenta=@DispVenta,  " +
                        "EsServicio=@EsServicio,  " +
                        "DispKit=@DispKit,  " +
                        "EsKit=@EsKit,  " +
                        "Foto=@Foto,  " +
                        "Observacion=@Observacion,  " +
                        "Estatus=@Estatus,  " +
                        "CveImpuesto=@CveImpuesto,  " +                        
                        "CveClase1=@CveClase1,  " +
                        "CveClase2=@CveClase2,  " +
                        //"Modelo=@Modelo,  " +
                        //"CveMarca=@CveMarca,  " +
                        //"FecUltCompra=@FecUltCompra,  " +
                        //"CveProveedorUlt=@CveProveedorUlt, " +
                        "CveClase3=@CveClase3  " +
                        "Where CveArticulo = @CveArticulo";
            return db.DeleteRegistro(sql, ArrParametros);
        }

        public int DeleteArticulo()
        {
            string sql = "Delete from inv_CatArticulos where CveArticulo = @CveArticulo";
            return db.UpdateRegistro(sql, ArrParametros);
        }

        public SqlDataAdapter ListArticulos()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveArticulo as Clave,CodigoBarra as Codigo,A.Descripcion,CodigoSat as 'Codigo SAT',Modelo,"+
                         "L.Descripcion as Linea,M.Descripcion as Marca,C.Descripcion as Clase,UM.Descripcion as 'U Medida',Observacion " +
                         "FROM inv_CatArticulos A Left join Inv_Lineas L on A.CveLinea = L.CveLinea " +
                         "Left join Inv_Clases C on A.CveClase1 = C.CveClase " +
                         "Left Join Inv_UMedidas UM on A.CveUMedida1 = UM.CveUMedida  " +
                         "Left Join Inv_Marcas M on A.CveMarca = M.Descripción";
            dt = db.SelectDA(Sql);
            return dt;
        }

        public SqlDataAdapter RegistroActivo()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select * " +
                          "from Inv_CatArticulos where CveArticulo =@CveArticulo";
            dt = db.SelectDA(Sql, ArrParametros);
            return dt;
        }

        public SqlDataAdapter BuscaArticulo(string bsq)
        {
            SqlDataAdapter dt = null;
            string sql = "Select CveArticulo as Clave,CodigoBarra as Codigo,A.Descripcion,CodigoSat as 'Codigo SAT',Modelo," +
                         "L.Descripcion as Linea,M.Descripcion as Marca,C.Descripcion as Clase,UM.Descripcion as 'U Medida',Observacion" +
               "FROM inv_CatArticulos A Left join Inv_Lineas L on A.CveLinea = L.CveLinea " +
                         "Left join Inv_Clases C on A.CveClase1 = C.CveClase " +
                         "Left Join Inv_UMedidas UM on A.CveUMedida1 = UM.CveUMedida  " +
                         "Left Join Inv_Marcas M on A.CveMarca = M.Descripción"+
               "where CveArticulo like '%" + bsq + "%' OR " +
               "A.Descripcion  like '%" + bsq + "%' OR " +
               "CodigoBarra    like '%" + bsq + "%' OR " +
               "M.Descripcion  like '%" + bsq + "%' OR " +
               "L.Descripcion  like '%" + bsq + "%' OR " +
               "C.Descripcion  like '%" + bsq + "%' OR " +
               "UM.Descripcion like '%" + bsq + "%' OR " +
               "CodigoSat like '%" + bsq + "%'";


            dt = db.SelectDA(sql);
            return dt;
        }
        public SqlDataAdapter ComboImpuesto()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveImpuesto as Clave,Tipo as Descripcion " +
                         "from Inv_Impuestos where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter ComboClase()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveClase as Clave,Descripcion " +
                         "from Inv_Clases where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }
        public SqlDataAdapter ComboMarca()
        {
            SqlDataAdapter dt = null;
            string Sql = "Select CveMarca as Clave,Descripcion " +
                         "from Inv_Marcas where Estatus=1";
            dt = db.SelectDA(Sql);
            return dt;
        }

    }
}
