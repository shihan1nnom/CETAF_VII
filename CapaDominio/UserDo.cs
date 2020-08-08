using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaDominio
{
    public class UserDo
    {
        #region Declaracion de propiedades
        private int UsuarioID;
        private string Nombre;
        private int TipoIdent;
        private string NumIdent;
        private string Telefono;
        private string Correo;
        private string NombreUsuario;
        private string Contrasena;
        private int TipoUsuario;

        public int _UsuarioID { get => UsuarioID; set => UsuarioID = value; }
        public string _Nombre { get => Nombre; set => Nombre = value; }
        public int _TipoIdent { get => TipoIdent; set => TipoIdent = value; }
        public string _NumIdent { get => NumIdent; set => NumIdent = value; }
        public string _Telefono { get => Telefono; set => Telefono = value; }
        public string _Correo { get => Correo; set => Correo = value; }
        public string _NombreUsuario { get => NombreUsuario; set => NombreUsuario = value; }
        public string _Contrasena { get => Contrasena; set => Contrasena = value; }
        public int _TipoUsuario { get => TipoUsuario; set => TipoUsuario = value; }
        #endregion

        Usuario _usuario = new Usuario();

        public int LoginUser()
        {
            _usuario._NombreUsuario = NombreUsuario;
            _usuario._Contrasena = Contrasena;
            return _usuario.Login();
        }

        public DataTable ListarTipoUser()
        {
            DataTable tabla = new DataTable();
            tabla = _usuario.ListarTipoUser();

            return tabla;
        }

        public DataTable ListarTipoIdent()
        {
            DataTable tabla = new DataTable();
            tabla = _usuario.ListarTipoIdent();

            return tabla;
        }

        public DataTable TipoUser(string pID)
        {
            DataTable tabla = new DataTable();
            _usuario._TipoUsuario = Convert.ToInt32(pID);
            tabla = _usuario.TipoUser();
            return tabla;
        }

        #region CRUD Usuario
        public DataTable MostrarUsuarios()
        {
            return _usuario.Mostrar();
        }

        public void InsertarUser(string pNombre, string pTipoIdent, string pNumIdent, string pTelefono, string pCorreo, string pNombreUser, string pPass, string pTipoUser)
        {
            _usuario._Nombre = pNombre;
            _usuario._TipoIdent = Convert.ToInt32(pTipoIdent);
            _usuario._NumIdent = pNumIdent;
            _usuario._Telefono = pTelefono;
            _usuario._Correo = pCorreo;
            _usuario._NombreUsuario = pNombreUser;
            _usuario._Contrasena = pPass;
            _usuario._TipoUsuario = Convert.ToInt32(pTipoUser);

            _usuario.Insertar();
        }

        #endregion

    }
}
