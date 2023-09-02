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
    public partial class P_Empleado : Form
    {
        private P_FormPrincipal principal;
        public P_Empleado(P_FormPrincipal principal)
        {
            InitializeComponent();
            this.principal = principal;

        }

        private void P_Categoria_Load(object sender, EventArgs e)
        {
            setDatosGrid();
            setFormatDataGridView();
        }
        public void setDatosGrid()
        {
            try
            {
                dgvEmpleados.DataSource = N_Empleado.getEmpleados();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void setFormatDataGridView()
        {
            dgvEmpleados.BorderStyle = BorderStyle.None;
            DataGridViewFormat dgvf = new DataGridViewFormat(dgvEmpleados);
            dgvf.ReadOnly();
            setHeaderName();
            setColumnOrder();
            dgvf.setStyleHeader(ColorPalette.ORANGE, ColorPalette.WHITE, ColorPalette.MEDIUM_ORANGE, ColorPalette.WHITE);
            dgvf.setStyleEven(ColorPalette.LIGHT_GREY, ColorPalette.BLUE, ColorPalette.SALMON, ColorPalette.WHITE);
            dgvf.setStyleOdd(ColorPalette.GREY, ColorPalette.BLUE, ColorPalette.SALMON, ColorPalette.WHITE);
        }

        private void setHeaderName()
        {
            dgvEmpleados.Columns[0].HeaderText = "";
            dgvEmpleados.Columns[1].HeaderText = "";
            dgvEmpleados.Columns[2].HeaderText = "Id";
            dgvEmpleados.Columns[3].HeaderText = "Cédula";
            dgvEmpleados.Columns[4].HeaderText = "Nombre";
            dgvEmpleados.Columns[5].HeaderText = "Cargo";
            dgvEmpleados.Columns[6].HeaderText = "Fecha Ingreso";

        }
        private void setColumnOrder()
        {

            dgvEmpleados.Columns["Id"].DisplayIndex = 0;
            dgvEmpleados.Columns["Nombre"].DisplayIndex = 1;
            dgvEmpleados.Columns["Cargo"].DisplayIndex = 2;
            dgvEmpleados.Columns["Cédula"].DisplayIndex = 3;
            dgvEmpleados.Columns["Fecha Ingreso"].DisplayIndex = 4;

            dgvEmpleados.Columns["Editar"].DisplayIndex = 5;
            dgvEmpleados.Columns["Eliminar"].DisplayIndex = 6;
        }

        //Agregar usuario
        private void btnAdd_Click(object sender, EventArgs e)
        {
           principal.abrirForm(new P_EmpleadoAdd(this, principal, null));
        }



        //Cuando se haga click en una celda
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*primero consigo la columna que esta seleccionada y luego su nombre
            para compararlo y ver si es Editar la celda en la que el usuario dio click*/
            if (dgvEmpleados.Columns[e.ColumnIndex].Name == "Editar")
            {
                /*ahora obtenemos el Id para enviarselo al formulario en el que 
                el usuario puede editar 
                CurrentRow obtiene la fila en la que se encuentra la celda actualmente
                Cells es una coleccion de todas las celdas que rellenan esa fila
                 */
                int id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["Id"].Value.ToString());
                P_EmpleadoAdd pca = new P_EmpleadoAdd(this, principal, id);
                this.principal.abrirForm(pca);

            }
            else if (dgvEmpleados.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult resultado = MessageBox.Show("¿Al eliminar al empleado también se elimina su usuario, desea continuar?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["Id"].Value.ToString());

                    P_EmpleadoDelete empDelete = new P_EmpleadoDelete(principal);
                    //principal.abrirForm(empDelete);

                    if (P_EmpleadoDelete.getFechaSalida() != null)
                    {
                        if (N_Empleado.deleteEmpleado(id,P_EmpleadoDelete.getFechaSalida()) > 0)
                        {
                            MessageBox.Show("Empleado eliminado con exito");
                            setDatosGrid();
                        }
                        else
                            MessageBox.Show("No se pudo eliminar");
                    }

                    

                }


            }
        }

        private void P_Empleado_Load(object sender, EventArgs e)
        {

        }
    }
}
