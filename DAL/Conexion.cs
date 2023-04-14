using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//libreria SQL
using System.Data.SqlClient;
using System.Data;
using BLL;
namespace DAL
{
    public class Conexion
    {
        //objetos para interactuar con la base de datos
        private string StringConexion;
        private SqlConnection connection;
        private SqlDataReader reader;
        private SqlCommand command;
        private SqlDataAdapter adapter;
        private DataSet dataset;

        //constructor por omision
        public Conexion()
        {
            //config del sitio
            this.StringConexion = "Data source=LAPTOP-G169758G\\SQLEXPRESS;initial catalog=DbPuntoVenta;User Id=UserPuntoVenta;password=Uh2023";
        }

        public bool ValidarUsuario(Usuario pUser)
        {
            try
            {
                bool autorizado = false;
                //siempre instanciar conexion
                this.connection = new SqlConnection(this.StringConexion);
                //se intenta abrir la conexion
                this.connection.Open();
                //se instancia el comando
                this.command = new SqlCommand();
                //al comando siempre se debe asignar la conexion
                this.command.Connection = this.connection;
                //se debe indicar el tipo de comando
                this.command.CommandType = CommandType.Text;
                //se asigna el transac-sql del comando ejecutar
                this.command.CommandText = "select email,Password from TblUsuarios where Email = '" + pUser.Email + "' and Password = '" + pUser.Password + "'";
                //ejecucion de lectura de datos
                this.reader = this.command.ExecuteReader();
                //se pregunta si se puede leer o tiene datos
                if (this.reader.Read())
                {
                    autorizado = true;
                }
                //siempre cerrar la conexion
                this.connection.Dispose();
                this.command.Dispose();
                this.reader = null;

                return autorizado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet BuscarUsuario(string pNombre)
        {
            try
            {
                //instanciar la conexion
                this.connection = new SqlConnection(this.StringConexion);

                //se intenta abrir
                this.connection.Open();

                //instancia comando
                this.command = new SqlCommand();

                //asigna la conexion
                this.command.Connection = this.connection;

                //se indica el tipo de comando  ejecuta un procedimiento almacenado
                this.command.CommandType = CommandType.StoredProcedure;

                //se debe indicar el procedimiento almacenado
                this.command.CommandText = "[Sp_Cns_Usuarios]";

                //si el procedimiento almacenado tiene parametros es muy importante darle los valores
                this.command.Parameters.AddWithValue("@Nombre", pNombre);

                //adaptador de datos
                this.adapter = new SqlDataAdapter();
                //este comando selecciona datos unicamente
                this.adapter.SelectCommand = this.command;

                //se instancia el dataSet
                //contenedor que permite mostrar datos tabulados
                this.dataset = new DataSet();

                //el adaptador es muy importante rellenar con datos el data set por medio del adaptador
                this.adapter.Fill(this.dataset);

                //es muy importante siempre despues de la transaccion cerrar la conexion
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.adapter.Dispose();

                return this.dataset;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet BuscarProductos(string nProducto)
        {
            try
            {
                //instanciar la conexion
                this.connection = new SqlConnection(this.StringConexion);
                //se intenta abrir
                this.connection.Open();
                //instancia comando
                this.command = new SqlCommand();
                //asigna la conexion
                this.command.Connection = this.connection;
                //se indica el tipo de comando  ejecuta un procedimiento almacenado
                this.command.CommandType = CommandType.StoredProcedure;
                //se debe indicar el nombre del procedimiento almacenado
                this.command.CommandText = "[Sp_Cns_Productos]";
                //si el procedimiento almacenado tiene parametros es muy importante darle los valores
                this.command.Parameters.AddWithValue("@Descripcion", nProducto);
                //adaptador de datos
                this.adapter = new SqlDataAdapter();
                //este comando selecciona datos unicamente
                this.adapter.SelectCommand = this.command;
                //se instancia el dataSet
                //contenedor que permite mostrar datos tabulados
                this.dataset = new DataSet();
                //el adaptador es muy importante rellenar con datos el data set por medio del adaptador
                this.adapter.Fill(this.dataset);
                //cerrar conexiones
                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();
                this.adapter.Dispose();

                return this.dataset;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void GUardarUsuario (Usuario pUser)
        {
            try
            {

                //se debe instanciar la conexion
                this.connection = new SqlConnection(this.StringConexion);
                //abrir conexion
                this.connection.Open();
                //se instancia el comando
                this.command = new SqlCommand();
                //se asigna la conexion al comando
                this.command.Connection = this.connection;
                //tipo de comando
                this.command.CommandType= CommandType.StoredProcedure;
                //nombre del procedimiento
                this.command.CommandText = "[Sp_Ins_Usuarios]";
                //se asignan los datos 
                this.command.Parameters.AddWithValue("@pEmail", pUser.Email);
                this.command.Parameters.AddWithValue("@pNombre", pUser.NombreCompleto);
                this.command.Parameters.AddWithValue("@pPassword", pUser.Password);
                //se ejecuta el comando
                this.command.ExecuteNonQuery();

                this.connection.Close();
                this.connection.Dispose();
                this.command.Dispose();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }//cierre class
}//cierre namespace
