using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAFE
{
    class clsGenCombos
    {
        private String Codigo;
        private String Descripcion;

        private Object[,] Datos;

        public clsGenCombos(String Codigo, String Descripcion)
        {
            this.Codigo = Codigo;
            this.Descripcion = Descripcion;
        }

        public clsGenCombos(Object[,] Datos)
        {
            this.Datos = Datos;
        }

        public void setCodigo(String Codigo)
        {
            this.Codigo = Codigo;
        }

        public void setDescripcion(String Descripcion)
        {
            this.Descripcion = Descripcion;
        }

        public String getCodigo()
        {
            return Codigo;
        }

        public String getDescripcion()
        {
            return Descripcion;
        }

        public String getCodigo(String Descripcion)
        {
            String dv = "";
            for (int j = 0; j < this.Datos.GetUpperBound(0) + 1; j++)
            {
                if (Descripcion == this.Datos[j,1].ToString())
                {
                    dv = this.Datos[j,0].ToString();
                    break;
                }
            }
            return dv;
        }

        public String getDescripcion(String Codigo)
        {
            String dv = "";
            for (int j = 0; j < this.Datos.GetUpperBound(0) + 1; j++)
            {
                if (Codigo == this.Datos[j,0].ToString())
                {
                    dv = this.Datos[j,1].ToString();
                    break;
                }
            }
            return dv;
        }

        public String getDescripcionInt(int Codigo)
        {
            String dv = "";
            for (int j = 0; j < this.Datos.GetUpperBound(0) + 1; j++)
            {
                if (int.Parse(this.Datos[j,0].ToString()) == Codigo)
                {
                    dv = this.Datos[j,1].ToString();
                    break;
                }
            }
            return dv;
        }
    }
}
