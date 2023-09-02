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
    public partial class P_FormPrincipal : Form
    {
        private int idRol;
        public P_FormPrincipal(int idRol)
        {
            InitializeComponent();
            if(idRol!=null)
            {
                this.idRol = idRol;
            }
            btnCargos.Visible = false;
            btnEmpleados.Visible = false;
            btnUsuario.Visible = false;
            btnClientes.Visible = false;
            btnCategorias.Visible = false;
            btnProveedores.Visible = false;
            btnProductos.Visible = false;
            btnCompras.Visible = false;
            btnVentas.Visible = false;

            menuEmpleados.Visible = false;
            menuUsuarios.Visible = false;
            menuClientes.Visible = false;
            menuProductos.Visible = false;
            menuExistencias.Visible = false;
            setMenuRol();
        }

        private void P_FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void hideMen()
        {
            
        }
        private void hideSubMenu()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }


        public void abrirForm(Form frm)
        {
            while(pnlPrincipal.Controls.Count > 0)
            {
                pnlPrincipal.Controls.RemoveAt(0);
            }

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            //frm.Dock = DockStyle.Fill;
            pnlPrincipal.Controls.Add(frm);
            frm.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            abrirForm(new P_Categoria(this));
        }

        private void btnCargos_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            abrirForm(new P_Cargo(this));
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            abrirForm(new P_Empleado(this));
        }

        private void menuEmpleados_Click(object sender, EventArgs e)
        {
            showSubMenu(panel1);
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }

        private void menuProductos_Click(object sender, EventArgs e)
        {
            showSubMenu(panel4);
        }

        private void menuExistencias_Click(object sender, EventArgs e)
        {
            showSubMenu(panel5);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //abrirForm(new P_Compra(this));
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //abrirForm(new P_Venta(this));
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //abrirForm(new P_Proveedor(this));
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            hideSubMenu();
           // abrirForm(new P_Producto(this));
        }

        private void menuClientes_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            abrirForm(new P_Usuario(this));
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            //abrirForm(new P_Cliente(this));
        }

        //Establecerá el menú según el rol que tenga
        private void setMenuRol()
        {
            //MessageBox.Show("id: " + idRol);
            if(idRol > 0)
            {
                List<Button> listSubMenu = new List<Button>();

                listSubMenu.Add(btnCargos);
                listSubMenu.Add(btnEmpleados);
                listSubMenu.Add(btnUsuario);
                listSubMenu.Add(btnClientes);
                listSubMenu.Add(btnCategorias);
                listSubMenu.Add(btnProveedores);
                listSubMenu.Add(btnProductos);
                listSubMenu.Add(btnCompras);
                listSubMenu.Add(btnVentas);

                for(int i=0; i < listSubMenu.Count; i++)
                {
                    listSubMenu[i].Tag = i + 1;
                }


                List<E_PermisoRol> listOpciones = N_PermisoRol.listPermisoRol(idRol);
                //MessageBox.Show("list count botones: " + listSubMenu.Count);
                //MessageBox.Show("list count opciones: " + listOpciones.Count);
                for (int i=0; i < listSubMenu.Count; i++)
                {
                    for(int j=0; j < listOpciones.Count; j++)
                    {
                       
                        
                        if (listSubMenu[i].Tag.Equals(listOpciones[j].IdOpcion))
                        {
                            listSubMenu[i].Visible = true;

                            Panel panelPadre = listSubMenu[i].Parent as Panel;
                            
                            if (panelPadre != null)
                            {
                               
                                panelPadre.Visible = true;
                            }
                        }
                    }
                }

                List<Button> listMenu = new List<Button>();

                listMenu.Add(menuEmpleados);
                listMenu.Add(menuUsuarios);
                listMenu.Add(menuClientes);
                listMenu.Add(menuProductos);
                listMenu.Add(menuExistencias);

                for (int i = 0; i < listMenu.Count; i++)
                {
                    listMenu[i].Tag = i + 1;

                }
                List<E_PermisoRol> listModulos = N_PermisoRol.listPermisoRolModulo(idRol);

                for (int i = 0; i < listMenu.Count; i++)
                {
                    for (int j = 0; j < listModulos.Count ; j++)
                    {
                        if (listMenu[i].Tag.Equals(listModulos[j].IdModulo))
                        {
                            listMenu[i].Visible = true;
                        }
                    }
                }
            }
        }

        private void pnlPrincipal_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
