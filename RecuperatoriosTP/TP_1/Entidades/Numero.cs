using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        /// <summary>
        /// Constructor sin parametros, setea el numero en 0
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe un double y lo cargara en el atributo numero
        /// </summary>
        /// <param name="numero">Elemento que se cargara en el atributo numero</param>
        public Numero(double numero):this()
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que recibe un string y lo cargara en el atributo numero
        /// </summary>
        /// <param name="numero">Elemento que se cargara en el atributo numero</param>
        public Numero(string numero):this()
        {
            this.SetNumero = numero;
        }

        #region Propiedades
        /// <summary>
        /// Setea el numero luego de usar el metodo de validar el string
        /// </summary>
        public string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }

        }
        #endregion

        /// <summary>
        /// Metodo que valida que el string ingresado sea un numero valido
        /// </summary>
        /// <param name="strNumero">String que va a ser valido</param>
        /// <returns>Devuelve el string validado como numero</returns>
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
        /// Sobrecarga del operador + que permite sumar 2 elementos del tipo double
        /// </summary>
        /// <param name="numUno">Elemento que sera el primer numero a sumar</param>
        /// <param name="numDos">Elemento que sera el segundo numero a sumar</param>
        /// <returns>Devuelve el resultado de la suma</returns>
        public static double operator +(Numero numUno,Numero numDos)
        {
            double resultado;
            resultado = numUno.numero + numDos.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga del operador - que permite restar 2 elementos del tipo double
        /// </summary>
        /// <param name="numUno">Elemento que sera el primer numero a restar</param>
        /// <param name="numDos">Elemento que sera el segundo numero a restar</param>
        /// <returns>Devuelve el resultado de la resta</returns>
        public static double operator -(Numero numUno, Numero numDos)
        {
            double resultado;
            resultado = numUno.numero - numDos.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga del operador * que permite multiplicar 2 elementos del tipo double
        /// </summary>
        /// <param name="numUno">Elemento que sera el primer numero a multiplicar</param>
        /// <param name="numDos">Elemento que sera el segundo numero a multiplicar</param>
        /// <returns>Devuelve el resultado de la multiplicacion</returns>
        public static double operator *(Numero numUno, Numero numDos)
        {
            double resultado;
            resultado = numUno.numero * numDos.numero;

            return resultado;
        }

        /// <summary>
        /// Sobrecarga del operador / que permite dividir 2 elementos del tipo double
        /// </summary>
        /// <param name="numUno">Elemento que sera el primer numero a dividir</param>
        /// <param name="numDos">Elemento que sera el segundo numero a dividir</param>
        /// <returns>Devuelve el resultado de la division</returns>
        public static double operator /(Numero numUno, Numero numDos)
        {
            double resultado;
            if(numDos.numero == 0)
            {
                resultado = Double.MinValue;
            }
            else
            {
                resultado = numUno.numero / numDos.numero;
            }            
            return resultado;
        }

        /// <summary>
        /// Metodo que transforma un numero binario a decimal
        /// </summary>
        /// <param name="numBinario">El string ingresador que contiene el numero binario</param>
        /// <returns>Devuelve el numero decimal</returns>
        public static string BinarioDecimal(string numBinario)
        {
            string retorno;
            int numDecimal;
            int resto = 0;
            int exponente = 0;
            int resultado = 0;
            
            if(numBinario is null || numBinario == "" || !EsBinario(numBinario))
            {
                retorno = "VALOR INVALIDO";
            }
            else
            {    
                numDecimal = int.Parse(numBinario);
                do
                {

                    resto = numDecimal % 10;
                    numDecimal = numDecimal / 10;
                    resultado += (int)(resto * Math.Pow(2, exponente));
                    exponente++;

                } while (numDecimal != 0);                  
              
                retorno = resultado.ToString();
            }
            return retorno;           
        }    
        
        /// <summary>
        /// Metodo que transforma un decimal en binario
        /// </summary>
        /// <param name="stringDecimal">Elemento string que contiene el decimal a transformar</param>
        /// <returns>Devuelve el binario que se transformo del decimal</returns>
        public static string DecimalBinario(string stringDecimal)
        {
            int numero; 
            string cadenaBinario = "";
            if(stringDecimal is null || !int.TryParse(stringDecimal,out numero))
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
        /// Metodo que transforma un decimal en binario
        /// </summary>
        /// <param name="stringDecimal">Elemento double que contiene el decimal a transformar</param>
        /// <returns>Devuelve el binario que se transformo del decimal</returns>
        public static string DecimalBinario(double numeroDecimal)
        {
            string cadenaBinario = numeroDecimal.ToString();
            return DecimalBinario(cadenaBinario);
        }


        /// <summary>
        /// Verifica que una cadena de caracteres solo contenga 0 y 1
        /// </summary>
        /// <param name="binario">Cadena de caracteres a validar</param>
        /// <returns>Retorna true si es solo 0 y 1, retorna false sino lo es</returns>
        private static bool EsBinario(string binario)
        {
            bool retorno = false;            

            for (int i = binario.Length -1; i >= 0; i--)
            {
                if(binario[i] == '0' || binario[i] == '1')
                {
                    retorno = true;
                }
            }
            return retorno;
            
        }
    }
}
