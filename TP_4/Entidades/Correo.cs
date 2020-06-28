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
        /// 
        /// </summary>
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        /// <summary>
        /// 
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

        /// <summary>
        /// 
        /// </summary>
        public Correo() 
        {
            mockPaquetes = new List<Thread>();
            paquetes = new List<Paquete>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
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
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
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
        /// 
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
    }
}
