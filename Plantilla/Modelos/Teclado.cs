using System;
using System.Collections.Generic;

namespace Plantilla.Modelos
{
    public class Teclado : Producto
    {
        private String dimensiones;
        private List<String> color;
        private String tipo;
        private String tipoSwitch;

        public Teclado()
        {
            this.dimensiones = "";
            this.color = new List<String>();
            this.tipo = "";
            this.tipoSwitch = "";
        }

        public Teclado(string idProducto, string marca, string nombre, double precio, int unidadesDisponibles, DateTime fechaLanzamiento, string dimensiones, List<string> color, string tipo, string tipoSwitch) : base(idProducto, marca, nombre, precio, unidadesDisponibles, fechaLanzamiento)
        {
            this.dimensiones = dimensiones;
            this.color = color;
            this.tipo = tipo;
            this.tipoSwitch = tipoSwitch;
        }

        public string Dimensiones { get => dimensiones; set => dimensiones = value; }
        public List<string> Color { get => color; set => color = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string TipoSwitch { get => tipoSwitch; set => tipoSwitch = value; }
    }
}