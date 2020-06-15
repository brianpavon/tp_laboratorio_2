using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using ClasesInstanciables;

namespace TestInstanciaTp3
{
    [TestClass]
    public class TestInstancia
    {
        /// <summary>
        /// Verificar que la lista de alumnos no sea nula, y se haya instanciado
        /// </summary>
        [TestMethod]
        public void AlumnosCorrectos()
        {
            Universidad uni = new Universidad();
            Alumno a1 = new Alumno(1, "Anita", "Juarez", "35640179", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.Becado);
            Alumno a2 = new Alumno(2, "German", "Gutierrez", "35057416", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            uni += a1;
            uni += a2;

            Assert.IsNotNull(uni.Alumnos);
        }

        /// <summary>
        /// Verifica que la lista de alumnos de jornada se haya instanciado
        /// </summary>
        [TestMethod]
        public void JornadaCorrecta()
        {
            Profesor profe = new Profesor(2, "Juancho", "Lopez", "16543968", EntidadesAbstractas.Universitario.ENacionalidad.Argentino);
            Jornada jornada1 = new Jornada(Universidad.EClases.Laboratorio, profe);

            Assert.IsNotNull(jornada1.Alumnos);
        }

        
    }
}
