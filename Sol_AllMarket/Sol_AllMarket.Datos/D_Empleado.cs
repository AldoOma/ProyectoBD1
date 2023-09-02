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
    public class D_Empleado
    {
        /*Aquí estaran todos los metodos para insertar, ver, 
         * eliminar y actualizar categorias
         * */

        private Connection conn;

        public D_Empleado()
        {

            conn = new Connection();

        }

        //Este metodo nos retorna una lista con los datos de las categorias
        public List<E_Empleado> getEmpleados()
        {
            //lista que me devolverá las categorías
            List<E_Empleado> listEmpleados = new List<E_Empleado>();

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

                    command.CommandText = "SP_MostrarEmpleados";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    while (reader.Read())
                    {//mientras haya contenido que leer entonces que haga:


                        E_Empleado empleado = new E_Empleado();

                        empleado.Id = Convert.ToInt32(reader["Id"]);
                        empleado.Cedula = Convert.ToString(reader["Cedula"]);
                        empleado.NombreCompleto = Convert.ToString(reader["NombreCompleto"]);
                        empleado.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);

                        //agregamos el objeto a la lista
                        listEmpleados.Add(empleado);

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
            return listEmpleados;
        }

        public int GetCurrentId()
        {
            int currentId = 0;
            string query = "SELECT IDENT_CURRENT('Empleados') 'Ident_Current';";

            SqlConnection connection = null;

            try
            {
                //using para crear y abrir la conexion, además los recursos serán cerrados
                using (connection = new SqlConnection(conn.getConnectionString()))
                {
                    //Creamos una instancia de la clase SqlCommand
                    SqlCommand command = new SqlCommand(query, connection);

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta
                    connection.Open();

                    //ahora ejecutamos la consulta
                    SqlDataReader reader = command.ExecuteReader();

                    //leemos el resultado del comando
                    if (reader.Read())
                    {   //si hay contenido que leer entonces:

                        currentId = Convert.ToInt32(reader["Ident_Current"]);

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

            return currentId;
        }

        //Este metodo nos ayudará a obtener la información de la categoria segun su ID

        public E_Empleado getInfoEmpleado(int Id)
        {

            E_Empleado e = new E_Empleado();

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

                    command.CommandText = "SP_ObtenerEmpleadoPorId";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    //establecemos los valores de los parametros

                    command.Parameters.AddWithValue("@Id", Id);


                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    if (reader.Read())
                    {//si hay contenido que leer entonces:

                        

                        e.Cedula = reader.GetString(0);
                        e.NombreCompleto = reader.GetString(1);
                        e.ApellidoCompleto = reader.GetString(2);
                        e.NombreCargo = reader.GetString(3);
                        e.FechaIngreso = reader.GetDateTime(4);
                        e.IdCargo = reader.GetInt32(5);

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

        //Este metodo guarda un empleado en la base de datos
        public int insertEmpleado(E_Empleado empleado)
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

                    command.CommandText = "SP_AgregarEmpleado";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@Cedula", empleado.Cedula);
                    
                    command.Parameters.AddWithValue("@PrimerNombre", empleado.PrimerNombre);
                   
                    command.Parameters.AddWithValue("@SegundoNombre", empleado.SegundoNombre);

                    command.Parameters.AddWithValue("@PrimerApellido", empleado.PrimerApellido);

                    command.Parameters.AddWithValue("@SegundoApellido", empleado.SegundoApellido);

                    command.Parameters.AddWithValue("@IdCargo",empleado.IdCargo);

                    command.Parameters.AddWithValue("@FechaIngreso", empleado.FechaIngreso);

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
        public int editEmpleado(E_Empleado e)
        {
            E_Empleado c = new E_Empleado();
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

                    command.CommandText = "SP_EditarEmpleado";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@Id", e.Id);
                    command.Parameters.AddWithValue("@Cedula", e.Cedula);
                    command.Parameters.AddWithValue("@PrimerNombre", e.PrimerNombre);
                    command.Parameters.AddWithValue("@SegundoNombre", e.SegundoNombre);
                    command.Parameters.AddWithValue("@PrimerApellido", e.PrimerApellido);
                    command.Parameters.AddWithValue("@SegundoApellido", e.SegundoApellido);
                    command.Parameters.AddWithValue("@IdCargo", e.IdCargo);
                    command.Parameters.AddWithValue("@FechaIngreso", e.FechaIngreso);

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

        //Este metodo va a eliminar un empleado
        public int deleteEmpleado(int Id, DateTime FechaSalida)
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

                    command.CommandText = "SP_EliminarEmpleado";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@Id", Id);

                    //agregamos el valor de la fecha de salida del empleado

                    command.Parameters.AddWithValue("@FechaSalida", FechaSalida);

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
