using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClasesInstanciables
{
    public enum EClases
    {
        Programacion,
        Laboratorio,
        Legislacion,
        SPD
    }
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;

        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornada = new List<Jornada>();
        }

        #region Propiedades
        public List<Jornada> Jornadas
        {
            get 
            { 
                return this.jornada; 
            }
            set
            {
                this.jornada = value; 
            }
        }

        public List<Profesor> Instructores
        {
            get 
            {
                return this.profesores; 
            }
            set
            { 
                this.profesores = value; 
            }
        }

        public List<Alumno> Alumnos
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

        public Jornada this[int i]
        {
            get
            {
                if(i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if(i > 0 && i < this.jornada.Count)
                {
                    this.jornada[i] = value;
                }
            }
        }
        #endregion


        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Lista de alumnos inscriptos: ");
            foreach (Alumno aux in this.alumnos)
            {
                sb.AppendLine(aux.ToString());
            }
            sb.AppendLine($"Lista de Profesores: ");
            foreach (Profesor aux in this.profesores)
            {
                sb.AppendLine(aux.ToString());
            }
            sb.AppendLine($"Jornada: ");
            foreach (Jornada aux in this.jornada)
            {
                sb.AppendLine(aux.ToString());
            }

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            bool retorno = false;
            foreach (Alumno aux in g.alumnos)
            {
                if(aux == a)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static bool operator != (Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator == (Universidad g, Profesor i)
        {
            bool retorno = false;
            foreach (Profesor aux in g.profesores)
            {
                if(aux == i)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static bool operator != (Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator == (Universidad u, EClases clase)
        {
            Profesor auxProfe = null;
            foreach (Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    auxProfe = item;
                }                
            }
            if(auxProfe is null)
            {
                throw new Exception("no se puede");
            }
            return auxProfe;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Profesor operator != (Universidad u, EClases clase)
        {
            Profesor auxProfe = null;
            foreach (Profesor item in u.profesores)
            {
                if(item != clase)
                {
                    auxProfe = item;
                    break;
                }
            }
            return auxProfe;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            bool alumnoRepetido = false;
            foreach (Alumno aux in u.alumnos)
            {
                if(aux == a)
                {
                    alumnoRepetido = true;
                }
            }
            if(alumnoRepetido is false)
            {
                u.alumnos.Add(a);
            }
            return u;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            bool profesorRepetido = false;
            foreach (Profesor aux in u.profesores)
            {
                if (aux == i)
                {
                    profesorRepetido = true;
                }
            }
            if (profesorRepetido is false)
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor auxProfe = null;
            Jornada nuevaJornada = null;
            Alumno auxAlumno = null;
            foreach (Profesor item in g.profesores)
            {
                if(item == clase)
                {
                    auxProfe = item;
                    break;
                }
            }
            nuevaJornada = new Jornada(clase, auxProfe);
            foreach (Alumno aux in g.alumnos)
            {
                if(aux == clase)
                {
                    auxAlumno = aux;
                    break;
                }
            }
            nuevaJornada.Alumnos.Add(auxAlumno);
            //nuevaJornada.Instructor = auxProfe;
            nuevaJornada.Clase = clase;
            g.jornada.Add(nuevaJornada);

            return g;
        }

        #endregion

    }
}
