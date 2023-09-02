using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sol_AllMarket.Entidades
{
    public class E_Empleado
    {
        public int Id { get; set; }

        public string Cedula { get; set; }

        public string PrimerNombre { get; set; }

        public string SegundoNombre { get; set; }

        public string PrimerApellido { get; set; }

        public string SegundoApellido { get; set; }


        public DateTime FechaIngreso { get; set; }


        public bool Estado { get; set; }

        public DateTime FechaSalida { get; set; }

        public int IdCargo { get; set; }

        public String NombreCompleto { get; set; }

        public String ApellidoCompleto { get; set; }

        public String NombreCargo { get; set; }
    }
}
