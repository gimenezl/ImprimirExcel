using System;
using System.Windows.Forms;

namespace Shonko1
{
    public partial class FormEditarEntrega : Form
    {
        public Entrega EntregaActual { get; private set; }

        public FormEditarEntrega(Entrega entrega)
        {
            InitializeComponent();
            EntregaActual = entrega;

            // Cargar datos en los TextBox
            txtEscuela.Text = entrega.Escuela;
            txtRuta.Text = entrega.Ruta;
            txtCantidad.Text = entrega.Cantidad.ToString();
            txtMenu.Text = entrega.Menu;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Guardar cambios en el objeto
            EntregaActual.Escuela = txtEscuela.Text;
            EntregaActual.Ruta = txtRuta.Text;
            EntregaActual.Cantidad = int.Parse(txtCantidad.Text);
            EntregaActual.Menu = txtMenu.Text;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}