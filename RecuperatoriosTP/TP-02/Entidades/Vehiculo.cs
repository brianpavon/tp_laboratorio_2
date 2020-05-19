using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        /// <summary>
        /// Enumerado para definir la marca de los vehiculos
        /// </summary>
        public enum EMarca
        {
            Chevrolet, 
            Ford, 
            Renault, 
            Toyota, 
            BMW, 
            Honda
        }
        /// <summary>
        /// Enumerado que define el tamaño de los vehiculos
        /// </summary>
        public enum ETamanio
        {
            Chico,
            Mediano, 
            Grande 
        }
        //Atributos:
        private EMarca marca;
        private string chasis;
        private ConsoleColor color;

        
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio 
        { 
            get; 
        }

        //CONSTRUCTOR:

        /// <summary>
        /// Constructor publico que recibe todos los parametros
        /// </summary>
        /// <param name="chasis">Parametro que se asignara al atributo de chasis</param>
        /// <param name="marca">Parametro que se asignara al atributo de marca</param>
        /// <param name="color">Parametro que se asignara al atributo de color</param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns>Devuelve un string con todos los datos del vehiculo</returns>
        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Chasis: {this.chasis}");
            sb.AppendLine($"Marca: {this.marca}");
            sb.AppendLine($"Color: {this.color}");
            sb.AppendLine("---------------------");         

            return sb.ToString();
        }

        /// <summary>
        /// Devuelve un string con los datos del vehiculo
        /// </summary>
        /// <param name="p">Recibe un objeto vehiculo el cual mostrara como un string</param>
        /// <returns>Retorna el string con los datos del vehiculo</returns>
        public static explicit operator string(Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(p.Mostrar());
            
            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1">Objeto Vehiculo que se comparara</param>
        /// <param name="v2">Objeto Vehiculo que sera el segundo a comparar</param>
        /// <returns>Devuelve True si ambos vehiculos son iguales,false sino lo son</returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return v1.chasis == v2.chasis;
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1">Objeto Vehiculo que se comparara</param>
        /// <param name="v2">Objeto Vehiculo que sera el segundo a comparar</param>
        /// <returns>Devuelve True si ambos vehiculos no son iguales, False si son iguales</returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return !(v1== v2);
        }
    }
}
