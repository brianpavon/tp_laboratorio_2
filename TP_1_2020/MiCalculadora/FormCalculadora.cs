using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        public FormCalculadora()
        {
            InitializeComponent();
        }
        /// <summary>
        /// //Metodo que realiza la operacion entre los 2 numeros ingresados
        /// </summary>
        /// <param name="numeroUno">Elemento de tipo string que asignara como primer numero</param>
        /// <param name="numeroDos">Elemento de tipo string que asignara como segundo numero</param>
        /// <param name="operador">Elemento de tipo string que se pasara como operador</param>
        /// <returns>Devuelve el resultado en tipo double</returns>
        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero numUno = new Numero(numeroUno);
            Numero numDos = new Numero(numeroDos);          

            return Calculadora.Operar(numUno, numDos, operador);
        }
        /// <summary>
        /// Metodo que realiza la operacion solicitada por el usuario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {     
            
            lblResultado.Text = FormCalculadora.Operar(txbNumeroUno.Text,txbNumeroDos.Text,cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Metodo que le asigna la funcion de cerrar el formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Limpia los campos de resultados,numeros ingresados y operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbNumeroUno.Text = null;
            txbNumeroDos.Text = null;
            lblResultado.Text = null;
            cmbOperador.Text = null;
        }

        /// <summary>
        /// Convierte el resultado a un numero binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (!(lblResultado.Text is null))
            {
                string numeroDecimal = lblResultado.Text;
                lblResultado.Text = Numero.DecimalBinario(numeroDecimal);
            }
                
        }

        /// <summary>
        /// Convierte el resultado a un numero decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if(!(lblResultado.Text is null))
            {
                string numeroBinario = this.lblResultado.Text;
                lblResultado.Text = Numero.BinarioDecimal(numeroBinario);
            }
            
        }        
        
    }
}
