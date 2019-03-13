using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinarioCSharp
{
    public class ABB
    {
        class Nodo
        {
            public int codigo, cantidad;
            public string nombre, descripcion, casaProductora;
            public double precio;
            public Nodo izquierda, derecha;
        }
        Nodo raiz;
        public ABB()
        {
            raiz = null;
        }
        public void insertarNodo(string[] recibe)
        {
            Nodo nuevo;
            nuevo = new Nodo();
            //se elimina el signo $ para tener unicamente el valor numérico
            if (recibe[4].Contains("$"))
            {
                recibe[4] = recibe[4].Trim(new Char[] { '$' });
            }
            nuevo.codigo = Convert.ToInt16(recibe[0]);
            nuevo.nombre = recibe[1];
            nuevo.descripcion = recibe[2];
            nuevo.casaProductora = recibe[3];
            nuevo.precio = Convert.ToDouble(recibe[4]);
            nuevo.cantidad = Convert.ToInt16(recibe[5]);
            nuevo.izquierda = null;
            nuevo.derecha = null;

            if (raiz == null)
            {
                raiz = nuevo;
            }
            else
            {
                Nodo anterior = null;
                Nodo recorrer = raiz;
                while (recorrer != null)
                {
                    anterior = recorrer;

                    if (nuevo.precio < recorrer.precio)
                    {
                        recorrer = recorrer.izquierda;
                    }
                    else
                    {
                        recorrer = recorrer.derecha;
                    }
                    if (nuevo.precio < anterior.precio)
                    {
                        anterior.izquierda = nuevo;
                    }
                    else
                    {
                        anterior.derecha = nuevo;
                    }
                }
            }
        }

        private void preOrden(Nodo recorrer)
        {
            if (recorrer != null)
            {
                Console.Write(recorrer.nombre + " ");
                preOrden(recorrer.izquierda);
                preOrden(recorrer.derecha);
            }
        }
        private void inOrden(Nodo recorrer)
        {
            if (recorrer != null)
            {
                inOrden(recorrer.izquierda);
                Console.Write(recorrer.nombre + " ");

                inOrden(recorrer.derecha);
            }
        }
        private void postOrden(Nodo recorrer)
        {
            if (recorrer != null)
            {
                postOrden(recorrer.izquierda);
                postOrden(recorrer.derecha);
                Console.Write(recorrer.nombre + " ");
            }
        }
        public void mostrarpreOrden()
        {
            preOrden(raiz);
        }
        public void mostrarinOrden()
        {
            inOrden(raiz);
        }
        public void mostrarpostOrden()
        {
            postOrden(raiz);
        }
    }
}
