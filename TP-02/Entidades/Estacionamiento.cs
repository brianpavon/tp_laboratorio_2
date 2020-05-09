using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Estacionamiento
    {
        /// <summary>
        /// Enumerado con los tipos de Vehiculos
        /// </summary>
        public enum ETipo
        {
            Moto,
            Automovil,
            Camioneta,
            Todos
        }


        private List<Vehiculo> vehiculos;
        private int espacioDisponible;
        

        #region "Constructores"
        /// <summary>
        /// Constructor privado que se utiliza para instanciar la lista de vehiculos
        /// </summary>
        private Estacionamiento()
        {
             vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor, que instancia el objeto estacionamiento, llama al constructor privado.
        /// </summary>
        /// <param name="espacioDisponible">Parametro que se cargara al atributo de espacioDisponible del Estacionamiento</param>
        public Estacionamiento(int espacioDisponible):this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos de acuerdo al tipo que se pase por parametro
        /// </summary>
        /// <returns>Devuelve un string con los datos del estacionamiento</returns>
        public override string ToString()
        {
            
            return this.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns>Devuelve un string con los datos del tipo especificado</returns>
        public string Mostrar(Estacionamiento c, ETipo tipo)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles",
                            c.vehiculos.Count,
                            c.espacioDisponible);
            sb.AppendLine("");
            foreach (Vehiculo v in c.vehiculos)
            {
                switch (tipo)
                { 
                    case ETipo.Camioneta:
                        if(v.Tamanio == Vehiculo.ETamanio.Grande)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Moto:
                        if(v.Tamanio == Vehiculo.ETamanio.Chico)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        break;
                    case ETipo.Automovil:
                        if(v.Tamanio == Vehiculo.ETamanio.Mediano)
                        {
                            sb.AppendLine(v.Mostrar());
                        }
                        
                        break;
                    default:
                        sb.AppendLine(v.Mostrar());
                        break;
                }
            }
            return sb.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista, siempre y cuando no exceda el limite de espacios disponibles y no esté en la lista
        /// </summary>
        /// <param name="c">Objeto donde se agregará el elemento</param>
        /// <param name="p">Objeto a agregar</param>
        /// <returns>Devuelve el objeto estacionamiento con el elemento agregado si corresponde</returns>
        public static Estacionamiento operator +(Estacionamiento c, Vehiculo p)
        {
                        
            if(c.vehiculos.Count > 0 && c.vehiculos.Count < c.espacioDisponible && !c.vehiculos.Contains(p) )
            {
                                
                foreach (Vehiculo v in c.vehiculos)
                {
                    if (!(v == p))
                    {
                        c.vehiculos.Add(p);
                        break;
                    }
                    
                }
            }
            else if(c.vehiculos.Count == 0)
            {
               c.vehiculos.Add(p);
            }           
            
            return c;
        }
        /// <summary>
        /// Quitará un elemento de la lista, siempre y cuando este contenida en la lista
        /// </summary>
        /// <param name="c">Objeto donde se quitará el elemento</param>
        /// <param name="p">Objeto a quitar</param>
        /// <returns>Devuelve el objeto estacionamiento menos el objeto que se quito</returns>
        public static Estacionamiento operator -(Estacionamiento c, Vehiculo p)
        {
            if(c.vehiculos.Count > 0)
            {
                foreach (Vehiculo v in c.vehiculos )
                {
                    if (v == p)
                    {
                        c.vehiculos.Remove(v);
                        break;
                    }
                }
            }   
          
            return c;
        }
        #endregion
    }
}
