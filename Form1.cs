using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;


namespace Shonko1
{
    public partial class dataGridViewEntregas : Form
    {
        private List<ReglaMenu> _listaDeReglas;
        public dataGridViewEntregas()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _listaDeReglas = GestorDeReglas.CargarReglas();
        }

        private void dataGridViewEntregas1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Obtener el nombre de la propiedad de la columna
                string campoAFoco = dataGridViewEntregas1.Columns[e.ColumnIndex].DataPropertyName;

                var entrega = (Entrega)dataGridViewEntregas1.Rows[e.RowIndex].DataBoundItem;

                // Pasar el nombre del campo al constructor
                FormEditarEntrega formEditar = new FormEditarEntrega(entrega, campoAFoco);

                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    dataGridViewEntregas1.Refresh();
                }
            }
        }

        int currentIndex = 0;
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            // 1. Fuentes, Logo y Pluma para el contorno
            Font fontTitulo = new Font("Arial", 9, FontStyle.Bold);
            Font fontSubTitulo = new Font("Arial", 8, FontStyle.Bold);
            Font fontCampo = new Font("Arial", 7, FontStyle.Regular);
            Font fontCampoNegrita = new Font("Arial", 7, FontStyle.Bold);
            SolidBrush pincelNegro = new SolidBrush(Color.Black);

            // (Pluma para el contorno negro)
            Pen penContorno = new Pen(Color.Black, 1);

            Image logo = null;
            try
            {
                
                logo = Properties.Resources.unnamed;
            }
            catch { }

            // 2. Grilla 3x6 (18 etiquetas)
            int etiquetasPorPagina = 18;
            int numColumnas = 3;

            // (Tamaño 72mm x 46.5mm -> 283x183 centésimas de pulgada)
            int anchoEtiqueta = 283;
            int altoEtiqueta = 183;

            var lista = (List<Entrega>)dataGridViewEntregas1.DataSource;
            if (lista == null) return;

            // 3. Bucle para dibujar las 18 etiquetas
            for (int i = 0; i < etiquetasPorPagina && currentIndex < lista.Count; i++)
            {
                // (Calcular posición en la grilla 3x6)
                int fila = i / numColumnas;
                int col = i % numColumnas;

                // (Calcular coordenadas X, Y)
                int x = e.MarginBounds.Left + (col * anchoEtiqueta);
                int y = e.MarginBounds.Top + (fila * altoEtiqueta);

                var entrega = lista[currentIndex];

                // --- 4. Dibujar la Etiqueta ---

                // (Dibujar contorno)
                e.Graphics.DrawRectangle(penContorno, x, y, anchoEtiqueta, altoEtiqueta);

                // (Coordenadas ajustadas para el padding)
                int x_logo = x + 5;
                int y_logo = y + 5;
                int x_texto_col1 = x + 10;
                int x_texto_col2 = x + 150;
                int x_texto_logo = x + 70;

                // A. Logo
                if (logo != null)
                {
                    e.Graphics.DrawImage(logo, x_logo, y_logo, 60, 60);
                }

                // B. Título
                e.Graphics.DrawString("Identificación de", fontTitulo, pincelNegro, x_texto_logo, y + 10);
                e.Graphics.DrawString("Contenedores", fontTitulo, pincelNegro, x_texto_logo, y + 25);

                // C. Escuela
                e.Graphics.DrawString(entrega.Escuela, fontSubTitulo, pincelNegro, x_texto_logo, y + 50);

                // D. Raciones y Peso
                e.Graphics.DrawString("Raciones:", fontCampo, pincelNegro, x_texto_col1, y + 80);
                e.Graphics.DrawString(entrega.Cantidad.ToString(), fontCampoNegrita, pincelNegro, x_texto_col1 + 60, y + 80);

                e.Graphics.DrawString("Peso Total:", fontCampo, pincelNegro, x_texto_col2, y + 80);
                e.Graphics.DrawString(entrega.Peso, fontCampoNegrita, pincelNegro, x_texto_col2 + 60, y + 80);

                // E. Fecha y Turno
                e.Graphics.DrawString("Fecha:", fontCampo, pincelNegro, x_texto_col1, y + 105);
                e.Graphics.DrawString(entrega.Fecha, fontCampoNegrita, pincelNegro, x_texto_col1 + 60, y + 105);

                e.Graphics.DrawString("Turno:", fontCampo, pincelNegro, x_texto_col2, y + 105);
                e.Graphics.DrawString(entrega.Turno, fontCampoNegrita, pincelNegro, x_texto_col2 + 60, y + 105);

                // F. Menú
                e.Graphics.DrawString("Menú:", fontCampo, pincelNegro, x_texto_col1, y + 130);
                e.Graphics.DrawString(entrega.Menu, fontCampoNegrita, pincelNegro, x_texto_col1 + 60, y + 130);

                currentIndex++;
            }

            // (Verifica si quedan más etiquetas para otra página)
            e.HasMorePages = currentIndex < lista.Count;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos Excel (*.xlsx)|*.xlsx",
                Title = "Cargar Totales de Entregas"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filePath = openFileDialog.FileName;
            List<Entrega> listaOriginal = new List<Entrega>();
            List<Entrega> listaProcesada = new List<Entrega>();

            try
            {
                // 1. Leer el Excel original
                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);

                    // (Usamos RowsUsed() para evitar el error de la imagen anterior)
                    var rows = worksheet.RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        listaOriginal.Add(new Entrega
                        {
                            Escuela = row.Cell(1).GetString(),
                            Cantidad = row.Cell(2).GetValue<int>(),
                            Peso = row.Cell(3).GetString(),
                            Menu = row.Cell(4).GetString(),
                            Turno = row.Cell(5).GetString(),

                            // --- LÍNEA ARREGLADA ---
                            // (GetFormattedString() lee la fecha como se ve en Excel)
                            Fecha = row.Cell(6).GetFormattedString()
                        });
                    }
                }

                if (listaOriginal.Count == 0)
                {
                    MessageBox.Show("El archivo no contiene datos válidos.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. PROCESAR LA LISTA (La Calculadora)
                foreach (var entrega in listaOriginal)
                {
                    var regla = _listaDeReglas.FirstOrDefault(r =>
                        r.NombreMenu.Equals(entrega.Menu, StringComparison.OrdinalIgnoreCase) &&
                        r.TipoUnidad == "Contenedor");

                    if (regla != null)
                    {
                        // (Lógica de cálculo de contenedores)
                        int maxPorContenedor = regla.CantidadMaxima;
                        int totalRaciones = entrega.Cantidad;
                        int contenedoresCompletos = totalRaciones / maxPorContenedor;
                        int sobrante = totalRaciones % maxPorContenedor;

                        for (int i = 0; i < contenedoresCompletos; i++)
                        {
                            listaProcesada.Add(new Entrega
                            {
                                Escuela = entrega.Escuela,
                                Cantidad = maxPorContenedor,
                                Menu = entrega.Menu,
                                Peso = entrega.Peso,
                                Fecha = entrega.Fecha,
                                Turno = entrega.Turno
                            });
                        }
                        if (sobrante > 0)
                        {
                            listaProcesada.Add(new Entrega
                            {
                                Escuela = entrega.Escuela,
                                Cantidad = sobrante,
                                Menu = entrega.Menu,
                                Peso = entrega.Peso,
                                Fecha = entrega.Fecha,
                                Turno = entrega.Turno
                            });
                        }
                    }
                    else
                    {
                        listaProcesada.Add(entrega);
                    }
                }

                // 3. Mostrar el resultado procesado
                dataGridViewEntregas1.DataSource = listaProcesada;
                MessageBox.Show($"Se procesaron {listaOriginal.Count} filas del Excel, generando {listaProcesada.Count} etiquetas.",
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el archivo:\n{ex.Message}\n\nAsegúrese de que el archivo tenga 6 columnas en el orden correcto.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            var lista = (List<Entrega>)dataGridViewEntregas1.DataSource;

            if (lista == null || lista.Count == 0)
            {
                MessageBox.Show("No hay datos para guardar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Archivo Excel (*.xlsx)|*.xlsx",
                Title = "Guardar cambios en Excel",
                FileName = $"Entregas_{DateTime.Now:yyyyMMdd}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Entregas");

                        // --- INICIO DE CAMBIOS ---
                        // Escribir Encabezados (en el nuevo orden)
                        worksheet.Cell(1, 1).Value = "escuela";
                        worksheet.Cell(1, 2).Value = "raciones";
                        worksheet.Cell(1, 3).Value = "peso";
                        worksheet.Cell(1, 4).Value = "men";
                        worksheet.Cell(1, 5).Value = "turno";
                        worksheet.Cell(1, 6).Value = "fecha";

                        // Escribir datos (en el nuevo orden)
                        int filaActual = 2;
                        foreach (var entrega in lista)
                        {
                            worksheet.Cell(filaActual, 1).Value = entrega.Escuela;
                            worksheet.Cell(filaActual, 2).Value = entrega.Cantidad;
                            worksheet.Cell(filaActual, 3).Value = entrega.Peso;
                            worksheet.Cell(filaActual, 4).Value = entrega.Menu;
                            worksheet.Cell(filaActual, 5).Value = entrega.Turno;
                            worksheet.Cell(filaActual, 6).Value = entrega.Fecha;
                            filaActual++;
                        }
                        // --- FIN DE CAMBIOS ---

                        worksheet.Columns().AdjustToContents();
                        workbook.SaveAs(saveFileDialog.FileName);

                        MessageBox.Show("¡Cambios guardados con éxito!", "Éxito",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el archivo:\n{ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {

                List<Entrega> lista;
                if (dataGridViewEntregas1.DataSource == null)
                {
                    lista = new List<Entrega>();
                    dataGridViewEntregas1.DataSource = lista;
                }
                else
                {
                    lista = (List<Entrega>)dataGridViewEntregas1.DataSource;
                }


                Entrega nuevaEntrega = new Entrega
                {
                    Escuela = "",
                    Cantidad = 1,
                    Menu = "",
                    Fecha = DateTime.Now.ToString("dd/MM/yyyy"),
                    Peso = " KG",
                    Turno = "MAÑANA"
                };


                FormEditarEntrega formEditar = new FormEditarEntrega(nuevaEntrega);


                if (formEditar.ShowDialog() == DialogResult.OK)
                {

                    lista.Add(nuevaEntrega);


                    dataGridViewEntregas1.DataSource = null;
                    dataGridViewEntregas1.DataSource = lista;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al añadir fila: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            if (dataGridViewEntregas1.DataSource == null ||
                ((List<Entrega>)dataGridViewEntregas1.DataSource).Count == 0)
            {
                MessageBox.Show("La lista ya está vacía.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            if (MessageBox.Show("¿Está seguro de que desea borrar todos los datos de la lista actual?",
                "Confirmar Vaciar", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {

                    List<Entrega> listaVacia = new List<Entrega>();
                    dataGridViewEntregas1.DataSource = listaVacia;

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al vaciar la lista: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            currentIndex = 0; // Reinicia el contador

            PrintDocument printDoc = new PrintDocument();

            // Configurar tamaño CARTA (8.5 x 11 pulgadas)
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("Letter", 850, 1100);

            // Márgenes
            printDoc.DefaultPageSettings.Margins = new Margins(25, 25, 25, 25);

            printDoc.PrintPage += PrintDoc_PrintPage;

            FormVistaPrevia vistaPrevia = new FormVistaPrevia(printDoc);
            vistaPrevia.ShowDialog();
        }

        private void editarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewEntregas1.CurrentRow != null)
            {
                var entrega = (Entrega)dataGridViewEntregas1.CurrentRow.DataBoundItem;
                FormEditarEntrega formEditar = new FormEditarEntrega(entrega);

                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    dataGridViewEntregas1.Refresh(); // Actualiza la vista
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void eliminarFilaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewEntregas1.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione la fila que desea eliminar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var entregaSeleccionada = (Entrega)dataGridViewEntregas1.CurrentRow.DataBoundItem;
            string msj = $"¿Está seguro de que desea eliminar la entrega de:\n\nEscuela: {entregaSeleccionada.Escuela}\nMenú: {entregaSeleccionada.Menu}";

            if (MessageBox.Show(msj, "Confirmar Eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Elimina  la entrega de la lista
                    var lista = (List<Entrega>)dataGridViewEntregas1.DataSource;
                    lista.Remove(entregaSeleccionada);


                    dataGridViewEntregas1.DataSource = null;
                    dataGridViewEntregas1.DataSource = lista;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar la fila: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridViewEntregas1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}