using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using Excepciones;

namespace Archivo
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo que serializa un objeto
        /// </summary>
        /// <param name="archivo">Nombre del archivo con el que se guardar</param>
        /// <param name="datos">Objeto a serializar</param>
        /// <returns>Si pudo serializar devuelve true sino false</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;
            if (!(String.IsNullOrEmpty(archivo)) || object.ReferenceEquals(datos,null))                
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer sr = new XmlSerializer(typeof(T));
                    sr.Serialize(writer, datos);
                    retorno = true;
                }
            }
            else
            {
                throw new ArchivosException(new Exception("No se pudo guardar el archivo"));
            }
            
            return retorno;
        }

        /// <summary>
        /// Metodo para deserializar un archivo xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo a deserializar</param>
        /// <param name="datos">Objeto al cual se le pasaran los datos</param>
        /// <returns>Si pudo deserializar devuelve true sino false</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;
           if(!(String.IsNullOrEmpty(archivo)))
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer deserialiazar = new XmlSerializer(typeof(T));
                    datos = (T)deserialiazar.Deserialize(reader);
                    retorno = true;
                }
            }                
            else
            {
                throw new ArchivosException(new Exception("No se puede leer el archivo"));
            }
            
            return retorno;
        }
    }
}
