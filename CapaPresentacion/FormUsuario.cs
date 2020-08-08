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
    public partial class FormUsuario : Form
    {
        public FormUsuario()
        {
            InitializeComponent();
        }

        public string _UsuarioID = null;

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormUsuario_Load(object sender, EventArgs e)
        {
            UserDo ModUser = new UserDo();
            txtTipoIdent.DataSource = ModUser.ListarTipoIdent();
            txtTipoIdent.DisplayMember = "Nombre";
            txtTipoIdent.ValueMember = "TipoIdentID";

            txtTipoUsuario.DataSource = ModUser.ListarTipoUser();
            txtTipoUsuario.DisplayMember = "Nombre";
            txtTipoUsuario.ValueMember = "TipoUserID";

            Deshabilitar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormBusquedaUser>();
            //lbAvisos.Text = _UsuarioID;
            btnActualizar.Enabled = true;
            btnDesactivar.Enabled = true;
            btnGuardar.Enabled = false;
        }

        // Metodo para abrir formularios
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form _formulario;
            _formulario = this.Controls.OfType<MiForm>().FirstOrDefault(); // Busca en la coleccion el formulario
            if (_formulario == null)
            {
                _formulario = new MiForm();
                AddOwnedForm(_formulario);
                _formulario.TopLevel = false;
                _formulario.FormBorderStyle = FormBorderStyle.None;
                _formulario.Dock = DockStyle.Fill;
                this.Controls.Add(_formulario);
                this.Tag = _formulario;
                _formulario.Show();
                _formulario.BringToFront();
                _formulario.FormClosed += new FormClosedEventHandler(CerrarForm);
            }
            else
            {
                _formulario.BringToFront();
            }
        }

        // Metodo para cerrar formulario
        private void CerrarForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FormBuscarUsuario"] == null)
            {
                btnBuscar.BackColor = Color.FromArgb(31, 30, 30);
            }
        }

        void Limpiar()
        {
            txtNombre.Clear();
            txtTipoIdent.SelectedIndex = 0;
            txtNumIdent.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtNombreUser.Clear();
            txtPass.Clear();
            txtReptirPass.Clear();
            txtTipoUsuario.SelectedIndex = 0;
        }

        void Habilitar()
        {
            txtNombre.Enabled = true;
            txtTipoIdent.Enabled = true;
            txtNumIdent.Enabled = true;
            txtTelefono.Enabled = true;
            txtCorreo.Enabled = true;
            txtNombreUser.Enabled = true;
            txtPass.Enabled = true;
            txtReptirPass.Enabled = true;
            txtTipoUsuario.Enabled = true;
            btnGuardar.Enabled = true;
        }

        void Deshabilitar()
        {
            txtNombre.Enabled = false;
            txtTipoIdent.Enabled = false;
            txtNumIdent.Enabled = false;
            txtTelefono.Enabled = false;
            txtCorreo.Enabled = false;
            txtNombreUser.Enabled = false;
            txtPass.Enabled = false;
            txtReptirPass.Enabled = false;
            txtTipoUsuario.Enabled = false;
            btnGuardar.Enabled = false;
            btnBuscar.Enabled = false;
            btnActualizar.Enabled = false;
            btnDesactivar.Enabled = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            lbAvisos.Text = "";
            Deshabilitar();
            Limpiar();
            Habilitar();
            btnBuscar.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            UserDo ModUser = new UserDo();
            if (txtPass.Text == txtReptirPass.Text)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtTipoIdent.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txtNumIdent.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtNombreUser.Text) ||
                        string.IsNullOrWhiteSpace(txtPass.Text) || txtTipoUsuario.SelectedIndex == 0)
                    {
                        lbAvisos.Text = "Existe uno o mas campos vacios";
                    }
                    else
                    {

                        ModUser.InsertarUser(txtNombre.Text, Convert.ToString(txtTipoIdent.SelectedValue), txtNumIdent.Text, txtTelefono.Text, txtCorreo.Text,
                            txtNombreUser.Text, txtPass.Text, Convert.ToString(txtTipoUsuario.SelectedValue));
                        lbAvisos.Text = "Datos guardados con Exito!!!";
                        Limpiar();
                        Deshabilitar();
                    }

                }
                catch (Exception ex)
                {
                    lbAvisos.Text = "No se insertaron los datos" + ex;
                }
            }
            else
                lbAvisos.Text = "La contraseña no coincide";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            UserDo ModUser = new UserDo();
            try
            {
                if (_UsuarioID != null)
                {
                    if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtTipoIdent.SelectedIndex == 0 || string.IsNullOrWhiteSpace(txtNumIdent.Text) ||
                        string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) || string.IsNullOrWhiteSpace(txtNombreUser.Text) ||
                        string.IsNullOrWhiteSpace(txtPass.Text) || txtTipoUsuario.SelectedIndex == 0)
                    {
                        lbAvisos.Text = "Existe uno o mas campos vacios";
                    }
                    else
                    {
                        ModUser.EditarUser(txtNombre.Text, Convert.ToString(txtTipoIdent.SelectedValue), txtNumIdent.Text, txtTelefono.Text, txtCorreo.Text,
                            txtNombreUser.Text, txtPass.Text, Convert.ToString(txtTipoUsuario.SelectedValue), _UsuarioID);
                        lbAvisos.Text = "Datos actualizados con Exito!!!";
                        Limpiar();
                        Deshabilitar();
                    }

                }
                else
                    lbAvisos.Text = "Debe seleccionar un registro en el boton 'Buscar'";

            }
            catch (Exception ex)
            {
                lbAvisos.Text = "No se actualizaron los datos" + ex;
            }
        }
    }
}
