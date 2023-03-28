using Application.Interfaces.ServicesPresentation;
using Application.Models.ProductoModels;
using Microsoft.AspNetCore.Mvc;

namespace ORM_TP2_CardosoMauro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productosController : ControllerBase
    {
        private readonly IServicesPresentation _servicesPresentation;

        public productosController(IServicesPresentation servicesPresentation)
        {
            _servicesPresentation = servicesPresentation;
        }

        [HttpPost]
        public async Task<ActionResult> GetByName([FromQuery] string? name, [FromQuery] bool? sort)
        {
            try
            {
                List<ProductoResponse> productos = await _servicesPresentation.EndPointGetProductoByName (name, sort);
                if (productos == null)
                {
                    return new JsonResult(productos) { StatusCode = 404 };
                }
                return new JsonResult (productos) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                ProductoResponse productoResponse = await _servicesPresentation.EndPointGetProductoById (id);
                if (productoResponse == null | id > int.MaxValue)
                {
                    return new JsonResult(productoResponse) { StatusCode = 404 };
                }
                return new JsonResult(productoResponse) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }
    }
}
