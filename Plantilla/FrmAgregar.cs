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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Plantilla
{
    public partial class FrmAgregar : Form
    {
        private BDTienda bbdd = new BDTienda();
        private string objeto;
        private string opcion = "";

        public FrmAgregar()
        {
            InitializeComponent();
        }

        public FrmAgregar(string obj)
        {
            InitializeComponent();
            this.objeto = obj;
        }

        public FrmAgregar(string obj, string op)
        {
            InitializeComponent();
            this.objeto = obj;
            this.opcion = op;
        }

        private void FrmAgregar_Load(object sender, EventArgs e)
        {
            string cod;
            switch (this.objeto)
            {
                case "emple":
                    grpBx.Text = "Agregar empleado";
                    pnlPersona.Visible = true;
                    pnlPersona.Dock = DockStyle.Fill;
                    pnlEmple.Visible = true;
                    pnlEmple.Dock = DockStyle.Top;
                    cod = new String('0', 8 - Convert.ToString(bbdd.NewID(this.objeto)).Length);
                    cod += Convert.ToString(bbdd.NewID(this.objeto)) + "EM";
                    txtIDUsu.Text = cod;
                    break;

                case "cliente":
                    grpBx.Text = "Agregar cliente";
                    pnlPersona.Visible = true;
                    pnlPersona.Dock = DockStyle.Fill;
                    pnlCliente.Visible = true;
                    pnlCliente.Dock = DockStyle.Top;
                    cod = new String('0', 8 - Convert.ToString(bbdd.NewID(this.objeto)).Length);
                    cod += Convert.ToString(bbdd.NewID(this.objeto)) + "CL";
                    txtIDUsu.Text = cod;
                    break;

                case "producto":
                    pnlProducto.Visible = true;
                    pnlProducto.Dock = DockStyle.Fill;
                    cod = new String('0', 8 - Convert.ToString(bbdd.NewID(this.opcion)).Length);
                    switch (this.opcion)
                    {
                        case "videojuego":
                            grpBx.Text = "Agregar videojuego";
                            pnlVideojuego.Visible = true;
                            pnlVideojuego.Dock = DockStyle.Top;
                            cod += Convert.ToString(bbdd.NewID(this.opcion)) + "VI";
                            break;

                        case "consola":
                            grpBx.Text = "Agregar consola";
                            pnlConsola.Visible = true;
                            pnlConsola.Dock = DockStyle.Top;
                            cod += Convert.ToString(bbdd.NewID(this.opcion)) + "CO";
                            break;

                        case "raton":
                            grpBx.Text = "Agregar ratón";
                            pnlRaton.Visible = true;
                            pnlRaton.Dock = DockStyle.Top;
                            cod += Convert.ToString(bbdd.NewID(this.opcion)) + "RA";
                            break;

                        case "teclado":
                            grpBx.Text = "Agregar teclado";
                            pnlTeclado.Visible = true;
                            pnlTeclado.Dock = DockStyle.Top;
                            cod += Convert.ToString(bbdd.NewID(this.opcion)) + "TE";
                            break;
                    }
                    txtIDProducto.Text = cod;
                    break;
            }
            this.Size = new Size(714, 561);
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            if (this.objeto == "emple")
            {
                if (ValPersona(this.objeto))
                {
                    if (bbdd.BuscarPersonaNomApe(txtNomApe.Text))
                    {
                        MessageBox.Show("No se ha podido dar de alta al empleado.\nEl nombre de usuario introducido ya se encuentra en uso.\nEl nombre de usuario es único para cada cuenta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (bbdd.BuscarPersonaDNI(txtDNI.Text))
                    {
                        MessageBox.Show("No se ha podido dar de alta al empleado.\nEl DNI introducido ya se encuentra en uso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string[] separator = { ", " };
                        string[] split = txtDirecc.Text.Split(separator, StringSplitOptions.None);
                        Direccion direc = new Direccion(split[0], split[1], split[2], split[3], split[4]);
                        Empleado em = new Empleado(txtIDUsu.Text, txtNomApe.Text, direc, txtDNI.Text,
                            txtSupervisor.Text == "SI");
                        bbdd.AddPersona(em);
                        MessageBox.Show("Se ha dado de alta al empleado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                    }
                }
                else
                    MessageBox.Show("No se ha podido dar de alta al empleado.\nRellene todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.objeto == "cliente")
            {
                if (ValPersona(this.objeto))
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
                        MessageBox.Show("Se ha dado de alta al cliente correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiarCampos();
                    }
                }
                else
                    MessageBox.Show("No se ha podido dar de alta al cliente.\nRellene todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (this.objeto == "producto")
            {
                if (ValProducto(this.opcion))
                {
                    string[] split = txtLanzamiento.Text.Split('/');
                    DateTime flanz = new DateTime(Convert.ToInt32(split[2]), Convert.ToInt32(split[1]),
                        Convert.ToInt32(split[0]));
                    switch (this.opcion)
                    {
                        case "videojuego":
                            Videojuego vi = new Videojuego(txtIDProducto.Text, txtMarca.Text,
                                txtNomProd.Text, double.Parse(txtPrecio.Text, System.Globalization.CultureInfo.InvariantCulture),
                                Convert.ToInt32(txtUnidades.Text), flanz, txtConsola.Text, txtGenero.Text,
                                txtDesarrolladora.Text, double.Parse(txtTamanyo.Text, System.Globalization.CultureInfo.InvariantCulture));
                            bbdd.AddProducto(vi);
                            break;

                        case "consola":
                            Consola co = new Consola(txtIDProducto.Text, txtMarca.Text,
                                txtNomProd.Text, double.Parse(txtPrecio.Text, System.Globalization.CultureInfo.InvariantCulture),
                                Convert.ToInt32(txtUnidades.Text), flanz, txtColoresC.Text.Split(';').ToList<String>(),
                                Convert.ToInt32(txtAlmacenamiento.Text));
                            bbdd.AddProducto(co);
                            break;

                        case "raton":
                            Raton ra = new Raton(txtIDProducto.Text, txtMarca.Text,
                                txtNomProd.Text, double.Parse(txtPrecio.Text, System.Globalization.CultureInfo.InvariantCulture),
                                Convert.ToInt32(txtUnidades.Text), flanz, txtDimensionesR.Text.Split(',')[0].Trim() + "x" + txtDimensionesR.Text.Split(',')[1].Trim(),
                                txtColoresR.Text.Split(';').ToList<String>(), txtDPI.Text, txtSensor.Text, txtConect.Text);
                            bbdd.AddProducto(ra);
                            break;

                        case "teclado":
                            Teclado te = new Teclado(txtIDProducto.Text, txtMarca.Text,
                                txtNomProd.Text, double.Parse(txtPrecio.Text, System.Globalization.CultureInfo.InvariantCulture),
                                Convert.ToInt32(txtUnidades.Text), flanz, txtDimensionesT.Text.Split(',')[0].Trim() + "x" + txtDimensionesT.Text.Split(',')[1].Trim(),
                                txtColoresT.Text.Split(';').ToList<String>(), txtTipoTeclado.Text, txtTipoSwitch.Text);
                            bbdd.AddProducto(te);
                            break;
                    }
                    MessageBox.Show("Se ha dado de alta al producto correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiarCampos();
                }
                else
                    MessageBox.Show("No se ha podido agregar el producto.\nRellene todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiarCampos()
        {
            string cod;
            if (this.objeto == "emple")
            {
                cod = new String('0', 8 - Convert.ToString(bbdd.NewID(this.objeto)).Length);
                cod += Convert.ToString(bbdd.NewID(this.objeto)) + "EM";
                txtIDUsu.Text = cod;
                txtNomApe.Text = "Nombre Apellido1 Apellido2";
                txtNomApe.ForeColor = Color.LightGray;
                txtDirecc.Text = "Calle Número, Piso{1,2}LETRA, Código Postal, Ciudad, Provincia";
                txtDirecc.ForeColor = Color.LightGray;
                txtDNI.Text = "12345678A";
                txtDNI.ForeColor = Color.LightGray;
                txtSupervisor.Text = "SI o NO";
                txtSupervisor.ForeColor = Color.LightGray;
            }
            else if (this.objeto == "cliente")
            {
                cod = new String('0', 8 - Convert.ToString(bbdd.NewID(this.objeto)).Length);
                cod += Convert.ToString(bbdd.NewID(this.objeto)) + "CL";
                txtIDUsu.Text = cod;
                txtNomApe.Text = "Nombre Apellido1 Apellido2";
                txtNomApe.ForeColor = Color.LightGray;
                txtDirecc.Text = "Calle Número, Piso{1,2}LETRA, Código Postal, Ciudad, Provincia";
                txtDirecc.ForeColor = Color.LightGray;
                txtDNI.Text = "12345678A";
                txtDNI.ForeColor = Color.LightGray;
                txtNumTarjeta.Text = "1111 2222 3333 4444";
                txtNumTarjeta.ForeColor = Color.LightGray;
            }
            else
            {
                txtNomProd.Text = "Nombre de Producto";
                txtNomProd.ForeColor = Color.LightGray;
                txtMarca.Text = "Marca";
                txtMarca.ForeColor = Color.LightGray;
                txtPrecio.Text = "0{1,}.00";
                txtPrecio.ForeColor = Color.LightGray;
                txtUnidades.Text = "Cantidad";
                txtUnidades.ForeColor = Color.LightGray;
                txtLanzamiento.Text = "DD/MM/YYYY";
                txtLanzamiento.ForeColor = Color.LightGray;
                cod = new String('0', 8 - Convert.ToString(bbdd.NewID(this.opcion)).Length);
                switch (this.opcion)
                {
                    case "videojuego":
                        cod += Convert.ToString(bbdd.NewID(this.opcion)) + "VI";
                        txtConsola.Text = "Consola";
                        txtConsola.ForeColor = Color.LightGray;
                        txtGenero.Text = "Género de Videojuego";
                        txtGenero.ForeColor = Color.LightGray;
                        txtDesarrolladora.Text = "Desarrolladora";
                        txtDesarrolladora.ForeColor = Color.LightGray;
                        txtTamanyo.Text = "0{1,}.00";
                        txtTamanyo.ForeColor = Color.LightGray;
                        break;

                    case "consola":
                        cod += Convert.ToString(bbdd.NewID(this.opcion)) + "CO";
                        txtAlmacenamiento.Text = "0{1,} (128 o 256 o 512 o 1024)";
                        txtAlmacenamiento.ForeColor = Color.LightGray;
                        txtColoresC.Text = "Color1 o Color1;Color2;Color3;...";
                        txtColoresC.ForeColor = Color.LightGray;
                        break;

                    case "raton":
                        cod += Convert.ToString(bbdd.NewID(this.opcion)) + "RA";
                        txtDPI.Text = "0DPI";
                        txtDPI.ForeColor = Color.LightGray;
                        txtSensor.Text = "Tipo de Sensor";
                        txtSensor.ForeColor = Color.LightGray;
                        txtConect.Text = "Conectividad";
                        txtConect.ForeColor = Color.LightGray;
                        txtDimensionesR.Text = "0{1,5}, 0{1,5} (Largo, Ancho)";
                        txtDimensionesR.ForeColor = Color.LightGray;
                        txtColoresR.Text = "Color1 o Color1;Color2;Color3;...";
                        txtColoresR.ForeColor = Color.LightGray;
                        break;

                    case "teclado":
                        cod += Convert.ToString(bbdd.NewID(this.opcion)) + "TE";
                        txtTipoTeclado.Text = "Tipo de Teclado";
                        txtTipoTeclado.ForeColor = Color.LightGray;
                        txtTipoSwitch.Text = "Tipo de Switch";
                        txtTipoSwitch.ForeColor = Color.LightGray;
                        txtDimensionesT.Text = "0{1,5}, 0{1,5} (Largo, Ancho)";
                        txtDimensionesT.ForeColor = Color.LightGray;
                        txtColoresT.Text = "Color1 o Color1;Color2;Color3;...";
                        txtColoresT.ForeColor = Color.LightGray;
                        break;
                }
                txtIDProducto.Text = cod;

            }
        }

        private bool ValPersona(string op)
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
            switch (op)
            {
                case "emple":
                    regex = new Regex(@"^(SI|NO)$");
                    if (!regex.IsMatch(txtSupervisor.Text))
                        return false;
                    break;

                case "cliente":
                    regex = new Regex(@"^\d{4}(\s\d{4}){3}$"); // QUE COMIENCE POR CUATRO DÍGITOS Y QUE FINALICE CON ESPACIO Y CUATRO DÍGITOS TRES VECES. 
                    if (!regex.IsMatch(txtNumTarjeta.Text))
                        return false;
                    break;
            }
            return true;
        }

        private bool ValProducto(string op)
        {
            Regex regex = new Regex(@"^.+$"); // QUE COMIENCE POR CUALQUIER CARÁCTER (COMO MÍNIMO 1) Y QUE FINALICE POR CUALQUIER CARÁCTER.
            if (!regex.IsMatch(txtMarca.Text) || !regex.IsMatch(txtNomProd.Text))
                return false;
            regex = new Regex(@"^\d+\.\d{2}$"); // QUE COMIENCE POR UN DÍGITO (COMO MÍNIMO 1), CONTINUA CON ".", FINALIZA CON DOS DÍGITOS. 
            if (!regex.IsMatch(txtPrecio.Text))
                return false;
            regex = new Regex(@"^([12]\d|0[1-9]|3[01])\/(1[0-2]|0[1-9])\/\d{4}$"); // DD/MM/AAAA 
            if (!regex.IsMatch(txtLanzamiento.Text))
                return false;
            regex = new Regex(@"^\d+$"); // QUE COMIENCE POR UN DÍGITO (COMO MÍNIMO 1) Y QUE FINALICE POR UN DÍGITO. 
            if (!regex.IsMatch(txtUnidades.Text))
                return false;
            switch (op)
            {
                case "videojuego":
                    regex = new Regex(@"^.+$"); // QUE COMIENCE POR CUALQUIER CARÁCTER (COMO MÍNIMO 1) Y QUE FINALICE POR CUALQUIER CARÁCTER.
                    if (!regex.IsMatch(txtConsola.Text) || !regex.IsMatch(txtDesarrolladora.Text)
                        || !regex.IsMatch(txtGenero.Text))
                        return false;
                    regex = new Regex(@"^\d+\.\d{2}$"); // QUE COMIENCE POR UN DÍGITO (COMO MÍNIMO 1), CONTINUA CON ".", FINALIZA CON DOS DÍGITOS. 
                    if (!regex.IsMatch(txtTamanyo.Text))
                        return false;
                    break;

                case "consola":
                    regex = new Regex(@"^[a-zA-Z]+(\;[a-zA-Z]+)*$"); // QUE COMIENCE POR UNA LETRA MINÚSCULA O MAYÚSCULA (COMO MÍNIMO 1), PUEDE CONTINUAR O NO (0, n) CON ";" JUNTO A OTRA LETRA MÍNUSCULA O MAYÚSCULA (COMO MÍNIMO 1). 
                    if (!regex.IsMatch(txtColoresC.Text))
                        return false;
                    regex = new Regex(@"^\d+$"); // QUE COMIENCE POR UN DÍGITO (COMO MÍNIMO 1) Y QUE FINALICE POR UN DÍGITO. 
                    if (!regex.IsMatch(txtAlmacenamiento.Text))
                        return false;
                    break;

                case "raton":
                    regex = new Regex(@"^[a-zA-Z]+(\;[a-zA-Z]+)*$"); // QUE COMIENCE POR UNA LETRA MINÚSCULA O MAYÚSCULA (COMO MÍNIMO 1), PUEDE CONTINUAR O NO (0, n) CON ";" JUNTO A OTRA LETRA MÍNUSCULA O MAYÚSCULA (COMO MÍNIMO 1). 
                    if (!regex.IsMatch(txtColoresR.Text))
                        return false;
                    regex = new Regex(@"^\d{1,5}\,\s\d{1,5}$"); // QUE COMIENCE POR UN DÍGITO (ENTRE 1 Y 5), CONTINUA CON ", ", FINALIZA CON UN DÍGITO (ENTRE 1 Y 5). 
                    if (!regex.IsMatch(txtDimensionesR.Text))
                        return false;
                    regex = new Regex(@"^\d+DPI$"); // QUE COMIENCE POR UN DÍGITO (COMO MÍNIMO 1) Y FINALICE CON "DPI". 
                    if (!regex.IsMatch(txtDPI.Text))
                        return false;
                    regex = new Regex(@"^.+$"); // QUE COMIENCE POR CUALQUIER CARÁCTER (COMO MÍNIMO 1) Y QUE FINALICE POR CUALQUIER CARÁCTER.
                    if (!regex.IsMatch(txtConect.Text) || !regex.IsMatch(txtSensor.Text))
                        return false;
                    break;

                case "teclado":
                    regex = new Regex(@"^[a-zA-Z]+(\;[a-zA-Z]+)*$"); // QUE COMIENCE POR UNA LETRA MINÚSCULA O MAYÚSCULA (COMO MÍNIMO 1), PUEDE CONTINUAR O NO (0, n) CON ";" JUNTO A OTRA LETRA MÍNUSCULA O MAYÚSCULA (COMO MÍNIMO 1). 
                    if (!regex.IsMatch(txtColoresT.Text))
                        return false;
                    regex = new Regex(@"^\d{1,5}\,\s\d{1,5}$"); // QUE COMIENCE POR UN DÍGITO (ENTRE 1 Y 5), CONTINUA CON ", ", FINALIZA CON UN DÍGITO (ENTRE 1 Y 5). 
                    if (!regex.IsMatch(txtDimensionesT.Text))
                        return false;
                    regex = new Regex(@"^.+$"); // QUE COMIENCE POR CUALQUIER CARÁCTER (COMO MÍNIMO 1) Y QUE FINALICE POR CUALQUIER CARÁCTER.
                    if (!regex.IsMatch(txtTipoTeclado.Text) || !regex.IsMatch(txtTipoSwitch.Text))
                        return false;
                    break;
            }
            return true;
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

        private void txtSupervisor_Enter(object sender, EventArgs e)
        {
            if (txtSupervisor.Text == "SI o NO")
            {
                txtSupervisor.Text = "";
                txtSupervisor.ForeColor = Color.Black;
            }
        }

        private void txtSupervisor_Leave(object sender, EventArgs e)
        {
            if (txtSupervisor.Text == "")
            {
                txtSupervisor.Text = "SI o NO";
                txtSupervisor.ForeColor = Color.LightGray;
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

        private void txtNomProd_Enter(object sender, EventArgs e)
        {
            if (txtNomProd.Text == "Nombre de Producto")
            {
                txtNomProd.Text = "";
                txtNomProd.ForeColor = Color.Black;
            }
        }

        private void txtNomProd_Leave(object sender, EventArgs e)
        {
            if (txtNomProd.Text == "")
            {
                txtNomProd.Text = "Nombre de Producto";
                txtNomProd.ForeColor = Color.LightGray;
            }
        }

        private void txtMarca_Enter(object sender, EventArgs e)
        {
            if (txtMarca.Text == "Marca")
            {
                txtMarca.Text = "";
                txtMarca.ForeColor = Color.Black;
            }
        }

        private void txtMarca_Leave(object sender, EventArgs e)
        {
            if (txtMarca.Text == "")
            {
                txtMarca.Text = "Marca";
                txtMarca.ForeColor = Color.LightGray;
            }
        }

        private void txtPrecio_Enter(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "0{1,}.00")
            {
                txtPrecio.Text = "";
                txtPrecio.ForeColor = Color.Black;
            }
        }

        private void txtPrecio_Leave(object sender, EventArgs e)
        {
            if (txtPrecio.Text == "")
            {
                txtPrecio.Text = "0{1,}.00";
                txtPrecio.ForeColor = Color.LightGray;
            }
        }

        private void txtUnidades_Enter(object sender, EventArgs e)
        {
            if (txtUnidades.Text == "Cantidad")
            {
                txtUnidades.Text = "";
                txtUnidades.ForeColor = Color.Black;
            }
        }

        private void txtUnidades_Leave(object sender, EventArgs e)
        {
            if (txtUnidades.Text == "")
            {
                txtUnidades.Text = "Cantidad";
                txtUnidades.ForeColor = Color.LightGray;
            }
        }

        private void txtLanzamiento_Enter(object sender, EventArgs e)
        {
            if (txtLanzamiento.Text == "DD/MM/YYYY")
            {
                txtLanzamiento.Text = "";
                txtLanzamiento.ForeColor = Color.Black;
            }
        }

        private void txtLanzamiento_Leave(object sender, EventArgs e)
        {
            if (txtLanzamiento.Text == "")
            {
                txtLanzamiento.Text = "DD/MM/YYYY";
                txtLanzamiento.ForeColor = Color.LightGray;
            }
        }

        private void txtDPI_Enter(object sender, EventArgs e)
        {
            if (txtDPI.Text == "0DPI")
            {
                txtDPI.Text = "";
                txtDPI.ForeColor = Color.Black;
            }
        }

        private void txtDPI_Leave(object sender, EventArgs e)
        {
            if (txtDPI.Text == "")
            {
                txtDPI.Text = "0DPI";
                txtDPI.ForeColor = Color.LightGray;
            }
        }

        private void txtSensor_Enter(object sender, EventArgs e)
        {
            if (txtSensor.Text == "Tipo de Sensor")
            {
                txtSensor.Text = "";
                txtSensor.ForeColor = Color.Black;
            }
        }

        private void txtSensor_Leave(object sender, EventArgs e)
        {
            if (txtSensor.Text == "")
            {
                txtSensor.Text = "Tipo de Sensor";
                txtSensor.ForeColor = Color.LightGray;
            }
        }

        private void txtConect_Enter(object sender, EventArgs e)
        {
            if (txtConect.Text == "Conectividad")
            {
                txtConect.Text = "";
                txtConect.ForeColor = Color.Black;
            }
        }

        private void txtConect_Leave(object sender, EventArgs e)
        {
            if (txtConect.Text == "")
            {
                txtConect.Text = "Conectividad";
                txtConect.ForeColor = Color.LightGray;
            }
        }

        private void txtDimensionesR_Enter(object sender, EventArgs e)
        {
            if (txtDimensionesR.Text == "0{1,5}, 0{1,5} (Largo, Ancho)")
            {
                txtDimensionesR.Text = "";
                txtDimensionesR.ForeColor = Color.Black;
            }
        }

        private void txtDimensionesR_Leave(object sender, EventArgs e)
        {
            if (txtDimensionesR.Text == "")
            {
                txtDimensionesR.Text = "0{1,5}, 0{1,5} (Largo, Ancho)";
                txtDimensionesR.ForeColor = Color.LightGray;
            }
        }

        private void txtColoresR_Enter(object sender, EventArgs e)
        {
            if (txtColoresR.Text == "Color1 o Color1;Color2;Color3;...")
            {
                txtColoresR.Text = "";
                txtColoresR.ForeColor = Color.Black;
            }
        }

        private void txtColoresR_Leave(object sender, EventArgs e)
        {
            if (txtColoresR.Text == "")
            {
                txtColoresR.Text = "Color1 o Color1;Color2;Color3;...";
                txtColoresR.ForeColor = Color.LightGray;
            }
        }

        private void txtTipoTeclado_Enter(object sender, EventArgs e)
        {
            if (txtTipoTeclado.Text == "Tipo de Teclado")
            {
                txtTipoTeclado.Text = "";
                txtTipoTeclado.ForeColor = Color.Black;
            }
        }

        private void txtTipoTeclado_Leave(object sender, EventArgs e)
        {
            if (txtTipoTeclado.Text == "")
            {
                txtTipoTeclado.Text = "Tipo de Teclado";
                txtTipoTeclado.ForeColor = Color.LightGray;
            }
        }

        private void txtTipoSwitch_Enter(object sender, EventArgs e)
        {
            if (txtTipoSwitch.Text == "Tipo de Switch")
            {
                txtTipoSwitch.Text = "";
                txtTipoSwitch.ForeColor = Color.Black;
            }
        }

        private void txtTipoSwitch_Leave(object sender, EventArgs e)
        {
            if (txtTipoSwitch.Text == "")
            {
                txtTipoSwitch.Text = "Tipo de Switch";
                txtTipoSwitch.ForeColor = Color.LightGray;
            }
        }

        private void txtDimensionesT_Enter(object sender, EventArgs e)
        {
            if (txtDimensionesT.Text == "0{1,5}, 0{1,5} (Largo, Ancho)")
            {
                txtDimensionesT.Text = "";
                txtDimensionesT.ForeColor = Color.Black;
            }
        }

        private void txtDimensionesT_Leave(object sender, EventArgs e)
        {
            if (txtDimensionesT.Text == "")
            {
                txtDimensionesT.Text = "0{1,5}, 0{1,5} (Largo, Ancho)";
                txtDimensionesT.ForeColor = Color.LightGray;
            }
        }

        private void txtColoresT_Enter(object sender, EventArgs e)
        {
            if (txtColoresT.Text == "Color1 o Color1;Color2;Color3;...")
            {
                txtColoresT.Text = "";
                txtColoresT.ForeColor = Color.Black;
            }
        }

        private void txtColoresT_Leave(object sender, EventArgs e)
        {
            if (txtColoresT.Text == "")
            {
                txtColoresT.Text = "Color1 o Color1;Color2;Color3;...";
                txtColoresT.ForeColor = Color.LightGray;
            }
        }

        private void txtAlmacenamiento_Enter(object sender, EventArgs e)
        {
            if (txtAlmacenamiento.Text == "0{1,} (128 o 256 o 512 o 1024)")
            {
                txtAlmacenamiento.Text = "";
                txtAlmacenamiento.ForeColor = Color.Black;
            }
        }

        private void txtAlmacenamiento_Leave(object sender, EventArgs e)
        {
            if (txtAlmacenamiento.Text == "")
            {
                txtAlmacenamiento.Text = "0{1,} (128 o 256 o 512 o 1024)";
                txtAlmacenamiento.ForeColor = Color.LightGray;
            }
        }

        private void txtColoresC_Enter(object sender, EventArgs e)
        {
            if (txtColoresC.Text == "Color1 o Color1;Color2;Color3;...")
            {
                txtColoresC.Text = "";
                txtColoresC.ForeColor = Color.Black;
            }
        }

        private void txtColoresC_Leave(object sender, EventArgs e)
        {
            if (txtColoresC.Text == "")
            {
                txtColoresC.Text = "Color1 o Color1;Color2;Color3;...";
                txtColoresC.ForeColor = Color.LightGray;
            }
        }

        private void txtConsola_Enter(object sender, EventArgs e)
        {
            if (txtConsola.Text == "Consola")
            {
                txtConsola.Text = "";
                txtConsola.ForeColor = Color.Black;
            }
        }

        private void txtConsola_Leave(object sender, EventArgs e)
        {
            if (txtConsola.Text == "")
            {
                txtConsola.Text = "Consola";
                txtConsola.ForeColor = Color.LightGray;
            }
        }

        private void txtGenero_Enter(object sender, EventArgs e)
        {
            if (txtGenero.Text == "Género de Videojuego")
            {
                txtGenero.Text = "";
                txtGenero.ForeColor = Color.Black;
            }
        }

        private void txtGenero_Leave(object sender, EventArgs e)
        {
            if (txtGenero.Text == "")
            {
                txtGenero.Text = "Género de Videojuego";
                txtGenero.ForeColor = Color.LightGray;
            }
        }

        private void txtDesarrolladora_Enter(object sender, EventArgs e)
        {
            if (txtDesarrolladora.Text == "Desarrolladora")
            {
                txtDesarrolladora.Text = "";
                txtDesarrolladora.ForeColor = Color.Black;
            }
        }

        private void txtDesarrolladora_Leave(object sender, EventArgs e)
        {
            if (txtDesarrolladora.Text == "")
            {
                txtDesarrolladora.Text = "Desarrolladora";
                txtDesarrolladora.ForeColor = Color.LightGray;
            }
        }

        private void txtTamanyo_Enter(object sender, EventArgs e)
        {
            if (txtTamanyo.Text == "0{1,}.00")
            {
                txtTamanyo.Text = "";
                txtTamanyo.ForeColor = Color.Black;
            }
        }

        private void txtTamanyo_Leave(object sender, EventArgs e)
        {
            if (txtTamanyo.Text == "")
            {
                txtTamanyo.Text = "0{1,}.00";
                txtTamanyo.ForeColor = Color.LightGray;
            }
        }
        #endregion
    }
}
