using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDominio;

namespace CapaPresentacion
{
    public partial class FormBusquedaUser : Form
    {
        public FormBusquedaUser()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormBusquedaUser_Load(object sender, EventArgs e)
        {
            UserDo _usuario = new UserDo();
            viewUsers.DataSource = _usuario.MostrarUsuarios();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            FormUsuario _usuario = Owner as FormUsuario;
            if (viewUsers.SelectedRows.Count > 0)
            {

                _usuario.txtNombre.Text = viewUsers.CurrentRow.Cells["Nombre"].Value.ToString();
                _usuario.txtTipoIdent.SelectedValue = viewUsers.CurrentRow.Cells["TipoIdent"].Value.ToString();
                _usuario.txtNumIdent.Text = viewUsers.CurrentRow.Cells["NumIdent"].Value.ToString();
                _usuario.txtTelefono.Text = viewUsers.CurrentRow.Cells["Telefono"].Value.ToString();
                _usuario.txtCorreo.Text = viewUsers.CurrentRow.Cells["Correo"].Value.ToString();
                _usuario.txtNombreUser.Text = viewUsers.CurrentRow.Cells["NombreUser"].Value.ToString();
                _usuario.txtPass.Text = viewUsers.CurrentRow.Cells["Password"].Value.ToString();
                _usuario.txtTipoUsuario.SelectedValue = viewUsers.CurrentRow.Cells["TipoUserID"].Value.ToString();
                _usuario._UsuarioID = viewUsers.CurrentRow.Cells["UsuarioID"].Value.ToString();
                lbAvisos.Text = "";
                this.Close();
            }
            else
            {
                lbAvisos.Text = "Debe seleccionar la fila a modificar";
            }
        }
    }
}
