namespace Plantilla
{
    partial class FrmEliminar
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
            this.pnlEliminar = new System.Windows.Forms.Panel();
            this.grpBx = new System.Windows.Forms.GroupBox();
            this.lstBx = new System.Windows.Forms.ListBox();
            this.pnlEliminar1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bttnBorrar = new System.Windows.Forms.Button();
            this.pnlEliminar.SuspendLayout();
            this.grpBx.SuspendLayout();
            this.pnlEliminar1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlEliminar
            // 
            this.pnlEliminar.BackColor = System.Drawing.Color.Lavender;
            this.pnlEliminar.Controls.Add(this.grpBx);
            this.pnlEliminar.Controls.Add(this.pnlEliminar1);
            this.pnlEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEliminar.Location = new System.Drawing.Point(0, 0);
            this.pnlEliminar.Name = "pnlEliminar";
            this.pnlEliminar.Size = new System.Drawing.Size(698, 522);
            this.pnlEliminar.TabIndex = 0;
            // 
            // grpBx
            // 
            this.grpBx.Controls.Add(this.lstBx);
            this.grpBx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBx.Location = new System.Drawing.Point(0, 0);
            this.grpBx.Name = "grpBx";
            this.grpBx.Padding = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.grpBx.Size = new System.Drawing.Size(698, 452);
            this.grpBx.TabIndex = 0;
            this.grpBx.TabStop = false;
            this.grpBx.Text = "...";
            // 
            // lstBx
            // 
            this.lstBx.BackColor = System.Drawing.Color.GhostWhite;
            this.lstBx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBx.FormattingEnabled = true;
            this.lstBx.ItemHeight = 16;
            this.lstBx.Location = new System.Drawing.Point(20, 26);
            this.lstBx.Name = "lstBx";
            this.lstBx.Size = new System.Drawing.Size(658, 416);
            this.lstBx.TabIndex = 0;
            // 
            // pnlEliminar1
            // 
            this.pnlEliminar1.Controls.Add(this.panel1);
            this.pnlEliminar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlEliminar1.Location = new System.Drawing.Point(0, 452);
            this.pnlEliminar1.Name = "pnlEliminar1";
            this.pnlEliminar1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlEliminar1.Size = new System.Drawing.Size(698, 70);
            this.pnlEliminar1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bttnBorrar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(149, 60);
            this.panel1.TabIndex = 1;
            // 
            // bttnBorrar
            // 
            this.bttnBorrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.bttnBorrar.Dock = System.Windows.Forms.DockStyle.Top;
            this.bttnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnBorrar.ForeColor = System.Drawing.Color.Gainsboro;
            this.bttnBorrar.Location = new System.Drawing.Point(20, 0);
            this.bttnBorrar.Name = "bttnBorrar";
            this.bttnBorrar.Size = new System.Drawing.Size(129, 40);
            this.bttnBorrar.TabIndex = 0;
            this.bttnBorrar.Text = "Borrar";
            this.bttnBorrar.UseVisualStyleBackColor = false;
            this.bttnBorrar.Click += new System.EventHandler(this.bttnBorrar_Click);
            // 
            // FrmEliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(698, 522);
            this.Controls.Add(this.pnlEliminar);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmEliminar";
            this.Text = "Eliminar";
            this.Load += new System.EventHandler(this.FrmEliminar_Load);
            this.pnlEliminar.ResumeLayout(false);
            this.grpBx.ResumeLayout(false);
            this.pnlEliminar1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlEliminar;
        private System.Windows.Forms.Button bttnBorrar;
        private System.Windows.Forms.GroupBox grpBx;
        private System.Windows.Forms.ListBox lstBx;
        private System.Windows.Forms.Panel pnlEliminar1;
        private System.Windows.Forms.Panel panel1;
    }
}