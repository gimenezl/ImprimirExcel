using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Shonko1
{
    public partial class FormVistaPrevia : Form
    {
        private PrintDocument _printDoc;
        private int paginaActual = 0;

        public FormVistaPrevia(PrintDocument printDoc)
        {
            InitializeComponent();
            _printDoc = printDoc;

            // Configurar PrintPreviewControl
            printPreviewControl1.Document = _printDoc;
            printPreviewControl1.Zoom = 1.0;
            printPreviewControl1.Dock = DockStyle.Fill;
            printPreviewControl1.Columns = 1; // (Fuerza 1 columna para la navegación)

            ActualizarLabelPagina();
        }

        // (ELIMINADO: El método 'ConfigurarVistaPrevia' estaba creando controles duplicados)

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            using (PrintDialog dlg = new PrintDialog())
            {
                dlg.Document = _printDoc;

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _printDoc.PrinterSettings = dlg.PrinterSettings;
                    _printDoc.Print();
                }
            }
        }

        // (Este es tu botón 'Cancelar', que en el diseñador se llama 'button1')
// (El archivo FormVistaPrevia.Designer.cs usa 'button1' para cancelar)
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        // (ELIMINADO: 'btnCancelar_Click' y 'lblPagina_Click' vacíos o duplicados)

        // --- CÓDIGO DE NAVEGACIÓN ---
        // (Asegurate de tener los botones 'btnAnterior', 'btnSiguiente' y el label 'lblPagina' en el diseñador)

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lblPagina_Click(object sender, EventArgs e)
        {

        }

        private void ActualizarLabelPagina()
        {
            // (Asegurate de tener un Label llamado 'lblPagina' en tu diseñador)
            if (lblPagina != null) 
            {
                lblPagina.Text = $"Página {paginaActual + 1}";
            }
        }

        private void btnSiguiente_Click_1(object sender, EventArgs e)
        {
            paginaActual++;
            printPreviewControl1.StartPage = paginaActual;
            ActualizarLabelPagina();
        }

        private void btnAnterior_Click_1(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                printPreviewControl1.StartPage = paginaActual;
                ActualizarLabelPagina();
            }
    }
}
}