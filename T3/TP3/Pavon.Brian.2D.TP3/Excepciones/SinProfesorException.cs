using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException :Exception
    {
        /// <summary>
        /// Constructor sin parametro
        /// </summary>
        public SinProfesorException()
        {
            
        }

        /// <summary>
        /// Constructor el cual tomara un string que mostrara indicando el error
        /// </summary>
        /// <param name="mensaje">El string a mostrar</param>
        public SinProfesorException(string mensaje):base(mensaje)
        {

        }
    }
}
