using CapaDominio;
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

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        UserDo UserDominio = new UserDo();
        private int _Tipo_User = 0;

        public int Tipo_User { get => _Tipo_User; set => _Tipo_User = value; }

        #region Control Ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Control Login
        private void txtUser_Enter_1(object sender, EventArgs e)
        {
            if (txtUser.Text == "USUARIO")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtUser_Leave_1(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "USUARIO";
                txtUser.ForeColor = Color.DarkCyan;
            }
        }

        private void txtPass_Enter_1(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave_1(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DarkCyan;
                txtPass.UseSystemPasswordChar = false;
            }
        }
        #endregion

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnAcceder_Click_1(object sender, EventArgs e)
        {
            if (txtUser.Text != "USUARIO" & txtUser.Text != "")
            {
                if (txtPass.Text != "CONTRASEÑA" & txtPass.Text != "")
                {
                    UserDominio._NombreUsuario = txtUser.Text;
                    UserDominio._Contrasena = txtPass.Text;
                    try
                    {
                        var valilogin = UserDominio.LoginUser();
                        if (valilogin != 0)
                        {
                            lbAviso.Text = "Conectado";
                            _Tipo_User = valilogin;
                            FormPrincipal forma = new FormPrincipal();
                            AddOwnedForm(forma);
                            forma.Show();
                            this.Hide();
                        }
                        else
                        {
                            lbAviso.Text = "Nombre de usuario o contraseña incorrecta";
                            txtPass.Clear();
                            txtUser.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        lbAviso.Text = "Error: " + ex;
                    }
                }
                else
                    lbAviso.Text = "Por favor ingresar la contraseña";
            }
            else
                lbAviso.Text = "Por favor ingresar nombre de usuario";
        }
    }
}
