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

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo; 
        /// <summary>
        /// Constructor en el que se instancia el objeto Correo
        /// </summary>
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        /// <summary>
        /// Se crea un nuevo paquete con el texto del txtDireccion y el texto del mTxtTrackingID, se le pasa el evento de informar el estado
        /// Se agrega el paquete a la lista del correo y se va actualizando los list box, para mostrar el estado del paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete paquete = new Paquete(this.txtDireccion.Text, this.mTxtTrackingId.Text);                
                paquete.InformaEstado += this.paq_InformaEstado;
                this.correo += paquete;
                this.ActualizarEstados();
            }
            catch(TrackingIdRepetidoException error)
            {
                MessageBox.Show(error.Message,"Paquete Repetido",MessageBoxButtons.OK,MessageBoxIcon.Question);
            }
            
        }

        /// <summary>
        /// Mediante el metodo de Mostrar, carga los datos en el richTextBox, de los paquetes que estan en la lista de Correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra en el richTextBox los datos del paquete que esta en estado entregado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Cierra todos los hilos que se encuentran abiertos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        #region Metodos
        /// <summary>
        /// Evento que informa el estado del paquete, este se pasara al evento InformaEstado de Paquete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Limpia los listBox, y va cargando los paquetes en el listBox que corresponda de acuerdo a su estado
        /// </summary>
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(item);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// En caso del objeto no ser nulo, mostrara sus datos, en el richTextBox
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (!object.ReferenceEquals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar("salida.txt");
            }
        }

        #endregion


    }
}
