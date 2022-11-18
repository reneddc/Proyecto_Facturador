global using Microsoft.VisualStudio.TestTools.UnitTesting;
using FACTURADOR_TESTS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Tests
{
    [TestClass]
    public class ClassTests
    {
        [TestMethod]
        public void shouldReturnTheAdition()
        {
            int a = 2;
            int b = 8;
            int resultadoEsperado = 10;
            int resultadoActual = ClasePrueba.suma(a, b);
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void shouldReturnTheSustraction()
        {
            int a = 2;
            int b = 8;
            int resultadoEsperado = -6;
            int resultadoActual = ClasePrueba.resta(a, b);
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void shouldReturnTheConcatenation()
        {
            string a = "Hola ";
            string b = "mundo";
            string resultadoEsperado = "Hola mundo";
            string resultadoActual = ClasePrueba.concatenar(a, b);
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }

        [TestMethod]
        public void shouldReturnTheContain()
        {
            string letra = "a";
            string array = "Palabra";
            bool resultadoEsperado = true;
            bool resultadoActual = ClasePrueba.contiene(letra, array);
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }
        [TestMethod]
        public void shouldReturnTheContainFalse()
        {
            string letra = "a";
            string array = "Mundo";
            bool resultadoEsperado = true;//hecho a propósito
            bool resultadoActual = ClasePrueba.contiene(letra, array);
            Assert.AreEqual(resultadoEsperado, resultadoActual);
        }
    }
}
