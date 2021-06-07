using PP.Infraestructura.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inicializador
{
    class Program
    {
        static void Main(string[] args)
        {
            var contex = new DataContext();

            foreach (var pais in contex.Pais)
            {
                
            }

            Console.WriteLine("Listo Para Trabajar");
            Console.ReadKey();
        }
    }
}
