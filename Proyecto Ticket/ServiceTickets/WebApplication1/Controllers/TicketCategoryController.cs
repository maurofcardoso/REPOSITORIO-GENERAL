using Aplication.Interfaces.IArea;
using Aplication.Interfaces.ITicketCategory;
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
    public class TicketCategoryController : ControllerBase
    {
        private readonly ITicketCategoryService _services;

        public TicketCategoryController(ITicketCategoryService services)
        {
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicketCategory(TicketCategoryRequest request)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.CreateTicketCategory(request, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpGet]
        public IActionResult GetAllTicketCategory()
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.GetAllTicketCategories(jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicketCategory(int id, TicketCategoryPutRequest request)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.UpdateTicketCategory(id, request, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTicketCategoryById(int id)
        {
            string jwt = Request.Headers["Authorization"];
            try
            {
                var result = _services.GetTicketCategoryById(id, jwt);
                return StatusCode(result.Codigo, result.Json);
            }
            catch (Exception)
            {
                return new JsonResult(null) { StatusCode = 500 };
            }
        }
    }
}
