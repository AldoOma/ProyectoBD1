using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Datos
{
    

    internal class Connection
    {
        //Variables para la conexion
        private string dataSource, initialCatalog, user, password;
        private bool integratedSecurity;
        private string connectionString;
        /*
         dataSource = nombre del servidor
         initialCatalog = nombre de la base de datos
         user = nombre del usuario
         password = contraseña para ese usuario
          integratedSecurity = si es true se utilizara la autentificacion de windows, de ser false entonces se debe especificar el usuario y la contraseña
         */

        public Connection()
        {
            dataSource = "DESKTOP-1A2DMPS\\SQLEXPRESS";
            initialCatalog = "bd_market";
            user = "sa";
            password = "Azlun101201#";
            integratedSecurity = true;
            setConnectionString();
        }

        //Metodo que nos ayudará a establecer la cadena de conexion
        private void setConnectionString()
        {
            connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};";

            if (integratedSecurity) connectionString += "Integrated Security=SSPI;";
            else connectionString += $"User={user};Password={password};";
        }


        public string getConnectionString()
        {
            return connectionString;
        }

    }
}
