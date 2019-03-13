using ArbolBinarioCSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    class Program
    {
        static void Main(string[] args) {
            ABB arbol = new ABB();
            //se lee el archivo
            StreamReader leer = new StreamReader(@"../../../ArchivosBase/MOCK_DATA.csv", true);
            string line = leer.ReadLine();
            line = leer.ReadLine();
            string[] separadas = new string[6];
            while (line != null)
            {
                //se vuelve a leer la línea para no tomar en cuenta los encabezados
                //se separan los campos del medicamento
                separadas = line.Split(',');
                arbol.insertarNodo(separadas);
                line = leer.ReadLine();
                arbol.mostrarinOrden();
                Console.WriteLine("\n");
            }
            Console.ReadLine();

        }
    }
}
