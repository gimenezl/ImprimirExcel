namespace Shonko1
{
    partial class FormInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEtiquetasComida = new System.Windows.Forms.Button();
            this.btnEtiquetasPan = new System.Windows.Forms.Button();
            this.btnEtiquetasPostres = new System.Windows.Forms.Button();
            this.btnEtiquetasDietas = new System.Windows.Forms.Button();
            this.btnGestionarMenus = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEtiquetasComida
            // 
            this.btnEtiquetasComida.Location = new System.Drawing.Point(53, 99);
            this.btnEtiquetasComida.Name = "btnEtiquetasComida";
            this.btnEtiquetasComida.Size = new System.Drawing.Size(148, 23);
            this.btnEtiquetasComida.TabIndex = 0;
            this.btnEtiquetasComida.Text = "Etiquetas de Comida";
            this.btnEtiquetasComida.UseVisualStyleBackColor = true;
            this.btnEtiquetasComida.Click += new System.EventHandler(this.btnEtiquetasComida_Click);
            // 
            // btnEtiquetasPan
            // 
            this.btnEtiquetasPan.Location = new System.Drawing.Point(53, 151);
            this.btnEtiquetasPan.Name = "btnEtiquetasPan";
            this.btnEtiquetasPan.Size = new System.Drawing.Size(148, 23);
            this.btnEtiquetasPan.TabIndex = 1;
            this.btnEtiquetasPan.Text = "Etiquetas de Pan";
            this.btnEtiquetasPan.UseVisualStyleBackColor = true;
            // 
            // btnEtiquetasPostres
            // 
            this.btnEtiquetasPostres.Location = new System.Drawing.Point(53, 204);
            this.btnEtiquetasPostres.Name = "btnEtiquetasPostres";
            this.btnEtiquetasPostres.Size = new System.Drawing.Size(148, 23);
            this.btnEtiquetasPostres.TabIndex = 2;
            this.btnEtiquetasPostres.Text = "Etiquetas de Postres";
            this.btnEtiquetasPostres.UseVisualStyleBackColor = true;
            // 
            // btnEtiquetasDietas
            // 
            this.btnEtiquetasDietas.Location = new System.Drawing.Point(53, 253);
            this.btnEtiquetasDietas.Name = "btnEtiquetasDietas";
            this.btnEtiquetasDietas.Size = new System.Drawing.Size(148, 23);
            this.btnEtiquetasDietas.TabIndex = 3;
            this.btnEtiquetasDietas.Text = "Etiquetas de Dietas";
            this.btnEtiquetasDietas.UseVisualStyleBackColor = true;
            // 
            // btnGestionarMenus
            // 
            this.btnGestionarMenus.Location = new System.Drawing.Point(53, 304);
            this.btnGestionarMenus.Name = "btnGestionarMenus";
            this.btnGestionarMenus.Size = new System.Drawing.Size(148, 23);
            this.btnGestionarMenus.TabIndex = 4;
            this.btnGestionarMenus.Text = "Gestionar Menús";
            this.btnGestionarMenus.UseVisualStyleBackColor = true;
            this.btnGestionarMenus.Click += new System.EventHandler(this.btnGestionarMenus_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(53, 353);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(148, 23);
            this.btnSalir.TabIndex = 5;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 608);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGestionarMenus);
            this.Controls.Add(this.btnEtiquetasDietas);
            this.Controls.Add(this.btnEtiquetasPostres);
            this.Controls.Add(this.btnEtiquetasPan);
            this.Controls.Add(this.btnEtiquetasComida);
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEtiquetasComida;
        private System.Windows.Forms.Button btnEtiquetasPan;
        private System.Windows.Forms.Button btnEtiquetasPostres;
        private System.Windows.Forms.Button btnEtiquetasDietas;
        private System.Windows.Forms.Button btnGestionarMenus;
        private System.Windows.Forms.Button btnSalir;
    }
}