namespace Plantilla.Modelos
{
    public class Cliente : Persona
    {
        private Tarjeta tarjeta;

        public Cliente()
        {
            this.tarjeta = new Tarjeta();
        }

        public Cliente(string idUsuario, string nombreApellidos, Direccion direccion, string dni, Tarjeta tarjeta) : base(idUsuario, nombreApellidos, direccion, dni)
        {
            this.tarjeta = tarjeta;
        }

        public Tarjeta Tarjeta { get => tarjeta; set => tarjeta = value; }
    }
}