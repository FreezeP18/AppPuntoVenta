using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace AppPuntoVenta
{
    public partial class FrmProductos : Form
    {
        private Conexion objCOnexion;
        public FrmProductos()
        {
            InitializeComponent();
            this.objCOnexion = new Conexion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusquedaProductos_TextChanged(object sender, EventArgs e)
        {
            try
            {

                this.BuscarPorNombre(this.txtBusquedaProductos.Text.Trim());

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
        }

        private void BuscarPorNombre(string nProducto)
        {
            try
            {
                //se utiliza la conexion y su metodo para buscar datos
                this.dataGridViewProductos.DataSource = this.objCOnexion.BuscarProductos(nProducto).Tables[0];
                //se ajustan los datos
                this.dataGridViewProductos.AutoResizeColumns();

                //se los datos solo lectura
                this.dataGridViewProductos.ReadOnly = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
