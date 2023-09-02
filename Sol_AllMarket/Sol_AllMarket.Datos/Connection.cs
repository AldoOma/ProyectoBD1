using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Datos
{
    public class Connection
    {
        //Variables para la conexion
        private string dataSource, initialCatalog, user, password;
        private bool integratedSecurity, columnEncryption;
        private string connectionString;
        /*
         dataSource = nombre del servidor
         initialCatalog = nombre de la base de datos
         user = nombre del usuario
         password = contraseña para ese usuario
          integratedSecurity = si es true se utilizara la autentificacion de windows, de ser false entonces se debe especificar el usuario y la contraseña
         columnEncryption = true lo que hará será habilitar Always Encrypted
         */

        public Connection()
        {
            dataSource = "Aldo\\SQLEXPRESS";
            initialCatalog = "bd_market";
            user = "sa";
            password = "Azlun101201#";
            integratedSecurity = true;
            columnEncryption = true;
            setConnectionString();
        }

        //Metodo que nos ayudará a establecer la cadena de conexion
        private void setConnectionString()
        {
            connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};";

            if (integratedSecurity) connectionString += "Integrated Security=SSPI;";
            else connectionString += $"User={user};Password={password};";
            if (columnEncryption) connectionString += "Column Encryption Setting=enabled";
        }


        public string getConnectionString()
        {
            return connectionString;
        }
    }
}
