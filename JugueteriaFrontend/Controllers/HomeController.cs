using JugueteriaFrontend.Helper;
using JugueteriaFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JugueteriaFrontend.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;
        ProductosAPI _apiProductos = new ProductosAPI();

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = _httpClientFactory.CreateClient("productos");

            List<Producto> productos = new List<Producto>();
         
            HttpResponseMessage response = await httpClient.GetAsync("Producto");

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                productos = JsonConvert.DeserializeObject<List<Producto>>(results);
            }
            return View(productos);
        }

        public async Task<JsonResult> CrearProducto([Bind("Nombre,Descripcion,RestriccionEdad,Compania,Precio")] Producto producto)
        {
            string vistaParcial = await this.RenderViewToStringAsync("~/Views/Home/_modalCrearProducto.cshtml", producto);
            var httpClient = _httpClientFactory.CreateClient("productos");          

            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(producto);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage postResponse = await httpClient.PostAsync("Producto", httpContent);

                if (postResponse.IsSuccessStatusCode)
                {
                    var productos = await ObtenerListaDeProductos();
                    string vistaParcialListaProductos = await this.RenderViewToStringAsync("~/Views/Home/_listaProductos.cshtml", productos);
                    return Json(new RespuestaDeProceso()
                    {
                        Satisfactorio = true,
                        Mensaje = "Guardado correctamente",
                        Vista = vistaParcialListaProductos,
                        ProductosEnInventario = productos.Count()
                    });
                }
                else
                {
                    var productos = await ObtenerListaDeProductos();

                    return Json(new RespuestaDeProceso() { Satisfactorio = false, Mensaje = "Algo salio mal", Productos = productos, Vista = vistaParcial });
                }
            }
            else {
                var productos = await ObtenerListaDeProductos();
                return Json(new RespuestaDeProceso() { Satisfactorio = false, Mensaje = "Algo salio mal", Productos = productos, Vista = vistaParcial });
            }
        }

        public async Task<JsonResult> EditarProducto([Bind("Id,Nombre,Descripcion,RestriccionEdad,Compania,Precio")] Producto producto)
        {
            string vistaParcial = await this.RenderViewToStringAsync("~/Views/Home/_modalEditarProducto.cshtml", producto);
            var httpClient = _httpClientFactory.CreateClient("productos");

            if (ModelState.IsValid)
            {
                string json = JsonConvert.SerializeObject(producto);
                StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage postResponse = await httpClient.PostAsync("Producto/Update", httpContent);

                if (postResponse.IsSuccessStatusCode)
                {
                    var productos = await ObtenerListaDeProductos();
                    string vistaParcialListaProductos = await this.RenderViewToStringAsync("~/Views/Home/_listaProductos.cshtml", productos);
                    return Json(new RespuestaDeProceso()
                    {
                        Satisfactorio = true,
                        Mensaje = "Guardado correctamente",
                        Vista = vistaParcialListaProductos,
                        ProductosEnInventario = productos.Count()
                    });
                }
                else
                {
                    var productos = await ObtenerListaDeProductos();

                    return Json(new RespuestaDeProceso() { Satisfactorio = false, Mensaje = "Algo salio mal", Productos = productos, Vista = vistaParcial });
                }
            }
            else
            {
                var productos = await ObtenerListaDeProductos();
                return Json(new RespuestaDeProceso() { Satisfactorio = false, Mensaje = "Algo salio mal", Productos = productos, Vista = vistaParcial });
            }
        }

        public  ActionResult ObtenerVistaCrearProducto()
        {
            return PartialView("~/Views/Home/_modalCrearProducto.cshtml");
        }

        public async Task<ActionResult> ObtenerVistaEditarProducto(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("productos");
            object data = new
            {
                id = id,
            };
            var myContent = JsonConvert.SerializeObject(data);
            StringContent httpContent = new StringContent(myContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage postResponse = await httpClient.GetAsync("Producto/GetById?id=" + id);

            if (postResponse.IsSuccessStatusCode)
            {
                var result = postResponse.Content.ReadAsStringAsync().Result;
                var producto = JsonConvert.DeserializeObject<Producto>(result);
                return PartialView("~/Views/Home/_modalEditarProducto.cshtml", producto);
            }
            else
            {
                return PartialView("~/Views/Home/_modalEditarProducto.cshtml");
            }
        }
    

    public async Task<List<Producto>> ObtenerListaDeProductos()
        {
            var httpClient = _httpClientFactory.CreateClient("productos");

            List<Producto> productos = new List<Producto>();

            HttpResponseMessage response = await httpClient.GetAsync("Producto");

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;
                productos = JsonConvert.DeserializeObject<List<Producto>>(results);
            }
            return productos;
        }

        public async Task<ActionResult> EliminarProducto(int id)
        {
            var httpClient = _httpClientFactory.CreateClient("productos");
            object data = new
            {
                id = id,
            };
            var myContent = JsonConvert.SerializeObject(data);
            StringContent httpContent = new StringContent(myContent, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage postResponse = await httpClient.GetAsync("Producto/EliminarProducto?id="+id);

            if (postResponse.IsSuccessStatusCode)
            {
                var productos = await ObtenerListaDeProductos();
                string vistaParcialListaProductos = await this.RenderViewToStringAsync("~/Views/Home/_listaProductos.cshtml", productos);
                return Json(new RespuestaDeProceso()
                {
                    Satisfactorio = true,
                    Mensaje = "Guardado correctamente",
                    Vista = vistaParcialListaProductos,
                    ProductosEnInventario= productos.Count()
                });
            }
            else
            {
                return PartialView("~/Views/Home/_modalEditarProducto.cshtml");
            }
        }
    }
    public class RespuestaDeProceso
    {
        public bool Satisfactorio { get; set; }
        public string Mensaje { get; set; }
        public string Vista { get; set; }
        public int ProductosEnInventario { get; set; }
        public List<Producto> Productos { get; set; }


    }
}
