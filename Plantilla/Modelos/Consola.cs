using System;
using System.Collections.Generic;

namespace Plantilla.Modelos
{
    public class Consola : Producto
    {
        private List<String> color;
        private Int32 almacenamiento;

        public Consola()
        {
            this.color = new List<String>();
            this.almacenamiento = 0;
        }

        public Consola(string idProducto, string marca, string nombre, double precio, int unidadesDisponibles, DateTime fechaLanzamiento, List<string> color, int almacenamiento) : base(idProducto, marca, nombre, precio, unidadesDisponibles, fechaLanzamiento)
        {
            this.color = color;
            this.almacenamiento = almacenamiento;
        }

        public List<string> Color { get => color; set => color = value; }
        public int Almacenamiento { get => almacenamiento; set => almacenamiento = value; }
    }
}