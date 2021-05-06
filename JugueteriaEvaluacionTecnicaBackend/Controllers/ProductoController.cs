using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JugueteriaEvaluacionTecnicaBackend.Controllers
{
   
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        readonly IProductoRepository _productoRepositorio;
        public ProductoController(IProductoRepository productoRepositorio) {

            _productoRepositorio = productoRepositorio;
        }

        string[] lista = new[] {"uno", "dos", "tes" } ;
        [HttpGet]
        public IActionResult Get()
        {
            var productos = _productoRepositorio.GetAll();
            return Ok(productos);
        }
    }
}
