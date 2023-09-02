using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Entidades
{
    public class E_Usuario
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Contrasenia { get; set; }

        public int IdRol { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime HoraCreacion { get; set; }

        public DateTime UltimaActualizacion { get; set; }

        public string NombreEmpleado { get; set; }

        public DateTime FechaHoraCreacion { get; set; }


    }
}
