using System;

namespace Plantilla.Modelos
{
    public class Direccion
    {
        private String calle;
        private String piso;
        private String codPostal;
        private String ciudad;
        private String provincia;

        public Direccion()
        {
            this.calle = "";
            this.piso = "";
            this.codPostal = "";
            this.ciudad = "";
            this.provincia = "";
        }

        public Direccion(string calle, string piso, string codPostal, string ciudad, string provincia)
        {
            this.calle = calle;
            this.piso = piso;
            this.codPostal = codPostal;
            this.ciudad = ciudad;
            this.provincia = provincia;
        }

        public override string ToString()
        {
            return (this.calle + ", " + this.piso + ", " + this.codPostal + ", " + this.ciudad + ", " + this.provincia);
        }

        public string Calle { get => calle; set => calle = value; }
        public string Piso { get => piso; set => piso = value; }
        public string CodPostal { get => codPostal; set => codPostal = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Provincia { get => provincia; set => provincia = value; }
    }
}