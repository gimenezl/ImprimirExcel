using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shonko1
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnEtiquetasComida_Click(object sender, EventArgs e)
        {
            // Llama a tu formulario original (Form1), que se llama 'dataGridViewEntregas'
            dataGridViewEntregas formComida = new dataGridViewEntregas();
            formComida.ShowDialog();
        }

        private void btnGestionarMenus_Click(object sender, EventArgs e)
        {
            FormGestionMenus formGestor = new FormGestionMenus();
            formGestor.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario de inicio y termina la aplicación
        }
    }
}
