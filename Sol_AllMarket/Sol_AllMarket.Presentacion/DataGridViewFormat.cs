using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sol_AllMarket.Presentacion
{
    public class DataGridViewFormat
    {
        private DataGridView dgv;

        public DataGridViewFormat(DataGridView dgv) {
            this.dgv = dgv;
            
        }

        /*Metodo que reducira la manipulacion por parte del usuario
        para que este no pueda agregar, borrar, ordenar, redimensionar filas o columnas
        */
        public void ReadOnly()
        {
                this.dgv.RowHeadersVisible = false;//para que no se vea una flecha en cada fila
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
                dgv.AllowUserToOrderColumns = true;
                dgv.ReadOnly = true;
                dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv.MultiSelect = false;
                dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                dgv.AllowUserToResizeColumns = false;
                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv.AllowUserToResizeRows = false;
                dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        }

        //Establece los colores para el encabezado
        public void setStyleHeader(Color background, Color text, Color selectionBackground, Color selectionText)
        {
            //establecemos a false para que los cambios tengan efectos
            dgv.EnableHeadersVisualStyles = false;

       
            //Color de fondo del encabezado
            dgv.ColumnHeadersDefaultCellStyle.BackColor = background;

            //Color de las letras del encabezado
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = text;

            //Color que tendra el fondo cuando se seleccione el encabezado
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = selectionBackground;

            //Color que tendra las letras del fondo cuando se seleccione el encabezado
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = selectionText;
        }

        //Establecera estilos a las filas pares
        public void setStyleEven(Color background, Color text, Color selectionBackground, Color selectionText)
        {

            //Color de fondo de las filas
            dgv.RowsDefaultCellStyle.BackColor = background;

            //Color de las letras de las filas
            dgv.RowsDefaultCellStyle.ForeColor = text;

            //Color que tendra el fondo cuando se seleccionen las filas
            dgv.RowsDefaultCellStyle.SelectionBackColor = selectionBackground;

            //Color que tendra las letras del fondo cuando se seleccionen las filas
            dgv.RowsDefaultCellStyle.SelectionForeColor = selectionText;
        }

        //Establecera estilos a las filas impares
        public void setStyleOdd(Color background, Color text, Color selectionBackground, Color selectionText)
        {

            //Color de fondo de las filas
            dgv.AlternatingRowsDefaultCellStyle.BackColor = background;

            //Color de las letras de las filas
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = text;

            //Color que tendra el fondo cuando se seleccionen las filas
            dgv.AlternatingRowsDefaultCellStyle.SelectionBackColor = selectionBackground;

            //Color que tendra las letras del fondo cuando se seleccionen las filas
            dgv.AlternatingRowsDefaultCellStyle.SelectionForeColor = selectionText;
        }

        
    }
}
