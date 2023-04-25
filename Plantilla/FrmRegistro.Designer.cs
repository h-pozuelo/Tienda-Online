namespace Plantilla
{
    partial class FrmRegistro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistro));
            this.lblNumTarjeta = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.lblDirecc = new System.Windows.Forms.Label();
            this.lblNomApe = new System.Windows.Forms.Label();
            this.lblIDUsu = new System.Windows.Forms.Label();
            this.pnlIDUsu = new System.Windows.Forms.Panel();
            this.txtIDUsu = new System.Windows.Forms.TextBox();
            this.pnlNomApe = new System.Windows.Forms.Panel();
            this.txtNomApe = new System.Windows.Forms.TextBox();
            this.pnlDirecc = new System.Windows.Forms.Panel();
            this.txtDirecc = new System.Windows.Forms.TextBox();
            this.pnlDNI = new System.Windows.Forms.Panel();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.pnlNumTarjeta = new System.Windows.Forms.Panel();
            this.txtNumTarjeta = new System.Windows.Forms.TextBox();
            this.pnlRegistro = new System.Windows.Forms.Panel();
            this.lnkGoBack = new System.Windows.Forms.LinkLabel();
            this.bttRegistrarse = new System.Windows.Forms.Button();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlIDUsu.SuspendLayout();
            this.pnlNomApe.SuspendLayout();
            this.pnlDirecc.SuspendLayout();
            this.pnlDNI.SuspendLayout();
            this.pnlNumTarjeta.SuspendLayout();
            this.pnlRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNumTarjeta
            // 
            this.lblNumTarjeta.AutoSize = true;
            this.lblNumTarjeta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblNumTarjeta.Location = new System.Drawing.Point(326, 405);
            this.lblNumTarjeta.Name = "lblNumTarjeta";
            this.lblNumTarjeta.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lblNumTarjeta.Size = new System.Drawing.Size(94, 20);
            this.lblNumTarjeta.TabIndex = 0;
            this.lblNumTarjeta.Text = "Num. Tarjeta:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblDNI.Location = new System.Drawing.Point(42, 405);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Padding = new System.Windows.Forms.Padding(0, 3, 59, 0);
            this.lblDNI.Size = new System.Drawing.Size(94, 20);
            this.lblDNI.TabIndex = 0;
            this.lblDNI.Text = "DNI:";
            // 
            // lblDirecc
            // 
            this.lblDirecc.AutoSize = true;
            this.lblDirecc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblDirecc.Location = new System.Drawing.Point(42, 289);
            this.lblDirecc.Name = "lblDirecc";
            this.lblDirecc.Padding = new System.Windows.Forms.Padding(0, 3, 23, 0);
            this.lblDirecc.Size = new System.Drawing.Size(94, 20);
            this.lblDirecc.TabIndex = 0;
            this.lblDirecc.Text = "Dirección:";
            // 
            // lblNomApe
            // 
            this.lblNomApe.AutoSize = true;
            this.lblNomApe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblNomApe.Location = new System.Drawing.Point(326, 173);
            this.lblNomApe.Name = "lblNomApe";
            this.lblNomApe.Padding = new System.Windows.Forms.Padding(0, 3, 32, 0);
            this.lblNomApe.Size = new System.Drawing.Size(94, 20);
            this.lblNomApe.TabIndex = 0;
            this.lblNomApe.Text = "Nombre:";
            // 
            // lblIDUsu
            // 
            this.lblIDUsu.AutoSize = true;
            this.lblIDUsu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblIDUsu.Location = new System.Drawing.Point(42, 173);
            this.lblIDUsu.Name = "lblIDUsu";
            this.lblIDUsu.Padding = new System.Windows.Forms.Padding(0, 3, 69, 0);
            this.lblIDUsu.Size = new System.Drawing.Size(98, 20);
            this.lblIDUsu.TabIndex = 0;
            this.lblIDUsu.Text = "ID: ";
            // 
            // pnlIDUsu
            // 
            this.pnlIDUsu.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlIDUsu.Controls.Add(this.txtIDUsu);
            this.pnlIDUsu.Enabled = false;
            this.pnlIDUsu.Location = new System.Drawing.Point(45, 196);
            this.pnlIDUsu.Name = "pnlIDUsu";
            this.pnlIDUsu.Size = new System.Drawing.Size(261, 45);
            this.pnlIDUsu.TabIndex = 11;
            // 
            // txtIDUsu
            // 
            this.txtIDUsu.BackColor = System.Drawing.Color.GhostWhite;
            this.txtIDUsu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDUsu.ForeColor = System.Drawing.Color.Black;
            this.txtIDUsu.Location = new System.Drawing.Point(0, 15);
            this.txtIDUsu.Name = "txtIDUsu";
            this.txtIDUsu.Size = new System.Drawing.Size(261, 16);
            this.txtIDUsu.TabIndex = 6;
            this.txtIDUsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlNomApe
            // 
            this.pnlNomApe.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlNomApe.Controls.Add(this.txtNomApe);
            this.pnlNomApe.Location = new System.Drawing.Point(329, 196);
            this.pnlNomApe.Name = "pnlNomApe";
            this.pnlNomApe.Size = new System.Drawing.Size(261, 45);
            this.pnlNomApe.TabIndex = 12;
            // 
            // txtNomApe
            // 
            this.txtNomApe.BackColor = System.Drawing.Color.GhostWhite;
            this.txtNomApe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNomApe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomApe.ForeColor = System.Drawing.Color.LightGray;
            this.txtNomApe.Location = new System.Drawing.Point(0, 15);
            this.txtNomApe.Name = "txtNomApe";
            this.txtNomApe.Size = new System.Drawing.Size(261, 16);
            this.txtNomApe.TabIndex = 6;
            this.txtNomApe.Text = "Nombre Apellido1 Apellido2";
            this.txtNomApe.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNomApe.Enter += new System.EventHandler(this.txtNomApe_Enter);
            this.txtNomApe.Leave += new System.EventHandler(this.txtNomApe_Leave);
            // 
            // pnlDirecc
            // 
            this.pnlDirecc.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlDirecc.Controls.Add(this.txtDirecc);
            this.pnlDirecc.Location = new System.Drawing.Point(45, 312);
            this.pnlDirecc.Name = "pnlDirecc";
            this.pnlDirecc.Size = new System.Drawing.Size(542, 45);
            this.pnlDirecc.TabIndex = 13;
            // 
            // txtDirecc
            // 
            this.txtDirecc.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDirecc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDirecc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDirecc.ForeColor = System.Drawing.Color.LightGray;
            this.txtDirecc.Location = new System.Drawing.Point(0, 15);
            this.txtDirecc.Name = "txtDirecc";
            this.txtDirecc.Size = new System.Drawing.Size(542, 16);
            this.txtDirecc.TabIndex = 6;
            this.txtDirecc.Text = "Calle Número, Piso{1,2}LETRA, Código Postal, Ciudad, Provincia";
            this.txtDirecc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDirecc.Enter += new System.EventHandler(this.txtDirecc_Enter);
            this.txtDirecc.Leave += new System.EventHandler(this.txtDirecc_Leave);
            // 
            // pnlDNI
            // 
            this.pnlDNI.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlDNI.Controls.Add(this.txtDNI);
            this.pnlDNI.Location = new System.Drawing.Point(45, 428);
            this.pnlDNI.Name = "pnlDNI";
            this.pnlDNI.Size = new System.Drawing.Size(261, 45);
            this.pnlDNI.TabIndex = 14;
            // 
            // txtDNI
            // 
            this.txtDNI.BackColor = System.Drawing.Color.GhostWhite;
            this.txtDNI.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDNI.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.ForeColor = System.Drawing.Color.LightGray;
            this.txtDNI.Location = new System.Drawing.Point(0, 15);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(261, 16);
            this.txtDNI.TabIndex = 6;
            this.txtDNI.Text = "12345678A";
            this.txtDNI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDNI.Enter += new System.EventHandler(this.txtDNI_Enter);
            this.txtDNI.Leave += new System.EventHandler(this.txtDNI_Leave);
            // 
            // pnlNumTarjeta
            // 
            this.pnlNumTarjeta.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlNumTarjeta.Controls.Add(this.txtNumTarjeta);
            this.pnlNumTarjeta.Location = new System.Drawing.Point(329, 428);
            this.pnlNumTarjeta.Name = "pnlNumTarjeta";
            this.pnlNumTarjeta.Size = new System.Drawing.Size(261, 45);
            this.pnlNumTarjeta.TabIndex = 15;
            // 
            // txtNumTarjeta
            // 
            this.txtNumTarjeta.BackColor = System.Drawing.Color.GhostWhite;
            this.txtNumTarjeta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNumTarjeta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumTarjeta.ForeColor = System.Drawing.Color.LightGray;
            this.txtNumTarjeta.Location = new System.Drawing.Point(0, 15);
            this.txtNumTarjeta.Name = "txtNumTarjeta";
            this.txtNumTarjeta.Size = new System.Drawing.Size(261, 16);
            this.txtNumTarjeta.TabIndex = 6;
            this.txtNumTarjeta.Text = "1111 2222 3333 4444";
            this.txtNumTarjeta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNumTarjeta.Enter += new System.EventHandler(this.txtNumTarjeta_Enter);
            this.txtNumTarjeta.Leave += new System.EventHandler(this.txtNumTarjeta_Leave);
            // 
            // pnlRegistro
            // 
            this.pnlRegistro.BackColor = System.Drawing.Color.Lavender;
            this.pnlRegistro.Controls.Add(this.pictureBox1);
            this.pnlRegistro.Controls.Add(this.lnkGoBack);
            this.pnlRegistro.Controls.Add(this.bttRegistrarse);
            this.pnlRegistro.Controls.Add(this.lblBienvenido);
            this.pnlRegistro.Controls.Add(this.lblIDUsu);
            this.pnlRegistro.Controls.Add(this.pnlNumTarjeta);
            this.pnlRegistro.Controls.Add(this.lblNumTarjeta);
            this.pnlRegistro.Controls.Add(this.pnlDNI);
            this.pnlRegistro.Controls.Add(this.pnlIDUsu);
            this.pnlRegistro.Controls.Add(this.pnlDirecc);
            this.pnlRegistro.Controls.Add(this.lblDNI);
            this.pnlRegistro.Controls.Add(this.pnlNomApe);
            this.pnlRegistro.Controls.Add(this.lblNomApe);
            this.pnlRegistro.Controls.Add(this.lblDirecc);
            this.pnlRegistro.Location = new System.Drawing.Point(12, 12);
            this.pnlRegistro.Name = "pnlRegistro";
            this.pnlRegistro.Size = new System.Drawing.Size(635, 633);
            this.pnlRegistro.TabIndex = 16;
            // 
            // lnkGoBack
            // 
            this.lnkGoBack.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(75)))), ((int)(((byte)(165)))));
            this.lnkGoBack.AutoSize = true;
            this.lnkGoBack.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lnkGoBack.Location = new System.Drawing.Point(500, 567);
            this.lnkGoBack.Name = "lnkGoBack";
            this.lnkGoBack.Size = new System.Drawing.Size(90, 17);
            this.lnkGoBack.TabIndex = 18;
            this.lnkGoBack.TabStop = true;
            this.lnkGoBack.Text = "Ir hacia atrás";
            this.lnkGoBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkGoBack_LinkClicked);
            // 
            // bttRegistrarse
            // 
            this.bttRegistrarse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.bttRegistrarse.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bttRegistrarse.FlatAppearance.BorderSize = 0;
            this.bttRegistrarse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttRegistrarse.ForeColor = System.Drawing.Color.Gainsboro;
            this.bttRegistrarse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttRegistrarse.Location = new System.Drawing.Point(45, 519);
            this.bttRegistrarse.Name = "bttRegistrarse";
            this.bttRegistrarse.Size = new System.Drawing.Size(545, 45);
            this.bttRegistrarse.TabIndex = 17;
            this.bttRegistrarse.Text = "Registrarse";
            this.bttRegistrarse.UseVisualStyleBackColor = false;
            this.bttRegistrarse.Click += new System.EventHandler(this.bttRegistrarse_Click);
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Brush Script MT", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblBienvenido.Location = new System.Drawing.Point(45, 45);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(545, 83);
            this.lblBienvenido.TabIndex = 16;
            this.lblBienvenido.Text = "Formulario de Registro";
            this.lblBienvenido.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(45, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(545, 83);
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // FrmRegistro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(75)))), ((int)(((byte)(165)))));
            this.ClientSize = new System.Drawing.Size(659, 656);
            this.Controls.Add(this.pnlRegistro);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(675, 695);
            this.MinimumSize = new System.Drawing.Size(675, 695);
            this.Name = "FrmRegistro";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrarse";
            this.Load += new System.EventHandler(this.FrmRegistro_Load);
            this.pnlIDUsu.ResumeLayout(false);
            this.pnlIDUsu.PerformLayout();
            this.pnlNomApe.ResumeLayout(false);
            this.pnlNomApe.PerformLayout();
            this.pnlDirecc.ResumeLayout(false);
            this.pnlDirecc.PerformLayout();
            this.pnlDNI.ResumeLayout(false);
            this.pnlDNI.PerformLayout();
            this.pnlNumTarjeta.ResumeLayout(false);
            this.pnlNumTarjeta.PerformLayout();
            this.pnlRegistro.ResumeLayout(false);
            this.pnlRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblNumTarjeta;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Label lblDirecc;
        private System.Windows.Forms.Label lblNomApe;
        private System.Windows.Forms.Label lblIDUsu;
        private System.Windows.Forms.Panel pnlIDUsu;
        private System.Windows.Forms.TextBox txtIDUsu;
        private System.Windows.Forms.Panel pnlNomApe;
        private System.Windows.Forms.TextBox txtNomApe;
        private System.Windows.Forms.Panel pnlDirecc;
        private System.Windows.Forms.TextBox txtDirecc;
        private System.Windows.Forms.Panel pnlDNI;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Panel pnlNumTarjeta;
        private System.Windows.Forms.TextBox txtNumTarjeta;
        private System.Windows.Forms.Panel pnlRegistro;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Button bttRegistrarse;
        private System.Windows.Forms.LinkLabel lnkGoBack;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}