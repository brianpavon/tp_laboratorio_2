using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Valida que el string ingresado corresponda a un operador valido
        /// </summary>
        /// <param name="operador">Elemento string que se validara </param>
        /// <returns>Devuelve el operador que fue validado correctamente</returns>
        private static string ValidarOperador(string operador)
        {
            if(operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }
            return operador;
        }

        /// <summary>
        /// Realiza la operacion matematica requerida
        /// </summary>
        /// <param name="numUno">Elemento que se tomara como primer valor</param>
        /// <param name="numDos">Elemento que se tomara como segundo valor</param>
        /// <param name="operador">Elemento que se tomara como la operacion a realizar</param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        public static double Operar(Numero numUno,Numero numDos,string operador)
        {
            double resultado = 0;
            switch(ValidarOperador(operador))
            {
                case "+":
                    resultado = numUno + numDos;
                    break;
                case "-":
                     resultado = numUno - numDos;
                    break;
                case "*":
                    resultado = numUno * numDos;
                    break;
                case "/":
                    resultado = numUno / numDos;
                    break;

            }
            return resultado;
            
        }
    }
}
