using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Laboratorio3_1251518.Models;

namespace Laboratorio3_1251518.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(new List<Medicamentos>());
        }
        static List<Medicamentos> inventario = new List<Medicamentos>();

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile) {
            //se crea una lista para almacenar los medicamentos
            
            
            string rutaArchivo = string.Empty;
            //el siguiente if permite seleccionar un archivo en específico
            if (postedFile != null) {
                string ruta = Server.MapPath("~/ArchivosBase/");
                if (!Directory.Exists(ruta)) {
                    Directory.CreateDirectory(ruta);
                }

                rutaArchivo = ruta + Path.GetFileName(postedFile.FileName);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.SaveAs(rutaArchivo);
                //se lee el archivo del inventario
                string datosMedicamento = System.IO.File.ReadAllText(rutaArchivo);
                //se tomara y fragmentara cada una de las lineas del archivo
                foreach (string registro in datosMedicamento.Split('\n')) {
                    if (!string.IsNullOrEmpty(registro)) {
                        inventario.Add(new Medicamentos {
                            nombreCliente = "",
                            nit ="",
                            direccion="",
                            ct = 0,
                            total = 0,
                            id = Convert.ToInt32(registro.Split(',')[0]),
                            nombre = registro.Split(',')[1],
                            descripcion = registro.Split(',')[2],
                            casaProductora = registro.Split(',')[3],
                            precio = registro.Split(',')[4],
                            cantidad = Convert.ToInt32(registro.Split(',')[5])
                            
                        });
                    }
                }
            }
            return View(inventario);
        }
        public ActionResult mostrar() {
            return View(inventario);
        }
        public ActionResult pedir() {
            return View(inventario);
        }
        public ActionResult modificar() {
            return View(inventario);
        }
        public ActionResult editar() {
            string medEditar = Request.Form["medicamento1"].ToString();
            string accion = Request.Form["accion"].ToString();
            if(accion == "Eliminar") {
                inventario.RemoveAll(x => x.nombre.Equals(medEditar));
            }
            else {
                var coincidencia = inventario.Where(item => item.nombre.Equals(medEditar));
                foreach (var propiedad in coincidencia) {
                    Random random = new Random();
                    int abastece = random.Next(1, 15);
                    propiedad.cantidad = propiedad.cantidad + abastece;

                }
            }
           
            return View();
        }

        Medicamentos cliente = new Medicamentos();
        public ActionResult facturar() {
            string nombreCliente = Request.Form["nombre"].ToString();
            string producto = Request.Form["medicamento1"].ToString();
            var coincidencia = inventario.Where(item => item.nombre.Equals(producto));
            foreach (var propiedad in coincidencia) {
               //se rellena con los datos del cliente
                cliente.nombre = propiedad.nombre;
                cliente.precio = propiedad.precio;
                cliente.nombreCliente = nombreCliente;
                cliente.nit = Request.Form["nit"].ToString();
                cliente.direccion = Request.Form["direccion"].ToString();
                cliente.ct = Convert.ToInt32(Request.Form["cantm1"]);
                double pr = Convert.ToDouble(cliente.precio.Trim(new Char[] { '$' }));
                cliente.total = cliente.ct * pr;
                //se disminuye la cantidad en inventario
                propiedad.cantidad = propiedad.cantidad - cliente.ct;
            }
            inventario.Add(cliente);
            return View(inventario.FindAll(x => x.nombreCliente.Equals(nombreCliente)));
        }

    }
}