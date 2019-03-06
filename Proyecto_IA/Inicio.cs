using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_IA
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            Creditos cred = new Creditos();
            cred.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Configuracion config = new Configuracion(this);
            config.Show();
            this.Hide();
        }
    }
}
