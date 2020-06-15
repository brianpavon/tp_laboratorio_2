using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        /// <summary>
        /// Enumerado con el estado de cuenta del alumno
        /// </summary>
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private EEstadoCuenta estadoCuenta;
        private Universidad.EClases claseQueToma;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor que instancia nombre,apellido,legajo,dni,nacionalidad y las clases que toma
        /// </summary>
        /// <param name="id">Parametro a asignar al legajo</param>
        /// <param name="nombre">Parametro a asignar al nombre</param>
        /// <param name="apellido">Parametro a asignar al apellido</param>
        /// <param name="dni">Parametro a asignar al dni</param>
        /// <param name="nacionalidad">Parametro a asignar a la nacionalidad</param>
        /// <param name="claseQueToma">Parametro a asignar a la clase a la que se anotara</param>
        public Alumno(int id, string nombre, string apellido,string dni,ENacionalidad nacionalidad,Universidad.EClases claseQueToma)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor que instancia nombre,apellido,legajo,dni,nacionalidad,las clases que toma y el estado de cuenta
        /// </summary>
        /// <param name="id">Parametro a asignar al legajo</param>
        /// <param name="nombre">Parametro a asignar al nombre</param>
        /// <param name="apellido">Parametro a asignar al apellido</param>
        /// <param name="dni">Parametro a asignar al dni</param>
        /// <param name="nacionalidad">Parametro a asignar a la nacionalidad</param>
        /// <param name="claseQueToma">Parametro a asignar a la clase a la que se anotara</param>
        /// <param name="estadoCuenta">Parametro a asignar a su estado de cuenta</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma,EEstadoCuenta estadoCuenta)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Implementacion del metodo MostrarDatos, heredado de la clase pade
        /// </summary>
        /// <returns>Devuelve un string con los datos del alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());            
            if(this.estadoCuenta == EEstadoCuenta.AlDia)
            {
                sb.AppendLine($"ESTADO DE CUENTA: Cuota al dia");
            }
            if (this.estadoCuenta == EEstadoCuenta.Becado)
            {
                sb.AppendLine($"ESTADO DE CUENTA: Becado");
            }
            sb.AppendLine($"{this.ParticiparEnClase()}");          

            return sb.ToString();
        }

        /// <summary>
        /// Implementacion del metodo heredad de la clase Universitario
        /// </summary>
        /// <returns>Devuelve un string con la clase que toma</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TOMA CLASE DE: {this.claseQueToma}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de ToString, llamando al metodo MostrarDatos
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos del alumnos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Sobrecarga del == verificando que un alumno tome esa clase y su estado no sea deudor
        /// </summary>
        /// <param name="a">Objeto alumno a verificar</param>
        /// <param name="clase">Enumerado clase a verificar</param>
        /// <returns>Devuelve true si el alumno toma esa clase y no es deudor</returns>
        public static bool operator == (Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador != verificando que no tome esa clase
        /// </summary>
        /// <param name="a">Objeto alumno a verificar</param>
        /// <param name="clase">Enumerado clase a verificar</param>
        /// <returns>Sino toma esa clase devuelve true, sino false</returns>
        public static bool operator != (Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;
            if(a.claseQueToma != clase)
            {
                retorno = true;
            }
            return retorno;
        }
        #endregion

    }
}
