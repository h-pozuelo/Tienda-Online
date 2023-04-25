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
    public partial class FrmListar : Form
    {
        private BDTienda bbdd = new BDTienda();
        private string objeto;

        public FrmListar()
        {
            InitializeComponent();
        }

        public FrmListar(string obj)
        {
            InitializeComponent();
            this.objeto = obj;
        }

        private void FrmListar_Load(object sender, EventArgs e)
        {
            switch (this.objeto)
            {
                case "emple":
                    grpBx.Text = "Empleados";
                    lstBx.DataSource = bbdd.ListEmples();
                    lstBx.DisplayMember = "IdUsuario";
                    pnlPersona.Visible = true;
                    pnlPersona.Dock = DockStyle.Top;
                    pnlEmple.Visible = true;
                    pnlEmple.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "cliente":
                    grpBx.Text = "Clientes";
                    lstBx.DataSource = bbdd.ListClientes();
                    lstBx.DisplayMember = "IdUsuario";
                    pnlPersona.Visible = true;
                    pnlPersona.Dock = DockStyle.Top;
                    pnlCliente.Visible = true;
                    pnlCliente.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "producto":
                    grpBx.Text = "Productos";
                    lstBx.DataSource = bbdd.ListProductos();
                    lstBx.DisplayMember = "IdProducto";
                    pnlProducto.Visible = true;
                    pnlProducto.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "trans":
                    grpBx.Text = "Transacciones";
                    lstBx.DataSource = bbdd.ListTransaccion();
                    lstBx.DisplayMember = "IdTransaccion";
                    pnlTrans.Visible = true;
                    pnlTrans.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;
            }
            if (lstBx.Items.Count == 0)
                MessageBox.Show("No se encontraron objetos de este tipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void colocarPaneles()
        {
            pnlVideojuego.Dock = DockStyle.None;
            pnlVideojuego.Visible = false;
            pnlConsola.Dock = DockStyle.None;
            pnlConsola.Visible = false;
            pnlRaton.Dock = DockStyle.None;
            pnlRaton.Visible = false;
            pnlTeclado.Dock = DockStyle.None;
            pnlTeclado.Visible = false;
        }

        private void lstBx_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (lstBx.SelectedIndex != -1)
            {
                switch (this.objeto)
                {
                    case "emple":
                        Empleado em = (Empleado)lstBx.SelectedItem;
                        AssignPersonas(em);
                        txtSupervisor.Text = em.Supervisor ? "SI" : "NO";
                        break;

                    case "cliente":
                        cmbBxTransUsu.Text = "";
                        cmbBxTransUsu.Items.Clear();
                        Cliente cli = (Cliente)lstBx.SelectedItem;
                        AssignPersonas(cli);
                        txtNumTarjeta.Text = cli.Tarjeta.NumTarjeta;
                        foreach (String s in bbdd.ListTransaccionesUsu(cli.IdUsuario))
                            cmbBxTransUsu.Items.Add(s);
                        break;

                    case "producto":
                        colocarPaneles();
                        Producto pr = (Producto)lstBx.SelectedItem;
                        AssignProductos(pr);
                        switch (pr.IdProducto.Substring(pr.IdProducto.Length - 2, 2))
                        {
                            case "VI":
                                Videojuego vi = (Videojuego)bbdd.BuscarProducto("videojuego", pr.IdProducto);
                                txtConsola.Text = vi.Consola;
                                txtGenero.Text = vi.Genero;
                                txtDesarrolladora.Text = vi.Desarrolladora;
                                txtTamanyo.Text = Convert.ToString(vi.Tamanyo);
                                pnlVideojuego.Dock = DockStyle.Top;
                                pnlVideojuego.Visible = true;
                                break;

                            case "CO":
                                Consola c = (Consola)bbdd.BuscarProducto("consola", pr.IdProducto);
                                txtColoresC.Text = String.Join(";", c.Color);
                                txtAlmacenamiento.Text = Convert.ToString(c.Almacenamiento);
                                pnlConsola.Dock = DockStyle.Top;
                                pnlConsola.Visible = true;
                                break;

                            case "RA":
                                Raton r = (Raton)bbdd.BuscarProducto("raton", pr.IdProducto);
                                txtDimensionesR.Text = r.Dimensiones;
                                txtColoresR.Text = String.Join(";", r.Color);
                                txtDPI.Text = r.Dpi;
                                txtSensor.Text = r.TipoSensor;
                                txtConect.Text = r.Conectividad;
                                pnlRaton.Dock = DockStyle.Top;
                                pnlRaton.Visible = true;
                                break;

                            case "TE":
                                Teclado t = (Teclado)bbdd.BuscarProducto("teclado", pr.IdProducto);
                                txtDimensionesT.Text = t.Dimensiones;
                                txtColoresT.Text = String.Join(";", t.Color);
                                txtTipoTeclado.Text = t.Tipo;
                                txtTipoSwitch.Text = t.TipoSwitch;
                                pnlTeclado.Dock = DockStyle.Top;
                                pnlTeclado.Visible = true;
                                break;
                        }
                        break;

                    case "trans":
                        cmbBxProductosTrans.Text = "";
                        cmbBxProductosTrans.Items.Clear();
                        Transaccion tr = (Transaccion)lstBx.SelectedItem;
                        txtIDTrans.Text = tr.IdTransaccion;
                        txtClienteTrans.Text = tr.IdCliente;
                        txtFechaTrans.Text = Convert.ToString(tr.FechaTrans);
                        double total = 0;
                        foreach (String p in tr.Productos)
                        {
                            cmbBxProductosTrans.Items.Add(p);
                            total += bbdd.GetPrecioProducto(p);
                        }
                        txtTotalTrans.Text = Convert.ToString(total) + "€";
                        break;
                }
            }
        }

        private void AssignProductos(Producto p)
        {
            txtIDProducto.Text = p.IdProducto;
            txtMarca.Text = p.Marca;
            txtNomProd.Text = p.Nombre;
            txtPrecio.Text = Convert.ToString(p.Precio);
            txtUnidades.Text = Convert.ToString(p.UnidadesDisponibles);
            txtLanzamiento.Text = Convert.ToString(p.FechaLanzamiento);
        }

        private void AssignPersonas(Persona p)
        {
            txtIDUsu.Text = p.IdUsuario;
            txtNomApe.Text = p.NombreApellidos;
            txtDirecc.Text = p.Direccion.ToString();
            txtDNI.Text = p.Dni;
        }
    }
}