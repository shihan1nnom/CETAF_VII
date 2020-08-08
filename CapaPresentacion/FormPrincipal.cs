using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDominio;

namespace CapaPresentacion
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        #region Propiedas/Variables
        int lx, ly, sw, sh;
        int tipo_usuario;
        #endregion

        #region Control Ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void PanelControlVentana_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Location = new Point(lx, ly);
            this.Size = new Size(sw, sh);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormUsuario>();
            btnUsuario.BackColor = Color.Black;
        }

        private void btnCategoria_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCategoria>();
            btnCategoria.BackColor = Color.Black;
        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormActivo>();
            btnActivos.BackColor = Color.Black;
        }

        private void btnTipoUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormTipoUsuario>();
            btnTipoUsuario.BackColor = Color.Black;
        }

        private void btnSedes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormSedes>();
            btnSedes.BackColor = Color.Black;
        }

        private void btnAmbientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormAmbientes>();
            btnAmbientes.BackColor = Color.Black;
        }

        private void btnAsignaciones_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormAsignar>();
            btnAsignaciones.BackColor = Color.Black;
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormConsultas>();
            btnConsultas.BackColor = Color.Black;
        }

        private void btnCopiaSeguridad_Click(object sender, EventArgs e)
        {
            AbrirFormulario<FormCopiaSeguridad>();
            btnCopiaSeguridad.BackColor = Color.Black;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void lbPruebas_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            FormLogin login = Owner as FormLogin;
            tipo_usuario = login.Tipo_User;
            //lbPruebas.Text = Convert.ToString(tipo_usuario);
            UserDo UserDominio = new UserDo();
            DataTable _permisos = new DataTable();
            _permisos = UserDominio.TipoUser(Convert.ToString(tipo_usuario));
            //lbPruebas.Text = _permisos.Rows[0][2].ToString();

            btnUsuario.Enabled = false;
            btnCategoria.Enabled = false;
            btnActivos.Enabled = false;
            btnTipoUsuario.Enabled = false;
            btnSedes.Enabled = false;
            btnAmbientes.Enabled = false;
            btnAsignaciones.Enabled = false;
            btnConsultas.Enabled = false;
            btnCopiaSeguridad.Enabled = false;

            if (_permisos.Rows[0][2].ToString() == "True")
            {
                btnUsuario.Enabled = true;
            }
            if (_permisos.Rows[0][3].ToString() == "True")
            {
                btnCategoria.Enabled = true;
            }
            if (_permisos.Rows[0][4].ToString() == "True")
            {
                btnActivos.Enabled = true;
            }
            if (_permisos.Rows[0][5].ToString() == "True")
            {
                btnTipoUsuario.Enabled = true;
            }
            if (_permisos.Rows[0][6].ToString() == "True")
            {
                btnSedes.Enabled = true;
            }
            if (_permisos.Rows[0][7].ToString() == "True")
            {
                btnAmbientes.Enabled = true;
            }
            if (_permisos.Rows[0][8].ToString() == "True")
            {
                btnAsignaciones.Enabled = true;
            }
            if (_permisos.Rows[0][9].ToString() == "True")
            {
                btnConsultas.Enabled = true;
            }
            if (_permisos.Rows[0][10].ToString() == "True")
            {
                btnCopiaSeguridad.Enabled = true;
            }
        }

        // Metodo para abrir formularios
        private void AbrirFormulario<MiForm>() where MiForm : Form, new()
        {
            Form _formulario;
            _formulario = PanelContenedor.Controls.OfType<MiForm>().FirstOrDefault(); // Busca en la coleccion el formulario
            if (_formulario == null)
            {
                _formulario = new MiForm();
                _formulario.TopLevel = false;
                _formulario.FormBorderStyle = FormBorderStyle.None;
                _formulario.Dock = DockStyle.Fill;
                PanelContenedor.Controls.Add(_formulario);
                PanelContenedor.Tag = _formulario;
                _formulario.Show();
                _formulario.BringToFront();
                _formulario.FormClosed += new FormClosedEventHandler(CerrarForm);
            }
            else
            {
                _formulario.BringToFront();
            }
        }

        private void CerrarForm(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["FormUsuario"] == null)
            {
                btnUsuario.BackColor = Color.FromArgb(255, 50, 1);
            }
            if (Application.OpenForms["FormCategoria"] == null)
            {
                btnCategoria.BackColor = Color.FromArgb(255, 50, 1);
            }
            if (Application.OpenForms["FormActivo"] == null)
            {
                btnActivos.BackColor = Color.FromArgb(255, 50, 1);
            }
            if (Application.OpenForms["FormTipoUsuario"] == null)
            {
                btnTipoUsuario.BackColor = Color.FromArgb(255, 50, 1);
            }
            if (Application.OpenForms["FormSedes"] == null)
            {
                btnSedes.BackColor = Color.FromArgb(255, 50, 1);
            }
            if (Application.OpenForms["FormAmbientes"] == null)
            {
                btnAmbientes.BackColor = Color.FromArgb(255, 50, 1);
            }
            if (Application.OpenForms["FormAsignar"] == null)
            {
                btnAsignaciones.BackColor = Color.FromArgb(255, 50, 1);
            }
            if (Application.OpenForms["FormConsultas"] == null)
            {
                btnConsultas.BackColor = Color.FromArgb(255, 50, 1);
            }
            if (Application.OpenForms["FormCopiaSeguridad"] == null)
            {
                btnCopiaSeguridad.BackColor = Color.FromArgb(255, 50, 1);
            }
        }

    }
}
