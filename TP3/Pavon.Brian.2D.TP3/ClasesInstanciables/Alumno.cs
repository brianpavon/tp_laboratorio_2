using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_Abstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private EEstadoCuenta estadoCuenta;
        private EClases claseQueToma;

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad,EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            //sb.AppendLine($"Clase a la que asiste: {this.claseQueToma}");
            sb.AppendLine($"{this.ParticiparEnClase()}");
            sb.AppendLine($"El estado de cuenta es: {this.estadoCuenta}");

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TOMA CLASE DE: {this.claseQueToma}");

            return sb.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator == (Alumno a, EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator != (Alumno a, EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma != clase)
            {
                retorno = true;
            }
            return retorno;
        }

        

    }
}
