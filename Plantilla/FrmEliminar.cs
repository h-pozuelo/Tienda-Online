using Plantilla.Modelos;
using Plantilla.Modelos.BBDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantilla
{
    public partial class FrmEliminar : Form
    {
        private BDTienda bbdd = new BDTienda();
        private string objeto;
        Empleado emple;

        public FrmEliminar()
        {
            InitializeComponent();
        }

        public FrmEliminar(string obj)
        {
            InitializeComponent();
            this.objeto = obj;
        }

        public FrmEliminar(string obj, Empleado emple)
        {
            InitializeComponent();
            this.objeto = obj;
            this.emple = emple;
        }

        private void FrmEliminar_Load(object sender, EventArgs e)
        {
            switch (this.objeto)
            {
                case "emple":
                    grpBx.Text = "Empleados";
                    lstBx.DataSource = bbdd.ListEmples();
                    lstBx.DisplayMember = "IdUsuario";
                    this.Size = new Size(714, 561);
                    break;

                case "cliente":
                    grpBx.Text = "Clientes";
                    lstBx.DataSource = bbdd.ListClientes();
                    lstBx.DisplayMember = "IdUsuario";
                    this.Size = new Size(714, 561);
                    break;

                case "producto":
                    grpBx.Text = "Productos";
                    lstBx.DataSource = bbdd.ListProductos();
                    lstBx.DisplayMember = "IdProducto";
                    this.Size = new Size(714, 561);
                    break;
            }
            if (lstBx.Items.Count == 0)
                MessageBox.Show("No se encontraron objetos de este tipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void bttnBorrar_Click(object sender, EventArgs e)
        {
            if (lstBx.SelectedIndex != -1)
            {
                DialogResult respuesta = MessageBox.Show("Esta operación no se puede deshacer.\n¿Seguro que desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                if (respuesta.Equals(DialogResult.Yes))
                {
                    int filas = 0;
                    switch (this.objeto)
                    {
                        case "emple":
                            Empleado em = (Empleado)lstBx.SelectedItem;
                            if (em.IdUsuario == emple.IdUsuario)
                            {
                                MessageBox.Show("No puedes eliminar al usuario empleado porque está siendo utilizado en este momento.", "Operación denegada", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                            filas = bbdd.DeletePersona(em.IdUsuario);
                            lstBx.DataSource = bbdd.ListEmples();
                            break;

                        case "cliente":
                            Cliente cl = (Cliente)lstBx.SelectedItem;
                            filas = bbdd.DeletePersona(cl.IdUsuario);
                            lstBx.DataSource = bbdd.ListClientes();
                            break;

                        case "producto":
                            Producto pr = (Producto)lstBx.SelectedItem;
                            filas = bbdd.DeleteProducto(pr.IdProducto);
                            lstBx.DataSource = bbdd.ListProductos();
                            break;
                    }
                    if (filas > 0)
                    {
                        MessageBox.Show("Borrado con éxito", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ningún objeto borrado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Operación abortada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}