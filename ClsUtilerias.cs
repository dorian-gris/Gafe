using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace GAFE
{
    class ClsUtilerias
    {
        private Boolean Ans = false;
        private Regex ExpReg = null;

        public Boolean Numeros(string PStr)
        {
            ExpReg = new Regex("^\\d*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public Boolean Letras(string PStr)
        {
            ExpReg = new Regex("^[a-zñÑA-Z]*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public Boolean LetrasSpa(string PStr)
        {
            ExpReg = new Regex("^[a-zñÑA-Z\\s]*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

        public Boolean LetrasNum(string PStr)
        {
            ExpReg = new Regex("^[0-9a-zñÑA-Z]*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }
        public Boolean LetrasNumSpa(string PStr)
        {
            ExpReg = new Regex("^[0-9a-zñÑA-Z\\s]*$");
            Ans = ExpReg.IsMatch(PStr) ? true : false;
            return Ans;
        }

    }
}
