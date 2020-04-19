using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Calculadora
    {
        private static string ValidarOperador(string operador)
        {
            if(operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                operador = "+";
            }
            return operador;
        }

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
