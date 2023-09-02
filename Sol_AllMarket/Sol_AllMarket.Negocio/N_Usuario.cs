using Sol_AllMarket.Datos;
using Sol_AllMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Negocio
{
    public class N_Usuario
    {
       //Obtener el rol del usuario
       public static int obtenerIdRol(string Nombre, string Contrasenia)
        {
            return new D_Usuario().obtenerRol(Nombre, Contrasenia);
        }



        //Listar
        public static List<E_Usuario> getUsuarios()
        {

            D_Usuario c = new D_Usuario();
            return c.getUsuarios();

        }


        //Buscar por id
        public static E_Usuario getInfoUsuario(int id)
        {

            D_Usuario c = new D_Usuario();
            return c.getInfoUsuario(id);

        }

        //Guardar
        public static int insertUsuario(E_Usuario e)
        {

            D_Usuario c = new D_Usuario();
            return c.insertUsuario(e);

        }

        //Editar

        public static int editUsuario(E_Usuario e)
        {
            D_Usuario c = new D_Usuario();
            return c.editUsuario(e);
        }

        //Eliminar

        public static int deleteUsuario(int Id)
        {
            D_Usuario c = new D_Usuario();
            return c.deleteUsuario(Id);
        }
    }
}
