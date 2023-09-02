using Sol_AllMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sol_AllMarket.Datos;

namespace Sol_AllMarket.Negocio
{
    public class N_Categoria
    {
        //Listar
        public static List<E_Categoria> getCategorias()
        {

            D_Categoria c = new D_Categoria();
            return c.getCategorias();

        }

        //Obtener el id actual de la tabla
        public static int GetCurrentId()
        {
            D_Categoria c = new D_Categoria();
            return c.GetCurrentId();
        }

        //Buscar por id
        public static E_Categoria getInfoCategoria(int id)
        {

            D_Categoria c = new D_Categoria();
            return c.getInfoCategoria(id);

        }

        //Guardar
        public static int insertCategoria(E_Categoria e)
        {

            D_Categoria c = new D_Categoria();
            return c.insertCategoria(e);

        }

        //Editar

        public static int editCategoria(E_Categoria e)
        {
            D_Categoria c = new D_Categoria();
            return c.editCategoria(e);
        }

        //Eliminar

        public static int deleteCategoria(int Id)
        {
            D_Categoria c = new D_Categoria();
            return c.deleteCategoria(Id);
        }


    }
}
