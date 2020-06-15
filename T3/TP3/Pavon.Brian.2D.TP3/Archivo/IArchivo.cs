using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Archivo
{
    interface IArchivo<T>
    {
        /// <summary>
        /// Metodo que implementaran las clases que hereden esta interfaz
        /// </summary>
        /// <param name="archivo">Nombre del archivo con el que se guardara</param>
        /// <param name="datos">Datos que se le pasaran para guardar</param>
        /// <returns>Si pudo realizar el metodo devuelve true, sino false</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Metodo que implementaran las clases que hereden esta interfaz
        /// </summary>
        /// <param name="archivo">Nombre del archivo del que se bajara la informacion</param>
        /// <param name="datos">Parametro al cual se le pasara la informacion</param>
        /// <returns>Si pudo realizar el metodo devuelve true, sino false</returns>
        bool Leer(string archivo, out T datos);
    }
}
