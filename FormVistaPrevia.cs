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
            ConfigurarVistaPrevia();
        }

        private void ConfigurarVistaPrevia()
        {
            this.Text = "Vista previa de impresión";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = System.Drawing.Color.WhiteSmoke;

            // --- Asegurar que el PrintPreviewControl ocupe el espacio restante ---
            printPreviewControl1.Document = _printDoc;
            printPreviewControl1.Zoom = 0.9;
            printPreviewControl1.Dock = DockStyle.Fill;

            // --- Crear un panel superior para los botones ---
            FlowLayoutPanel panelBotones = new FlowLayoutPanel();
            panelBotones.FlowDirection = FlowDirection.LeftToRight;
            panelBotones.Dock = DockStyle.Top;
            panelBotones.Height = 55;
            panelBotones.Padding = new Padding(10);
            panelBotones.BackColor = System.Drawing.Color.Gainsboro;

            // --- Configurar los botones existentes ---
            btnImprimir.Text = "Imprimir";
            btnImprimir.Width = 120;
            btnImprimir.Height = 35;
            btnImprimir.Click -= btnImprimir_Click; // prevenir doble evento
            btnImprimir.Click += btnImprimir_Click;

            btnCancelar.Text = "Cancelar";
            btnCancelar.Width = 120;
            btnCancelar.Height = 35;
            btnCancelar.Click -= btnCancelar_Click;
            btnCancelar.Click += btnCancelar_Click;

            // --- Agregar botones al panel ---
            panelBotones.Controls.Add(btnImprimir);
            panelBotones.Controls.Add(btnCancelar);

            // --- Limpiar el layout actual y rearmar ---
            this.Controls.Clear();
            this.Controls.Add(printPreviewControl1);
            this.Controls.Add(panelBotones);
        }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
