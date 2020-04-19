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


        public Numero()
        {
            this.numero = 0;
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }
        
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

       
        private double ValidarNumero(string strNumero)
        {
            double esNumero;
            while(!Double.TryParse(strNumero, out esNumero))
            {
                esNumero = 0;
            }
               
            return esNumero;
        }

        public string SetNumero
        {
            set 
            {
                numero = ValidarNumero(value);
            }
           
        }

        public static double operator +(Numero numUno,Numero numDos)
        {
            double resultado;
            resultado = numUno.numero + numDos.numero;

            return resultado;
        }

        public static double operator -(Numero numUno, Numero numDos)
        {
            double resultado;
            resultado = numUno.numero - numDos.numero;

            return resultado;
        }

        public static double operator *(Numero numUno, Numero numDos)
        {
            double resultado;
            resultado = numUno.numero * numDos.numero;

            return resultado;
        }

        public static double operator /(Numero numUno, Numero numDos)
        {
            double resultado = double.MinValue;
            
            if(numDos.numero > 0)
            {
                resultado = numUno.numero / numDos.numero;
            }

            
            return resultado;
        }

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

        public static string DecimalBinario(double numeroDecimal)
        {
            string cadenaBinario = numeroDecimal.ToString();
            return DecimalBinario(cadenaBinario);
        }
    }
}
