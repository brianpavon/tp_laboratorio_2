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
        /// Valida que el operador ingresado sea + - / * caso contrario devuelve +
        /// </summary>
        /// <param name="operador">String a verificar</param>
        /// <returns>Devuelve el operador luego de ser validado</returns>
        private static string ValidarOperador(char operador)
        {
            
            if(operador != '+' && operador != '-' && operador != '*' && operador != '/')
            {
                operador = '+';
            }
            return operador.ToString();
        }

        /// <summary>
        /// Valida y realiza la operación pedida entre ambos numeros
        /// </summary>
        /// <param name="numUno">Primer numero de la operacion</param>
        /// <param name="numDos">Segundo numero de la operacion</param>
        /// <param name="operador">El operador que define que operacion realizar</param>
        /// <returns>Devuelve el resultado de la operacion matematica</returns>
        public static double Operar(Numero numUno,Numero numDos,string operador)
        {
            char op;              
            double resultado = 0;
            if (Char.TryParse(operador, out op))
            {
                switch (ValidarOperador(op))
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
            }            
            return resultado;            
        }
    }
}
