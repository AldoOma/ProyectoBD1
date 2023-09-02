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
    public partial class P_Usuario : Form
    {
        private P_FormPrincipal principal;
        public P_Usuario(P_FormPrincipal principal)
        {
            InitializeComponent();
            this.principal = principal;

        }

        private void P_Usuario_Load(object sender, EventArgs e)
        {
            setDatosGrid();
            setFormatDataGridView();
        }

        public void setDatosGrid()
        {
            try
            {
                dgvUsuarios.DataSource = N_Usuario.getUsuarios();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void setFormatDataGridView()
        {
            dgvUsuarios.BorderStyle = BorderStyle.None;
            DataGridViewFormat dgvf = new DataGridViewFormat(dgvUsuarios);
            dgvf.ReadOnly();
            setHeaderName();
            //setColumnOrder();
            dgvf.setStyleHeader(ColorPalette.ORANGE, ColorPalette.WHITE, ColorPalette.MEDIUM_ORANGE, ColorPalette.WHITE);
            dgvf.setStyleEven(ColorPalette.LIGHT_GREY, ColorPalette.BLUE, ColorPalette.SALMON, ColorPalette.WHITE);
            dgvf.setStyleOdd(ColorPalette.GREY, ColorPalette.BLUE, ColorPalette.SALMON, ColorPalette.WHITE);
        }

        private void setHeaderName()
        {
            dgvUsuarios.Columns[0].HeaderText = "";
            dgvUsuarios.Columns[1].HeaderText = "";
            dgvUsuarios.Columns[2].HeaderText = "Nombre";
            dgvUsuarios.Columns[3].HeaderText = "Empleado";
            dgvUsuarios.Columns[4].HeaderText = "Fecha/Hora de creación";
            dgvUsuarios.Columns[5].HeaderText = "Ultima actualización";
            
        }

        private void setColumnOrder()
        {

            dgvUsuarios.Columns["Nombre"].DisplayIndex = 0;
            dgvUsuarios.Columns["NombreEmpleado"].DisplayIndex = 1;
            dgvUsuarios.Columns["FechaHoraCreacion"].DisplayIndex = 2;
            dgvUsuarios.Columns["UltimaActualizacion"].DisplayIndex = 3;
            dgvUsuarios.Columns[0].DisplayIndex = 4;
            dgvUsuarios.Columns[1].DisplayIndex = 5;
        }

        //Agregar usuario
        private void btnAdd_Click(object sender, EventArgs e)
        {
            principal.abrirForm(new P_UsuarioAdd(this, principal, null));
        }



        //Cuando se haga click en una celda
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*primero consigo la columna que esta seleccionada y luego su nombre
            para compararlo y ver si es Editar la celda en la que el usuario dio click*/
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Editar")
            {
                /*ahora obtenemos el Id para enviarselo al formulario en el que 
                el usuario puede editar 
                CurrentRow obtiene la fila en la que se encuentra la celda actualmente
                Cells es una coleccion de todas las celdas que rellenan esa fila
                 */
                int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value.ToString());
                P_UsuarioAdd pca = new P_UsuarioAdd(this, principal, id);
                this.principal.abrirForm(pca);

            }
            else if (dgvUsuarios.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult resultado = MessageBox.Show("¿Desea continuar con la eliminación?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value.ToString());

                    if (N_Usuario.deleteUsuario(id) > 0)
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
