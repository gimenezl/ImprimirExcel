namespace Shonko1
{
    partial class dataGridViewEntregas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param> 
        /// 
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dataGridViewEntregas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnCargarExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnGuardarCambios = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnAnadirFila = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnVaciar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editarFilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarFilaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewEntregas1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntregas1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnCargarExcel,
            this.toolStripBtnGuardarCambios,
            this.toolStripBtnAnadirFila,
            this.toolStripBtnVaciar,
            this.toolStripBtnImprimir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1392, 47);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripBtnCargarExcel
            // 
            this.toolStripBtnCargarExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnCargarExcel.Image")));
            this.toolStripBtnCargarExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnCargarExcel.Name = "toolStripBtnCargarExcel";
            this.toolStripBtnCargarExcel.Size = new System.Drawing.Size(116, 44);
            this.toolStripBtnCargarExcel.Text = "Cargar Excel";
            this.toolStripBtnCargarExcel.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripBtnGuardarCambios
            // 
            this.toolStripBtnGuardarCambios.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnGuardarCambios.Image")));
            this.toolStripBtnGuardarCambios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnGuardarCambios.Name = "toolStripBtnGuardarCambios";
            this.toolStripBtnGuardarCambios.Size = new System.Drawing.Size(143, 44);
            this.toolStripBtnGuardarCambios.Text = "Guardar Cambios";
            this.toolStripBtnGuardarCambios.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripBtnAnadirFila
            // 
            this.toolStripBtnAnadirFila.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnAnadirFila.Image")));
            this.toolStripBtnAnadirFila.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnAnadirFila.Name = "toolStripBtnAnadirFila";
            this.toolStripBtnAnadirFila.Size = new System.Drawing.Size(107, 44);
            this.toolStripBtnAnadirFila.Text = "Añadir Fila";
            this.toolStripBtnAnadirFila.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripBtnVaciar
            // 
            this.toolStripBtnVaciar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnVaciar.Image")));
            this.toolStripBtnVaciar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnVaciar.Name = "toolStripBtnVaciar";
            this.toolStripBtnVaciar.Size = new System.Drawing.Size(109, 44);
            this.toolStripBtnVaciar.Text = "Vaciar Lista";
            this.toolStripBtnVaciar.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripBtnImprimir
            // 
            this.toolStripBtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("toolStripBtnImprimir.Image")));
            this.toolStripBtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnImprimir.Name = "toolStripBtnImprimir";
            this.toolStripBtnImprimir.Size = new System.Drawing.Size(148, 44);
            this.toolStripBtnImprimir.Text = "Imprimir Etiquetas";
            this.toolStripBtnImprimir.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editarFilaToolStripMenuItem,
            this.eliminarFilaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 48);
            // 
            // editarFilaToolStripMenuItem
            // 
            this.editarFilaToolStripMenuItem.Name = "editarFilaToolStripMenuItem";
            this.editarFilaToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.editarFilaToolStripMenuItem.Text = "Editar Fila";
            this.editarFilaToolStripMenuItem.Click += new System.EventHandler(this.editarFilaToolStripMenuItem_Click);
            // 
            // eliminarFilaToolStripMenuItem
            // 
            this.eliminarFilaToolStripMenuItem.Name = "eliminarFilaToolStripMenuItem";
            this.eliminarFilaToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.eliminarFilaToolStripMenuItem.Text = "Eliminar Fila";
            this.eliminarFilaToolStripMenuItem.Click += new System.EventHandler(this.eliminarFilaToolStripMenuItem_Click);
            // 
            // dataGridViewEntregas1
            // 
            this.dataGridViewEntregas1.AllowUserToAddRows = false;
            this.dataGridViewEntregas1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEntregas1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEntregas1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridViewEntregas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewEntregas1.Location = new System.Drawing.Point(0, 47);
            this.dataGridViewEntregas1.Name = "dataGridViewEntregas1";
            this.dataGridViewEntregas1.Size = new System.Drawing.Size(1392, 596);
            this.dataGridViewEntregas1.TabIndex = 7;
            this.dataGridViewEntregas1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridViewEntregas1.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEntregas1_CellDoubleClick_1);
            // 
            // dataGridViewEntregas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 643);
            this.Controls.Add(this.dataGridViewEntregas1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "dataGridViewEntregas";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEntregas1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripBtnCargarExcel;
        private System.Windows.Forms.ToolStripButton toolStripBtnGuardarCambios;
        private System.Windows.Forms.ToolStripButton toolStripBtnAnadirFila;
        private System.Windows.Forms.ToolStripButton toolStripBtnVaciar;
        private System.Windows.Forms.ToolStripButton toolStripBtnImprimir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editarFilaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminarFilaToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewEntregas1;
    }
}

