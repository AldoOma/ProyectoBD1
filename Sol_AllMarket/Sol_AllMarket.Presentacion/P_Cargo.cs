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
    public partial class P_Cargo : Form
    {
        private P_FormPrincipal principal;
        public P_Cargo(P_FormPrincipal principal)
        {
            InitializeComponent();
            this.principal = principal;

        }

        private void P_Cargo_Load(object sender, EventArgs e)
        {

            setDatosGrid();
            setFormatDataGridView();

        }

        public void setDatosGrid()
        {
            try
            {
                dgvCargos.DataSource = N_Cargo.getCargos();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void setFormatDataGridView()
        {

            dgvCargos.BorderStyle = BorderStyle.None;
            DataGridViewFormat dgvf = new DataGridViewFormat(dgvCargos);
            dgvf.ReadOnly();
            setHeaderName();
            setColumnOrder();
            dgvf.setStyleHeader(ColorPalette.ORANGE, ColorPalette.WHITE, ColorPalette.MEDIUM_ORANGE, ColorPalette.WHITE);
            dgvf.setStyleEven(ColorPalette.LIGHT_GREY, ColorPalette.BLUE, ColorPalette.SALMON, ColorPalette.WHITE);
            dgvf.setStyleOdd(ColorPalette.GREY, ColorPalette.BLUE, ColorPalette.SALMON, ColorPalette.WHITE);
        }

        private void setHeaderName()
        {

            dgvCargos.Columns["Estado"].Visible = false;
            dgvCargos.Columns[0].HeaderText = "";
            dgvCargos.Columns[1].HeaderText = "";
            dgvCargos.Columns[2].HeaderText = "Id";
            dgvCargos.Columns[3].HeaderText = "Nombre";
            dgvCargos.Columns[4].HeaderText = "Descripción";
            dgvCargos.Columns[5].HeaderText = "Salario";

        }
        private void setColumnOrder()
        {
            dgvCargos.Columns["Id"].DisplayIndex = 0;
            dgvCargos.Columns["Nombre"].DisplayIndex = 1;
            dgvCargos.Columns["Descripcion"].DisplayIndex = 2;
            dgvCargos.Columns["Salario"].DisplayIndex = 3;
            dgvCargos.Columns["Editar"].DisplayIndex = 4;
            dgvCargos.Columns["Eliminar"].DisplayIndex = 5;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            principal.abrirForm(new P_CargoAdd(this, principal, null));
        }


        //Cuando se haga click en una celda
        private void dgvCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*primero consigo la columna que esta seleccionada y luego su nombre
            para compararlo y ver si es Editar la celda en la que el usuario dio click*/
            if (dgvCargos.Columns[e.ColumnIndex].Name == "Editar")
            {
                /*ahora obtenemos el Id para enviarselo al formulario en el que 
                el usuario puede editar 
                CurrentRow obtiene la fila en la que se encuentra la celda actualmente
                Cells es una coleccion de todas las celdas que rellenan esa fila
                 */
                int id = Convert.ToInt32(dgvCargos.CurrentRow.Cells["Id"].Value.ToString());
                P_CargoAdd pca = new P_CargoAdd(this, principal, id);
                this.principal.abrirForm(pca);

            }
            else if (dgvCargos.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult resultado = MessageBox.Show("¿Desea continuar con la eliminación?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvCargos.CurrentRow.Cells["Id"].Value.ToString());

                    if (N_Cargo.deleteCargo(id) > 0)
                    {
                        MessageBox.Show("Registro eliminado con exito");
                        setDatosGrid();
                    }
                    else
                        MessageBox.Show("No se pudo eliminar");

                }


            }
        }

    }
}
