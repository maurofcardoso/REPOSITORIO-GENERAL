using Application.Exceptions;
using Application.Interfaces.Mappers;
using Application.Interfaces.SendEmails;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Request;
using Application.Models.Response;
using Application.Tools;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoAlkemy.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IServiceQueryWithUser<User> _userService;
        private readonly IMapperDisney _mapper;
        private readonly ISendEmail _sendEmail;

        public AuthenticationController(IServiceQueryWithUser<User> userService, IMapperDisney mapper, ISendEmail sendEmail)
        {
            _userService = userService;
            _mapper = mapper;
            _sendEmail = sendEmail;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserAuthRequest userAuthRequest)
        {
            if (userAuthRequest == null)
            {
                return new JsonResult(userAuthRequest) { StatusCode = 404 };
            }
            try
            {
                PayloadUserResponse usuarioAuth = await _userService.GetUserAuth(userAuthRequest.Email, userAuthRequest.Password);

                if (usuarioAuth == null)
                {
                    return new JsonResult(usuarioAuth) { StatusCode = 404 };
                }

                return new JsonResult(usuarioAuth) { StatusCode = 200 };
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return new JsonResult(userRequest) { StatusCode = 404 };
            };
            try
            {
                User user = await _userService.CreateElement(userRequest);

                if (user == null)
                {
                    return new JsonResult(user) { StatusCode = 404 };
                }

                UserResponse userResponse = _mapper.UserAtResponse(user);

                await _sendEmail.GetEmail(userRequest.Email, userRequest.Name);
                return new JsonResult(userResponse) { StatusCode = 200 };

            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }
    }
}
