using Aplication.Interfaces.ITicketComment;
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
    public class TicketCommentController : ControllerBase
    {
        private readonly ITicketCommentService _services;

        public TicketCommentController(ITicketCommentService services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult CreateTicketComment(TicketCommentRequest request)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.CreateTicketComment(request, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTicketComments(TicketCommentRequestGet request)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.GetAllTicketComments(request.idTicket, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicketComment(int id, TicketCommentUpdateRequest request)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.UpdateTicketComment(id, request, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTicketComment(int id)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.DeleteTicketComment(id, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

    }
}
