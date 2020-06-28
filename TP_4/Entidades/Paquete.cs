using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
       
        /// <summary>
        /// Enumerado en el que se defines los estados del paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #region Atributos,Delegado y Evento
        /// <summary>
        /// Delegado creado para manejar el evento Informa Estado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void DelegadoEstado(object sender, EventArgs e);

        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;
        public event DelegadoEstado InformaEstado;

        #endregion


        #region Propiedades
        /// <summary>
        /// Propiedada que setea o devuelve el trackingId del paquete
        /// </summary>
        public string TrackingID
        {
            get
            {
                return trackingID;
            }
            set
            {
                trackingID = value;
            }
        }

        /// <summary>
        /// Propiedad que setea o devuelve el estado del paquete
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return estado;
            }
            set
            {
                estado = value;
            }
        }

        /// <summary>
        /// Propiedad que setea o devuelve la direccion de entrega del paquete
        /// </summary>
        public string DireccionEntrega
        {
            get
            {
                return direccionEntrega;
            }
            set
            {
                direccionEntrega = value;
            }
        }
        #endregion

        /// <summary>
        /// Constructor que carga los parametros pasados a los atributos del objeto, y setea el estado en ingresado
        /// </summary>
        /// <param name="direccionEntrega">String que se guardara en el atributo direccionEntrega</param>
        /// <param name="trackingID">String que se guardara en el atributo TrackingID</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackingID = trackingID;
            this.estado = EEstado.Ingresado;
        }

        #region Metodos
        /// <summary>
        /// Sobrecarga del operador ==, donde se compara que sean iguales de acuerdo a su trackingID
        /// </summary>
        /// <param name="p1">Primer objeto a comparar</param>
        /// <param name="p2">Segundo objeto a comparar</param>
        /// <returns>Si son iguales devuelve true, sino false</returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            return p1.TrackingID == p2.TrackingID;
        }

        /// <summary>
        /// Sobrecarga del operador !=, donde se compara que sean distintos de acuerdo a su trackingID
        /// </summary>
        /// <param name="p1">Primer objeto a comparar</param>
        /// <param name="p2">Segundo objeto a comparar</param>
        /// <returns>Si son distintos devuelve true sino false</returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Implementacion del metodo MostrarDatos, se muestran los datos del paquete
        /// </summary>
        /// <param name="elemento">Obejto del cual se mostraran los datos</param>
        /// <returns>Devuelve una cadena con los datos del paquete</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}", ((Paquete)elemento).TrackingID, ((Paquete)elemento).DireccionEntrega);
        }


        /// <summary>
        /// Sobrecarga del metodo ToString, donde llamando al metodo MostrarDatos, se muestran los datos del paquete
        /// </summary>
        /// <returns>Devuelve una cadena de caracteres con los datos del objeto</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }


        /// <summary>
        /// Hace que el estado vaya cambiando cada 4 segundos, informa el estado a traves del evento InformarEstado,
        /// Al final guarda los datos en la base de datos
        /// </summary>
        public void MockCicloDeVida()
        {
            while (this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.estado += 1; 
                this.InformaEstado(this, new EventArgs());
            }
            PaqueteDAO.Insertar(this);
        }

        #endregion

    }
}
