using Aplication.Interfaces.IArea;
using Aplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [EnableCors("Policy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _services;

        public AreaController(IAreaService services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> CreateArea(AreaCreateRequest request)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.CreateArea(request, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpGet]
        public IActionResult GetAllAreas()
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.GetAllAreas(jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpPut]
        public IActionResult UpdateArea(int id, AreaUpdateRequest request)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.UpdateArea(id, request, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetAreaById(int id)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.GetAreaById(id);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

    }
}
