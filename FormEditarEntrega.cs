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
            // Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(txtEscuela.Text))
            {
                MessageBox.Show("El campo Escuela no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEscuela.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRuta.Text))
            {
                MessageBox.Show("El campo Ruta no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRuta.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMenu.Text))
            {
                MessageBox.Show("El campo Menú no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMenu.Focus();
                return;
            }

            // Validar que Cantidad sea un número válido
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            // Si todo está bien, guardar los cambios
            EntregaActual.Escuela = txtEscuela.Text.Trim();
            EntregaActual.Ruta = txtRuta.Text.Trim();
            EntregaActual.Cantidad = cantidad;
            EntregaActual.Menu = txtMenu.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}