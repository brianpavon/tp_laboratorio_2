using EntidadesAbstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Profesor()
        {
               
        }

        /// <summary>
        /// Constructor que inicializa el atributo random
        /// </summary>
        static Profesor()
        {
            random = new Random();                
        }

        /// <summary>
        /// Constructor que instancia legajo,nombre,apellido,dni,nacionalidad llamando al de la clase padre e instancia las clases
        /// </summary>
        /// <param name="id">Parametro a setear en el atributo legajo</param>
        /// <param name="nombre">Parametro a setear en el atributo nombre</param>
        /// <param name="apellido">Parametro a setear en el atributo apellido</param>
        /// <param name="dni">Parametro a setear en el atributo dni</param>
        /// <param name="nacionalidad">Parametro a setear en el atributo nacionalidad</param>
        public Profesor(int id,string nombre, string apellido,string dni,ENacionalidad nacionalidad)
            :base(id,nombre,apellido,dni,nacionalidad)
        {
            clasesDelDia = new Queue<Universidad.EClases>();

            for (int i = 0; i < 2 ; i++)
            {
                this._randomClases();
            }

        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que asigna clases mediante un random
        /// </summary>
        private void _randomClases()
        {
            int claseAsignada = random.Next(0, Enum.GetNames(typeof(Universidad.EClases)).Length-1);
            this.clasesDelDia.Enqueue((Universidad.EClases)claseAsignada);
        }

        /// <summary>
        /// Implementacion del metodo MostrarDatos heredado de universitario, muestra los datos del profesor
        /// </summary>
        /// <returns>Devuelve un string con los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// Implementacion del metodo ParticiparEnCladse heredado de universitario, muestra las clases asignadas
        /// </summary>
        /// <returns>Devuelve un string con las clases asignadas del profesor</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CLASES DEL DIA: ");
            foreach (Universidad.EClases aux in this.clasesDelDia)
            {
                sb.AppendLine(aux.ToString());
            }
            
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de ToString, para mostrar los datos del profesor
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Sobrecarga del operador == comparando si el profesor es igual a una clase, si es que fue asignado a ella
        /// </summary>
        /// <param name="i">Objeto profesor a verificar sus clases</param>
        /// <param name="e">Objeto profesor a verificar sus clases</param>
        /// <returns>Si tiene asignada la clase devuelve true, sino false</returns>
        public static bool operator == (Profesor i, Universidad.EClases e)
        {
            bool retorno = false;
            foreach (Universidad.EClases aux in i.clasesDelDia)
            {
                if(aux == e)
                {
                    retorno = true;
                }
            }
            
            return retorno;
        }

        /// <summary>
        /// Sobrecarga del operador !=, utilizando la definicion del ==
        /// </summary>
        /// <param name="i">Objeto profesor a verificar sus clases</param>
        /// <param name="e">Objeto profesor a verificar sus clases</param>
        /// <returns>Si tiene asignada la clase devuelve false, sino true</returns>
        public static bool operator != (Profesor i, Universidad.EClases e)
        {
            return !(i == e);
        }
        #endregion

    }
}
