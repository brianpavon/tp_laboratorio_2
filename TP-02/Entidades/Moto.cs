using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        /// <summary>
        /// Constructor que instancia el objeto Moto, heredando el constructor de la clase Vehiculo
        /// </summary>
        /// <param name="marca">Parametro que se pasara al atributo marca</param>
        /// <param name="chasis">Parametro que se pasara al atributo chasis</param>
        /// <param name="color">Parametro que se pasara al atributo color</param>
        public Moto(EMarca marca, string chasis, ConsoleColor color) : base(chasis,marca,color)
        {
            
        }

        /// <summary>
        /// Las motos son chicas, retorna el tamaño del objeto Moto
        /// </summary>
        public sealed override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Metodo heredado de la clase padre, en el cual se redefine Mostrar,y muestra los atributos de la clase Moto
        /// </summary>
        /// <returns>Devuelve un string con los datos del objeto Moto</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");            
            sb.AppendLine(base.Mostrar());            
            sb.AppendLine("TAMAÑO : " + this.Tamanio);            
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
