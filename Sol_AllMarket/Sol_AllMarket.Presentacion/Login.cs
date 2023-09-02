using Sol_AllMarket.Negocio;
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
    public partial class Login : Form
    {
        private int idRol;
        private string usuario, contrasenia;

        public Login()
        {
            InitializeComponent();
            txtUsuarioContraseña.MaxLength = 30;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private ErrorProvider error;
        private void txtUsuarioNombre_KeyPress(object sender, KeyPressEventArgs e)
        {/*
            error = new ErrorProvider();
            //no vacio
            if (!Validacion.textosVacios(txtUsuarioNombre)) error.SetError(txtUsuarioNombre, "Campo vacio y requerido");
            else error.Clear();

            //no vacio
            if (!Validacion.textosVacios(txtUsuarioContraseña)) error.SetError(txtUsuarioContraseña, "Campo vacio y requerido");
            else error.Clear();*/
        }

        private void txtUsuarioContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtUsuarioContraseña.PasswordChar = '\0'; // Mostrar contraseña sin enmascararla
            }
            else
            {
                txtUsuarioContraseña.PasswordChar = '*'; // Enmascarar la contraseña
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
                 usuario = txtUsuarioNombre.Text;
                contrasenia = txtUsuarioContraseña.Text;

                
                int idRol = N_Usuario.obtenerIdRol(usuario, contrasenia);
                //MessageBox.Show("idrol:" + idRol);

                if (idRol != 0)
                {

                P_FormPrincipal p = new P_FormPrincipal(idRol);
                //MessageBox.Show("idrol:" + idRol);
                this.Visible = false;
                p.Show();
                

                }
           
            
           
        }

    }
}
