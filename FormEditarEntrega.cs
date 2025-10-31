using System;
using System.Windows.Forms;

namespace Shonko1
{
    public partial class FormEditarEntrega : Form
    {
        public Entrega EntregaActual { get; private set; }
        private string _campoAFoco;

        public FormEditarEntrega(Entrega entrega, string campoAFoco = null)
        {
            InitializeComponent();
            EntregaActual = entrega;
            _campoAFoco = campoAFoco;

            // Cargar datos
            txtEscuela.Text = entrega.Escuela;

            txtCantidad.Text = entrega.Cantidad.ToString();
            txtMenu.Text = entrega.Menu;
            txtPeso.Text = entrega.Peso;
            txtFecha.Text = entrega.Fecha;
            txtTurno.Text = entrega.Turno;
        }

        private void FormEditarEntrega_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_campoAFoco))
            {
                switch (_campoAFoco)
                {
                    case "Escuela":
                        this.ActiveControl = txtEscuela; // Añadir esto
                        txtEscuela.SelectAll();
                        break;
                    case "Cantidad":
                        this.ActiveControl = txtCantidad; // Añadir esto
                        txtCantidad.SelectAll();
                        break;
                    case "Menu":
                        this.ActiveControl = txtMenu; // Añadir esto
                        txtMenu.SelectAll();
                        break;
                    case "Peso":
                        this.ActiveControl = txtPeso; // Añadir esto
                        txtPeso.SelectAll();
                        break;
                    case "Fecha":
                        this.ActiveControl = txtFecha; // Añadir esto
                        txtFecha.SelectAll();
                        break;
                    case "Turno":
                        this.ActiveControl = txtTurno; // Añadir esto
                        txtTurno.SelectAll();
                        break;
                    default:
                        this.ActiveControl = txtEscuela;
                        txtEscuela.SelectAll();
                        break;
                }
            }
            else
            {
                this.ActiveControl = txtEscuela;
                txtEscuela.SelectAll();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtEscuela.Text))
            {
                MessageBox.Show("El campo Escuela no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEscuela.Focus();
                return;
            }  

            if (string.IsNullOrWhiteSpace(txtMenu.Text))
            {
                MessageBox.Show("El campo Menú no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMenu.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPeso.Text))
            {
                MessageBox.Show("El campo Peso no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPeso.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtFecha.Text))
            {
                MessageBox.Show("El campo Fecha no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFecha.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTurno.Text))
            {
                MessageBox.Show("El campo Turno no puede estar vacío.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTurno.Focus();
                return;
            }

            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("La cantidad debe ser un número mayor a 0.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Focus();
                return;
            }

            // Guardar cambios
            EntregaActual.Escuela = txtEscuela.Text.Trim();
            EntregaActual.Cantidad = cantidad;
            EntregaActual.Menu = txtMenu.Text.Trim();
            EntregaActual.Peso = txtPeso.Text.Trim();
            EntregaActual.Fecha = txtFecha.Text.Trim();
            EntregaActual.Turno = txtTurno.Text.Trim();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            // Método vacío
        }
    }
}