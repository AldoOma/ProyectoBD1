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
    public partial class P_CategoriaAdd : Form
    {
        private int? Id;
        private P_Categoria Form;
        private P_FormPrincipal principal;
        public P_CategoriaAdd(P_Categoria Form, P_FormPrincipal principal, int? Id = null)//puede recibir o no un id
        {
            InitializeComponent();
            this.Form = Form;
            this.Id = Id;
            this.principal = principal;
            txtIdCategoria.Text = (N_Categoria.GetCurrentId() + 1).ToString();
            if (Id != null)
            {
                setDatosCategoria();//si el id tiene un valor es porque se trata de editar
            }
        }

        private void setDatosCategoria()
        {
            E_Categoria c =  N_Categoria.getInfoCategoria((int)this.Id);
            if (c != null)
            {
                fillCampos(c);
            }
        }

        private void fillCampos(E_Categoria c)
        {
            
            txtIdCategoria.Text = c.Id.ToString();
            txtNombreCategoria.Text = c.Nombre;
            rtbDescripcionCategoria.Text = c.Descripcion;
        }

        
        private void clearCampos()
        {
            txtIdCategoria.Text = "";
            txtNombreCategoria.Text = "";
            rtbDescripcionCategoria.Text = "";
        }
        

        private void P_CategoriaAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Id != null)
            {
                //es una actualizacion
                E_Categoria c = new E_Categoria();
                c.Id = (int) this.Id;
                c.Nombre = txtNombreCategoria.Text;
                c.Descripcion = rtbDescripcionCategoria.Text;
               
                if(N_Categoria.editCategoria(c) > 0)//si se puede actualizar
                {

                    this.Form.setDatosGrid();

                    this.Close();

                    this.principal.abrirForm(new P_Categoria(principal));
                }
            }
            else
            {
                //es guardado

                 if(N_Categoria.insertCategoria(getValueCampos()) > 0)
                {
                    this.Form.setDatosGrid();

                    this.Close();

                   this.principal.abrirForm(new P_Categoria(principal));
                }
                
            }
        }

        private E_Categoria getValueCampos()
        {
            E_Categoria e = new E_Categoria();
            e.Nombre = txtNombreCategoria.Text;
            e.Descripcion = rtbDescripcionCategoria.Text;
            return e;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.principal.abrirForm(new P_Categoria(principal));
        }
    }
}
