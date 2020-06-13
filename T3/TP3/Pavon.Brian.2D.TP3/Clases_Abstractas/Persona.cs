using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {                
                this.apellido = this.NombreApellido(value);
            }
        }

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

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = this.NombreApellido(value);
            }
        }

        public string StringToDni
        {
            set
            {                
                int dniValido = this.ValidarDni(this.nacionalidad, value);
                if(dniValido != 0)
                {
                    this.dni = dniValido;
                }
            }
        }

        public Persona()
        {
                
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad):this()
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.nacionalidad = nacionalidad;
        }

        public Persona(string nombre,string apellido,int dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {            
            this.dni = dni;                
        }

        public Persona(string nombre,string apellido,string dni,ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDni = dni;
        }

        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            if(dato < 1 || dato > 89999999 && nacionalidad == ENacionalidad.Argentino)
            {
                throw new DniInvalidoException("El largo del DNI es incorrecto");
            }
            else if(dato > 1 || dato < 89999999 && nacionalidad != ENacionalidad.Argentino)
            {
                throw new NacionalidadInvalidadException("La nacionalidad no corresponde con el nro de DNI");
            }
            
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int aux = 0;
            if(!int.TryParse(dato,out aux))
            {
                throw new DniInvalidoException("Valor de DNI invalido, solo ingrese numeros");
            }
            aux = ValidarDni(nacionalidad, aux);
            return aux;
        }

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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Los datos son: ");
            sb.AppendLine($"Nombre: {this.nombre}");
            sb.AppendLine($"Apellido: {this.apellido}");
            sb.AppendLine($"DNI: {this.dni}");
            sb.AppendLine($"Nacionalidad: {this.nacionalidad}");           
            
            return sb.ToString();
        }


    }
}
