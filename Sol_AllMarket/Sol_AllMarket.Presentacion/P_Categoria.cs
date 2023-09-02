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
    public partial class P_Categoria : Form
    {
        private P_FormPrincipal principal;
        public P_Categoria(P_FormPrincipal principal)
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
                dgvCategorias.DataSource = N_Categoria.getCategorias();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
       
        private void setFormatDataGridView()
        {
            dgvCategorias.BorderStyle = BorderStyle.None;
            DataGridViewFormat dgvf = new DataGridViewFormat(dgvCategorias);
            dgvf.ReadOnly();
            setHeaderName();
            setColumnOrder();
            dgvf.setStyleHeader(ColorPalette.ORANGE, ColorPalette.WHITE, ColorPalette.MEDIUM_ORANGE, ColorPalette.WHITE);
            dgvf.setStyleEven(ColorPalette.LIGHT_GREY, ColorPalette.BLUE, ColorPalette.SALMON, ColorPalette.WHITE);
            dgvf.setStyleOdd(ColorPalette.GREY, ColorPalette.BLUE, ColorPalette.SALMON, ColorPalette.WHITE);
        }

        private void setHeaderName()
        {
            dgvCategorias.Columns[0].HeaderText = "";
            dgvCategorias.Columns[1].HeaderText = "";
            dgvCategorias.Columns[2].HeaderText = "Id";
            dgvCategorias.Columns[3].HeaderText = "Nombre";
            dgvCategorias.Columns[4].HeaderText = "Descripción";

        }
        private void setColumnOrder()
        {

            dgvCategorias.Columns["Id"].DisplayIndex = 0;
            dgvCategorias.Columns["Nombre"].DisplayIndex = 1;
            dgvCategorias.Columns["Descripcion"].DisplayIndex = 2;
            dgvCategorias.Columns["Editar"].DisplayIndex = 3;
            dgvCategorias.Columns["Eliminar"].DisplayIndex = 4;
        }

        //Agregar usuario
        private void btnAdd_Click(object sender, EventArgs e)
        {
            principal.abrirForm(new P_CategoriaAdd(this,principal,null));
        }



        //Cuando se haga click en una celda
        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            /*primero consigo la columna que esta seleccionada y luego su nombre
            para compararlo y ver si es Editar la celda en la que el usuario dio click*/
            if (dgvCategorias.Columns[e.ColumnIndex].Name == "Editar")
            {
                /*ahora obtenemos el Id para enviarselo al formulario en el que 
                el usuario puede editar 
                CurrentRow obtiene la fila en la que se encuentra la celda actualmente
                Cells es una coleccion de todas las celdas que rellenan esa fila
                 */
                int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["Id"].Value.ToString());
                P_CategoriaAdd pca = new P_CategoriaAdd(this, principal, id);
                this.principal.abrirForm(pca);

            }
            else if (dgvCategorias.Columns[e.ColumnIndex].Name == "Eliminar")
            {
                DialogResult resultado = MessageBox.Show("¿Desea continuar con la eliminación?", "Confirmacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(resultado == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells["Id"].Value.ToString());

                    if (N_Categoria.deleteCategoria(id) > 0)
                    { 
                        MessageBox.Show("Registro eliminado con exito");
                        setDatosGrid();
                    }
                    else
                        MessageBox.Show("No se pudo eliminar");

                }
                
            
            }
        }

        public DataGridView GetDataGridView()
        {
            return dgvCategorias;
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
