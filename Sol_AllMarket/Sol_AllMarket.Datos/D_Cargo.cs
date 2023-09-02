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
    public class D_Cargo
    {
        /*Aquí estaran todos los metodos para insertar, ver, 
 * eliminar y actualizar cargos*/

        private Connection conn;

        public D_Cargo()
        {

            conn = new Connection();

        }

        //Este metodo nos retorna una lista con los datos de los cargos
        public List<E_Cargo> getCargos()
        {
            //lista que me devolverá las categorías
            List<E_Cargo> listCategorias = new List<E_Cargo>();

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

                    command.CommandText = "SP_MostrarCargos";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    while (reader.Read())
                    {//mientras haya contenido que leer entonces que haga:


                        E_Cargo cargo = new E_Cargo();

                        cargo.Id = Convert.ToInt32(reader["Id"]);
                        cargo.Nombre = Convert.ToString(reader["Nombre"]);
                        cargo.Descripcion = Convert.ToString(reader["Descripcion"]);
                        cargo.Salario =(float)reader.GetDouble(3);

                        //agregamos el objeto a la lista
                        listCategorias.Add(cargo);
                        

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

            return listCategorias;

        }

        //Este metodo guarda un cargo en la base de datos
        public int insertCargo(E_Cargo cargo)
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

                    command.CommandText = "SP_AgregarCargo";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@Nombre", cargo.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", cargo.Descripcion);
                    command.Parameters.AddWithValue("@Salario", cargo.Salario);


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


        /*Borrar cargos*/
        public int deleteCargo(int Id)
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

                    command.CommandText = "SP_EliminarCargo";

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

        /*Obtenemos los datos de los cargos para llenar los formularios*/
        public E_Cargo getInfoCargo(int Id, string Nombre = null)
        {

            E_Cargo e = new E_Cargo();

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

                    command.CommandText = "SP_ObtenerCargoPorId";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();

                    //establecemos los valores de los parametros

                    command.Parameters.AddWithValue("@Id", Id);

                    if(Nombre != null)
                    {
                        command.Parameters.AddWithValue("@Nombre", Nombre);
                    }

                    //ahora ejecutamos el procedimiento almacenado
                    SqlDataReader reader = command.ExecuteReader();


                    //leemos el resultado del comando
                    if (reader.Read())
                    {//si hay contenido que leer entonces:

                        e.Id = reader.GetInt32(0);

                        e.Nombre = reader.GetString(1);

                        e.Descripcion = reader.GetString(2);

                        e.Salario = (float) reader.GetDouble(3);

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

        //Este metodo va a editar un cargo
        public int editCargo(E_Cargo e)
        {
            E_Cargo c = new E_Cargo();
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

                    command.CommandText = "SP_EditarCargo";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@Id", e.Id);
                    command.Parameters.AddWithValue("@Nombre", e.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", e.Descripcion);
                    command.Parameters.AddWithValue("@Salario", e.Salario);


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

        //Este metodo se usara para mostrar solo los nombres de los cargos en el combobox
        public DataTable listNombresCargos()
        {
            SqlConnection connection = null;
            DataTable dt = new DataTable();

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

                    command.CommandText = "SP_ObtenerNombresCargos";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

 

                    connection.Open();

                    SqlDataAdapter da = new SqlDataAdapter(command);

                    //Llenamos nuestro datatable con nuestro data adapter 

                    da.Fill(dt);

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
            return dt;
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
