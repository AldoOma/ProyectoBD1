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
    public partial class P_CargoAdd : Form
    {
        private void P_CargoAdd_Load(object sender, EventArgs e)
        {

        }
        private int? Id;
        private P_Cargo Form;
        private P_FormPrincipal principal;

        public P_CargoAdd(P_Cargo Form, P_FormPrincipal principal, int? Id = null)//puede recibir o no un id
        {
           InitializeComponent();
           this.Form = Form;
           this.Id = Id;
           this.principal = principal;
           if (Id != null)
           {
               setDatosCargos();//si el id tiene un valor es porque se trata de editar
           }
        }

        private void setDatosCargos()
        {

           E_Cargo c = N_Cargo.getInfoCargo((int)this.Id);
           if (c != null)
           {
               fillCampos(c);
           }
        }

        private void fillCampos(E_Cargo c)
        {
           txtNombreCargo.Text = c.Nombre;
           rtbDescripcionCargo.Text = c.Descripcion;
           txtSalario.Text = Convert.ToString(c.Salario);


        }


        private void clearCampos()
        {
           txtNombreCargo.Text = "";
           rtbDescripcionCargo.Text = "";
           txtSalario.Text = "";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           if (Id != null)
           {
               //es una actualizacion

               if (N_Cargo.editCargo(getValueCampos()) > 0)//si se puede actualizar
               {

                   this.Close();
                   this.principal.abrirForm(new P_Cargo(principal));
                   this.Form.setDatosGrid();
               }
           }
           else
           {
               //es guardado

               if (N_Cargo.insertCargo(getValueCampos()) > 0)
               {
                   this.Form.setDatosGrid();

                   this.Close();

                   this.principal.abrirForm(new P_Cargo(principal));
               }

           }
        }

        private E_Cargo getValueCampos()
        {        
           E_Cargo e = new E_Cargo();
           e.Nombre = txtNombreCargo.Text;
           e.Descripcion = rtbDescripcionCargo.Text;
           e.Salario = float.Parse(txtSalario.Text);
           return e;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           this.Close();
           this.principal.abrirForm(new P_Cargo(principal));
        }


        private ErrorProvider error;
        private void txtNombreCargo_KeyPress(object sender, KeyPressEventArgs e)
        {
           error = new ErrorProvider();
           //solo letras
           if (!Validacion.soloLetras(e)) error.SetError(txtNombreCargo, "No se admiten numeros");
           else error.Clear();
           //no vacio
           if (!Validacion.textosVacios(txtNombreCargo)) error.SetError(txtNombreCargo, "No se admiten campos vacios");
           else error.Clear();
        }

        private void txtSalario_KeyPress(object sender, KeyPressEventArgs e)
        {
           int precio = 0;
           try
           {
               precio = Int32.Parse(txtSalario.Text);
           }catch(Exception ex)
           {
           }
           error = new ErrorProvider();
           //solo numeros y punto por el decimal
           if (!Validacion.soloNumerosPunto(e)) error.SetError(txtSalario, "Solo numeros");
           else error.Clear();
           //no vacio
           if (!Validacion.textosVacios(txtSalario)) error.SetError(txtNombreCargo, "No se admiten campos vacios");
           else error.Clear();
           //no negativos ni 0
           if (!Validacion.mayorCero(precio)) error.SetError(txtSalario, "Salario debe ser mayor a cero");
           else error.Clear();
        }
    }
}
