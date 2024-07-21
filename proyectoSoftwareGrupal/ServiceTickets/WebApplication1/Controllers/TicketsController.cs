using Aplication.Interfaces.ITicket;
using Aplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;

namespace WebApplication1.Controllers
{
    [EnableCors("Policy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _services;

        public TicketsController(ITicketService services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            string jwt = Request.Headers["Authorization"];
            var result = _services.GetAll(jwt);
            return StatusCode(result.Codigo, result.Json);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            string jwt = Request.Headers["Authorization"];
            var result = _services.GetById(id, jwt);
            return StatusCode(result.Codigo, result.Json);
        }

        [HttpPost]
        public IActionResult Create(TicketRequest request)
        {
            string jwt = Request.Headers["Authorization"];
            var result = _services.Create(request, jwt);
            return StatusCode(result.Codigo, result.Json);
        }

        [HttpPut]
        public IActionResult UpdateStatus(TicketUpdateStatusRequest request)
        {
            string jwt = Request.Headers["Authorization"];
            var result = _services.UpdateStatus(request, jwt);
            return StatusCode(result.Codigo, result.Json);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(TicketUpdateCategoryRequest request,int id)
        {
            request.idTicket = id;
            string jwt = Request.Headers["Authorization"];
            var result = _services.UpdateCategory(request, jwt);
            return StatusCode(result.Codigo, result.Json);
        }
    }
}
