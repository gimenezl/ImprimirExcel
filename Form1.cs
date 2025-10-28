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
        public dataGridViewEntregas()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Archivos Excel (*.xlsx)|*.xlsx"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                List<Entrega> entregas = new List<Entrega>();

                try
                {
                    using (var workbook = new XLWorkbook(filePath))
                    {
                        var worksheet = workbook.Worksheet(1);
                        var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                        foreach (var row in rows)
                        {
                            // Validar que la fila tenga al menos 4 columnas con datos
                            if (row.CellsUsed().Count() < 4)
                                continue;

                            entregas.Add(new Entrega
                            {
                                // Campos originales del Excel
                                Escuela = row.Cell(1).GetString(),
                                Ruta = row.Cell(2).GetString(),
                                Cantidad = row.Cell(3).GetValue<int>(),
                                Menu = row.Cell(4).GetString(),

                                // --- NUEVO: Asignar valores por defecto ---
                                Fecha = DateTime.Now.ToString("dd/MM/yyyy"), // Fecha de hoy
                                Peso = " KG", // Valor predeterminado
                                Turno = "MAÑANA" // Valor predeterminado
                            });
                        }
                    }

                    if (entregas.Count == 0)
                    {
                        MessageBox.Show("El archivo no contiene datos válidos.", "Advertencia",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    dataGridViewEntregas1.DataSource = entregas;
                    MessageBox.Show($"Se cargaron {entregas.Count} entregas correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el archivo:\n{ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void button2_Click(object sender, EventArgs e)
        {
            
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


        private void btnImprimirEtiquetas_Click(object sender, EventArgs e)
        {
            currentIndex = 0;

            PrintDocument printDoc = new PrintDocument();
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
            printDoc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
            printDoc.PrintPage += PrintDoc_PrintPage;

            FormVistaPrevia vistaPrevia = new FormVistaPrevia(printDoc);
            vistaPrevia.ShowDialog();
        }

        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
       
            Font fontTitulo = new Font("Arial", 14, FontStyle.Bold);
            Font fontSubTitulo = new Font("Arial", 12, FontStyle.Bold);
            Font fontCampo = new Font("Arial", 11, FontStyle.Regular);
            Font fontCampoNegrita = new Font("Arial", 11, FontStyle.Bold);
            SolidBrush pincelNegro = new SolidBrush(Color.Black);

            Image logo = null;
            try
            {
         
                logo = null;
            }
            catch { /* No hacer nada, logo sigue null */ }

      
            int etiquetasPorPagina = 4;
            int anchoEtiqueta = 380;
            int altoEtiqueta = 250;
            int margenIzquierdo = e.MarginBounds.Left + 20;
            int y = e.MarginBounds.Top;

            var lista = (List<Entrega>)dataGridViewEntregas1.DataSource;

            for (int i = 0; i < etiquetasPorPagina && currentIndex < lista.Count; i++)
            {
                var entrega = lista[currentIndex];
                int x = margenIzquierdo;

                e.Graphics.DrawRectangle(new Pen(pincelNegro, 1), x, y, anchoEtiqueta, altoEtiqueta);

                int x_texto = x + 120; 

                // A. Dibujar Logo (sólo si existe)
                if (logo != null)
                {
                    e.Graphics.DrawImage(logo, x + 10, y + 10, 100, 100);
                }
                else
                {
                    // Si no hay logo, el texto empieza más a la izquierda
                    x_texto = x + 15;
                }

                // B. Título
                e.Graphics.DrawString("Identificación de Contenedores", fontTitulo, pincelNegro, x_texto, y + 20);

                // C. Escuela
                e.Graphics.DrawString(entrega.Escuela, fontSubTitulo, pincelNegro, x_texto, y + 55);

                // D. Raciones y Peso (en la misma línea, debajo del logo/título)
                e.Graphics.DrawString("Raciones: ", fontCampo, pincelNegro, x + 15, y + 130);
                e.Graphics.DrawString(entrega.Cantidad.ToString(), fontCampoNegrita, pincelNegro, x + 95, y + 130);

                e.Graphics.DrawString("Peso Total: ", fontCampo, pincelNegro, x + 200, y + 130);
                e.Graphics.DrawString(entrega.Peso, fontCampoNegrita, pincelNegro, x + 285, y + 130);

                // E. Fecha y Turno
                e.Graphics.DrawString("Fecha: ", fontCampo, pincelNegro, x + 15, y + 170);
                e.Graphics.DrawString(entrega.Fecha, fontCampoNegrita, pincelNegro, x + 95, y + 170);

                e.Graphics.DrawString("Turno: ", fontCampo, pincelNegro, x + 200, y + 170);
                e.Graphics.DrawString(entrega.Turno, fontCampoNegrita, pincelNegro, x + 285, y + 170);

                // F. Menú
                e.Graphics.DrawString("Menú: ", fontCampo, pincelNegro, x + 15, y + 210);
                e.Graphics.DrawString(entrega.Menu, fontCampoNegrita, pincelNegro, x + 95, y + 210);

                y += altoEtiqueta + 20; // Espacio entre etiquetas
                currentIndex++;
            }

            // --- 5. Verificar si hay más páginas ---
            e.HasMorePages = currentIndex < lista.Count;
        }


        private void btnEditar_Click(object sender, EventArgs e)
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

    }
}