using System;
using System.Collections;

namespace Plantilla.Modelos
{
    public class Transaccion
    {
        private String idTransaccion;
        private String idCliente;
        private String[] productos;
        private DateTime fechaTrans;

        public Transaccion()
        {
            this.idTransaccion = "";
            this.idCliente = "";
            this.productos = new String[999];
            this.fechaTrans = new DateTime();
        }

        public Transaccion(string idTransaccion, string idCliente, String[] productos, DateTime fechaTrans)
        {
            this.idTransaccion = idTransaccion;
            this.idCliente = idCliente;
            this.productos = productos;
            this.fechaTrans = fechaTrans;
        }

        public string IdTransaccion { get => idTransaccion; set => idTransaccion = value; }
        public string IdCliente { get => idCliente; set => idCliente = value; }
        public String[] Productos { get => productos; set => productos = value; }
        public DateTime FechaTrans { get => fechaTrans; set => fechaTrans = value; }
    }
}