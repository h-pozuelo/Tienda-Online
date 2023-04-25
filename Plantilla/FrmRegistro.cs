using Plantilla.Modelos;
using Plantilla.Modelos.BBDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantilla
{
    public partial class FrmRegistro : Form
    {
        Thread th;
        private BDTienda bbdd = new BDTienda();

        public FrmRegistro()
        {
            InitializeComponent();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            string cod;
            cod = new String('0', 8 - Convert.ToString(bbdd.NewID("cliente")).Length);
            cod += Convert.ToString(bbdd.NewID("cliente")) + "CL";
            txtIDUsu.Text = cod;
        }

        private void lnkGoBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            th = new Thread(openFrmLogin);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openFrmLogin(object obj)
        {
            Application.Run(new FrmLogin());
        }

        #region placeholder
        private void txtNomApe_Enter(object sender, EventArgs e)
        {
            if (txtNomApe.Text == "Nombre Apellido1 Apellido2")
            {
                txtNomApe.Text = "";
                txtNomApe.ForeColor = Color.Black;
            }
        }

        private void txtNomApe_Leave(object sender, EventArgs e)
        {
            if (txtNomApe.Text == "")
            {
                txtNomApe.Text = "Nombre Apellido1 Apellido2";
                txtNomApe.ForeColor = Color.LightGray;
            }
        }

        private void txtDirecc_Enter(object sender, EventArgs e)
        {
            if (txtDirecc.Text == "Calle Número, Piso{1,2}LETRA, Código Postal, Ciudad, Provincia")
            {
                txtDirecc.Text = "";
                txtDirecc.ForeColor = Color.Black;
            }
        }

        private void txtDirecc_Leave(object sender, EventArgs e)
        {
            if (txtDirecc.Text == "")
            {
                txtDirecc.Text = "Calle Número, Piso{1,2}LETRA, Código Postal, Ciudad, Provincia";
                txtDirecc.ForeColor = Color.LightGray;
            }
        }

        private void txtDNI_Enter(object sender, EventArgs e)
        {
            if (txtDNI.Text == "12345678A")
            {
                txtDNI.Text = "";
                txtDNI.ForeColor = Color.Black;
            }
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                txtDNI.Text = "12345678A";
                txtDNI.ForeColor = Color.LightGray;
            }
        }

        private void txtNumTarjeta_Enter(object sender, EventArgs e)
        {
            if (txtNumTarjeta.Text == "1111 2222 3333 4444")
            {
                txtNumTarjeta.Text = "";
                txtNumTarjeta.ForeColor = Color.Black;
            }
        }

        private void txtNumTarjeta_Leave(object sender, EventArgs e)
        {
            if (txtNumTarjeta.Text == "")
            {
                txtNumTarjeta.Text = "1111 2222 3333 4444";
                txtNumTarjeta.ForeColor = Color.LightGray;
            }
        }
        #endregion

        private void bttRegistrarse_Click(object sender, EventArgs e)
        {
            if (ValPersona())
            {
                if (bbdd.BuscarPersonaNomApe(txtNomApe.Text))
                {
                    MessageBox.Show("No se ha podido dar de alta al cliente.\nEl nombre de usuario introducido ya se encuentra en uso.\nEl nombre de usuario es único para cada cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (bbdd.BuscarPersonaDNI(txtDNI.Text))
                {
                    MessageBox.Show("No se ha podido dar de alta al cliente.\nEl DNI introducido ya se encuentra en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (bbdd.BuscarTarjeta(txtNumTarjeta.Text))
                {
                    MessageBox.Show("No se ha podido dar de alta al cliente.\nEl número de tarjeta introducido ya se encuentra en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string[] separator = { ", " };
                    string[] split = txtDirecc.Text.Split(separator, StringSplitOptions.None);
                    Direccion direc = new Direccion(split[0], split[1], split[2], split[3], split[4]);
                    Random rnd = new Random();
                    String fecha = DateTime.UtcNow.Date.AddYears(6).ToString("MM/yy");
                    Tarjeta t = new Tarjeta(txtNumTarjeta.Text, rnd.Next(1, 999).ToString().PadLeft(3, '0'), fecha, txtNomApe.Text);
                    Cliente cl = new Cliente(txtIDUsu.Text, txtNomApe.Text, direc, txtDNI.Text, t);
                    bbdd.AddPersona(cl);
                    MessageBox.Show("Cuenta creada correctamente.\nSe te redirigirá a la ventana de inicio de sesión.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    th = new Thread(openFrmLogin);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            else
                MessageBox.Show("No se ha podido dar de alta al cliente.\nRellene todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ValPersona()
        {
            Regex regex = new Regex(@"^.+$"); // QUE COMIENCE POR CUALQUIER CARÁCTER (COMO MÍNIMO 1) Y QUE FINALICE POR CUALQUIER CARÁCTER.
            if (!regex.IsMatch(txtNomApe.Text))
                return false;
            regex = new Regex(@"^.+(\,\s\d{1,2}[A-Z])(\,\s\d{5})(\,\s.+){2}$"); // QUE COMIENCE POR CUALQUIER CARÁCTER (COMO MÍNIMO 1), CONTINUA CON ", " Y ENTRE UNO Y DOS DÍGITOS JUNTO A UNA LETRA EN MAYÚSCULA, CONTINUA CON ", " Y CINCO DÍGITOS, FINALIZA CON ", " Y CUALQUIER CARÁCTER (COMO MÍNIMO 1) DOS VECES. 
            if (!regex.IsMatch(txtDirecc.Text))
                return false;
            regex = new Regex(@"^\d{8}[A-Z]$"); // QUE COMIENCE POR OCHO DÍGITOS Y QUE FINALICE POR UNA LETRA EN MAYÚSCULA. 
            if (!regex.IsMatch(txtDNI.Text))
                return false;
            regex = new Regex(@"^\d{4}(\s\d{4}){3}$"); // QUE COMIENCE POR CUATRO DÍGITOS Y QUE FINALICE CON ESPACIO Y CUATRO DÍGITOS TRES VECES. 
            if (!regex.IsMatch(txtNumTarjeta.Text))
                return false;
            return true;
        }
    }
}
