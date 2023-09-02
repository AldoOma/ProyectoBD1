using Sol_AllMarket.Entidades;
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
    public partial class P_EmpleadoAdd : Form
    {
        private int? Id;
        private P_Empleado Form;
        private P_FormPrincipal principal;

        public P_EmpleadoAdd(P_Empleado Form, P_FormPrincipal principal, int? Id = null)//puede recibir o no un id
        {
            InitializeComponent();
            this.Form = Form;
            this.Id = Id;
            this.principal = principal;
            if (Id != null)
            {
                setDatosCategoria();//si el id tiene un valor es porque se trata de editar
            }

            DataTable dt = N_Cargo.listNombresCargos();
            cbxCargos.ValueMember = "Id";
            cbxCargos.DisplayMember = "Nombre";
            cbxCargos.DataSource = dt;

        }

        private void setDatosCategoria()
        {
            E_Empleado c = N_Empleado.getInfoEmpleado((int)this.Id);
            if (c != null)
            {
                fillCampos(c);
            }
        }

        private void setDatosCargos()
        {

        }

        private void fillCampos(E_Empleado c)
        {

            txtCedula.Text = c.Cedula;

            txtNombres.Text = c.NombreCompleto;

            txtApellidos.Text = c.ApellidoCompleto;

            cbxCargos.SelectedIndex = c.IdCargo;

        }

       

        private void clearCampos()
        {
        }


        private void P_CategoriaAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Id != null)
            {
                //es una actualizacion

                if (N_Empleado.editEmpleado(getValueCampos()) > 0)//si se puede actualizar
                {

                    this.Form.setDatosGrid();

                    this.Close();

                    this.principal.abrirForm(new P_Empleado(principal));
                }
            }
            else
            {
                //es guardado

                if (N_Empleado.insertEmpleado(getValueCampos()) > 0)
                {
                    this.Form.setDatosGrid();


                    this.Close();
                    
                    this.principal.abrirForm(new P_Empleado(principal));
                }

            }
        }

        private E_Empleado getValueCampos()
        {
            //es una actualizacion
            E_Empleado c = new E_Empleado();

            //Obtenemos los valores de nombre
            string[] nombres;

            if (!String.IsNullOrEmpty(txtNombres.Text))
            {
                nombres = txtNombres.Text.Trim().Split(' ');

                if (nombres.Length == 1 || nombres.Length == 2)
                {
                    if (String.IsNullOrEmpty(nombres[1]))
                    {
                        c.PrimerNombre = nombres[1].ToString();
                    }

                    c.SegundoNombre = nombres[2].ToString();

                }

            }

            //Obtenemos los valores del apellido
            string[] apellidos;

            if (!String.IsNullOrEmpty(txtApellidos.Text))
            {
                apellidos = txtApellidos.Text.Trim().Split(' ');

                if (apellidos.Length == 1 || apellidos.Length == 2)
                {
                    if (String.IsNullOrEmpty(apellidos[1]))
                    {
                        c.PrimerApellido = apellidos[1].ToString();
                    }

                    c.SegundoApellido = apellidos[2].ToString();

                }

            }

            c.Cedula = txtCedula.Text;
            DateTime fechaIngreso;
            DateTime.TryParse(dtpIngreso.Text, out fechaIngreso);
            c.FechaIngreso = fechaIngreso;
            c.IdCargo = cbxCargos.SelectedIndex;

            return c;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.principal.abrirForm(new P_Categoria(principal));
        }

        private void P_EmpleadoAdd_Load(object sender, EventArgs e)
        {

        }

        private ErrorProvider error;
        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            error = new ErrorProvider();

            //no vacio
            if (!Validacion.textosVacios(txtCedula)) error.SetError(txtCedula, "No se admiten campos vacios");
            else error.Clear();

            //cedula en formato correcto
            if (!Validacion.validarCedula(txtCedula.Text)) error.SetError(txtCedula, "Formato de cédula no valido");
            else error.Clear();


                
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            error = new ErrorProvider();
            //no vacio
            if (!Validacion.textosVacios(txtNombres)) error.SetError(txtNombres, "No se admiten campos vacios");
            else error.Clear();

            //solo letras
            if (!Validacion.soloLetras(e)) error.SetError(txtNombres, "No se admiten numeros");
            else error.Clear();
        }

        private void txtApellidos_KeyPress(object sender, KeyPressEventArgs e)
        {
            error = new ErrorProvider();
            //no vacio
            if (!Validacion.textosVacios(txtApellidos)) error.SetError(txtApellidos, "No se admiten campos vacios");
            else error.Clear();

            //solo letras
            if (!Validacion.soloLetras(e)) error.SetError(txtApellidos, "No se admiten numeros");
            else error.Clear();
        }
    }
}
