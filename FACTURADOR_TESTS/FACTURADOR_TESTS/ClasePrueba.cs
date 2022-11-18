using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FACTURADOR_TESTS
{
    public class ClasePrueba
    {
        public static int suma(int a, int b)
        {
            return a + b;
        }
        public static int resta(int a, int b)
        {
            return a - b;
        }
        public static string concatenar(string a, string b)
        {
            return a + b;
        }
        public static bool contiene(string letra, string array)
        {
            return array.Contains(letra);
        }
    }
}
