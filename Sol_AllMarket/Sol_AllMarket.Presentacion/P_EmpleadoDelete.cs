using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_AllMarket.Presentacion
{
    public partial class P_EmpleadoDelete : Form
    {
        private P_FormPrincipal principal;
        private static DateTime fechaSalida;

        public P_EmpleadoDelete(P_FormPrincipal principal)
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            //si se puede convertir en fecha entonces lo guardara en la variable fechaSalida
            DateTime.TryParse(dtpFechaSalida.Text, out fechaSalida);
            this.Close();
            //this.principal.abrirForm(new P_Empleado(principal));
        }

        public static DateTime getFechaSalida()
        {
            return fechaSalida;
        }

        private void P_EmpleadoDelete_Load(object sender, EventArgs e)
        {

        }
    }
}
