using Sol_AllMarket.Datos;
using Sol_AllMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Negocio
{
    public class N_Empleado
    {
        //Listar
        public static List<E_Empleado> getEmpleados()
        {

            D_Empleado c = new D_Empleado();
            return c.getEmpleados();

        }

        //Buscar por id
        public static E_Empleado getInfoEmpleado(int Id)
        { 
            D_Empleado c = new D_Empleado();
            return c.getInfoEmpleado(Id);

        }

        //Guardar
        public static int insertEmpleado(E_Empleado e)
        {

            D_Empleado c = new D_Empleado();
            return c.insertEmpleado(e);

        }

        //Editar

        public static int editEmpleado(E_Empleado e)
        {
            D_Empleado c = new D_Empleado();
            return c.editEmpleado(e);
        }

        //Eliminar

        public static int deleteEmpleado(int Id,DateTime FechaSalida)
        {
            D_Empleado c = new D_Empleado();
            return c.deleteEmpleado(Id, FechaSalida);
        }


    }
}

