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
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        private static string Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero numUno = new Numero(numeroUno);
            Numero numDos = new Numero(numeroDos);
            string resultado;

            return resultado = Calculadora.Operar(numUno, numDos, operador).ToString();

        }
        private void btnOperar_Click(object sender, EventArgs e)
        {            
            lblResultado.Text = LaCalculadora.Operar(txbNumeroUno.Text,txbNumeroDos.Text,cmbOperador.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txbNumeroUno.Text = null;
            txbNumeroDos.Text = null;
            lblResultado.Text = null;
            cmbOperador.Text = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!(lblResultado.Text is null))
            {
                string numeroDecimal = lblResultado.Text;
                lblResultado.Text = Numero.DecimalBinario(numeroDecimal);
            }
                
        }

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
