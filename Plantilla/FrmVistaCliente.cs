using Plantilla.Modelos;
using Plantilla.Modelos.BBDD;
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
    public partial class FrmVistaCliente : Form
    {
        Thread th;
        private BDTienda bbdd = new BDTienda();
        private List<String> carrito = new List<String>();
        Cliente cli;

        public FrmVistaCliente(Cliente cli)
        {
            this.cli = cli;
            InitializeComponent();
        }

        private void FrmVistaCliente_Load(object sender, EventArgs e)
        {
            this.Size = new Size(1005, 655);
            cmbBxCategoria.SelectedIndex = 0;
            pnlCompra.Dock = DockStyle.Fill;
            pnlCompra.Visible = true;
            this.CenterToScreen();
        }

        #region bttPnlCompra
        private void bttCarrito_Click(object sender, EventArgs e)
        {
            pnlCompra.Visible = false;
            pnlCompra.Dock = DockStyle.None;
            pnlCarrito.Dock = DockStyle.Fill;
            pnlCarrito.Visible = true;
        }

        private void bttPerfil_Click(object sender, EventArgs e)
        {
            infoCliente();
            pnlCompra.Visible = false;
            pnlCompra.Dock = DockStyle.None;
            pnlPerfil.Dock = DockStyle.Fill;
            pnlPerfil.Visible = true;
        }
        #endregion

        #region bttPnlCarrito
        private void bttAtras_Click(object sender, EventArgs e)
        {
            pnlCarrito.Visible = false;
            pnlCarrito.Dock = DockStyle.None;
            pnlCompra.Dock = DockStyle.Fill;
            pnlCompra.Visible = true;
        }
        #endregion

        #region bttPnlPerfil
        private void bttAtras2_Click(object sender, EventArgs e)
        {
            pnlPerfil.Visible = false;
            pnlPerfil.Dock = DockStyle.None;
            pnlCompra.Dock = DockStyle.Fill;
            pnlCompra.Visible = true;
        }

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
        #endregion

        private void cmbBxCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarCampos();
            pnlConsola.Visible = false;
            pnlRaton.Visible = false;
            pnlTeclado.Visible = false;
            pnlVideojuego.Visible = false;
            switch (Convert.ToString(cmbBxCategoria.SelectedItem))
            {
                case "Todos":
                    lstBxProductos.DataSource = bbdd.ListProductos();
                    lstBxProductos.DisplayMember = "Nombre";
                    break;

                case "Consolas":
                    lstBxProductos.DataSource = bbdd.ListCategoria("CO");
                    lstBxProductos.DisplayMember = "Nombre";
                    pnlConsola.Dock = DockStyle.Top;
                    pnlConsola.Visible = true;
                    break;

                case "Ratones":
                    lstBxProductos.DataSource = bbdd.ListCategoria("RA");
                    lstBxProductos.DisplayMember = "Nombre";
                    pnlRaton.Dock = DockStyle.Top;
                    pnlRaton.Visible = true;
                    break;

                case "Teclados":
                    lstBxProductos.DataSource = bbdd.ListCategoria("TE");
                    lstBxProductos.DisplayMember = "Nombre";
                    pnlTeclado.Dock = DockStyle.Top;
                    pnlTeclado.Visible = true;
                    break;

                case "Videojuegos":
                    lstBxProductos.DataSource = bbdd.ListCategoria("VI");
                    lstBxProductos.DisplayMember = "Nombre";
                    pnlVideojuego.Dock = DockStyle.Top;
                    pnlVideojuego.Visible = true;
                    break;

                default:
                    lstBxProductos.DataSource = null;
                    break;
            }
            if (lstBxProductos.Items.Count == 0 && Convert.ToString(cmbBxCategoria.SelectedItem) != "(Seleccione una categoría)")
                MessageBox.Show("No se encontraron objetos de este tipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void lstBxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBxProductos.SelectedIndex != -1)
            {
                txtCantidad.Enabled = true;
                txtCantidad.Text = "0";
                txtTotal.Text = "0 €";
                if (Convert.ToString(cmbBxCategoria.SelectedItem) == "Todos")
                {
                    pnlConsola.Visible = false;
                    pnlRaton.Visible = false;
                    pnlTeclado.Visible = false;
                    pnlVideojuego.Visible = false;
                }
                Producto pr = (Producto)lstBxProductos.SelectedItem;
                AssignProductos(pr);
                switch (pr.IdProducto.Substring(pr.IdProducto.Length - 2, 2))
                {
                    case "VI":
                        Videojuego vi = (Videojuego)bbdd.BuscarProducto("videojuego", pr.IdProducto);
                        txtConsola.Text = vi.Consola;
                        txtGenero.Text = vi.Genero;
                        txtDesarrolladora.Text = vi.Desarrolladora;
                        txtTamanyo.Text = Convert.ToString(vi.Tamanyo);
                        if (Convert.ToString(cmbBxCategoria.SelectedItem) == "Todos")
                        {
                            pnlVideojuego.Dock = DockStyle.Top;
                            pnlVideojuego.Visible = true;
                        }
                        break;

                    case "CO":
                        Consola c = (Consola)bbdd.BuscarProducto("consola", pr.IdProducto);
                        txtColoresC.Text = String.Join(";", c.Color);
                        txtAlmacenamiento.Text = Convert.ToString(c.Almacenamiento);
                        if (Convert.ToString(cmbBxCategoria.SelectedItem) == "Todos")
                        {
                            pnlConsola.Dock = DockStyle.Top;
                            pnlConsola.Visible = true;
                        }
                        break;

                    case "RA":
                        Raton r = (Raton)bbdd.BuscarProducto("raton", pr.IdProducto);
                        txtDimensionesR.Text = r.Dimensiones;
                        txtColoresR.Text = String.Join(";", r.Color);
                        txtDPI.Text = r.Dpi;
                        txtSensor.Text = r.TipoSensor;
                        txtConect.Text = r.Conectividad;
                        if (Convert.ToString(cmbBxCategoria.SelectedItem) == "Todos")
                        {
                            pnlRaton.Dock = DockStyle.Top;
                            pnlRaton.Visible = true;
                        }
                        break;

                    case "TE":
                        Teclado t = (Teclado)bbdd.BuscarProducto("teclado", pr.IdProducto);
                        txtDimensionesT.Text = t.Dimensiones;
                        txtColoresT.Text = String.Join(";", t.Color);
                        txtTipoTeclado.Text = t.Tipo;
                        txtTipoSwitch.Text = t.TipoSwitch;
                        if (Convert.ToString(cmbBxCategoria.SelectedItem) == "Todos")
                        {
                            pnlTeclado.Dock = DockStyle.Top;
                            pnlTeclado.Visible = true;
                        }
                        break;
                }
            }
            else
            {
                txtCantidad.Enabled = false;
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

        private void limpiarCampos()
        {
            txtIDProducto.Clear();
            txtNomProd.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtUnidades.Clear();
            txtLanzamiento.Clear();

            txtDPI.Clear();
            txtSensor.Clear();
            txtConect.Clear();
            txtDimensionesR.Clear();
            txtColoresR.Clear();

            txtAlmacenamiento.Clear();
            txtColoresC.Clear();

            txtTipoTeclado.Clear();
            txtTipoSwitch.Clear();
            txtDimensionesT.Clear();
            txtColoresT.Clear();

            txtConsola.Clear();
            txtGenero.Clear();
            txtDesarrolladora.Clear();
            txtTamanyo.Clear();

            txtCantidad.Text = "0";
            txtTotal.Text = "0 €";
        }

        private void bttAddCarrito_Click(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "0")
            {
                MessageBox.Show("Selecciona un producto e indica una cantidad para poder añadirlo a tu carrito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String[] producto = new String[5];
            Producto pr = (Producto)lstBxProductos.SelectedItem;
            switch (pr.IdProducto.Substring(pr.IdProducto.Length - 2, 2))
            {
                case "VI":
                    producto = new String[] { pr.IdProducto, "Videojuego", pr.Nombre, pr.Marca, Convert.ToString(pr.Precio) };
                    break;

                case "CO":
                    producto = new String[] { pr.IdProducto, "Consola", pr.Nombre, pr.Marca, Convert.ToString(pr.Precio) };
                    break;

                case "RA":
                    producto = new String[] { pr.IdProducto, "Ratón", pr.Nombre, pr.Marca, Convert.ToString(pr.Precio) };
                    break;

                case "TE":
                    producto = new String[] { pr.IdProducto, "Teclado", pr.Nombre, pr.Marca, Convert.ToString(pr.Precio) };
                    break;
            }
            double importe = Convert.ToDouble(txtImporte.Text.Substring(0, txtImporte.Text.Length - 2));
            for (int i = 0; i < Convert.ToInt32(txtCantidad.Text); i++)
            {
                carrito.Add(String.Join(";", producto));
                importe += pr.Precio;
            }
            txtImporte.Text = Convert.ToString(importe) + " €";
            lstBxCarrito.DataSource = null;
            lstBxCarrito.DataSource = carrito;
            txtCantidad.Text = "0";
            txtTotal.Text = "0 €";
        }

        private void bttComprar_Click(object sender, EventArgs e)
        {
            if (lstBxCarrito.Items.Count == 0)
            {
                MessageBox.Show("Añade productos a tu carrito para poder comprar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            String cod = new String('0', 8 - Convert.ToString(bbdd.NewID("trans")).Length);
            cod += Convert.ToString(bbdd.NewID("trans")) + "TR";
            bbdd.AddTransaccion(new Transaccion(cod, cli.IdUsuario, carrito.ToArray(), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)));
            carrito = new List<String>();
            lstBxCarrito.DataSource = null;
            txtImporte.Text = "0 €";
            lstBxProductos.DataSource = null;
            limpiarCampos();
            cmbBxCategoria.SelectedIndex = 0;
        }

        private void infoCliente()
        {
            txtIDUsu.Text = this.cli.IdUsuario;
            txtNomApe.Text = this.cli.NombreApellidos;
            txtDirecc.Text = this.cli.Direccion.ToString();
            txtDNI.Text = this.cli.Dni;
            txtNumTarjeta.Text = this.cli.Tarjeta.NumTarjeta;
            lstBxTransUsu.Items.Clear();
            foreach (String s in bbdd.ListTransaccionesUsu(this.cli.IdUsuario))
            {
                lstBxTransUsu.Items.Add(s.Substring(0, 10));
            }
            lstBxProductosUsu.Items.Clear();
        }

        private void lstBxTransUsu_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstBxProductosUsu.Items.Clear();
            Transaccion tr = bbdd.BuscarTransaccion(lstBxTransUsu.SelectedItem.ToString());
            foreach (String p in tr.Productos)
            {
                lstBxProductosUsu.Items.Add(p);
            }
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            if (txtCantidad.Text == "0")
            {
                txtTotal.Text = "0 €";
                return;
            }
            int num = 0;
            if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out num))
            {
                MessageBox.Show("El campo cantidad solo puede contener números enteros.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCantidad.Text = "0";
                return;
            }
            Producto pr = (Producto)lstBxProductos.SelectedItem;
            int cantidadEnCarrito = 0;
            foreach (String prCarrito in carrito)
            {
                if (prCarrito.Split(';').ToList<String>()[0] == pr.IdProducto)
                {
                    cantidadEnCarrito += 1;
                }
            }
            if (int.Parse(txtCantidad.Text) > (pr.UnidadesDisponibles - cantidadEnCarrito))
            {
                MessageBox.Show("Solo quedan " + pr.UnidadesDisponibles + " unidades disponibles.\nUnidades en mi carrito = " + cantidadEnCarrito, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidad.Text = Convert.ToString(pr.UnidadesDisponibles - cantidadEnCarrito);
            }
            txtTotal.Text = Convert.ToString(int.Parse(txtCantidad.Text) * double.Parse(txtPrecio.Text)) + " €";
        }

        private void bttLimpiarCarrito_Click(object sender, EventArgs e)
        {
            if (lstBxCarrito.Items.Count == 0)
            {
                MessageBox.Show("El carrito se encuentra vacío.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult respuesta = MessageBox.Show("Esta operación no se puede deshacer.\n¿Seguro que desea continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (respuesta.Equals(DialogResult.Yes))
            {
                carrito = new List<String>();
                lstBxCarrito.DataSource = null;
                txtImporte.Text = "0 €";
            }
            else
            {
                MessageBox.Show("Operación abortada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
