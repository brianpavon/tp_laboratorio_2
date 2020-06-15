using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException :Exception
    {
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public ArchivosException()
        {
            
        }

        /// <summary>
        /// Constructor que recibira un string y lo pasara al de de su clase base
        /// </summary>
        /// <param name="mensaje"></param>
        public ArchivosException(string mensaje):base(mensaje)
        {

        }
        /// <summary>
        /// Constructor que guardara otra excepcion
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
        {
            
        }

        
    }
}
