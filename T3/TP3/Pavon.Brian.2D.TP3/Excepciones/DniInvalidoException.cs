using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        /// <summary>
        /// Constructor sin parametros
        /// </summary>
        public DniInvalidoException()
        {
            
        }

        /// <summary>
        /// Constructor que recibe como parametro una excepcion
        /// </summary>
        /// <param name="e">excepcion que se pasara por parametro</param>
        public DniInvalidoException(Exception e) : this()
        {

        }

        /// <summary>
        /// Constructor que recibe un string
        /// </summary>
        /// <param name="message">string que se pasara al constructor de la base</param>
        public DniInvalidoException(string message):base(message)
        {
            
        }

        /// <summary>
        /// Constructor que recibe un mensaje y una excepcion
        /// </summary>
        /// <param name="message">string que se pasara al constructor de la base</param>
        /// <param name="e">Excepcion que se pasara al constructor de la base</param>
        public DniInvalidoException(string message,Exception e):base(message,e)
        {

        }

        
    }
}
