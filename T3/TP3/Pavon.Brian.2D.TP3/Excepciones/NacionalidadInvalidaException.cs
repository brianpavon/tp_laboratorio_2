using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public NacionalidadInvalidaException()
        {
           
        }

        /// <summary>
        /// Constructor que recibe un string para mostrar ese mensaje
        /// </summary>
        /// <param name="mensaje">string en el que se cargara</param>
        public NacionalidadInvalidaException(string mensaje):base(mensaje)
        {
                
        }
    }
}
