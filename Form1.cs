using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
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
            // Puedes inicializar cosas aquí si lo necesitas
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

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1); // Primera hoja
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Saltar encabezado

                    foreach (var row in rows)
                    {
                        entregas.Add(new Entrega
                        {
                            Escuela = row.Cell(1).GetString(),
                            Ruta = row.Cell(2).GetString(),
                            Cantidad = row.Cell(3).GetValue<int>(), // Mejor usar GetValue<int>()
                            Menu = row.Cell(4).GetString()
                        });
                    }
                }

                dataGridViewEntregas1.DataSource = entregas;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Aquí pondremos la lógica para guardar cambios más adelante
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewEntregas1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var entrega = (Entrega)dataGridViewEntregas1.Rows[e.RowIndex].DataBoundItem;
                FormEditarEntrega formEditar = new FormEditarEntrega(entrega);

                if (formEditar.ShowDialog() == DialogResult.OK)
                {
                    dataGridViewEntregas1.Refresh(); // Actualiza la vista
                }
            }
    }

int currentIndex = 0;

    private void btnImprimirEtiquetas_Click(object sender, EventArgs e)
    {
        PrintDocument printDoc = new PrintDocument();
        printDoc.DefaultPageSettings.PaperSize = new PaperSize("A4", 827, 1169);
        printDoc.DefaultPageSettings.Margins = new Margins(50, 50, 50, 50);
        printDoc.PrintPage += PrintDoc_PrintPage;

        // Mostrar cuadro de diálogo para elegir impresora y opciones
        PrintDialog printDialog = new PrintDialog
        {
            Document = printDoc,
            AllowSomePages = true,
            UseEXDialog = true
        };

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            // Vista previa antes de imprimir
            PrintPreviewDialog preview = new PrintPreviewDialog
            {
                Document = printDoc,
                Width = 1000,
                Height = 800
            };

            preview.ShowDialog();
        }
    }

    private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
    {
        int etiquetasPorPagina = 4;
        int anchoEtiqueta = 350;
        int altoEtiqueta = 250;
        int x = e.MarginBounds.Left;
        int y = e.MarginBounds.Top;

        Font fontTitulo = new Font("Arial", 16, FontStyle.Bold);
        Font fontTexto = new Font("Arial", 14);

        var lista = (List<Entrega>)dataGridViewEntregas1.DataSource;

        for (int i = 0; i < etiquetasPorPagina && currentIndex < lista.Count; i++)
        {
            var entrega = lista[currentIndex];

            e.Graphics.FillRectangle(Brushes.White, x, y, anchoEtiqueta, altoEtiqueta);
            e.Graphics.DrawRectangle(new Pen(Color.Black, 2), x, y, anchoEtiqueta, altoEtiqueta);

            e.Graphics.DrawString($"Escuela: {entrega.Escuela}", fontTitulo, Brushes.Black, x + 10, y + 10);
            e.Graphics.DrawString($"Ruta: {entrega.Ruta}", fontTexto, Brushes.Black, x + 10, y + 50);
            e.Graphics.DrawString($"Cantidad: {entrega.Cantidad}", fontTexto, Brushes.Black, x + 10, y + 90);
            e.Graphics.DrawString($"Menú: {entrega.Menu}", fontTexto, Brushes.Black, x + 10, y + 130);

            y += altoEtiqueta + 20;
            currentIndex++;
        }

        e.HasMorePages = currentIndex < lista.Count;
    }
}
}