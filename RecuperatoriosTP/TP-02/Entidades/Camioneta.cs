using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Camioneta : Vehiculo
    {
        /// <summary>
        /// Constructor que instancia el objeto Camioneta, heredando el constructor de la clase Vehiculo
        /// </summary>
        /// <param name="marca">Parametro que se pasara al atributo marca</param>
        /// <param name="chasis">Parametro que se pasara al atributo chasis</param>
        /// <param name="color">Parametro que se pasara al atributo color</param>
        public Camioneta(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Las camionetas son grandes, retorna el tamaño del objeto Camioneta
        /// </summary>
        public sealed override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }

        /// <summary>
        /// Metodo heredado de la clase padre, en el cual se redefinen mostrar los atributos de la clase Camioneta
        /// </summary>
        /// <returns>Devuelve un string con los datos del objeto Camioneta</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CAMIONETA");            
            sb.AppendLine(base.Mostrar());            
            sb.AppendLine("TAMAÑO : " + this.Tamanio);
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
