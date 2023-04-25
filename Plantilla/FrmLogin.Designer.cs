namespace Plantilla
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.pnlIDUsu = new System.Windows.Forms.Panel();
            this.txtIDUsu = new System.Windows.Forms.TextBox();
            this.lnkLoginCliente = new System.Windows.Forms.LinkLabel();
            this.bttLoginEmpleado = new System.Windows.Forms.Button();
            this.lnkLoginEmpleado = new System.Windows.Forms.LinkLabel();
            this.lnkRegistrarse = new System.Windows.Forms.LinkLabel();
            this.bttLoginCliente = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.pnlLogin.SuspendLayout();
            this.pnlIDUsu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Lavender;
            this.pnlLogin.Controls.Add(this.pictureBox1);
            this.pnlLogin.Controls.Add(this.pnlIDUsu);
            this.pnlLogin.Controls.Add(this.lnkLoginCliente);
            this.pnlLogin.Controls.Add(this.bttLoginEmpleado);
            this.pnlLogin.Controls.Add(this.lblBienvenido);
            this.pnlLogin.Controls.Add(this.lnkLoginEmpleado);
            this.pnlLogin.Controls.Add(this.lnkRegistrarse);
            this.pnlLogin.Controls.Add(this.bttLoginCliente);
            this.pnlLogin.Location = new System.Drawing.Point(12, 12);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(350, 400);
            this.pnlLogin.TabIndex = 0;
            // 
            // pnlIDUsu
            // 
            this.pnlIDUsu.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlIDUsu.Controls.Add(this.txtIDUsu);
            this.pnlIDUsu.Location = new System.Drawing.Point(45, 176);
            this.pnlIDUsu.Name = "pnlIDUsu";
            this.pnlIDUsu.Size = new System.Drawing.Size(261, 45);
            this.pnlIDUsu.TabIndex = 10;
            // 
            // txtIDUsu
            // 
            this.txtIDUsu.BackColor = System.Drawing.Color.GhostWhite;
            this.txtIDUsu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtIDUsu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDUsu.ForeColor = System.Drawing.Color.LightGray;
            this.txtIDUsu.Location = new System.Drawing.Point(0, 15);
            this.txtIDUsu.Name = "txtIDUsu";
            this.txtIDUsu.Size = new System.Drawing.Size(261, 16);
            this.txtIDUsu.TabIndex = 6;
            this.txtIDUsu.Text = "ID de Usuario";
            this.txtIDUsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIDUsu.Enter += new System.EventHandler(this.txtIDUsu_Enter);
            this.txtIDUsu.Leave += new System.EventHandler(this.txtIDUsu_Leave);
            // 
            // lnkLoginCliente
            // 
            this.lnkLoginCliente.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(75)))), ((int)(((byte)(165)))));
            this.lnkLoginCliente.AutoSize = true;
            this.lnkLoginCliente.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lnkLoginCliente.Location = new System.Drawing.Point(209, 224);
            this.lnkLoginCliente.Name = "lnkLoginCliente";
            this.lnkLoginCliente.Size = new System.Drawing.Size(97, 17);
            this.lnkLoginCliente.TabIndex = 9;
            this.lnkLoginCliente.TabStop = true;
            this.lnkLoginCliente.Text = "Soy un cliente";
            this.lnkLoginCliente.Visible = false;
            this.lnkLoginCliente.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoginCliente_LinkClicked);
            // 
            // bttLoginEmpleado
            // 
            this.bttLoginEmpleado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.bttLoginEmpleado.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bttLoginEmpleado.FlatAppearance.BorderSize = 0;
            this.bttLoginEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttLoginEmpleado.ForeColor = System.Drawing.Color.Gainsboro;
            this.bttLoginEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttLoginEmpleado.Location = new System.Drawing.Point(45, 289);
            this.bttLoginEmpleado.Name = "bttLoginEmpleado";
            this.bttLoginEmpleado.Size = new System.Drawing.Size(261, 45);
            this.bttLoginEmpleado.TabIndex = 5;
            this.bttLoginEmpleado.Text = "Iniciar Sesión";
            this.bttLoginEmpleado.UseVisualStyleBackColor = false;
            this.bttLoginEmpleado.Visible = false;
            this.bttLoginEmpleado.Click += new System.EventHandler(this.bttLoginEmpleado_Click);
            // 
            // lnkLoginEmpleado
            // 
            this.lnkLoginEmpleado.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(75)))), ((int)(((byte)(165)))));
            this.lnkLoginEmpleado.AutoSize = true;
            this.lnkLoginEmpleado.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lnkLoginEmpleado.Location = new System.Drawing.Point(188, 224);
            this.lnkLoginEmpleado.Name = "lnkLoginEmpleado";
            this.lnkLoginEmpleado.Size = new System.Drawing.Size(118, 17);
            this.lnkLoginEmpleado.TabIndex = 8;
            this.lnkLoginEmpleado.TabStop = true;
            this.lnkLoginEmpleado.Text = "Soy un empleado";
            this.lnkLoginEmpleado.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLoginEmpleado_LinkClicked);
            // 
            // lnkRegistrarse
            // 
            this.lnkRegistrarse.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(75)))), ((int)(((byte)(165)))));
            this.lnkRegistrarse.AutoSize = true;
            this.lnkRegistrarse.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lnkRegistrarse.Location = new System.Drawing.Point(188, 337);
            this.lnkRegistrarse.Name = "lnkRegistrarse";
            this.lnkRegistrarse.Size = new System.Drawing.Size(118, 17);
            this.lnkRegistrarse.TabIndex = 7;
            this.lnkRegistrarse.TabStop = true;
            this.lnkRegistrarse.Text = "Crear una cuenta";
            this.lnkRegistrarse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegistrarse_LinkClicked);
            // 
            // bttLoginCliente
            // 
            this.bttLoginCliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.bttLoginCliente.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bttLoginCliente.FlatAppearance.BorderSize = 0;
            this.bttLoginCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttLoginCliente.ForeColor = System.Drawing.Color.Gainsboro;
            this.bttLoginCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bttLoginCliente.Location = new System.Drawing.Point(45, 289);
            this.bttLoginCliente.Name = "bttLoginCliente";
            this.bttLoginCliente.Size = new System.Drawing.Size(261, 45);
            this.bttLoginCliente.TabIndex = 4;
            this.bttLoginCliente.Text = "Iniciar Sesión";
            this.bttLoginCliente.UseVisualStyleBackColor = false;
            this.bttLoginCliente.Click += new System.EventHandler(this.bttLoginCliente_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(45, 45);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 83);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Brush Script MT", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.lblBienvenido.Location = new System.Drawing.Point(45, 45);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(261, 83);
            this.lblBienvenido.TabIndex = 9;
            this.lblBienvenido.Text = "Bienvenido";
            this.lblBienvenido.Visible = false;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(75)))), ((int)(((byte)(165)))));
            this.ClientSize = new System.Drawing.Size(374, 426);
            this.Controls.Add(this.pnlLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(390, 465);
            this.MinimumSize = new System.Drawing.Size(390, 465);
            this.Name = "FrmLogin";
            this.Text = "Iniciar Sesión";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlIDUsu.ResumeLayout(false);
            this.pnlIDUsu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button bttLoginCliente;
        private System.Windows.Forms.TextBox txtIDUsu;
        private System.Windows.Forms.Button bttLoginEmpleado;
        private System.Windows.Forms.LinkLabel lnkLoginCliente;
        private System.Windows.Forms.LinkLabel lnkLoginEmpleado;
        private System.Windows.Forms.LinkLabel lnkRegistrarse;
        private System.Windows.Forms.Panel pnlIDUsu;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblBienvenido;
    }
}