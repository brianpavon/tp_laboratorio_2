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
        /// Llama al metodo operar, el cual utilizar el metodo de la clase Calculadora para llevar a cabo la operacion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {            
            lblResultado.Text = FormCalculadora.Operar(txbNumeroUno.Text,txbNumeroDos.Text,cmbOperador.Text).ToString();
        }

        /// <summary>
        /// Cierra el formulario, mediante el metodo close
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Llama al metodo limpiar, el cual pone todos los text box, label y combobox en blanco
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
        
        /// <summary>
        /// Convierte el string que se encuentra en resultado a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!(lblResultado.Text is null))
            {
                string numeroBinario = this.lblResultado.Text;
                lblResultado.Text = Numero.DecimalBinario(numeroBinario); 
            }
            
        }


        /// <summary>
        /// Convierte el string que se encuentra en resultado a un numero decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!(lblResultado.Text is null))
            {
                string numeroBinario = this.lblResultado.Text;
                
                lblResultado.Text = Numero.BinarioDecimal(numeroBinario);
            }
        }

        #region Metodos
        /// <summary>
        /// Metodo que borra los campos de los text box, label de resultado y el combobox de operador
        /// </summary>
        private void Limpiar()
        {
            txbNumeroUno.Text = String.Empty;
            txbNumeroDos.Text = String.Empty;
            lblResultado.Text = String.Empty;
            cmbOperador.Text = String.Empty;
        }

        /// <summary>
        /// Realiza la operacion solicitada, llamando al metodo de la clase Calculadora
        /// </summary>
        /// <param name="numeroUno">Primer valor de la operacion</param>
        /// <param name="numeroDos">Segundo valor de la operacion</param>
        /// <param name="operador">Operador que indica que cuenta matematica realizar</param>
        /// <returns>Devuelve el resultado de la operacion</returns>
        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero numUno = new Numero(numeroUno);
            Numero numDos = new Numero(numeroDos);         
           
            return Calculadora.Operar(numUno, numDos, operador);

        }
        #endregion
    }
}
