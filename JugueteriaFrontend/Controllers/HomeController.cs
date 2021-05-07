using JugueteriaFrontend.Helper;
using JugueteriaFrontend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<HomeController> _logger;
        ProductosAPI _apiProductos = new ProductosAPI();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<Producto> productos = new List<Producto>();
            HttpClient client = _apiProductos.Initial();
            HttpResponseMessage response = await client.GetAsync("Productos");

            if (response.IsSuccessStatusCode) 
            {
                var results = response.Content.ReadAsStringAsync().Result;
                productos = JsonConvert.De
            }
            var productos = new RequestToApi().ObtenerProductos();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
