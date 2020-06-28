using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Linq.Expressions;
using System.Data;
using System.Runtime.Remoting.Channels;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        /// <summary>
        /// Se instancian los objetos conexion y comando y realiza la conexion a la base de datos, y se pasa la misma al comando.
        /// </summary>
        static PaqueteDAO()
        {
            try
            {
                conexion = new SqlConnection();
                comando = new SqlCommand();
                conexion.ConnectionString = @"Data Source = LAPTOP-Q1OJ1113\SQLEXPRESS01; Initial Catalog = correo-sp-2017; Integrated Security = True";
                comando.Connection = conexion;
            }
            catch(Exception ex)
            {
               throw new Exception("No se realizo la conexion a la base de datos",ex.InnerException);
            }
            
        }

        /// <summary>
        /// Va abrir la conexion e insertar el nuevo paquete en la base de datos
        /// </summary>
        /// <param name="p">Paquete nuevo a cargar en la base de datos</param>
        /// <returns>Si pudo insertar el cambio devuelve true sino false</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            int inserto = -1;
            try
            {
                if(conexion.State != ConnectionState.Open)
                {
                    comando.Parameters.Clear();
                    conexion.Open();

                    comando.CommandText = "insert into Paquetes (direccionEntrega, trackingID, alumno) Values(@direccionEntrega,@trackingID, @alumno)";

                    comando.Parameters.Add("direccionEntrega", p.DireccionEntrega);
                    comando.Parameters.Add("trackingID", p.TrackingID);
                    comando.Parameters.Add("alumno", "Brian Pavon");

                    inserto = comando.ExecuteNonQuery();
                    if (inserto != -1)
                    {
                        retorno = true;
                    }
                }
            }
            catch(Exception ex)
            {
                throw new Exception("No se pudo agregar el paquete ingresado", ex.InnerException);
            }
            finally
            {
                if(conexion.State != ConnectionState.Closed)
                {
                    conexion.Close();
                }
            }
            return retorno;
        }

        
        

    }
}
