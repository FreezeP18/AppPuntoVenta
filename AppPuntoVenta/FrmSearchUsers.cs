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
    public partial class FrmSearchUsers : Form
    {
        //declarar la variable conexion
        private Conexion objCOnexion;
        public FrmSearchUsers()
        {
            
            InitializeComponent();
            //instanciar el objeto
            this.objCOnexion = new Conexion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //se cierra el formulario
            this.Close();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //se utiliza metodo para buscar
                this.BuscarPorNombre(this.txtNombre.Text.Trim());
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarPorNombre(string pNomb)
        {
            try
            {
                //se utiliza la conexion y su metodo para buscar datos
                this.dataGridViewDatos.DataSource = this.objCOnexion.BuscarUsuario(pNomb).Tables[0];
                //se ajustan los datos
                this.dataGridViewDatos.AutoResizeColumns();

                //se los datos solo lectura
                this.dataGridViewDatos.ReadOnly = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                this.MostrarPantallaUsuarios();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void MostrarPantallaUsuarios()
        {
            //declarar formulario
            FrmIU_Usuarios frm = new FrmIU_Usuarios();
            frm.ShowDialog();
            frm.Dispose();
        }

    }//cierre formulario
}//cierre namespace
