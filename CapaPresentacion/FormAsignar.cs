using Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormAsignar : Form
    {
        public FormAsignar()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = new DialogResult();
            Form mensaje = new FormMsgBox();
            resultado = mensaje.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
