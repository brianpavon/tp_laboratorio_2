using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        /// <summary>
        /// Atributo de la clase
        /// </summary>
        private int legajo;

        #region Constructores
        /// <summary>
        /// Constructor por defecto, sin parametros
        /// </summary>
        public Universitario()
        {

        }

        /// <summary>
        /// Constructor que instancia nombre,apellido,dni,nacionalidad y legajo
        /// </summary>
        /// <param name="legajo">Parametro que se carga al atributo legajo</param>
        /// <param name="nombre">Parametro que se carga al atributo nombre</param>
        /// <param name="apellido">Parametro que se carga al atributo apellido</param>
        /// <param name="dni">Parametro que se carga al atributo dni</param>
        /// <param name="nacionalidad">Parametro que se carga al atributo nacionalidad</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Metodo abstracto que definiran las clases que lo hereden
        /// </summary>
        /// <returns>Retorna el string definido por cada clase hija</returns>
        protected abstract string ParticiparEnClase();

        /// <summary>
        /// Muestra los datos del universitario
        /// </summary>
        /// <returns>Devuelve un string con los datos</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NUMERO: {this.legajo}");

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del Equals del universitario comparando que dni y legajo sean iguales
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Si son iguales retorna true, sino false</returns>
        public override bool Equals(object obj)
        {
            
            return ((Universitario)obj).DNI == this.DNI || ((Universitario)obj).legajo == this.legajo && obj.GetType() == this.GetType();
        }

        /// <summary>
        /// Sobrecarga del operador ==, llama al metodo equals para verificar que sean iguales
        /// </summary>
        /// <param name="pg1">Primer universitario a comparar</param>
        /// <param name="pg2">Segundo universitario a comparar</param>
        /// <returns>Si son iguales retorna true, sino false</returns>
        public static bool operator == (Universitario pg1, Universitario pg2)
        {
            return pg1.Equals(pg2);
        }

        /// <summary>
        /// Sobrecarga del operador != llama al metodo == para verificar la desigualdad
        /// </summary>
        /// <param name="pg1">Primer objeto a comparar</param>
        /// <param name="pg2">Segundo objeto a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion

    }
}
