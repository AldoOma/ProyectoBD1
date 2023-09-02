using Sol_AllMarket.Datos;
using Sol_AllMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Negocio
{
    public class N_PermisoRol
    {
        public static List<E_PermisoRol> listPermisoRol(int IdRol)
        {
            return new D_PermisoRol().listPermisoRol(IdRol);
        }

        public static List<E_PermisoRol> listPermisoRolModulo(int IdRol)
        {
            return new D_PermisoRol().listPermisoRolModulo(IdRol);
        }
    }
}
