using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor sin parametro setea el atributo en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }
        /// <summary>
        /// Constructor que recibe un double y lo setea en el atributo numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
        {
            this.numero = numero;
        }
        
        /// <summary>
        /// Constructor que recibe un string y lo setea en el atributo numero
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

       /// <summary>
       /// Valida que el string recibido sea un numero
       /// </summary>
       /// <param name="strNumero"></param>
       /// <returns>Devuelve el string validado en tipo double</returns>
        private double ValidarNumero(string strNumero)
        {
            double esNumero;
            while(!Double.TryParse(strNumero, out esNumero))
            {
                esNumero = 0;
            }
               
            return esNumero;
        }
        /// <summary>
        /// Setea el atributo numero luego de validarlo
        /// </summary>
        public string SetNumero
        {
            set 
            {
                numero = ValidarNumero(value);
            }
           
        }
        /// <summary>
        /// Sobrecarga del operador + para realizar la suma entre 2 parametros de tipo double
        /// </summary>
        /// <param name="numUno">Primer elemento que se sumara</param>
        /// <param name="numDos">Segundo elemento que se sumara</param>
        /// <returns>Devuelve el resultado de la suma</returns>
        public static double operator +(Numero numUno,Numero numDos)
        {
            double resultado;
            resultado = numUno.numero + numDos.numero;

            return resultado;
        }
        /// <summary>
        /// Sobrecarga del operador - para realizar la resta entre 2 parametros de tipo double
        /// </summary>
        /// <param name="numUno">Primer elemento que se usara para la resta</param>
        /// <param name="numDos">Segundo elemento que se usara para la resta</param>
        /// <returns>Devuelve el resultado de la resta</returns>
        public static double operator -(Numero numUno, Numero numDos)
        {
            double resultado;
            resultado = numUno.numero - numDos.numero;

            return resultado;
        }
        /// <summary>
        /// Sobrecarga del operador * para realizar la multiplicacion entre 2 parametros de tipo double
        /// </summary>
        /// <param name="numUno">Primer elemento que se usara para la multiplicacion</param>
        /// <param name="numDos">Segundo elemento que se usara para la multiplicacion</param>
        /// <returns>Devuelve el resultado de la multiplicacion</returns>
        public static double operator *(Numero numUno, Numero numDos)
        {
            double resultado;
            resultado = numUno.numero * numDos.numero;

            return resultado;
        }
        /// <summary>
        /// Sobrecarga del operador / para realizar la division entre 2 parametros de tipo double
        /// </summary>
        /// <param name="numUno">Primer elemento que se usara para la division</param>
        /// <param name="numDos">Segundo elemento que se usara para la division</param>
        /// <returns>Devuelve el resultado de la division</returns>
        public static double operator /(Numero numUno, Numero numDos)
        {
            double resultado;
            if(numDos.numero == 0)
            {
                resultado = double.MinValue;
            }            
            else
            {
                resultado = numUno.numero / numDos.numero;
            }            
            return resultado;
        }

        /// <summary>
        /// Transforma un binario a numero decimal
        /// </summary>
        /// <param name="numBinario">El string que contiene el numero binario a transformar</param>
        /// <returns>Devuelve el numero decimal correspondiente al binario</returns>
        public static string BinarioDecimal(string numBinario)
        {
            string retorno;
            int numDecimal = 0;


            if(numBinario is null)
            {
                retorno = "VALOR INVALIDO";
            }
            else 
            {  
                for (int i = 1; i < numBinario.Length; i++)
                {
                    numDecimal += (int)Math.Pow(2,numBinario.Length-i) * int.Parse(numBinario[i-1].ToString()) ;
                }
                retorno = numDecimal.ToString();
            }

            return retorno;           
        }    
        /// <summary>
        /// Transforma un numero decimal a binario
        /// </summary>
        /// <param name="stringDecimal">El string que contiene el numero decimal a transfromar</param>
        /// <returns>El numero binario correspondiente a ese decimal</returns>
        public static string DecimalBinario(string stringDecimal)
        {
            int numero = int.Parse(stringDecimal);
            string cadenaBinario = "";
            if(stringDecimal is null)
            {
                cadenaBinario = "VALOR INVALIDO";
            }
            else 
            {
                while (numero > 0)
                {
                    cadenaBinario = (numero % 2).ToString() + cadenaBinario;
                    numero = numero / 2;
                }

            }            
            return cadenaBinario;
        }
        /// <summary>
        /// Transforma un numero decimal a binario
        /// </summary>
        /// <param name="stringDecimal">El double que contiene el numero decimal a transfromar</param>
        /// <returns>El numero binario correspondiente a ese decimal</returns>
        public static string DecimalBinario(double numeroDecimal)
        {
            string cadenaBinario = numeroDecimal.ToString();
            return DecimalBinario(cadenaBinario);
        }
    }
}
