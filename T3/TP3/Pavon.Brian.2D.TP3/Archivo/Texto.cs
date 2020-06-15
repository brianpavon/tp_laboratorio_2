using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.Xml.Serialization;


namespace Archivo
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Metodo que guardara en formato txt
        /// </summary>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <param name="datos">Cadena de caracteres a guardar</param>
        /// <returns>Si pudo guardar devuelve true sino false</returns>
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;
            if (!(String.IsNullOrEmpty(archivo)) || object.ReferenceEquals(datos, null))
            {
                using (StreamWriter sw = new StreamWriter(archivo))
                {
                    sw.Write(datos);
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
        /// Metodo que leera un txt, y lo cargara a un objeto
        /// </summary>
        /// <param name="archivo">Nombre del archivo a leer</param>
        /// <param name="datos">Cadena de caracteresa leer</param>
        /// <returns>Si pudo leer devuelve true sino false</returns>
        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            if(!(String.IsNullOrEmpty(archivo)))            
            {
                using (StreamReader sr = new StreamReader(archivo))
                {                    
                    StringBuilder sb = new StringBuilder();
                    while ((datos = sr.ReadLine()) != null)
                    {
                        sb.AppendLine(datos);
                    }                    
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
