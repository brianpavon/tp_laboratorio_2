using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesAbstractas;
using ClasesInstanciables;

namespace TestUnitariosTp3
{
    [TestClass]
    public class TestException
    {
        /// <summary>
        /// Verificar que se lance la excepcion cuando no corresponde la nacionalidad con el nro de dni
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void PersonaNacionalidadInvalida()
        {
            Profesor persona = new Profesor(2,"Anita", "Gutierrez", "35640179", EntidadesAbstractas.Persona.ENacionalidad.Extranjero);
        }

        /// <summary>
        /// Verifica que se lance la excepcion si el alumno esta repetido
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void AlumnoRepetido()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1,"Anita","Juarez","35640179",EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(2, "Anita", "Juarez", "35640179",EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            uni += a1;
            uni += a2;
        }
    }
}
