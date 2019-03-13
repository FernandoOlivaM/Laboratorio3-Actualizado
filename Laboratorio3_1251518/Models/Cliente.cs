using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio3_1251518.Models
{
    public class Cliente {
        public string nombreCliente { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public double precio { get; set; }
        public double total { get; set; }
    }
}