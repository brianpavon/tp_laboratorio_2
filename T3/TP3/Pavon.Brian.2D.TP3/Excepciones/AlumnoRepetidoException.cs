using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public AlumnoRepetidoException()
        {
            
        }

        /// <summary>
        /// Constructor que recibe un string con un mensaje
        /// </summary>
        /// <param name="mensaje">string que se pasara al constructor de la base que recibe el mismo parametro</param>
        public AlumnoRepetidoException(string mensaje):base(mensaje)
        {

        }

        
    }
}
