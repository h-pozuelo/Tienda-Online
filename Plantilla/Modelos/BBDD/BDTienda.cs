using Plantilla.Modelos.Exceptions;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Plantilla.Modelos.BBDD
{
    public class BDTienda : Connector
    {
        public BDTienda()
            : base()
        {
        }

        //Otros
        public int NewID(string op)
        {
            if (base.Abrir())
            {
                String campo;

                if (op != "trans")
                {
                    campo = op == "emple" || op == "cliente" ? "idusuario" : "idprod";
                }
                else
                {
                    campo = "idtrans";
                }

                string cadena = "SELECT TOP 1 " + campo + " FROM ";
                switch (op)
                {
                    case "emple":
                        cadena += "Personas WHERE supervisor IS NOT NULL ORDER BY " + campo + " DESC";
                        break;

                    case "cliente":
                        cadena += "Personas WHERE supervisor IS NULL ORDER BY " + campo + " DESC";
                        break;

                    case "teclado":
                        cadena += "Teclados ORDER BY " + campo + " DESC";
                        break;

                    case "videojuego":
                        cadena += "Videojuegos ORDER BY " + campo + " DESC";
                        break;

                    case "consola":
                        cadena += "Consolas ORDER BY " + campo + " DESC";
                        break;

                    case "raton":
                        cadena += "Ratones ORDER BY " + campo + " DESC";
                        break;

                    case "trans":
                        cadena += "Transacciones ORDER BY " + campo + " DESC";
                        break;
                }
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    String identificador = Convert.ToString(comando.ExecuteScalar());
                    if (identificador == "")
                    {
                        identificador = "0";
                    }
                    else
                    {
                        identificador = identificador.Substring(0, identificador.Length - 2);
                        foreach (char c in identificador)
                        {
                            if (c == '0')
                            {
                                identificador = identificador.Substring(1, identificador.Length - 1);
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    int m = Convert.ToInt32(identificador);
                    this.Cerrar();
                    return m + 1;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        //Personas
        public int AddPersona(Persona p)
        {
            if (base.Abrir())
            {
                string cadena = "INSERT INTO Personas VALUES('" + p.IdUsuario + "','" + p.NombreApellidos +
                    "','" + p.Direccion.ToString() + "','" + p.Dni + "',";
                if (p is Empleado empleado)
                {
                    cadena += (empleado.Supervisor == true ? 1 : 0) + ",NULL)";
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        int f = comando.ExecuteNonQuery();
                        this.Cerrar();
                        return f;
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                {
                    cadena += "NULL,'" + ((Cliente)(p)).Tarjeta.NumTarjeta + "')";
                    try
                    {

                        this.comando = new SqlCommand(cadena, this.conexion);
                        int f = comando.ExecuteNonQuery();

                        cadena = "INSERT INTO Tarjetas VALUES('" + ((Cliente)(p)).Tarjeta.NumTarjeta
                            + "', " + ((Cliente)(p)).Tarjeta.Ccv
                            + ", '" + ((Cliente)(p)).Tarjeta.FechaCaducidad
                            + "', '" + p.NombreApellidos + "')";
                        this.comando = new SqlCommand(cadena, this.conexion);
                        comando.ExecuteNonQuery();

                        this.Cerrar();
                        return f;

                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public bool BuscarPersonaNomApe(string nomApe)
        {
            if (this.Abrir())
            {
                string cadena = "SELECT * FROM Personas WHERE nomape = '" + nomApe + "'";
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    if (registros.Read())
                    {
                        this.Cerrar();
                        return true;
                    }
                    this.Cerrar();
                    return false;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public bool BuscarPersonaDNI(string DNI)
        {
            if (this.Abrir())
            {
                string cadena = "SELECT * FROM Personas WHERE dni = '" + DNI + "'";
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    if (registros.Read())
                    {
                        this.Cerrar();
                        return true;
                    }
                    this.Cerrar();
                    return false;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public bool BuscarTarjeta(string numTarjeta)
        {
            if (this.Abrir())
            {
                string cadena = "SELECT * FROM Tarjetas WHERE numtarjeta = '" + numTarjeta + "'";
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    if (registros.Read())
                    {
                        this.Cerrar();
                        return true;
                    }
                    this.Cerrar();
                    return false;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public int ModificarPersona(string id, string var, string valor)
        {

            List<String> tarjeta = new List<string>();
            int f;

            if (id.Substring(id.Length - 2).ToUpper() == "CL" && var == "nomape")
            {

                String nomape;

                if (base.Abrir()) // OBTENEMOS EL NOMBRE ACTUAL DEL CLIENTE A PARTIR DE SU IDENTIFICADOR.
                {
                    string cadena = "SELECT nomape FROM Personas WHERE idusuario = '" + id + "'";
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        nomape = Convert.ToString(comando.ExecuteScalar());
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

                if (base.Abrir()) // VOLCAMOS LOS DATOS DE LA TARJETA ANTES DE REALIZAR NINGÚN CAMBIO.
                {
                    string cadena = "SELECT * FROM Tarjetas WHERE nomtitular = '" + nomape + "'";
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        this.registros = comando.ExecuteReader();
                        if (registros.Read())
                        {
                            tarjeta.Add(Convert.ToString(registros["numtarjeta"]));
                            tarjeta.Add(Convert.ToString(registros["ccv"]));
                            tarjeta.Add(Convert.ToString(registros["fechacaducidad"]));
                            tarjeta.Add(valor);
                        }
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

                if (base.Abrir()) // BORRAMOS DE LA TABLA TARJETA LA TARJETA DE UN CLIENTE.
                {
                    string cadena = "DELETE FROM Tarjetas WHERE nomtitular = '" + nomape + "'";
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        comando.ExecuteNonQuery();
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

            }

            if (base.Abrir())
            {
                string cadena;
                switch (var)
                {
                    case "supervisor":
                        int superv = (valor == "SI") ? 1 : 0;
                        cadena = "UPDATE Personas SET " + var + " = " + superv + " " +
                            "WHERE idusuario = '" + id + "'";
                        break;

                    default:
                        cadena = "UPDATE Personas SET " + var + " = '" + valor + "' " +
                            "WHERE idusuario = '" + id + "'";
                        break;
                }
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    f = comando.ExecuteNonQuery();
                    this.Cerrar();
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");

            if (id.Substring(id.Length - 2).ToUpper() == "CL" && var == "nomape")
            {

                if (base.Abrir()) // POR ÚLTIMO CREAMOS LA NUEVA TARJETA CON EL NOMBRE DE TITULAR MODIFICADO PARA QUE YA NO DE PROBLEMAS CON LA CLAVE FORÁNEA.
                {
                    try
                    {
                        String cadena = "INSERT INTO Tarjetas VALUES('" + tarjeta[0]
                            + "', " + tarjeta[1]
                            + ", '" + tarjeta[2]
                            + "', '" + tarjeta[3] + "')";
                        this.comando = new SqlCommand(cadena, this.conexion);
                        comando.ExecuteNonQuery();

                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

            }

            return f;

        }

        public List<Cliente> ListClientes()
        {
            List<Cliente> list = new List<Cliente>();
            List<String> tarjetas = new List<String>();
            string cadena = "SELECT * FROM Personas WHERE SUBSTRING(idusuario,LEN(idusuario)-1,2) = 'CL'";
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    while (registros.Read())
                    {
                        string[] separator = { ", " };
                        string[] split = Convert.ToString(registros["direccion"]).Split(separator, StringSplitOptions.None);
                        Direccion direc = new Direccion(split[0], split[1], split[2], split[3], split[4]);
                        Tarjeta t = new Tarjeta();
                        list.Add(new Cliente((Convert.ToString(registros["idusuario"])), Convert.ToString(registros["nomape"]), direc, Convert.ToString(registros["dni"]), t));
                        tarjetas.Add(Convert.ToString(registros["numtarjeta"]));
                    }
                    this.Cerrar();
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");

            int count = 0;

            foreach (Cliente cliente in list)
            {
                cadena = "SELECT * FROM Tarjetas WHERE numtarjeta = '" + tarjetas[count] + "'";
                if (this.Abrir())
                {
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        this.registros = comando.ExecuteReader();
                        if (registros.Read())
                        {
                            cliente.Tarjeta = new Tarjeta(Convert.ToString(registros["numtarjeta"]), Convert.ToString(registros["ccv"]), Convert.ToString(registros["fechacaducidad"]), Convert.ToString(registros["nomtitular"]));
                        }
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

                count++;
            }
            return list;
        }

        public List<Empleado> ListEmples()
        {
            List<Empleado> list = new List<Empleado>();
            string cadena = "SELECT * FROM Personas WHERE SUBSTRING(idusuario,LEN(idusuario)-1,2) = 'EM'";
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    while (registros.Read())
                    {
                        string[] separator = { ", " };
                        string[] split = Convert.ToString(registros["direccion"]).Split(separator, StringSplitOptions.None);
                        Direccion direc = new Direccion(split[0], split[1], split[2], split[3], split[4]);
                        list.Add(new Empleado((Convert.ToString(registros["idusuario"])),
                        Convert.ToString(registros["nomape"]), direc, Convert.ToString(registros["dni"]),
                        (Convert.ToInt32(registros["supervisor"]) == 1)));
                    }
                    this.Cerrar();
                    return list;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public Cliente BuscarCliente(string variable, string valor)
        {
            Cliente c;
            String tarjeta = "";
            string cadena = "SELECT * FROM Personas WHERE " + variable + " = '" + valor + "'" + " AND SUBSTRING(idusuario,LEN(idusuario)-1,2) = 'CL'";
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    if (registros.Read())
                    {
                        string[] separator = { ", " };
                        string[] split = Convert.ToString(registros["direccion"]).Split(separator, StringSplitOptions.None);
                        Direccion direc = new Direccion(split[0], split[1], split[2], split[3], split[4]);
                        Tarjeta t = new Tarjeta();

                        tarjeta = Convert.ToString(registros["numtarjeta"]);

                        c = new Cliente((Convert.ToString(registros["idusuario"])), Convert.ToString(registros["nomape"]), direc, Convert.ToString(registros["dni"]), t);
                        this.Cerrar();
                    }
                    else
                    {
                        this.Cerrar();
                        throw new ConnectionException("Cliente no encontrado");
                    }
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");

            cadena = "SELECT * FROM Tarjetas WHERE numtarjeta = '" + tarjeta + "'";
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    if (registros.Read())
                    {
                        c.Tarjeta = new Tarjeta(Convert.ToString(registros["numtarjeta"]), Convert.ToString(registros["ccv"]), Convert.ToString(registros["fechacaducidad"]), Convert.ToString(registros["nomtitular"]));
                    }
                    this.Cerrar();
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");

            return c;
        }

        public Empleado BuscarEmple(string variable, string valor)
        {
            string cadena = "SELECT * FROM Personas WHERE " + variable + " = '" + valor + "'" + " AND SUBSTRING(idusuario,LEN(idusuario)-1,2) = 'EM'";
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    if (registros.Read())
                    {
                        string[] separator = { ", " };
                        string[] split = Convert.ToString(registros["direccion"]).Split(separator, StringSplitOptions.None);
                        Direccion direc = new Direccion(split[0], split[1], split[2], split[3], split[4]);
                        Empleado e = new Empleado((Convert.ToString(registros["idusuario"])),
                        Convert.ToString(registros["nomape"]), direc, Convert.ToString(registros["dni"]),
                        (Convert.ToInt32(registros["supervisor"]) == 1));
                        this.Cerrar();
                        return e;
                    }
                    else
                    {
                        this.Cerrar();
                        throw new ConnectionException("Empleado no encontrado");
                    }
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public int DeletePersona(string id)
        {

            if (id.Substring(id.Length - 2).ToUpper() == "CL")
            {

                List<String> idTransacciones = new List<String>();

                if (base.Abrir()) // RECOGEMOS TODAS LAS TRANSACCIONES DE UN MISMO CLIENTE Y VOLCAMOS SUS IDENTIFICADORES EN UNA LISTA.
                {
                    string cadena = "SELECT * FROM Transacciones WHERE idcliente = '" + id + "'";
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        this.registros = comando.ExecuteReader();
                        while (registros.Read())
                        {
                            idTransacciones.Add(Convert.ToString(registros["idtrans"]));
                        }
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

                foreach (String idtrans in idTransacciones) // POR CADA IDENTIFICADOR DE TRANSACCIÓN QUE SE ENCUENTRE EN LA LISTA BORRAMOS TODAS SUS COINCIDENCIAS DE LA TABLA TRANSPROD.
                {

                    if (base.Abrir())
                    {
                        string cadena = "DELETE FROM TransProd WHERE idtrans = '" + idtrans + "'";
                        try
                        {
                            this.comando = new SqlCommand(cadena, this.conexion);
                            int f = comando.ExecuteNonQuery();
                            this.Cerrar();
                        }
                        catch (SqlException err)
                        {
                            this.Cerrar();
                            throw err;
                        }
                    }
                    else
                        throw new ConnectionException("Problemas técnicos");

                }

                if (base.Abrir()) // BORRAMOS DE LA TABLA TRANSACCIONES TODAS LAS TRANSACCIONES DE UN MISMO CLIENTE.
                {
                    string cadena = "DELETE FROM Transacciones WHERE idcliente = '" + id + "'";
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        int f = comando.ExecuteNonQuery();
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

                String nomtitular;

                if (base.Abrir()) // OBTENEMOS EL NOMBRE DEL TITULAR DE LA TARJETA PARA PODER ELIMINAR SU TARJETA.
                {
                    string cadena = "SELECT nomape FROM Personas WHERE idusuario = '" + id + "'";
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        nomtitular = Convert.ToString(comando.ExecuteScalar());
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

                if (base.Abrir()) // BORRAMOS DE LA TABLA TARJETA LA TARJETA DE UN CLIENTE.
                {
                    string cadena = "DELETE FROM Tarjetas WHERE nomtitular = '" + nomtitular + "'";
                    try
                    {
                        this.comando = new SqlCommand(cadena, this.conexion);
                        int f = comando.ExecuteNonQuery();
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

            }

            if (base.Abrir()) // POR ÚLTIMO BORRAMOS DE LA TABLA PERSONA A LA PERSONA CORRESPONDIENTE. 
            {
                string cadena = "DELETE FROM Personas WHERE idusuario = '" + id + "'";
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    int f = comando.ExecuteNonQuery();
                    this.Cerrar();
                    return f;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        //Productos
        public int AddProducto(Producto p)
        {
            if (base.Abrir())
            {
                string cadena = "INSERT INTO Productos VALUES('" + p.IdProducto + "','"
                    + p.Marca + "','" + p.Nombre + "'," + Convert.ToString(p.Precio).Replace(',', '.') + "," + p.UnidadesDisponibles
                    + ",'" + p.FechaLanzamiento.ToString(@"yyyy-MM-dd hh:mm:ss") + "')";
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    comando.ExecuteNonQuery();
                    if (p is Videojuego videojuego)
                    {
                        cadena = "INSERT INTO Videojuegos VALUES('" + p.IdProducto + "','"
                        + videojuego.Consola + "','" + videojuego.Genero + "','"
                        + videojuego.Desarrolladora + "'," + Convert.ToString(videojuego.Tamanyo).Replace(',', '.') + ")";
                    }
                    else if (p is Raton raton)
                    {
                        cadena = "INSERT INTO Ratones VALUES('" + p.IdProducto + "','"
                        + raton.Dimensiones + "','" + String.Join(";", raton.Color) + "','"
                        + raton.Dpi + "','" + raton.TipoSensor + "','"
                        + raton.Conectividad + "')";
                    }
                    else if (p is Teclado teclado)
                    {
                        cadena = "INSERT INTO Teclados VALUES('" + p.IdProducto + "','"
                        + teclado.Dimensiones + "','" + String.Join(";", teclado.Color) + "','"
                        + teclado.Tipo + "','" + teclado.TipoSwitch + "')";
                    }
                    else if (p is Consola consola)
                    {
                        cadena = "INSERT INTO Consolas VALUES('" + p.IdProducto + "','"
                        + String.Join(";", consola.Color) + "'," + consola.Almacenamiento + ")";
                    }
                    this.comando = new SqlCommand(cadena, this.conexion);
                    int f = comando.ExecuteNonQuery();
                    this.Cerrar();
                    return f;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public int ModificarProducto(string id, string var, string valor)
        {
            if (base.Abrir())
            {
                string cadena;
                string[] itemspr = new string[] { "marca", "nombre", "precio", "unidades", "fechalanzamiento" };
                if (itemspr.Contains(var))
                {
                    switch (var)
                    {
                        case "precio":
                        case "unidades":
                            cadena = "UPDATE Productos SET " + var + " = " + valor + " WHERE idprod = '" + id + "'";
                            break;

                        case "fechalanzamiento":
                            string[] split = valor.Split('/');
                            DateTime flanz = new DateTime(Convert.ToInt32(split[2]), Convert.ToInt32(split[1]),
                                Convert.ToInt32(split[0]));
                            cadena = $"UPDATE Productos SET {var} = '{flanz.ToString(@"yyyy-MM-dd hh:mm:ss")}' WHERE idprod = '{id}'";
                            break;

                        default:
                            cadena = "UPDATE Productos SET " + var + " = '" + valor + "' WHERE idprod = '" + id + "'";
                            break;
                    }
                }
                else
                {
                    string tabla = "";
                    switch (id.Substring(id.Length - 2, 2))
                    {
                        case "CO":
                            tabla = "Consolas";
                            break;

                        case "TE":
                            tabla = "Teclados";
                            break;

                        case "VI":
                            tabla = "Videojuegos";
                            break;

                        case "RA":
                            tabla = "Ratones";
                            break;
                    }
                    switch (var)
                    {
                        case "almacenamiento":
                        case "tamanyo":
                            cadena = "UPDATE " + tabla + " SET " + var + " = " + valor + " WHERE idprod = '" + id + "'";
                            break;

                        case "dimensiones":
                            string[] split = valor.Split(',');
                            cadena = "UPDATE " + tabla + " SET " + var + " = '" + split[0].Trim() + "x" + split[1].Trim() + "' WHERE idprod = '" + id + "'";
                            break;

                        default:
                            cadena = "UPDATE " + tabla + " SET " + var + " = '" + valor + "' WHERE idprod = '" + id + "'";
                            break;
                    }
                }
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    int f = comando.ExecuteNonQuery();
                    this.Cerrar();
                    return f;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public List<Producto> ListProductos()
        {
            List<Producto> list = new List<Producto>();
            string cadena = "SELECT * FROM Productos";
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    while (registros.Read())
                    {
                        list.Add(new Producto(Convert.ToString(registros["idprod"]),
                            Convert.ToString(registros["marca"]), Convert.ToString(registros["nombre"]),
                            Convert.ToDouble(registros["precio"]), Convert.ToInt32(registros["unidades"]),
                            Convert.ToDateTime(registros["fechalanzamiento"])));
                    }
                    this.Cerrar();
                    return list;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public List<Producto> ListCategoria(string categoria)
        {
            List<Producto> list = new List<Producto>();
            string cadena = "SELECT * FROM Productos WHERE SUBSTRING(idprod,LEN(idprod)-1,2) = '" + categoria + "'";
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    while (registros.Read())
                    {
                        list.Add(new Producto(Convert.ToString(registros["idprod"]),
                            Convert.ToString(registros["marca"]), Convert.ToString(registros["nombre"]),
                            Convert.ToDouble(registros["precio"]), Convert.ToInt32(registros["unidades"]),
                            Convert.ToDateTime(registros["fechalanzamiento"])));
                    }
                    this.Cerrar();
                    return list;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public Producto BuscarProducto(string tipo, string valor)
        {
            string cadena = "SELECT a.idprod AS idprod, a.marca AS marca, a.nombre AS nombre, " +
                "a.precio AS precio, a.unidades AS unidades, a.fechalanzamiento AS flanz, ";
            switch (tipo)
            {
                case "raton":
                    cadena += "b.dimensiones AS dim, b.colores AS colores, b.dpi AS dpi, b.tiposensor AS sensor, " +
                        "b.conectividad AS conectividad FROM Productos a, Ratones b ";
                    break;

                case "consola":
                    cadena += "b.colores AS colores, b.almacenamiento AS almac " +
                        "FROM Productos a, Consolas b ";
                    break;

                case "videojuego":
                    cadena += "b.consola AS consola, b.genero AS genero, b.desarrolladora AS desarr, b.tamanyo AS tam " +
                        "FROM Productos a, Videojuegos b ";
                    break;

                case "teclado":
                    cadena += "b.dimensiones AS dim, b.colores AS colores, b.tipo AS tipo, b.tiposwitch AS switch " +
                        "FROM Productos a, Teclados b ";
                    break;
            }
            cadena += "WHERE a.idprod = '" + valor + "' AND a.idprod = b.idprod";
            if (this.Abrir())
            {
                List<String> colores;
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    if (registros.Read())
                    {
                        switch (tipo)
                        {
                            case "raton":
                                colores = Convert.ToString(registros["colores"]).Split(';').ToList();
                                Raton r = new Raton(Convert.ToString(registros["idprod"]),
                                    Convert.ToString(registros["marca"]), Convert.ToString(registros["nombre"]),
                                    Convert.ToDouble(registros["precio"]), Convert.ToInt32(registros["unidades"]),
                                    Convert.ToDateTime(registros["flanz"]),
                                    Convert.ToString(registros["dim"]), colores,
                                    Convert.ToString(registros["dpi"]), Convert.ToString(registros["sensor"]),
                                    Convert.ToString(registros["conectividad"]));
                                this.Cerrar();
                                return r;

                            case "consola":
                                colores = Convert.ToString(registros["colores"]).Split(';').ToList();
                                Consola c = new Consola(Convert.ToString(registros["idprod"]),
                                    Convert.ToString(registros["marca"]), Convert.ToString(registros["nombre"]),
                                    Convert.ToDouble(registros["precio"]), Convert.ToInt32(registros["unidades"]),
                                    Convert.ToDateTime(registros["flanz"]),
                                    colores, Convert.ToInt32(registros["almac"]));
                                this.Cerrar();
                                return c;

                            case "videojuego":
                                Videojuego v = new Videojuego(Convert.ToString(registros["idprod"]),
                                    Convert.ToString(registros["marca"]), Convert.ToString(registros["nombre"]),
                                    Convert.ToDouble(registros["precio"]), Convert.ToInt32(registros["unidades"]),
                                    Convert.ToDateTime(registros["flanz"]),
                                    Convert.ToString(registros["consola"]),
                                    Convert.ToString(registros["genero"]),
                                    Convert.ToString(registros["desarr"]),
                                    Convert.ToDouble(registros["tam"]));
                                this.Cerrar();
                                return v;

                            case "teclado":
                                colores = Convert.ToString(registros["colores"]).Split(';').ToList();
                                Teclado t = new Teclado(Convert.ToString(registros["idprod"]),
                                    Convert.ToString(registros["marca"]), Convert.ToString(registros["nombre"]),
                                    Convert.ToDouble(registros["precio"]), Convert.ToInt32(registros["unidades"]),
                                    Convert.ToDateTime(registros["flanz"]),
                                    Convert.ToString(registros["dim"]), colores,
                                    Convert.ToString(registros["tipo"]),
                                    Convert.ToString(registros["switch"]));
                                this.Cerrar();
                                return t;

                            default:
                                throw new ConnectionException("Tipo de producto inválido");
                        }
                    }
                    else
                    {
                        this.Cerrar();
                        throw new ConnectionException("Producto no encontrado");
                    }
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public int DeleteProducto(string id)
        {

            if (base.Abrir())
            {
                string cadena = "DELETE FROM TransProd WHERE idprod = '" + id + "'";
                try
                {

                    this.comando = new SqlCommand(cadena, this.conexion);
                    comando.ExecuteNonQuery();

                    String tipo = id.Substring(id.Length - 2).ToUpper();

                    switch (tipo)
                    {

                        case "CO":
                            cadena = "DELETE FROM Consolas WHERE idprod = '" + id + "'";
                            break;

                        case "RA":
                            cadena = "DELETE FROM Ratones WHERE idprod = '" + id + "'";
                            break;

                        case "TE":
                            cadena = "DELETE FROM Teclados WHERE idprod = '" + id + "'";
                            break;

                        case "VI":
                            cadena = "DELETE FROM Videojuegos WHERE idprod = '" + id + "'";
                            break;

                    }

                    this.comando = new SqlCommand(cadena, this.conexion);
                    comando.ExecuteNonQuery();

                    cadena = "DELETE FROM Productos WHERE idprod = '" + id + "'";

                    this.comando = new SqlCommand(cadena, this.conexion);
                    int f = comando.ExecuteNonQuery();

                    this.Cerrar();
                    return f;

                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");

        }

        public double GetPrecioProducto(string id)
        {
            if (base.Abrir())
            {
                string cadena = "SELECT precio FROM Productos WHERE idprod = '" + id + "'";
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    double precio = Convert.ToDouble(comando.ExecuteScalar());
                    this.Cerrar();
                    return precio;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        public int GetUnidadesProducto(string id)
        {
            if (base.Abrir())
            {
                string cadena = "SELECT unidades FROM Productos WHERE idprod = '" + id + "'";
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    int unidades = Convert.ToInt32(comando.ExecuteScalar());
                    this.Cerrar();
                    return unidades;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }

        //Transacciones
        public List<String> ListTransaccionesUsu(string id)
        {
            List<String> list = new List<String>();
            string cadena = "SELECT * FROM Transacciones WHERE idcliente = '" + id + "'";
            List<String> ids = new List<String>();
            string info;
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    while (registros.Read())
                    {
                        ids.Add(Convert.ToString(registros["idtrans"]));
                    }
                    this.Cerrar();
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
            foreach (String idcli in ids)
            {
                if (this.Abrir())
                {
                    try
                    {
                        info = Convert.ToString(idcli) + " (";
                        cadena = "SELECT p.nombre AS nombre, t.num AS num FROM Productos p, TransProd t WHERE t.idtrans = '"
                            + idcli + "' and p.idprod = t.idprod";
                        this.comando = new SqlCommand(cadena, this.conexion);
                        this.registros = comando.ExecuteReader();
                        while (registros.Read())
                        {
                            info += Convert.ToString(registros["nombre"]) + ": " +
                                Convert.ToString(registros["num"]) + "u,";
                        }
                        info += ")";
                        list.Add(info);
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");
            }
            return list;
        }

        public List<Transaccion> ListTransaccion()
        {
            string cadena = "SELECT * FROM Transacciones";
            List<Transaccion> ids = new List<Transaccion>();
            List<String> productos = new List<String>();
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    while (registros.Read())
                    {
                        ids.Add(new Transaccion(Convert.ToString(registros["idtrans"]),
                                Convert.ToString(registros["idcliente"]),
                                new String[999], Convert.ToDateTime(registros["fechatrans"])));
                    }
                    this.Cerrar();
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
            foreach (Transaccion trans in ids)
            {
                if (this.Abrir())
                {
                    try
                    {
                        productos.Clear();
                        cadena = "SELECT p.nombre AS nombre, t.num AS num FROM Productos p, TransProd t WHERE t.idtrans = '"
                            + trans.IdTransaccion + "' and p.idprod = t.idprod";
                        this.comando = new SqlCommand(cadena, this.conexion);
                        this.registros = comando.ExecuteReader();
                        while (registros.Read())
                            productos.AddRange(Enumerable.Repeat(Convert.ToString(registros["nombre"]), Convert.ToInt32(registros["num"])));
                        trans.Productos = productos.ToArray();
                        this.Cerrar();
                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");
            }
            return ids;
        }

        public Transaccion BuscarTransaccion(string valor)
        {
            Transaccion tr;
            string cadena = "SELECT * FROM Transacciones WHERE idtrans = '" + valor + "'";
            if (this.Abrir())
            {
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    if (registros.Read())
                    {
                        tr = new Transaccion(Convert.ToString(registros["idtrans"]),
                                Convert.ToString(registros["idcliente"]),
                                new String[999], Convert.ToDateTime(registros["fechatrans"]));
                        this.Cerrar();
                    }
                    else
                    {
                        this.Cerrar();
                        throw new ConnectionException("Transacción no encontrada");
                    }
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
            if (this.Abrir())
            {
                try
                {
                    List<String> productos = new List<String>();
                    cadena = "SELECT p.nombre AS nombre, t.num AS num FROM Productos p, TransProd t WHERE t.idtrans = '"
                            + tr.IdTransaccion + "' and p.idprod = t.idprod";
                    this.comando = new SqlCommand(cadena, this.conexion);
                    this.registros = comando.ExecuteReader();
                    while (registros.Read())
                    {
                        productos.AddRange(Enumerable.Repeat(Convert.ToString(registros["nombre"]), Convert.ToInt32(registros["num"])));
                    }
                    tr.Productos = productos.ToArray();
                    this.Cerrar();
                    return tr;
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");
        }
        public void AddTransaccion(Transaccion t)
        {

            if (base.Abrir())
            {
                string cadena = "INSERT INTO Transacciones VALUES('" + t.IdTransaccion + "','"
                    + t.IdCliente + "','" + t.FechaTrans.ToString(@"yyyy-MM-dd hh:mm:ss") + "')";
                try
                {
                    this.comando = new SqlCommand(cadena, this.conexion);
                    comando.ExecuteNonQuery();
                    this.Cerrar();
                }
                catch (SqlException err)
                {
                    this.Cerrar();
                    throw err;
                }
            }
            else
                throw new ConnectionException("Problemas técnicos");

            List<String> productosCantidad = t.Productos.ToList();

            var occurrences = productosCantidad.GroupBy(x => x).ToDictionary(y => y.Key, z => z.Count());

            foreach (var item in occurrences)
            {

                if (base.Abrir())
                {
                    string cadena = "INSERT INTO TransProd VALUES('" + t.IdTransaccion + "','"
                        + Convert.ToString(item.Key).Split(';')[0] + "'," + Convert.ToInt32(item.Value) + ")";
                    try
                    {

                        this.comando = new SqlCommand(cadena, this.conexion);
                        comando.ExecuteNonQuery();
                        this.Cerrar();

                        ModificarProducto(Convert.ToString(item.Key).Split(';')[0], "unidades", Convert.ToString(GetUnidadesProducto(Convert.ToString(item.Key).Split(';')[0]) - Convert.ToInt32(item.Value)));

                    }
                    catch (SqlException err)
                    {
                        this.Cerrar();
                        throw err;
                    }
                }
                else
                    throw new ConnectionException("Problemas técnicos");

            }

        }
    }
}