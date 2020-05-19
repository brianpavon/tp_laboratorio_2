using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    
    public class Automovil : Vehiculo
    {
        /// <summary>
        /// Enumerados que definen los tipos de Automovil
        /// </summary>
        public enum ETipo 
        { 
            Monovolumen, 
            Sedan 
        }

        //Atributo
        private ETipo tipo;

        /// <summary>
        /// Por defecto, TIPO será Monovolumen, constructor publico, que hereda de la clase Vehiculo
        /// </summary>
        /// <param name="marca">Parametro que se asigna al atributo marca del automovil</param>
        /// <param name="chasis">Parametro que se asigna al atributo chasis del automovil</param>
        /// <param name="color">Parametro que se asigna al atributo color del automovil</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color): base(chasis, marca, color)
        {
            this.tipo = ETipo.Monovolumen;
        }

        /// <summary>
        /// Constructor que recibe ademas el parametro ETipo, y llama al constructor que recibe a la base
        /// </summary>
        /// <param name="marca">Parametro que se pasara al atributo marca</param>
        /// <param name="chasis">Parametros que se pasara al atributo chasis</param>
        /// <param name="color">Parametros que se pasara al atributo color</param>
        /// <param name="tipo">Parametros que se pasara al atributo tipo</param>
        public Automovil(EMarca marca, string chasis, ConsoleColor color, ETipo tipo):this(marca,chasis,color)
        {
            this.tipo = tipo;
        }

        /// <summary>
        /// Los automoviles son medianos, retorna el tamaño de los automoviles
        /// </summary>
        public sealed override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }

        /// <summary>
        /// Metodo heredado de la clase padre, que retorna los datos del automovil
        /// </summary>
        /// <returns>Devuelve un string con todos los datos del automovil</returns>
        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("AUTOMOVIL");            
            sb.AppendLine(base.Mostrar());            
            sb.AppendLine("TAMAÑO : MedianoTIPO: " + this.tipo);
            sb.AppendLine("\n---------------------");

            return sb.ToString();
        }
    }
}
