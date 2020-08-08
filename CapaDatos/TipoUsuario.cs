using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class TipoUsuario
    {
        private int TipoUserID;
        private string Nombre;
        private bool User;
        private bool Categoria;
        private bool Activo;
        private bool TipoUser;
        private bool Sedes;
        private bool Ambientes;
        private bool Asignar;
        private bool Consultas;
        private bool CopiaSecu;

        public int TipoUserID1 { get => TipoUserID; set => TipoUserID = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public bool User1 { get => User; set => User = value; }
        public bool Categoria1 { get => Categoria; set => Categoria = value; }
        public bool Activo1 { get => Activo; set => Activo = value; }
        public bool TipoUser1 { get => TipoUser; set => TipoUser = value; }
        public bool Sedes1 { get => Sedes; set => Sedes = value; }
        public bool Ambientes1 { get => Ambientes; set => Ambientes = value; }
        public bool Asignar1 { get => Asignar; set => Asignar = value; }
        public bool Consultas1 { get => Consultas; set => Consultas = value; }
        public bool CopiaSecu1 { get => CopiaSecu; set => CopiaSecu = value; }
    }
}
