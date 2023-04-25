using System;

namespace Plantilla.Modelos
{
    public class Producto
    {
        private String idProducto;
        private String marca;
        private String nombre;
        private Double precio;
        private Int32 unidadesDisponibles;
        private DateTime fechaLanzamiento;

        public Producto()
        {
            this.idProducto = "";
            this.marca = "";
            this.nombre = "";
            this.precio = 0.0;
            this.unidadesDisponibles = 0;
            this.fechaLanzamiento = new DateTime();
        }

        public Producto(string idProducto, string marca, string nombre, double precio, int unidadesDisponibles, DateTime fechaLanzamiento)
        {
            this.idProducto = idProducto;
            this.marca = marca;
            this.nombre = nombre;
            this.precio = precio;
            this.unidadesDisponibles = unidadesDisponibles;
            this.fechaLanzamiento = fechaLanzamiento;
        }

        public string IdProducto { get => idProducto; set => idProducto = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Precio { get => precio; set => precio = value; }
        public int UnidadesDisponibles { get => unidadesDisponibles; set => unidadesDisponibles = value; }
        public DateTime FechaLanzamiento { get => fechaLanzamiento; set => fechaLanzamiento = value; }
    }
}