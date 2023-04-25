using System;
using System.Collections.Generic;

namespace Plantilla.Modelos
{
    public class Raton : Producto
    {
        private String dimensiones;
        private List<String> color;
        private String dpi;
        private String tipoSensor;
        private String conectividad;

        public Raton()
        {
            this.dimensiones = "";
            this.color = new List<String>();
            this.dpi = "";
            this.tipoSensor = "";
            this.conectividad = "";
        }

        public Raton(string idProducto, string marca, string nombre, double precio, int unidadesDisponibles, DateTime fechaLanzamiento, string dimensiones, List<string> color, string dpi, string tipoSensor, string conectividad) : base(idProducto, marca, nombre, precio, unidadesDisponibles, fechaLanzamiento)
        {
            this.dimensiones = dimensiones;
            this.color = color;
            this.dpi = dpi;
            this.tipoSensor = tipoSensor;
            this.conectividad = conectividad;
        }

        public string Dimensiones { get => dimensiones; set => dimensiones = value; }
        public List<string> Color { get => color; set => color = value; }
        public string Dpi { get => dpi; set => dpi = value; }
        public string TipoSensor { get => tipoSensor; set => tipoSensor = value; }
        public string Conectividad { get => conectividad; set => conectividad = value; }
    }
}