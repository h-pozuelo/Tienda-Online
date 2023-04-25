using System;

namespace Plantilla.Modelos
{
    public class Persona
    {
        private String idUsuario;
        private String nombreApellidos;
        private Direccion direccion;
        private String dni;

        public Persona()
        {
            this.idUsuario = "";
            this.nombreApellidos = "";
            this.direccion = new Direccion();
            this.dni = "";
        }

        public Persona(string idUsuario, string nombreApellidos, Direccion direccion, string dni)
        {
            this.idUsuario = idUsuario;
            this.nombreApellidos = nombreApellidos;
            this.direccion = direccion;
            this.dni = dni;
        }

        public string IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreApellidos { get => nombreApellidos; set => nombreApellidos = value; }
        public Direccion Direccion { get => direccion; set => direccion = value; }
        public string Dni { get => dni; set => dni = value; }
    }
}