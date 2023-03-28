using Application.Interfaces.ServicesPresentation;
using Application.Models.ClienteModels;
using Application.Models.ResponseCompleto;
using Microsoft.AspNetCore.Mvc;

namespace ORM_TP2_CardosoMauro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientesController : ControllerBase
    {
        private readonly IServicesPresentation _servicesPresentation;

        public clientesController(IServicesPresentation servicesPresentation)
        {
            _servicesPresentation = servicesPresentation;
        }

        [HttpPost]
        public async Task<ActionResult> CreateCliente(ClienteRequest request)
        {
            try
            {
                ClienteResponse cliente = await _servicesPresentation.EndPointRegistrarCliente(request);
                if (cliente == null)
                {
                    return new JsonResult(cliente) { StatusCode = 400 };
                }
                return new JsonResult(cliente) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }            
        }

        [HttpGet("{clientId:int}")]
        public async Task<ActionResult> GetById(int clientId)
        {
            try
            {
                ClienteResponseCompleto clienteResponse = await _servicesPresentation.EndPointGetCliente(clientId);
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
