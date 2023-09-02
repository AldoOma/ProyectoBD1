using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sol_AllMarket.Entidades;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Sol_AllMarket.Datos
{
    public class D_Categoria
    {
        /*Aquí estaran todos los metodos para insertar, ver, 
         * eliminar y actualizar categorias
         * */

        private Connection conn;

        public D_Categoria() {

            conn = new Connection();
        
        }

        //Este metodo nos retorna una lista con los datos de las categorias
        public List<E_Categoria> getCategorias()
        {
            //lista que me devolverá las categorías
            List<E_Categoria> listCategorias = new List<E_Categoria>();
          
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


                            E_Categoria categoria = new E_Categoria();

                            categoria.Id = reader.GetInt32(0);

                            categoria.Nombre = reader.GetString(1);

                            categoria.Descripcion = reader.GetString(2);

                            //agregamos el objeto a la lista
                            listCategorias.Add(categoria);
                    }

                    reader.Close();//cerramos el lector
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }finally
            {
                if (connection != null)
                    connection.Close();
            }
            return listCategorias;
        }

        public int getCurrentId()
        {
            int currentId=0;
            string query = "SELECT IDENT_CURRENT('Categorias') 'Ident_Current';";

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

        public E_Categoria getInfoCategoria(int Id)
        {

            E_Categoria e = new E_Categoria();

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

                    command.CommandText = "SP_ObtenerCategoriaPorId";

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

                        e.Nombre = reader.GetString(1);

                        e.Descripcion = reader.GetString(2);
                       
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
        public bool insertCategoria(E_Categoria categoria)
        {
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

                    command.CommandText = "SP_AgregarCategorias";

                    //abrimos la conexion ya que ExecuteReader necesita una conexion abierta

                    connection.Open();


                    //agregamos el valor que tendran los parametros 

                    command.Parameters.AddWithValue("@Nombre", categoria.Nombre);
                    command.Parameters.AddWithValue("@Descripcion", categoria.Descripcion);

                    //va a devolver 1 si se pudo insertar y 0 si no se pudo
                    int rowAffected = command.ExecuteNonQuery();

                    //si es falso es porque no se pudo guardar
                    if (rowAffected == 0) return false;
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
            return true;
        }
    }
}
