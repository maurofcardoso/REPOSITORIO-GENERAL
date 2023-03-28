using Application.Interfaces.ServicesPresentation;
using Application.Models.OrdenModels;
using Application.Models.ResponseCompleto;
using Microsoft.AspNetCore.Mvc;

namespace ORM_TP2_CardosoMauro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ordenController : ControllerBase
    {
        private readonly IServicesPresentation _servicesPresentation;

        public ordenController(IServicesPresentation servicesPresentation)
        {
            _servicesPresentation = servicesPresentation;
        }

        [HttpPost("{clientId:Int}")]
        public async Task<ActionResult> CreateOrden(int clientId)
        {
            try
            {
                OrdenResponseCompleto ordenResponse = await _servicesPresentation.EndPointCreateOrden(clientId);
                if(ordenResponse == null | clientId > int.MaxValue)
                {
                    return new JsonResult(ordenResponse) { StatusCode = 400 };
                }
                return new JsonResult(ordenResponse) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpPost]
        public async Task<ActionResult> GetOrdenByDate([FromQuery] DateTime? from, [FromQuery] DateTime? to)
        {
            try
            {
                BalanceComplete listOrdenResponse = await _servicesPresentation.EndPointBalanceOfDay(from, to);
                if (listOrdenResponse == null)
                {
                    return new JsonResult(listOrdenResponse) { StatusCode = 404 };
                }
                return new JsonResult(listOrdenResponse) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }
    }
}
