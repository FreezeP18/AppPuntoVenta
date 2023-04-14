using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace AppPuntoVenta
{
    public partial class FrmIU_Usuarios : Form
    {
        private Usuario objUsuario;
        private Conexion objConexion;
        public FrmIU_Usuarios()
        {
            InitializeComponent();
            this.objConexion= new Conexion();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            try
            {
                //confirmar accion
                if (MessageBox.Show("Desea registrar al usuario?","Confirmar",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    //se rellena el objeto con la info del front end
                    this.CrearUsuario();

                    //almacenar en base de datos
                    this.RegistarUsuario();

                    //mensaje de confirmacion
                    MessageBox.Show("Usuario registrado correctamente","Registro Aplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CrearUsuario()
        {
            this.objUsuario = new Usuario();

            this.objUsuario.Email= this.txtEmail.Text.Trim();
            this.objUsuario.NombreCompleto = this.txtNombre.Text.Trim();
            this.objUsuario.Password= this.txtPassword.Text.Trim();
        }

        private void RegistarUsuario()
        {
            try
            {
                //se confirma el password
                if (this.objUsuario.Confirmar(this.txtpassword2.Text.Trim()))
                {
                    //se envia la info como parametro
                    this.objConexion.GUardarUsuario(this.objUsuario);

                }
                else
                {
                    new Exception("Usuario o contraseña incorrecto...");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void LimpiarPantalla()
        {
            this.txtEmail.Clear();
            this.txtPassword.Clear();
            this.txtNombre.Clear();
            this.txtpassword2.Clear();

        }
    }
}
