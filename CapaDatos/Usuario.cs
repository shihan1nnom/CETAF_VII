using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Usuario:BdComun
    {
        private int UsuarioID;
        private string Nombre;
        private int TipoIdent;
        private string NumIdent;
        private string Telefono;
        private string Correo;
        private string NombreUsuario;
        private string Contrasena;
        private int TipoUsuario;

        private TipoUsuario _permisos = new TipoUsuario();

        public int _UsuarioID { get => UsuarioID; set => UsuarioID = value; }
        public string _Nombre { get => Nombre; set => Nombre = value; }
        public int _TipoIdent { get => TipoIdent; set => TipoIdent = value; }
        public string _NumIdent { get => NumIdent; set => NumIdent = value; }
        public string _Telefono { get => Telefono; set => Telefono = value; }
        public string _Correo { get => Correo; set => Correo = value; }
        public string _NombreUsuario { get => NombreUsuario; set => NombreUsuario = value; }
        public string _Contrasena { get => Contrasena; set => Contrasena = value; }
        public int _TipoUsuario { get => TipoUsuario; set => TipoUsuario = value; }
        public TipoUsuario Permisos { get => _permisos; set => _permisos = value; }

        public int Login()
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    int CodigoUser = 0;
                    DataTable UsuarioActual = new DataTable();
                    comando.Connection = conexion;
                    comando.CommandText = "Logearse";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@user", NombreUsuario);
                    comando.Parameters.AddWithValue("@pass", Contrasena);
                    SqlDataReader leer = comando.ExecuteReader();
                    if(leer.HasRows)
                    {
                        UsuarioActual.Load(leer);
                        return CodigoUser = Convert.ToInt32(UsuarioActual.Rows[0][8].ToString());
                    }
                    return CodigoUser;
                }
            }
        }

        #region Listar ComboBox
        public DataTable ListarTipoUser()
        {
            DataTable _tabla = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "ListarTipoUser";
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = comando.ExecuteReader();
                    _tabla.Load(leer);
                    leer.Close();
                }
            }
            return _tabla;
        }

        public DataTable ListarTipoIdent()
        {
            DataTable _tabla = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "ListarTipoIdent";
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlDataReader leer = comando.ExecuteReader();
                    _tabla.Load(leer);
                    leer.Close();
                }
            }
            return _tabla;
        }
        #endregion

        public DataTable TipoUser()
        {
            DataTable tabla = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "SelTipoUser";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@tipouser", TipoUsuario);
                    SqlDataReader leer = comando.ExecuteReader();
                    tabla.Load(leer);
                    leer.Close();
                }
            }
            return tabla;
        }

        #region CRUD Usuario
        public DataTable Mostrar()
        {
            DataTable tabla = new DataTable();
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "Select * From Usuarios";
                    SqlDataReader leer = comando.ExecuteReader();
                    tabla.Load(leer);
                    leer.Close();
                }
            }
            return tabla;
        }

        public void Insertar()
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "InsertarUser";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nombre", Nombre);
                    comando.Parameters.AddWithValue("@TipoIdent", TipoIdent);
                    comando.Parameters.AddWithValue("@NumIdent", NumIdent);
                    comando.Parameters.AddWithValue("@Telefono", Telefono);
                    comando.Parameters.AddWithValue("@Correo", Correo);
                    comando.Parameters.AddWithValue("@NombreUser", NombreUsuario);
                    comando.Parameters.AddWithValue("@Password", Contrasena);
                    comando.Parameters.AddWithValue("@TipoUserID", TipoUsuario);
                    comando.ExecuteNonQuery();
                }
            }
        }

        public void Modificar()
        {
            using (var conexion = ObtenerConexion())
            {
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = "ModificarUser";
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@nombre", Nombre);
                    comando.Parameters.AddWithValue("@TipoIdent", TipoIdent);
                    comando.Parameters.AddWithValue("@NumIdent", NumIdent);
                    comando.Parameters.AddWithValue("@Telefono", Telefono);
                    comando.Parameters.AddWithValue("@Correo", Correo);
                    comando.Parameters.AddWithValue("@NombreUser", NombreUsuario);
                    comando.Parameters.AddWithValue("@Password", Contrasena);
                    comando.Parameters.AddWithValue("@TipoUserID", TipoUsuario);
                    comando.Parameters.AddWithValue("@UsuarioID", UsuarioID);
                    comando.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}
