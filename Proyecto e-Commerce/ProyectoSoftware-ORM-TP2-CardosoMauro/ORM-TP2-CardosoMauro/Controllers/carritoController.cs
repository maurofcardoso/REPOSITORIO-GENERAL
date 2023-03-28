using Application.Interfaces.ServicesPresentation;
using Application.Models.CarritoModels;
using Application.Models.ResponseCompleto;
using Microsoft.AspNetCore.Mvc;

namespace ORM_TP2_CardosoMauro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class carritoController : ControllerBase
    {
        private readonly IServicesPresentation _servicesPresentation;

        public carritoController(IServicesPresentation servicesPresentation)
        {
            _servicesPresentation = servicesPresentation;
        }

        [HttpPatch]
        public async Task<ActionResult> AddProducto(BodyCarritoModels bodyCarritoModels)
        {
            try
            {
                CarritoResponse carritoResponse = await _servicesPresentation.EndPointAddProducto(bodyCarritoModels);
                if (carritoResponse == null)
                {
                    return new JsonResult(null) { StatusCode = 404 };
                }
                return new JsonResult(carritoResponse) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCarrito(BodyCarritoModels bodyCarritoModels)
        {
            try
            {
                ProductoResponseCompleto carritoResponse = await _servicesPresentation.EndPointUpdateCarrito(bodyCarritoModels);
                if (carritoResponse == null)
                {
                    return new JsonResult(null) { StatusCode = 400 };
                }
                return new JsonResult(carritoResponse) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpDelete("{clientId:Int}/{productId:Int}")]
        public async Task<ActionResult> DeleteCarrito(int clientId, int productId)
        {
            try
            {
                bool carrito = await _servicesPresentation.EndPointDeleteProducto(clientId, productId);
                if (carrito == false)
                {
                    return new JsonResult(carrito) { StatusCode = 404 };
                }
                return new JsonResult(carrito) { StatusCode = 200 };
            }
            catch(Exception e)
            {
                return new JsonResult(false) { StatusCode = 500 };
            }
        }

        [HttpGet("{clientId:int}")]
        public async Task<ActionResult> GetById(int clientId)
        {
            try
            {
                CarritoResponse clienteResponse = await _servicesPresentation.EndPointGetByIdCarrito (clientId);
                if (clienteResponse == null | clientId > int.MaxValue)
                {
                    return new JsonResult(clienteResponse) { StatusCode = 404 };
                }
                return new JsonResult(clienteResponse) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }
    }
}
