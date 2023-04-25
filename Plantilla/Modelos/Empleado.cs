using System;

namespace Plantilla.Modelos
{
    public class Empleado : Persona
    {
        private Boolean supervisor;

        public Empleado()
        {
            this.supervisor = false;
        }

        public Empleado(string idUsuario, string nombreApellidos, Direccion direccion, string dni, bool supervisor) : base(idUsuario, nombreApellidos, direccion, dni)
        {
            this.supervisor = supervisor;
        }

        public bool Supervisor { get => supervisor; set => supervisor = value; }
    }
}