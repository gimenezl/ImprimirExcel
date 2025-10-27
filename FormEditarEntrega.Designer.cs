namespace Shonko1
{
    partial class FormEditarEntrega
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
            this.txtEscuela = new System.Windows.Forms.TextBox();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtMenu = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblEscuela = new System.Windows.Forms.Label();
            this.lblRuta = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblMenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEscuela
            // 
            this.txtEscuela.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtEscuela.Location = new System.Drawing.Point(120, 30);
            this.txtEscuela.Name = "txtEscuela";
            this.txtEscuela.Size = new System.Drawing.Size(300, 23);
            this.txtEscuela.TabIndex = 0;
            // 
            // txtRuta
            // 
            this.txtRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtRuta.Location = new System.Drawing.Point(120, 70);
            this.txtRuta.Name = "txtRuta";
            this.txtRuta.Size = new System.Drawing.Size(300, 23);
            this.txtRuta.TabIndex = 1;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtCantidad.Location = new System.Drawing.Point(120, 110);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 23);
            this.txtCantidad.TabIndex = 2;
            // 
            // txtMenu
            // 
            this.txtMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMenu.Location = new System.Drawing.Point(120, 150);
            this.txtMenu.Name = "txtMenu";
            this.txtMenu.Size = new System.Drawing.Size(300, 23);
            this.txtMenu.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGuardar.Location = new System.Drawing.Point(170, 200);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(120, 35);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblEscuela
            // 
            this.lblEscuela.AutoSize = true;
            this.lblEscuela.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblEscuela.Location = new System.Drawing.Point(30, 33);
            this.lblEscuela.Name = "lblEscuela";
            this.lblEscuela.Size = new System.Drawing.Size(68, 17);
            this.lblEscuela.TabIndex = 5;
            this.lblEscuela.Text = "Escuela:";
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblRuta.Location = new System.Drawing.Point(30, 73);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(48, 17);
            this.lblRuta.TabIndex = 6;
            this.lblRuta.Text = "Ruta:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.Location = new System.Drawing.Point(30, 113);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(78, 17);
            this.lblCantidad.TabIndex = 7;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblMenu.Location = new System.Drawing.Point(30, 153);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(53, 17);
            this.lblMenu.TabIndex = 8;
            this.lblMenu.Text = "Menú:";
            // 
            // FormEditarEntrega
            // 
            this.ClientSize = new System.Drawing.Size(460, 270);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.lblEscuela);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtMenu);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.txtEscuela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEditarEntrega";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Entrega";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtEscuela;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtMenu;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblEscuela;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblMenu;
    }
}