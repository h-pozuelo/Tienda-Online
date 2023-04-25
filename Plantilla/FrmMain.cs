using Plantilla.Modelos;
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
    public partial class frmMain : Form
    {
        Thread th;
        Empleado emple;

        public frmMain(Empleado emple)
        {
            this.emple = emple;
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

            ddmBuscar.IsMainMenu = true;
            ddmBuscar.PrimaryColor = Color.FromArgb(111, 75, 165);
            ddmBuscar.MenuItemTextColor = Color.Gainsboro;

            ddmListar.IsMainMenu = true;
            ddmListar.PrimaryColor = Color.FromArgb(111, 75, 165);
            ddmListar.MenuItemTextColor = Color.Gainsboro;

            ddmAnyadir.IsMainMenu = true;
            ddmAnyadir.PrimaryColor = Color.FromArgb(111, 75, 165);
            ddmAnyadir.MenuItemTextColor = Color.Gainsboro;

            ddmModificar.IsMainMenu = true;
            ddmModificar.PrimaryColor = Color.FromArgb(111, 75, 165);
            ddmModificar.MenuItemTextColor = Color.Gainsboro;

            ddmEliminar.IsMainMenu = true;
            ddmEliminar.PrimaryColor = Color.FromArgb(111, 75, 165);
            ddmEliminar.MenuItemTextColor = Color.Gainsboro;

            this.CenterToScreen();

        }

        private void bttBuscar_Click(object sender, EventArgs e)
        {
            ddmBuscar.Show(bttBuscar, bttBuscar.Width, 0);
        }

        private void bttListar_Click(object sender, EventArgs e)
        {
            ddmListar.Show(bttListar, bttListar.Width, 0);
        }

        private void bttAnyadir_Click(object sender, EventArgs e)
        {
            ddmAnyadir.Show(bttAnyadir, bttAnyadir.Width, 0);
        }

        private void bttModificar_Click(object sender, EventArgs e)
        {
            ddmModificar.Show(bttModificar, bttModificar.Width, 0);
        }

        private void bttEliminar_Click(object sender, EventArgs e)
        {
            ddmEliminar.Show(bttEliminar, bttEliminar.Width, 0);
        }

        private Form currentForm = null;

        private void openChildForm(Form childForm)
        {

            if (currentForm != null)
            {
                currentForm.Close();
            }

            pnlFondo.Visible = true;

            currentForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Add(childForm);
            pnlChildForm.Tag = childForm;
            childForm.BringToFront();

            bttCerrarFrm.Visible = true;
            bttCerrarFrm.BringToFront();

            childForm.Show();

        }

        private void bttCerrarFrm_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
            {
                bttCerrarFrm.Visible = false;
                currentForm.Close();
                pnlFondo.Visible = false;
            }
        }

        #region bttBuscar
        private void porIdentificadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("emple", "ID"));
        }

        private void porDNIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("emple", "DNI"));
        }

        private void porNombreApellidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("emple", "Nombre/Apellidos"));
        }

        private void porIdentificadorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("cliente", "ID"));
        }

        private void porDNIToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("cliente", "DNI"));
        }

        private void porNombreApellidosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("cliente", "Nombre/Apellidos"));
        }

        private void consolasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("consola", "ID"));
        }

        private void ratonesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("raton", "ID"));
        }

        private void tecladosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("teclado", "ID"));
        }

        private void videojuegosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("videojuego", "ID"));
        }

        private void transacciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmBuscar("trans", "ID"));
        }
        #endregion

        #region bttListar
        private void empleadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmListar("emple"));
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmListar("cliente"));
        }

        private void productoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmListar("producto"));
        }

        private void transacciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmListar("trans"));
        }
        #endregion

        #region bttEliminar
        private void empleadoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmEliminar("emple", emple));
        }

        private void clienteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmEliminar("cliente"));
        }

        private void productoToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmEliminar("producto"));
        }
        #endregion

        #region bttAnyadir
        private void empleadoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAgregar("emple"));
        }

        private void clienteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAgregar("cliente"));
        }

        private void consolaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAgregar("producto", "consola"));
        }

        private void ratónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAgregar("producto", "raton"));
        }

        private void tecladoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAgregar("producto", "teclado"));
        }

        private void videojuegoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmAgregar("producto", "videojuego"));
        }
        #endregion

        #region bttModificar
        private void empleadoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmModificar("emple"));
        }

        private void productoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmModificar("cliente"));
        }

        private void productoToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmModificar("producto"));
        }
        #endregion

        private void bttCerrarSesion_Click(object sender, EventArgs e)
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
    }
}
