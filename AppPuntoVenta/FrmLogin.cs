using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
namespace AppPuntoVenta
{
    public partial class FrmLogin : Form
    {
        //crear objeto usuario
        private Usuario objUsuario;
        private bool Autenticado = false;
        //declarar variable conexion
        private Conexion objConexion;
        public FrmLogin()
        {
            InitializeComponent();
            this.objUsuario = new Usuario();
            //siempre se debe instanciar el objeto conexion
            this.objConexion= new Conexion();
            

        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Autenticado == false)
            {
                //en caso de presionar una tecla de finalizar se termina todo
                Environment.Exit(0);
            }
            
            
        }

        private void pictureBoxSalir_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// evento encargado de realizar la autenticacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.intentoAutenticacion())
                {
                    this.Autenticado= true;


                    this.Close();
                }
                else 
                {
                    throw new Exception("Usuario o contraseña son incorrectos..");   
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool intentoAutenticacion()
        {
            try
            {
                //variable control
                bool autorizado = false;

                //rellenar el objeto con los datos del front end
                this.objUsuario.Email = this.txtUsuario.Text.Trim();
                this.objUsuario.Password = this.txtContrasena.Text.Trim();

                //validar usuario y contraseña
                //version legacy
                //if (this.objUsuario.Email.Equals("admin@gmail.com"))
                //{
                //    aca le pasamos la contraseña
                //    if (this.objUsuario.Confirmar("123456"))
                //    {
                //        si se valida
                //                autorizado = true;
                //    }
                //}

                autorizado = this.objConexion.ValidarUsuario(this.objUsuario);
                //se retorna la variable
                return autorizado;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
