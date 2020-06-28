using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
        /// Metodo de extension para la clase string, a traves del cual creara un txt
        /// </summary>
        /// <param name="texto">Cadena de caracteres de la cual se creara el txt</param>
        /// <param name="archivo">Nombre del archivo, con el que se guardara</param>
        /// <returns>Si pudo crear o agregar mas informacion al archivo devuelve true, sino false</returns>
        public static bool Guardar(this string texto,string archivo)
        {
            bool agrego = false;
            using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))
            {
                writer.WriteLine(texto);
                agrego = true;
            }
            return agrego;
        }
    }
}
