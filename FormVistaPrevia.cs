using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Shonko1
{
    public partial class FormVistaPrevia : Form
    {
        private PrintDocument _printDoc;

        public FormVistaPrevia(PrintDocument printDoc)
        {
            InitializeComponent();
            _printDoc = printDoc;

            // Configurar PrintPreviewControl
            printPreviewControl1.Document = _printDoc;
            printPreviewControl1.Zoom = 1.0; // Ajuste de zoom
            printPreviewControl1.Dock = DockStyle.Fill;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog
            {
                Document = _printDoc,
                AllowSomePages = true,
                UseEXDialog = true
            };

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                _printDoc.Print();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}