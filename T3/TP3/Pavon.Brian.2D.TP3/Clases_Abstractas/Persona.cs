using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    
    public abstract class Persona
    {
        /// <summary>
        /// Enumerado con la nacionalidad de la persona
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        /// <summary>
        /// Atributos de la clase persona
        /// </summary>
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;


        #region Propiedades
        /// <summary>
        /// Propiedad que retorna o setea el atributo apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                if (!(this.NombreApellido(value) == String.Empty))
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// Propiedad que retorna o setea el atributo Dni
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                int aux = this.ValidarDni(this.nacionalidad, value);
                if(aux != 0)
                {
                    this.dni = value;
                }                   
            }
        }

        /// <summary>
        /// Propiedad que retorna o setea el atributo Nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad que retorna o setea el atributo Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                if(!(this.NombreApellido(value) == String.Empty))
                {
                    this.nombre = value;
                }               
                
            }
        }

        /// <summary>
        /// Propiedad que retorna o setea el atributo dni, pero validando que el string sea el correcto
        /// </summary>
        public string StringToDni
        {
            set
            {                
                int dniValido = this.ValidarDni(this.nacionalidad, value);
                if(dniValido == 0)
                {
                    throw new DniInvalidoException("No se cargo el dni");
                }
                else
                {
                    this.dni = dniValido;
                }
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public Persona()
        {
                
        }

        /// <summary>
        /// Constructor que instancia nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre">Parametro que sera cargado al atributo nombre</param>
        /// <param name="apellido">Parametro que sera cargado al atributo apellido</param>
        /// <param name="nacionalidad">Parametro que sera cargado al atributo nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor que instancia el dni
        /// </summary>
        /// <param name="nombre">Parametro que sera cargado al atributo nombre</param>
        /// <param name="apellido">Parametro que sera cargado al atributo apellido</param>
        /// <param name="dni">Parametro que sera cargado al atributo dni</param>
        /// <param name="nacionalidad">Parametro que sera cargado al atributo nacionalidad</param>
        public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {            
            this.dni = dni;                
        }

        /// <summary>
        /// Constructor que instancia el dni, pero que es pasado como string
        /// </summary>
        /// <param name="nombre">Parametro que sera cargado al atributo nombre</param>
        /// <param name="apellido">Parametro que sera cargado al atributo apellido</param>
        /// <param name="dni">Parametro que sera cargado al atributo dni</param>
        /// <param name="nacionalidad">Parametro que sera cargado al atributo nacionalidad</param>
        public Persona(string nombre,string apellido,string dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDni = dni;
        }
#endregion

        #region Metodos
        /// <summary>
        /// Valida que el dni sea el correcto de acuerdo a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Parametro con la nacionalidad a evaluar</param>
        /// <param name="dato">Parametro con el dni a evaluar</param>
        /// <returns>Si es correcto devuelve el dni, sino la excepcion NacionalidadInvalida</returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            int retorno = 0;
            if(dato >= 1 && dato <= 899999999 && nacionalidad == ENacionalidad.Argentino)
            {
                retorno = dato;
            }                     
            else if(dato >= 90000000 && dato <= 99999999 && nacionalidad == ENacionalidad.Extranjero)
            {
                retorno = dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("El  largo no se condice con la nacionalidad");
            }
            
            return retorno;
        }

        /// <summary>
        /// Validad que el string pasado sea cadena de caracteres y del tipo dni
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad que se validara de acuerdo al dni</param>
        /// <param name="dato">Cadena de caracteres con el dni</param>
        /// <returns>Devuelve el dni valido sino lo valida, devuelve una excepcion DniInvalidoException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = 0;
            if(!int.TryParse(dato,out aux) && dato.Length > 8)
            {
                throw new DniInvalidoException("Valor de DNI invalido, solo ingrese numeros");
            }
            aux = ValidarDni(nacionalidad, aux);
            return aux;
            
        }

        /// <summary>
        /// Metodo que valida que la cadena sean de formato valido para un nombre o apellido
        /// </summary>
        /// <param name="dato">Cadena de caracteresa evaluar</param>
        /// <returns>Si la cadena es correcta la devuelve, sino devuelve vacio</returns>
        private string NombreApellido(string dato)
        {                        
            foreach (char aux in dato)
            {
                if(!Char.IsLetter(aux))
                {
                    return String.Empty;
                }
            }       
            return dato;
        }

        /// <summary>
        /// Sobrecarga del metodo ToString, donde se muestran los datos de la persona
        /// </summary>
        /// <returns>Devuelve un string con los datos de la persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();            
            sb.AppendLine($"{this.apellido}, {this.nombre}");            
            sb.AppendLine($"Nacionalidad: {this.nacionalidad}");           
            
            return sb.ToString();
        }
#endregion


    }
}
