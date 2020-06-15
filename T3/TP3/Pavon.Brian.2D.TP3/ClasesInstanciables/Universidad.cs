using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivo;
using Excepciones;

namespace ClasesInstanciables
{
    
    public class Universidad
    {
        /// <summary>
        /// Enumerado con las clases disponibles
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private List<Alumno> alumnos;
        private List<Profesor> profesores;
        private List<Jornada> jornada;

        #region Constructores

        /// <summary>
        /// Constructor por defecto el cual instancia las listas
        /// </summary>
        public Universidad()
        {
            alumnos = new List<Alumno>();
            profesores = new List<Profesor>();
            jornada = new List<Jornada>();
        }

        #endregion


        #region Propiedades

        /// <summary>
        /// Propiedad que setea o devuelve la lista de Jornada
        /// </summary>
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

        /// <summary>
        /// Propiedad que setea o devuelve la lista de Profesores
        /// </summary>
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

        /// <summary>
        /// Propiedad que setea o devuelve la lista de Alumnos
        /// </summary>
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

        /// <summary>
        /// Indexador que setea o devuelve una jornada en un indice dado
        /// </summary>
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
        /// Muestra los datos de la universidad
        /// </summary>
        /// <returns>Devuelve un string con los datos que tiene la universidad, alumnos, profesores y jornadas</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();            
            sb.AppendLine($"JORNADA: ");
            foreach (Jornada aux in this.jornada)
            {
                sb.AppendLine(aux.ToString());
            }
            

            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga de ToString, usa el metodo MostrarDatos
        /// </summary>
        /// <returns>Devuelve un string con los atributos de la universidad</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        /// <summary>
        /// Sobrecarga del operador == ,una Universidad será igual a un Alumno si el mismo está inscripto en él
        /// </summary>
        /// <param name="g">Objeto universidad a verificar si en su lista esta el alumno</param>
        /// <param name="a">Objeto alumnos a verificar si esta en la lista de universidad</param>
        /// <returns>Si esta en la lista devuelve true, sino false</returns>
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
        /// Sobrecarga del operador == ,una Universidad será distinto a un Alumno si el mismo no está inscripto en él
        /// </summary>
        /// <param name="g">Objeto universidad a verificar que en su lista no esta el alumno</param>
        /// <param name="a">Objeto alumno a verificar que no esta en la lista de universidad</param>
        /// <returns>Sino esta devuelve true sino false</returns>
        public static bool operator != (Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Sobrecarga del operador ==, una Universidad será igual a un Profesor si el mismo está dando clases en ella
        /// </summary>
        /// <param name="g">Obejto universidad a verificar que el profesor este en su lista</param>
        /// <param name="i">Objeto profesor a verificar si esta en la lista de la universidad</param>
        /// <returns>Si se encuentra en la lista devuelve true, sino false</returns>
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
        /// Sobrecarga del operador !=, verificando si la universidad ya tiene al profesor en su lista
        /// </summary>
        /// <param name="g">Obejto universidad a verificar que el profesor no este en su lista</param>
        /// <param name="i">Objeto profesor a verificar que no este en la lista de la universidad</param>
        /// <returns>Sino esta devuelve true sino false</returns>
        public static bool operator != (Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Sobrecarga de == entre profesor y una clase verificando que el profesor la tenga asignada
        /// </summary>
        /// <param name="u">Objeto universidad a verficar las clases que tienen sus profesores</param>
        /// <param name="clase">Enumerado de clase a verificar si es la misma que los profesores de la lista</param>
        /// <returns>Devuelve el primer profesor disponible a dar esa clase, sino lanza una excepcion</returns>
        public static Profesor operator == (Universidad u, EClases clase)
        {
            Profesor auxProfe = null;
            foreach (Profesor item in u.profesores)
            {
                if(item == clase)
                {
                    auxProfe = item;
                    break;
                }                
            }
            if(auxProfe is null)
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }
            return auxProfe;
        }

        /// <summary>
        /// Sobrecarga de != entre profesor y una clase verificando que el profesor no la tenga asignada
        /// </summary>
        /// <param name="u">Objeto universidad a verficar las clases que tienen sus profesores</param>
        /// <param name="clase">Enumerado de clase a verificar si es la misma que los profesores de la lista</param>
        /// <returns>Retornara el primer profesor que no pueda dar la clase</returns>
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
        /// Sobrecarga del operador +, a traves del cual se agregara un alumno a la lista
        /// </summary>
        /// <param name="u">Objeto universidad a verificar su lista de alumnos</param>
        /// <param name="a">Objeto alumno a verificar si esta en la lista de universidad</param>
        /// <returns>Devuelve una universidad con el alumno cargado sino esta repetido, si lo esta devuelve una excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            
            if(u == a)
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }
            else
            {
                u.alumnos.Add(a);
            }          
            
            return u;
        }

        /// <summary>
        /// Sobrecarga del operador +, a traves del cual se agregara un profesor a la lista
        /// </summary>
        /// <param name="u">Objeto universidad a verificar su lista de profesores</param>
        /// <param name="a">Objeto profesor a verificar si esta en la lista de universidad</param>
        /// <returns>Devuelve una universidad con el profesor cargado sino esta repetido</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {            
            if(u == i)
            {
                throw new SinProfesorException("Este profesor ya se encuentra en la lista");
            }
            else
            {
                u.profesores.Add(i);
            }
            return u;
        }

        /// <summary>
        /// Sobrecarga del operador +, se agrega una nueva Jornada indicando la clase, el Profesor que pueda darla y la lista de alumnos que la toman
        /// </summary>
        /// <param name="g">Objeto universidad en el cual se verificaran que sus profesores y alumnos</param>
        /// <param name="clase">Enumerado clase, el cual se verificara que haya profesores y alumnos con el mismo parametro</param>
        /// <returns>Devuelve un objeto universidad con la clase cargada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            
            Profesor auxProfe = g == clase;
            Jornada nuevaJornada = null;
                            
            
            if (!(auxProfe is null))
            {
                nuevaJornada = new Jornada(clase, auxProfe);
               
                for (int i = 0; i < g.Alumnos.Count; i++)
                {
                    if (g.Alumnos[i] == clase)
                    {                       
                        nuevaJornada.Alumnos.Add(g.Alumnos[i]);
                    }
                }
            }
            else
            {
                throw new SinProfesorException("No hay profesor para la clase");
            }          
            
            g.Jornadas.Add(nuevaJornada);

            return g;
        }

        /// <summary>
        /// Metodo que serializara el objeto
        /// </summary>
        /// <param name="uni">Obejto a serializar</param>
        /// <returns>Si puedo serializar devuelve true</returns>
        public static bool Guardar(Universidad uni)
        {
            
            Xml<Universidad> archivo = new Xml<Universidad>();
            return archivo.Guardar("Universidad.xml", uni);
            
        }

        /// <summary>
        /// Metodo que deserializara un archivo y lo cargara como objeto universidad
        /// </summary>
        /// <returns>Devuelve un objeto si lo puede deserializar</returns>
        public static Universidad Leer()
        {
            Universidad aux = new Universidad();
            Xml<Universidad> archivo = new Xml<Universidad>();
            if(!archivo.Leer("Universidad.xml",out aux))
            {
                throw new FileNotFoundException();
            }
            return aux;
        }

        #endregion

    }
}
