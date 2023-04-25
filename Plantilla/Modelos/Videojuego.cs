using System;

namespace Plantilla.Modelos
{
    public class Videojuego : Producto
    {
        private String consola;
        private String genero;
        private String desarrolladora;
        private Double tamanyo;

        public Videojuego() : base()
        {
            this.consola = "";
            this.genero = "";
            this.desarrolladora = "";
            this.tamanyo = 0.0;
        }

        public Videojuego(string idProducto, string marca, string nombre, double precio, int unidadesDisponibles, DateTime fechaLanzamiento, string consola, string genero, string desarrolladora, double tamanyo) : base(idProducto, marca, nombre, precio, unidadesDisponibles, fechaLanzamiento)
        {
            this.consola = consola;
            this.genero = genero;
            this.desarrolladora = desarrolladora;
            this.tamanyo = tamanyo;
        }

        public string Consola { get => consola; set => consola = value; }
        public string Genero { get => genero; set => genero = value; }
        public string Desarrolladora { get => desarrolladora; set => desarrolladora = value; }
        public double Tamanyo { get => tamanyo; set => tamanyo = value; }
    }
}