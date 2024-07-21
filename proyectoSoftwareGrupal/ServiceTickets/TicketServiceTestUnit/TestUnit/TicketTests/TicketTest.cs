using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplication.Interfaces.IArea;
using Aplication.Interfaces.ITicket;
using Aplication.Mappers;
using Aplication.Models;
using Aplication.Response;
using Aplication.Response.ServiceUser;
using Aplication.UseCase;
using Infrastructure.Command;
using Moq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace TicketServiceTestUnit.TestUnit.TicketTests
{
    public class TicketTest
    {
        private readonly Mock<TicketRequest> _ticketRequest;
        private readonly Mock<ITicketCommand> _ticketCommand;
        private readonly Mock<ITicketQuery> _ticketQuery;
        private readonly Mock<IAreaQuery> _areaQuery;
        private readonly Mock<ITicketLogCommand> _ticketLogCommand;
        private readonly Mock<UserResponseJwt> _userResponseJwt;
        private readonly Mock<Mapper> _mapper;
        private readonly Mock<ResponseGral> _responseGral;


        private readonly ITicketService _ticketService;

        public TicketTest ()
        {
            _ticketRequest = new Mock<TicketRequest>();
            _ticketCommand = new Mock<ITicketCommand>();
            _ticketQuery = new Mock<ITicketQuery>();
            _areaQuery = new Mock<IAreaQuery>();
            _ticketLogCommand = new Mock<ITicketLogCommand>();
            _userResponseJwt = new Mock<UserResponseJwt>();
            _mapper = new Mock<Mapper>();
            _responseGral = new Mock<ResponseGral>();

            _ticketService = new TicketService(_ticketCommand.Object, _ticketQuery.Object, _areaQuery.Object, _ticketLogCommand.Object);
        }
        public static string CeateTokensTest (int userId, string userName, int rolId, string permisions, string email, string areaId)
        {
            int UserId = userId;
            string UserName = userName;
            int RolId = rolId;
            string Permissions = permisions;
            string Email = email;
            string AreaId = areaId;

            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, UserId.ToString()),
                new Claim(ClaimTypes.Name, UserName),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Role, RolId.ToString()),
                new Claim(ClaimTypes.Gender, Permissions),
                new Claim(ClaimTypes.Actor, AreaId),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Inter202211111111"));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credenciales,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [Fact]
        public void Create_Test_NotPermisions()
        {
            //BodyCarritoModels bodyCarritoModels = null;

            //var response = await _carritoServiceCommand.AddProducto(bodyCarritoModels);

            //Assert.Null(response);
            //await Assert.IsType<Task<Carrito>>(response);
            //Assert.IsType<Carrito>(response);
            //Assert.False(response);
            //_clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(carrito);
            //_productoServiceQuery.Setup(obj => obj.GetProductos()).ReturnsAsync(_listaProductos.Object);
            var mockToken = CeateTokensTest(100, "admin", 1, "1", "maurofcardoso@hotmail.com", "1");

            ResponseGral response = _ticketService.Create(_ticketRequest.Object, mockToken);

            Assert.True(response.Codigo == 400, "El usuario indicado NO posee el permiso de Crear Tickets");
        }

    }

}
