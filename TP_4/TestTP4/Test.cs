using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace TestTP4
{
    [TestClass]
    public class Test
    {

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void VerificarLista()
        {
            Correo c1 = new Correo();
            Paquete p1 = new Paquete("Las Heras 3230", "236-200-0001");
            Paquete p2 = new Paquete("Las Heras 1800", "236-200-0002");
            Paquete p3 = new Paquete("Las Heras 4200", "236-200-0003");

            c1 += p1;
            c1 += p2;
            c1 += p3;

            Assert.IsNotNull(c1.Paquetes);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(TrackingIdRepetidoException))]
        public void VerificarRepetido()
        {
            Correo c = new Correo();
            Paquete p1 = new Paquete("Albarracin 1120", "000-000-0001");
            Paquete p2 = new Paquete("Albarracin 1121", "000-000-0001");

            c += p1;
            c += p2;

        }

    }
}
