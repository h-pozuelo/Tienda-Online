using Plantilla.Modelos;
using Plantilla.Modelos.BBDD;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantilla
{
    public partial class FrmModificar : Form
    {
        private BDTienda bbdd = new BDTienda();
        private string objeto;

        public FrmModificar()
        {
            InitializeComponent();
        }

        public FrmModificar(string obj)
        {
            InitializeComponent();
            this.objeto = obj;
        }

        private void FrmModificar_Load(object sender, EventArgs e)
        {
            switch (this.objeto)
            {
                case "emple":
                    grpBx.Text = "Empleados";
                    lstBx.DataSource = bbdd.ListEmples();
                    lstBx.DisplayMember = "IdUsuario";
                    pnlPersona.Visible = true;
                    pnlPersona.Dock = DockStyle.Top;
                    break;

                case "cliente":
                    grpBx.Text = "Clientes";
                    lstBx.DataSource = bbdd.ListClientes();
                    lstBx.DisplayMember = "IdUsuario";
                    pnlPersona.Visible = true;
                    pnlPersona.Dock = DockStyle.Top;
                    break;

                case "producto":
                    grpBx.Text = "Productos";
                    lstBx.DataSource = bbdd.ListProductos();
                    lstBx.DisplayMember = "IdProducto";
                    pnlProducto.Visible = true;
                    pnlProducto.Dock = DockStyle.Top;
                    break;
            }
            pnlMod.Dock = DockStyle.Top;
            this.Size = new Size(714, 561);
            if (lstBx.Items.Count == 0)
                MessageBox.Show("No se encontraron objetos de este tipo", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void lstBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBx.SelectedIndex != -1)
            {
                limpiarCampos();
                cmbBxVar.Items.Clear();
                string[] itemspe = new string[] { "nomape", "direccion", "dni" };
                string[] itemspr = new string[] { "marca", "nombre", "precio", "unidades", "fechalanzamiento" };
                switch (this.objeto)
                {
                    case "emple":
                        Empleado em = (Empleado)lstBx.SelectedItem;
                        txtIDUsu.Text = em.IdUsuario;
                        txtNomApe.Text = em.NombreApellidos;
                        foreach (string item in itemspe)
                        {
                            cmbBxVar.Items.Add(item);
                        }
                        cmbBxVar.Items.Add("supervisor");
                        break;

                    case "cliente":
                        Cliente cli = (Cliente)lstBx.SelectedItem;
                        txtIDUsu.Text = cli.IdUsuario;
                        txtNomApe.Text = cli.NombreApellidos;
                        foreach (string item in itemspe)
                        {
                            cmbBxVar.Items.Add(item);
                        }
                        break;

                    case "producto":
                        Producto pr = (Producto)lstBx.SelectedItem;
                        txtIDProducto.Text = pr.IdProducto;
                        txtNomProd.Text = pr.Nombre;
                        foreach (string item in itemspr)
                        {
                            cmbBxVar.Items.Add(item);
                        }
                        string[] itemspr_unicos = new string[] { };
                        switch (pr.IdProducto.Substring(pr.IdProducto.Length - 2, 2))
                        {
                            case "VI":
                                itemspr_unicos = new string[] { "consola", "genero", "desarrolladora", "tamaño" };
                                break;

                            case "CO":
                                itemspr_unicos = new string[] { "colores", "almacenamiento" };
                                break;

                            case "RA":
                                itemspr_unicos = new string[] { "dimensiones", "colores", "dpi", "tiposensor", "conectividad" };
                                break;

                            case "TE":
                                itemspr_unicos = new string[] { "dimensiones", "colores", "tipo", "tiposwitch" };
                                break;
                        }
                        foreach (string item in itemspr_unicos)
                        {
                            cmbBxVar.Items.Add(item);
                        }
                        break;
                }
                cmbBxVar.Enabled = true;
                txtValor.Enabled = true;
            }
        }

        private void cmbBxVar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBx.SelectedIndex != -1)
            {
                Hashtable hasht = new Hashtable();
                switch (this.objeto)
                {
                    case "emple":
                        Empleado em = (Empleado)lstBx.SelectedItem;
                        hasht.Add("nomape", em.NombreApellidos);
                        hasht.Add("direccion", em.Direccion.ToString());
                        hasht.Add("dni", em.Dni);
                        hasht.Add("supervisor", em.Supervisor);
                        break;

                    case "cliente":
                        Cliente cli = (Cliente)lstBx.SelectedItem;
                        hasht.Add("nomape", cli.NombreApellidos);
                        hasht.Add("direccion", cli.Direccion.ToString());
                        hasht.Add("dni", cli.Dni);
                        break;

                    case "producto":
                        Producto pr = (Producto)lstBx.SelectedItem;
                        hasht.Add("marca", pr.Marca);
                        hasht.Add("nombre", pr.Nombre);
                        hasht.Add("precio", pr.Precio);
                        hasht.Add("unidades", pr.UnidadesDisponibles);
                        hasht.Add("fechalanzamiento", pr.FechaLanzamiento);
                        switch (pr.IdProducto.Substring(pr.IdProducto.Length - 2, 2))
                        {
                            case "VI":
                                Videojuego vi = (Videojuego)bbdd.BuscarProducto("videojuego", pr.IdProducto);
                                hasht.Add("consola", vi.Consola);
                                hasht.Add("genero", vi.Genero);
                                hasht.Add("desarrolladora", vi.Desarrolladora);
                                hasht.Add("tamaño", vi.Tamanyo);
                                break;

                            case "CO":
                                Consola co = (Consola)bbdd.BuscarProducto("consola", pr.IdProducto);
                                hasht.Add("colores", String.Join(";", co.Color));
                                hasht.Add("almacenamiento", co.Almacenamiento);
                                break;

                            case "RA":
                                Raton ra = (Raton)bbdd.BuscarProducto("raton", pr.IdProducto);
                                hasht.Add("dimensiones", ra.Dimensiones);
                                hasht.Add("colores", String.Join(";", ra.Color));
                                hasht.Add("dpi", ra.Dpi);
                                hasht.Add("tiposensor", ra.TipoSensor);
                                hasht.Add("conectividad", ra.Conectividad);
                                break;

                            case "TE":
                                Teclado te = (Teclado)bbdd.BuscarProducto("teclado", pr.IdProducto);
                                hasht.Add("dimensiones", te.Dimensiones);
                                hasht.Add("colores", String.Join(";", te.Color));
                                hasht.Add("tipo", te.Tipo);
                                hasht.Add("tiposwitch", te.TipoSwitch);
                                break;
                        }
                        break;
                }
                txtValor.Text = "";
                txtAntiguo.Text = Convert.ToString(hasht[cmbBxVar.GetItemText(cmbBxVar.SelectedItem)]);
            }
        }

        private void bttnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstBx.SelectedIndex != -1 && txtValor.Text.Length > 0)
                {
                    string var = cmbBxVar.GetItemText(cmbBxVar.SelectedItem);
                    if (ValMod(var, txtValor.Text))
                    {
                        string tipo = (txtIDProducto.Text.Length > 0) ?
                            txtIDProducto.Text.Substring(txtIDProducto.Text.Length - 2, 2) :
                            txtIDUsu.Text.Substring(txtIDUsu.Text.Length - 2, 2);
                        string id = txtIDProducto.Text.Length > 0 ? txtIDProducto.Text : txtIDUsu.Text;
                        switch (tipo)
                        {
                            case "CL":
                            case "EM":
                                if (bbdd.ModificarPersona(id, var, txtValor.Text) == 1)
                                {
                                    txtValor.Text = "";
                                    MessageBox.Show("Valor modificado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (tipo == "EM")
                                    {
                                        lstBx.DataSource = bbdd.ListEmples();
                                    }
                                    else
                                    {
                                        lstBx.DataSource = bbdd.ListClientes();
                                    }
                                    limpiarCampos();
                                }
                                else
                                    MessageBox.Show("Error (valor no modificado)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;

                            case "VI":
                            case "TE":
                            case "CO":
                            case "RA":
                                if (var == "tamaño")
                                {
                                    var = "tamanyo";
                                }
                                if (bbdd.ModificarProducto(id, var, txtValor.Text) == 1)
                                {
                                    txtValor.Text = "";
                                    MessageBox.Show("Valor modificado", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lstBx.DataSource = bbdd.ListProductos();
                                    limpiarCampos();
                                }
                                else
                                    MessageBox.Show("Error (valor no modificado)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                        }
                    }
                    else
                        MessageBox.Show("Algún valor inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException err)
            {
                MessageBox.Show(
                    "No ha sido posible llevar a cabo la modificación.\n"
                    + "\nEsto se puede deber a causa de:\n"
                    + "\n1. Haber dejado en blanco el campo de [ Variable ].\n"
                    + "\n2. Haber indicado una variable que no existe.\n"
                    + "\n3. Haber introducido un valor que ya se encuentra en uso como PK en otro registro.\n"
                    + "\n4. Otro error desconocido.\n"
                    + "\nDescripción:\n" + err.Message
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarCampos()
        {
            cmbBxVar.Text = "";
            txtAntiguo.Text = "";
            txtValor.Text = "";
        }

        private bool ValMod(string var, string valor)
        {
            Regex regex = new Regex(@"");
            switch (var)
            {
                case "nomape":
                case "marca":
                case "nombre":
                case "consola":
                case "genero":
                case "desarrolladora":
                case "tiposensor":
                case "conectividad":
                case "tipo":
                case "tiposwitch":
                    regex = new Regex(@"^.+$");
                    break;

                case "direccion":
                    regex = new Regex(@"^.+(\,\s\d{1,2}[A-Z])(\,\s\d{5})(\,\s.+){2}$");
                    break;

                case "dni":
                    regex = new Regex(@"^\d{8}[A-Z]$");
                    break;

                case "supervisor":
                    regex = new Regex(@"^(SI|NO)$");
                    break;

                case "precio":
                case "tamanyo":
                    regex = new Regex(@"^\d+\.\d{2}$");
                    break;

                case "fechalanzamiento":
                    regex = new Regex(@"^([12]\d|0[1-9]|3[01])\/(1[0-2]|0[1-9])\/\d{4}$");
                    break;

                case "unidades":
                case "almacenamiento":
                    regex = new Regex(@"^\d+$");
                    break;

                case "colores":
                    regex = new Regex(@"^[a-zA-Z]+(\;[a-zA-Z]+)*$");
                    break;

                case "dimensiones":
                    regex = new Regex(@"^\d{1,5}\,\s\d{1,5}$");
                    break;

                case "dpi":
                    regex = new Regex(@"^\d+DPI$");
                    break;
            }
            return regex.IsMatch(valor);
        }
    }
}