using Domain.Entities;
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

        [HttpGet("getById", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var producto = _productoRepositorio.GetById(id);
            return Ok(producto);
        }

        [HttpPost]
        public IActionResult Post(Producto producto)
        {
            try
            {
                _productoRepositorio.Add(producto);
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }

        }

        [HttpPost("update", Name = "Update")]
        public IActionResult Update(Producto producto)
        {
            try
            {
                _productoRepositorio.Update(producto);

                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
    }
}
