using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public abstract class BdComun
    {
        private readonly string conexion;
        public BdComun()
        {
            conexion = "Server = SHIHAN; DataBase = BdCETAF; Integrated Security = True";
        }

        protected SqlConnection ObtenerConexion()
        {
            return new SqlConnection(conexion);
        }
    }
}
