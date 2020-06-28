using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.CompilerServices;

namespace Entidades
{
    public class Correo: IMostrar<List<Paquete>>
    {
        /// <summary>
        /// Atributos de la clase
        /// </summary>
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Propiedades
        /// <summary>
        /// Propiedad que setea o devuelve la lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return paquetes;
            }
            set
            {
                paquetes = value;
            }
        }


        #endregion


        /// <summary>
        /// Constructor en el que se instancian las listas del Correo
        /// </summary>
        public Correo() 
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }

        #region Metodos

        /// <summary>
        /// Implementacion del metodo MostrarDatos, donde se muestran los datos de los paquetes de la lista
        /// </summary>
        /// <param name="elementos">Es la lista del cual se mostraran los datos</param>
        /// <returns>Devuelve una cadena con los datos de los paquetes</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Paquete item in ((Correo)elementos).Paquetes)
            {
                sb.AppendLine(string.Format(item.MostrarDatos(item) + "({0})",item.Estado.ToString()));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador +, a través del cual se agregara un nuevo paquete a la lista del correo en caso que no este en la lista
        /// Si estuviera, lanza una excepcion de paquete repetido
        /// Crea un hilo para el metodo MockCicloDeVida, lo agrega a lista de hilos y lo ejecuta
        /// </summary>
        /// <param name="c">Objeto correo, al cual se le agregara el paquete en su lista de paquetes</param>
        /// <param name="p">Obejto a agregar en la lista de paquetes de Correo</param>
        /// <returns>En caso de poder agregar devuelve el objeto Correo, con el nuevo paquete en su lista</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            bool repetido = false;            
            foreach (Paquete item in c.Paquetes)
            {
                if(item == p)
                {
                    repetido = true;
                    throw new TrackingIdRepetidoException("El tracking ID " + item.TrackingID + " ya figura en la lista de envios");
                }
            }
            if(repetido is false)
            {
                c.Paquetes.Add(p);
                Thread hiloNuevo = new Thread(p.MockCicloDeVida);
                hiloNuevo.Start();
                c.mockPaquetes.Add(hiloNuevo);
            }
            return c;
        }

        /// <summary>
        /// Cierra todos los hilos que se encuentran activos
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                if (item.IsAlive)
                {
                    item.Abort();
                }
            }
        }

#endregion
    }
}
