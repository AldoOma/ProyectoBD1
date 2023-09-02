using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Sol_AllMarket.Presentacion
{
    public class Validacion
    {

        public static bool soloNumeros(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
  
                e.Handled = true;
                return false;
            }
            else
            { e.Handled = false; return true; }    

        }


        public static bool soloLetras(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 96) || (e.KeyChar >= 123 && e.KeyChar <= 255))
            {
                
                e.Handled = true;
                return false;
            }
            { e.Handled = false; return true; }
        }

        //es un metodo para que admita solo numeros pero pueda admitir el punto
        public static bool soloNumerosPunto(KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 45 && e.KeyChar != 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {

                e.Handled = true;
                return false;
            }
            else
            { e.Handled = false; return true; }
        }

        public static bool textosVacios(TextBox txt)
        {
            if (String.IsNullOrEmpty(txt.Text))
            {
                txt.Focus();
                return true;
            }
            return false;
        }

        public static bool validarCedula(String cedula)
        {
            return cedula != null && Regex.IsMatch(cedula,"[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][0-9][0-9]-[0-9][0-9][0-9][0-9][A-Z]");
        }

        public static bool mayorCero(int num)
        {
            if (num >= 0) return true;
            return false;
        }
         
    }
}
