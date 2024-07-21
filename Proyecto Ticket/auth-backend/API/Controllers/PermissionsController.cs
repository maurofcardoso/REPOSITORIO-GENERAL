using Aplication.Exceptions;
using Aplication.Interfaces;
using Aplication.Response;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly IPermissionServices _permissionServices;

        public PermissionsController(IPermissionServices permissionServices)
        {
            _permissionServices = permissionServices;
        }

        [EnableCors("Policy")]
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _permissionServices.GetAll();
            return new JsonResult(result);
        }

        [EnableCors("Policy")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult Get(int id)
        {
            try
            {
                var result = _permissionServices.Get(id);
                return new JsonResult(result);
            }
            catch (ItemNotFound)
            {
                ErrorResponse error = new ErrorResponse()
                {
                    Status = 404,
                    Title = "Permiso inexistente",
                    Message = "No existe un permiso asociado al ID "+ id,
                    Date = DateTime.Now.ToString(),
                    Path = "api/Permissions/"+id
                };

                return NotFound(error);
            }
        }

        [EnableCors("Policy")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<IActionResult> Add(AddPermissionRequest request)
        {
            if (request == null)
                return NotFound();

            try
            {
                var result = await _permissionServices.Add(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (ItemDuplicate)
            {
                ErrorResponse error = new ErrorResponse()
                {
                    Status = 400,
                    Title = "Elemento Duplicado",
                    Message = "El permiso ya fue dado de alta con anterioridad.",
                    Date = DateTime.Now.ToString(),
                    Path = "api/Permissions"
                };

                return BadRequest(error);
            }
        }
    }
}
