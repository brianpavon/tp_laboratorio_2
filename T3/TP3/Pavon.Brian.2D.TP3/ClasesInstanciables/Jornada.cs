using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Archivo;

namespace ClasesInstanciables
{
    public class Jornada
    {
		/// <summary>
		/// Atributos de la clase
		/// </summary>
		private List<Alumno> alumnos;
		private Universidad.EClases clase;
		private Profesor profesor;

        #region Propiedades
        /// <summary>
        /// Propiedad que setea o devuelve el atributo profesor
        /// </summary>
        public Profesor Instructor
		{
			get 
			{
				return this.profesor; 
			}
			set 
			{
				profesor = value; 
			}
		}

		/// <summary>
		/// Propiedad que setea o devulve la clase de la jornada
		/// </summary>
		public Universidad.EClases Clase
		{
			get 
			{
				return this.clase; 
			}
			set 
			{ 
				this.clase = value; 
			}
		}

		/// <summary>
		/// Propiedad que setea o devuelve la lista de alumnos
		/// </summary>
		public  List<Alumno> Alumnos
		{
			get 
			{ 
				return this.alumnos; 
			}
			set 
			{ 
				this.alumnos = value; 
			}
		}
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor defecto, donde se inicializa la lista de alumnos
        /// </summary>
        private Jornada()
		{
			alumnos = new List<Alumno>();
		}

		/// <summary>
		/// Constructor que instancia el atributo clase y profesor
		/// </summary>
		/// <param name="clase">Parametro a cargar en clase</param>
		/// <param name="instructor">Parametro que se cargar en el atributo profesor</param>
		public Jornada(Universidad.EClases clase, Profesor instructor):this()
		{
			this.clase = clase;
			this.profesor = instructor;
		}
        #endregion

        #region Metodos

        /// <summary>
        /// Sobrecarga de ToString, donde se muestran los datos de la Jornada
        /// </summary>
        /// <returns>Devuelve un string con los datos de la jornada</returns>
        public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			
			sb.AppendLine($"CLASE DE: {this.clase} POR NOMBRE COMPLETO: {this.profesor.ToString()}");			
			sb.AppendLine($"ALUMNOS: ");
			foreach (Alumno aux in this.alumnos)
			{
				sb.AppendLine($"NOMBRE COMPLETO: {aux.ToString()}");
				
			}
			sb.AppendLine($"<----------------------------------->");
			return sb.ToString();
		}

		/// <summary>
		/// Sobrecarga del operador +, agregando al alumno si el mismo no esta ya en la lista
		/// </summary>
		/// <param name="j">Objeto Jornada a verificar si tiene el alumno cargado</param>
		/// <param name="a">Obejto alumno a verificar si ya esta en la lista</param>
		/// <returns>Devuelve una jornada con el nuevo alumno si el mismo no estaba en la lista</returns>
		public static Jornada operator +(Jornada j, Alumno a)
		{
			bool estaAsignado = false;
			foreach (Alumno aux in j.alumnos)
			{
				if(aux == a)
				{
					estaAsignado = true;
				}
			}
			if(estaAsignado is false)
			{
				j.alumnos.Add(a);
			}
			return j;
		}

		/// <summary>
		/// Sobrecarga de == ,una Jornada será igual a un Alumno si el mismo participa de la clase
		/// </summary>
		/// <param name="j">Objeto Jornada a verificar si en su clase es la misma que el alumno</param>
		/// <param name="a">Objeto Alumno a verificar si su clase es la misma que la jornada</param>
		/// <returns>Si las clases son iguales retorna true sino false</returns>
		public static bool operator == (Jornada j, Alumno a)
		{		
			return a == j.clase;			
		}

		/// <summary>
		/// Sobrecarga de !=, una Jornada será distinta a un Alumno si el mismo no participa de la clase
		/// </summary>
		/// <param name="j">Objeto Jornada a verificar si en su clase es distinta que el alumno</param>
		/// <param name="a">Objeto Alumno a verificar si su clase es distinta que la jornada</p</param>		
		/// <returns>Si las clases son distintas retorna true sino false</returns>
		public static bool operator != (Jornada j, Alumno a)
		{
			return !(j == a);
		}

		/// <summary>
		/// Metodo que guarda la Jornada en un txt
		/// </summary>
		/// <param name="jornada">Objeto a guardar en un txt</param>
		/// <returns>Si pudo guardar devuelve true, sino false</returns>
		public static bool Guardar(Jornada jornada)
		{
			Texto archivo = new Texto();
			return archivo.Guardar("Jornada.txt", jornada.ToString());
		}

		/// <summary>
		/// Metodo que carga un archivo txt a un string con los datos que tiene
		/// </summary>
		/// <returns>Si pudo leer el archivo devuelve true, sino false</returns>
		public static string Leer()
		{
			string texto = String.Empty;
			Texto archivo = new Texto();
			if(!archivo.Leer("Jornada.txt", out texto))
			{
				throw new FileNotFoundException();
			}
			return texto;
		}
        #endregion
    }
}
