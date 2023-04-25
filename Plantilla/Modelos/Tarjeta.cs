using System;

namespace Plantilla.Modelos
{
    public class Tarjeta
    {
        private String numTarjeta;
        private String ccv;
        private String fechaCaducidad;
        private String nombreTitular;

        public Tarjeta()
        {
            this.numTarjeta = "";
            this.ccv = "";
            this.fechaCaducidad = "";
            this.nombreTitular = "";
        }

        public Tarjeta(string numTarjeta, string ccv, string fechaCaducidad, string nombreTitular)
        {
            this.numTarjeta = numTarjeta;
            this.ccv = ccv;
            this.fechaCaducidad = fechaCaducidad;
            this.nombreTitular = nombreTitular;
        }

        public string NumTarjeta { get => numTarjeta; set => numTarjeta = value; }
        public string Ccv { get => ccv; set => ccv = value; }
        public string FechaCaducidad { get => fechaCaducidad; set => fechaCaducidad = value; }
        public string NombreTitular { get => nombreTitular; set => nombreTitular = value; }
    }
}