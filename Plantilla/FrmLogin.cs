using Plantilla.Modelos;
using Plantilla.Modelos.BBDD;
using Plantilla.Modelos.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantilla
{
    public partial class FrmLogin : Form
    {
        Thread th;
        private BDTienda bbdd = new BDTienda();
        Cliente cli;
        Empleado emple;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }

        private void lnkLoginEmpleado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkLoginEmpleado.Visible = false;
            lnkLoginCliente.Visible = true;
            bttLoginCliente.Visible = false;
            bttLoginEmpleado.Visible = true;
        }

        private void bttLoginCliente_Click(object sender, EventArgs e)
        {
            try
            {
                cli = bbdd.BuscarCliente("idusuario", txtIDUsu.Text);
                this.Close();
                th = new Thread(openFrmVistaCliente);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            catch (ConnectionException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFrmVistaCliente(object obj)
        {
            Application.Run(new FrmVistaCliente(cli));
        }

        private void lnkLoginCliente_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lnkLoginCliente.Visible = false;
            lnkLoginEmpleado.Visible = true;
            bttLoginEmpleado.Visible = false;
            bttLoginCliente.Visible = true;
        }

        private void bttLoginEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                emple = bbdd.BuscarEmple("idusuario", txtIDUsu.Text);
                this.Close();
                th = new Thread(openFrmMain);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            catch (ConnectionException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openFrmMain(object obj)
        {
            Application.Run(new frmMain(emple));
        }

        private void txtIDUsu_Enter(object sender, EventArgs e)
        {
            if (txtIDUsu.Text == "ID de Usuario")
            {
                txtIDUsu.Text = "";
                txtIDUsu.ForeColor = Color.Black;
            }
        }

        private void txtIDUsu_Leave(object sender, EventArgs e)
        {
            if (txtIDUsu.Text == "")
            {
                txtIDUsu.Text = "ID de Usuario";
                txtIDUsu.ForeColor = Color.LightGray;
            }
        }

        private void lnkRegistrarse_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
            th = new Thread(openFrmRegistro);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openFrmRegistro(object obj)
        {
            Application.Run(new FrmRegistro());
        }
    }
}
