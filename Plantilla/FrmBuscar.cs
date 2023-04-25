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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantilla
{
    public partial class FrmBuscar : Form
    {
        private BDTienda bbdd = new BDTienda();
        private string objeto;
        private string opcion;

        public FrmBuscar()
        {
            InitializeComponent();
        }

        public FrmBuscar(string obj, string op)
        {
            InitializeComponent();
            this.objeto = obj;
            this.opcion = op;
        }

        private void FrmBuscar_Load(object sender, EventArgs e)
        {
            grpBx.Text = "Buscar " + this.objeto + " por " + this.opcion;
            lblOpcion.Text = this.opcion;
            switch (this.objeto)
            {
                case "emple":
                    pnlPersona.Visible = true;
                    pnlPersona.Dock = DockStyle.Fill;
                    pnlEmple.Visible = true;
                    pnlEmple.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "cliente":
                    pnlPersona.Visible = true;
                    pnlPersona.Dock = DockStyle.Fill;
                    pnlCliente.Visible = true;
                    pnlCliente.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "videojuego":
                    pnlProducto.Visible = true;
                    pnlProducto.Dock = DockStyle.Fill;
                    pnlVideojuego.Visible = true;
                    pnlVideojuego.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "teclado":
                    pnlProducto.Visible = true;
                    pnlProducto.Dock = DockStyle.Fill;
                    pnlTeclado.Visible = true;
                    pnlTeclado.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "consola":
                    pnlProducto.Visible = true;
                    pnlProducto.Dock = DockStyle.Fill;
                    pnlConsola.Visible = true;
                    pnlConsola.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "raton":
                    pnlProducto.Visible = true;
                    pnlProducto.Dock = DockStyle.Fill;
                    pnlRaton.Visible = true;
                    pnlRaton.Dock = DockStyle.Top;
                    this.Size = new Size(714, 561);
                    break;

                case "trans":
                    pnlTrans.Visible = true;
                    pnlTrans.Dock = DockStyle.Fill;
                    this.Size = new Size(714, 561);
                    break;
            }
        }

        private void bttnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                string var = "";
                switch (this.objeto)
                {
                    case "emple":
                        switch (this.opcion)
                        {
                            case "ID":
                                var = "idusuario";
                                break;

                            case "Nombre/Apellidos":
                                var = "nomape";
                                break;

                            case "DNI":
                                var = "dni";
                                break;
                        }
                        Empleado emple = bbdd.BuscarEmple(var, txtBusqueda.Text);
                        AssignPersonas(emple);
                        txtSupervisor.Text = emple.Supervisor ? "Si" : "No";
                        break;

                    case "cliente":
                        switch (this.opcion)
                        {
                            case "ID":
                                var = "idusuario";
                                break;

                            case "Nombre/Apellidos":
                                var = "nomape";
                                break;

                            case "DNI":
                                var = "dni";
                                break;
                        }
                        cmbBxTransUsu.Text = "";
                        cmbBxTransUsu.Items.Clear();
                        Cliente cli = bbdd.BuscarCliente(var, txtBusqueda.Text);
                        AssignPersonas(cli);
                        txtNumTarjeta.Text = cli.Tarjeta.NumTarjeta;
                        foreach (String s in bbdd.ListTransaccionesUsu(cli.IdUsuario))
                            cmbBxTransUsu.Items.Add(s);
                        break;

                    case "videojuego":
                        Videojuego vi = (Videojuego)bbdd.BuscarProducto("videojuego", txtBusqueda.Text);
                        AssignProductos(vi);
                        txtConsola.Text = vi.Consola;
                        txtGenero.Text = vi.Genero;
                        txtDesarrolladora.Text = vi.Desarrolladora;
                        txtTamanyo.Text = Convert.ToString(vi.Tamanyo);
                        break;

                    case "teclado":
                        Teclado t = (Teclado)bbdd.BuscarProducto("teclado", txtBusqueda.Text);
                        AssignProductos(t);
                        txtDimensionesT.Text = t.Dimensiones;
                        txtColoresT.Text = String.Join(";", t.Color);
                        txtTipoTeclado.Text = t.Tipo;
                        txtTipoSwitch.Text = t.TipoSwitch;
                        break;

                    case "consola":
                        Consola c = (Consola)bbdd.BuscarProducto("consola", txtBusqueda.Text);
                        AssignProductos(c);
                        txtColoresC.Text = String.Join(";", c.Color);
                        txtAlmacenamiento.Text = Convert.ToString(c.Almacenamiento);
                        break;

                    case "raton":
                        Raton r = (Raton)bbdd.BuscarProducto("raton", txtBusqueda.Text);
                        AssignProductos(r);
                        txtDimensionesR.Text = r.Dimensiones;
                        txtColoresR.Text = String.Join(";", r.Color);
                        txtDPI.Text = r.Dpi;
                        txtSensor.Text = r.TipoSensor;
                        txtConect.Text = r.Conectividad;
                        break;

                    case "trans":
                        cmbBxProductosTrans.Text = "";
                        cmbBxProductosTrans.Items.Clear();
                        Transaccion tr = bbdd.BuscarTransaccion(txtBusqueda.Text);
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
            catch (ConnectionException err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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