using Sol_AllMarket.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_AllMarket.Datos
{
    public class D_Usuario
    {
        private Connection conn;

        public D_Usuario()
        {

            conn = new Connection();

        }

  

        //PROCEDIMIENTO ALMACENADO PARA OBTENER EL ID DEL ROL DEL USUARIO
        public int obtenerRol(string Nombre, string Contrasenia )
        {
            int idRol = 0;

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

                    command.CommandText = "SP_ObtenerIdRol";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    //establecemos los valores de los parametros

                    command.Parameters.AddWithValue("@NombreUsuario", Nombre);
                    command.Parameters.AddWithValue("@ContraseniaUsuario", Contrasenia);

                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    if (reader.Read())
                    {//si hay contenido que leer entonces:

                        idRol = reader.GetInt32(0);

                        

                    }

                    reader.Close();//cerramos el lector

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return idRol;
        }


        //Este metodo nos retorna una lista con los usuarios activos
        public List<E_Usuario> getUsuarios()
        {
            //lista que me devolverá las categorías
            List<E_Usuario> listUsuario = new List<E_Usuario>();

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

                    command.CommandText = "SP_MostrarCategorias";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    while (reader.Read())
                    {//mientras haya contenido que leer entonces que haga:


                        E_Usuario usuario = new E_Usuario();

                        usuario.Nombre = Convert.ToString(reader["Nombre"]);
                        usuario.NombreEmpleado = Convert.ToString(reader["Empleado"]);
                        usuario.FechaHoraCreacion = Convert.ToDateTime(reader["Fecha/Hora de creación"]);
                        usuario.UltimaActualizacion = Convert.ToDateTime(reader["UltimaActualizacion"]);

                        //agregamos el objeto a la lista
                        listUsuario.Add(usuario);

                    }

                    reader.Close();//cerramos el lector

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            /*for (int i = 0; i < listCategorias.Count; i++)
            {
                MessageBox.Show($"ID: {listCategorias[i].Id}, Nombre: {listCategorias[i].Nombre}, Descripcion: {listCategorias[i].Descripcion}");
            }*/
            return listUsuario;
        }

 
        //Este metodo nos ayudará a obtener la información de la categoria segun su ID

        public E_Usuario getInfoUsuario(int Id)
        {

            E_Usuario e = new E_Usuario();

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

                    command.CommandText = "SP_ObtenerUsuarioPorId";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    //establecemos los valores de los parametros

                    command.Parameters.AddWithValue("@Id", Id);


                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    if (reader.Read())
                    {//si hay contenido que leer entonces:

                        e.Id = reader.GetInt32(0);

                    }

                    reader.Close();//cerramos el lector

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return e;
        }

        //Este metodo guarda una categoria en la base de datos
        public int insertUsuario(E_Usuario usuario)
        {
            SqlConnection connection = null;
            int rowsAffected = 0;
            try
            {
                //using para crear y abrir la conexion, además los recursos serán cerrados
                using (connection = new SqlConnection(conn.getConnectionString()))
                {
                    //Primero vamos a recuperar los mensajes del print
                    connection.InfoMessage += ConnectionMessage;

                    //Creamos una instancia de la clase SqlCommand
                    SqlCommand command = new SqlCommand();

                    //Especificamos la conexion
                    command.Connection = connection;

                    //Especificamos el tipo de comando, por defecto viene como texto
                    command.CommandType = CommandType.StoredProcedure;

                    //El nombre del procedimiento al que queremos llamar

                    command.CommandText = "SP_AgregarUsuario";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@IdEmpleado", usuario.Id);
                    command.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    command.Parameters.AddWithValue("@Contrasenia", usuario.Contrasenia);
                    command.Parameters.AddWithValue("@IdRol", usuario.IdRol);

                    //va a devolver 1 si se pudo insertar y 0 si no se pudo
                    rowsAffected = command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return rowsAffected;
        }

        //Este metodo va a editar una categoria
        public int editUsuario(E_Usuario e)
        {
            E_Usuario c = new E_Usuario();
            int rowsAffected = 0;
            SqlConnection connection = null;

            try
            {
                //using para crear y abrir la conexion, además los recursos serán cerrados
                using (connection = new SqlConnection(conn.getConnectionString()))
                {
                    //Primero vamos a recuperar los mensajes del print
                    connection.InfoMessage += ConnectionMessage;

                    //Creamos una instancia de la clase SqlCommand
                    SqlCommand command = new SqlCommand();

                    //Especificamos la conexion
                    command.Connection = connection;

                    //Especificamos el tipo de comando, por defecto viene como texto
                    command.CommandType = CommandType.StoredProcedure;

                    //El nombre del procedimiento al que queremos llamar

                    command.CommandText = "SP_EditarUsuario";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@Id", e.Id);
                    command.Parameters.AddWithValue("@Nombre", e.Nombre);
                    command.Parameters.AddWithValue("@Contrasenia", e.Contrasenia);
                    command.Parameters.AddWithValue("@IdRol", e.IdRol);


                    //va a devolver 1 si se pudo borrar y 0 si no se pudo
                    rowsAffected = command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }

            return rowsAffected;
        }

        //Este metodo va a eliminar una categoria
        public int deleteUsuario(int Id)
        {
            SqlConnection connection = null;
            int rowsAffected = 0;
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

                    command.CommandText = "SP_EliminarUsuario";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@Id", Id);

                    //va a devolver 1 si se pudo borrar y 0 si no se pudo
                    rowsAffected = command.ExecuteNonQuery();


                    return rowsAffected;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return rowsAffected;
        }

        
        private static void ConnectionMessage(object sender, SqlInfoMessageEventArgs e)
        {
            foreach (SqlError error in e.Errors)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}
