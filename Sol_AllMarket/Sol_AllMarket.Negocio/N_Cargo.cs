using Sol_AllMarket.Datos;
using Sol_AllMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Negocio
{
    public class N_Cargo
    {
        //Listar
        public static List<E_Cargo> getCargos()
        {

            D_Cargo c = new D_Cargo();
            return c.getCargos();

        }

        //Guardar
        public static int insertCargo(E_Cargo e)
        {

            D_Cargo c = new D_Cargo();
            return c.insertCargo(e);

        }
        //Buscar por id
        public static E_Cargo getInfoCargo(int Id, string Nombre = null)
        {

            D_Cargo c = new D_Cargo();
            return c.getInfoCargo(Id,Nombre);

        }

        //Editar
        
        public static int editCargo(E_Cargo e)
        {
            D_Cargo c = new D_Cargo();
            return c.editCargo(e);
        }

        //Eliminar

        public static int deleteCargo(int Id)
        {
            D_Cargo c = new D_Cargo();
            return c.deleteCargo(Id);
        }

        //Metodo usado para llenar el combobox

        public static DataTable listNombresCargos()
        {
            D_Cargo c = new D_Cargo();
            return c.listNombresCargos();
        }
    }
}
