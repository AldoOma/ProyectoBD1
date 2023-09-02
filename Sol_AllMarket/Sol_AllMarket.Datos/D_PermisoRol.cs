using Sol_AllMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Sol_AllMarket.Datos
{
    public class D_PermisoRol
    {
        private Connection conn;

        public D_PermisoRol()
        {

            conn = new Connection();

        }

         
        public List<E_PermisoRol> listPermisoRol(int IdRol)
        {
            //lista que me devolverá los permisos de un rol
            List<E_PermisoRol> listPermisoRol = new List<E_PermisoRol>();

            SqlConnection connection = null;
            try
            {
                //using para crear y abrir la conexion, además los recursos serán cerrados
                using (connection = new SqlConnection(conn.getConnectionString()))
                {

                    //Creamos una instancia de la clase SqlCommand
                    SqlCommand command = new SqlCommand();

                    //Especificamos la conexion
                    command.Connection = connection;

                    //Especificamos el tipo de comando, por defecto viene como texto
                    command.CommandType = CommandType.StoredProcedure;

                    //El nombre del procedimiento al que queremos llamar

                    command.CommandText = "SP_MostrarOpcionesRol";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    command.Parameters.AddWithValue("@IdRol", IdRol);

                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    while (reader.Read())
                    {//mientras haya contenido que leer entonces que haga:


                        E_PermisoRol pRol = new E_PermisoRol();

                        pRol.IdOpcion = Convert.ToInt32(reader["IdOpcion"]);

                        //agregamos el objeto a la lista
                        listPermisoRol.Add(pRol);


                    }

                    reader.Close();//cerramos el lector

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return listPermisoRol;
        }

        public List<E_PermisoRol> listPermisoRolModulo(int IdRol)
        {
            //lista que me devolverá los permisos de un rol
            List<E_PermisoRol> listPermisoRolModulo = new List<E_PermisoRol>();

            SqlConnection connection = null;
            try
            {
                //using para crear y abrir la conexion, además los recursos serán cerrados
                using (connection = new SqlConnection(conn.getConnectionString()))
                {

                    //Creamos una instancia de la clase SqlCommand
                    SqlCommand command = new SqlCommand();

                    //Especificamos la conexion
                    command.Connection = connection;

                    //Especificamos el tipo de comando, por defecto viene como texto
                    command.CommandType = CommandType.StoredProcedure;

                    //El nombre del procedimiento al que queremos llamar

                    command.CommandText = "SP_MostrarModuloOpciones";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    command.Parameters.AddWithValue("@IdRol", IdRol);

                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    while (reader.Read())
                    {//mientras haya contenido que leer entonces que haga:


                        E_PermisoRol pRol = new E_PermisoRol();

                        pRol.IdModulo = Convert.ToInt32(reader["IdModulo"]);

                        //agregamos el objeto a la lista
                        listPermisoRolModulo.Add(pRol);


                    }

                    reader.Close();//cerramos el lector

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return listPermisoRolModulo;
        }
    }
}
