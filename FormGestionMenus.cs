using System;
using System.Collections.Generic;
using System.Linq; // Necesario para .Find()
using System.Windows.Forms;

namespace Shonko1
{
    public partial class FormGestionMenus : Form
    {
        private List<ReglaMenu> listaDeReglas;

        public FormGestionMenus()
        {
            InitializeComponent();
        }

        // Evento Load (Conectar desde el diseñador)
        private void FormGestionMenus_Load(object sender, EventArgs e)
        {
            listaDeReglas = GestorDeReglas.CargarReglas();

            CargarTiposUnidad();
            RefrescarGrid();
        }

        private void CargarTiposUnidad()
        {
            // Carga las opciones fijas del ComboBox
            cmbTipoUnidad.Items.Clear();
            cmbTipoUnidad.Items.Add("Contenedor");
            cmbTipoUnidad.Items.Add("Caja");
            cmbTipoUnidad.Items.Add("Bolsa");
        }

        private void RefrescarGrid()
        {
            // Método para actualizar la grilla
            dgvReglas.DataSource = null;
            dgvReglas.DataSource = listaDeReglas;
            dgvReglas.ClearSelection();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // Limpia los campos de edición
            txtNombreMenu.Text = "";
            numCantidad.Value = 1;
            cmbTipoUnidad.SelectedItem = null;
            txtNombreMenu.Focus();
        }

        // Evento Click del botón 'Eliminar'
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvReglas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione una regla para eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var reglaSeleccionada = (ReglaMenu)dgvReglas.SelectedRows[0].DataBoundItem;

            if (MessageBox.Show($"¿Seguro que desea eliminar la regla '{reglaSeleccionada.NombreMenu}'?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                listaDeReglas.Remove(reglaSeleccionada);
                GestorDeReglas.GuardarReglas(listaDeReglas);
                RefrescarGrid();
            }
        }

        // Evento Click del botón 'Guardar'
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreMenu.Text))
            {
                MessageBox.Show("El nombre del menú no puede estar vacío.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a 0.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmbTipoUnidad.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de unidad.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nombre = txtNombreMenu.Text.Trim();
            int cantidad = (int)numCantidad.Value;
            string unidad = cmbTipoUnidad.SelectedItem.ToString();

            // Buscar si la regla ya existe (para editarla)
            var reglaExistente = listaDeReglas.FirstOrDefault(r =>
                r.NombreMenu.Equals(nombre, StringComparison.OrdinalIgnoreCase));

            if (reglaExistente != null)
            {
                // Editar regla existente
                reglaExistente.CantidadMaxima = cantidad;
                reglaExistente.TipoUnidad = unidad;
                MessageBox.Show("Regla actualizada.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Agregar regla nueva
                ReglaMenu nuevaRegla = new ReglaMenu(nombre, cantidad, unidad);
                listaDeReglas.Add(nuevaRegla);
                MessageBox.Show("Nueva regla agregada.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            GestorDeReglas.GuardarReglas(listaDeReglas);
            RefrescarGrid();
        }

        private void dgvReglas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // (Comprueba si el clic es en una fila válida)
            if (e.RowIndex >= 0 && e.RowIndex != dgvReglas.NewRowIndex)
            {
                // (Usa 'as' para evitar el crash si el objeto es null)
                var regla = dgvReglas.Rows[e.RowIndex].DataBoundItem as ReglaMenu;

                if (regla != null)
                {
                    txtNombreMenu.Text = regla.NombreMenu;
                    numCantidad.Value = regla.CantidadMaxima;
                    cmbTipoUnidad.SelectedItem = regla.TipoUnidad;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)

        {



        }


    }
}