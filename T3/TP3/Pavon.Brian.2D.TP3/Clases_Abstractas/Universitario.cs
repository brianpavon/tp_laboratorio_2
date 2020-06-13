using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        public Universitario()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
                
        }

        protected abstract string ParticiparEnClase();

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Legajo: {this.legajo}");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            
            return ((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo;
        }

        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }



    }
}
