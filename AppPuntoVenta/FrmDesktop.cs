using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPuntoVenta
{
    public partial class FrmDesktop : Form
    {
        public FrmDesktop()
        {
            InitializeComponent();
        }
        private void documentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("winword.exe");
        }

        private void hojaDeCalculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("excel.exe");
        }

        private void presentadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("powerpnt.exe");
        }

        private void calculadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("AppCalculadora.exe");
        }

        private void FrmDesktop_Load(object sender, EventArgs e)
        {
            this.notifyIcon1.ShowBalloonTip(25);

            //se llama al metodo al cargar el formulario
            this.MostrarPantallaLogin();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void MostrarPantallaLogin()
        {
            //se declara una variable de tipo formulario
            FrmLogin frm= new FrmLogin();

            //se muestra el formulario
            frm.ShowDialog();

            //se libera la memoria
            frm.Dispose();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarPantallaLogin();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        /// <summary>
        /// evento click item usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //se utiliza el metodo 
            this.MostrarPantallaUsuario();
        }

        /// <summary>
        /// metodo encargado de mostrar el formulario para usuarios
        /// </summary>
        private void MostrarPantallaUsuario()
        {
            FrmSearchUsers frm = new FrmSearchUsers();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarPantallaProductos();
        }

        private void MostrarPantallaProductos()
        {
            FrmProductos frm = new FrmProductos();
            frm.ShowDialog();
            frm.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.MostrarPantallaProductos();
        }
    }
}
