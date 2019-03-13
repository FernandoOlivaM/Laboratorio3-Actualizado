using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio3_1251518.Models { 
    public class Medicamentos {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string casaProductora { get; set; }
        public string precio { get; set; }
        public int cantidad { get; set; }

        public string nombreCliente { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public int ct { get; set; }
        public double total { get; set; }

    }
}