using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public class Jornada
    {
		private List<Alumno> alumnos;
		private EClases clase;
		private Profesor profesor;

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

		public EClases Clase
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

		private Jornada()
		{
			alumnos = new List<Alumno>();
		}

		public Jornada(EClases clase, Profesor instructor):this()
		{
			this.clase = clase;
			this.profesor = instructor;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"Clases de la jornada: {this.clase}");
			sb.AppendLine($"Instructor: {this.profesor.ToString()}");
			sb.AppendLine($"Lista de alumnos: ");
			foreach (Alumno aux in this.alumnos)
			{
				sb.AppendLine(aux.ToString());
			}	
			
			return sb.ToString();
		}

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

		public static bool operator == (Jornada j, Alumno a)
		{		
			return a == j.clase;			
		}

		public static bool operator != (Jornada j, Alumno a)
		{
			return !(j == a);
		}
	}
}
