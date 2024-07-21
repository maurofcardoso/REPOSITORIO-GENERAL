using Aplication.Exceptions;
using Aplication.Interfaces;
using Aplication.Response;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [EnableCors("Policy")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolServices _rolServices;

        public RolesController(IRolServices rolServices)
        {
            _rolServices = rolServices;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _rolServices.GetAll();
            return new JsonResult(result);
        }

        [EnableCors("Policy")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            var result = _rolServices.Get(id);

            if (result == null)
                return NotFound();

            return new JsonResult(result);
        }

        [EnableCors("Policy")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddRolRequest request)
        {
            if (request == null)
                return NotFound();

            try
            {
                var result = await _rolServices.Add(request);
                return new JsonResult(result) { StatusCode = 201 };

            }
            catch (ItemDuplicate)
            {
                ErrorResponse error = new ErrorResponse()
                {
                    Status = 400,
                    Title = "Elemento Duplicado",
                    Message = "El rol ya fue dado de alta con anterioridad.",
                    Date = DateTime.Now.ToString(),
                    Path = "api/Roles"
                };

                return BadRequest(error);
            }
        }
        
    }
}
