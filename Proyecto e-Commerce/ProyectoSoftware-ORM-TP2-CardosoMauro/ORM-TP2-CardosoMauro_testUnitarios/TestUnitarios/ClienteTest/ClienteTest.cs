using Application.Interfaces.ChangeModels;
using Application.Interfaces.ICarrito;
using Application.Interfaces.ICliente;
using Application.Models.CarritoModels;
using Application.Models.ClienteModels;
using Application.UseCase.Clientes;
using Domain.Entities;
using Moq;

namespace ORM_TP2_CardosoMauro_testUnitarios.TestUnitarios.ClienteTest
{
    public class ClienteTest
    {
        private readonly Mock<IChangeModels> _changeModels;
        private readonly Mock<IClienteCommand> _IclienteCommand;
        private readonly Mock<ICarritoServiceCommand> _carritoServiceCommand;
        private readonly Mock<IClienteServiceQuery> _IclienteServiceQuery;
        private readonly Mock<IClienteQuery> _clienteQuery;
        private readonly Mock<ICarritoServiceQuery> _carritoServiceQuery;
        private readonly Mock<Cliente> _cliente;
        private readonly Mock<ClienteRequest> _clienteRequest;
        private readonly Mock<CarritoRequest> _carritoRequest;

        private readonly ClienteServiceQuery _clienteServiceQuery;
        private readonly ClienteServiceCommand _clienteServiceCommand;

        public ClienteTest()
        {
            _changeModels = new Mock<IChangeModels>();
            _IclienteCommand = new Mock<IClienteCommand>();
            _carritoServiceCommand = new Mock<ICarritoServiceCommand>();
            _clienteQuery = new Mock<IClienteQuery>();
            _carritoServiceQuery = new Mock<ICarritoServiceQuery>();
            _cliente = new Mock<Cliente>();
            _IclienteServiceQuery = new Mock<IClienteServiceQuery>();
            _carritoRequest = new Mock<CarritoRequest>();

            _clienteRequest = new Mock<ClienteRequest>();
            _clienteServiceQuery = new ClienteServiceQuery(_clienteQuery.Object, _carritoServiceQuery.Object);
            _clienteServiceCommand = new ClienteServiceCommand(_changeModels.Object, _IclienteCommand.Object, _carritoServiceCommand.Object, _IclienteServiceQuery.Object, _clienteQuery.Object);
        }

        [Fact]
        public async Task GetClienteById_testIdLessZero ()
        {
            int input = -1;

            var response = await _clienteServiceQuery.GetClienteById(input);

            Assert.Null (response);
        }

        [Fact]
        public async Task GetClienteById_testIdGreaterZero ()
        {
            int input = 1;
            _clienteQuery.Setup(obj => obj.GetCliente(input)).ReturnsAsync(_cliente.Object);

            var response = _clienteServiceQuery.GetClienteById(input);

            await Assert.IsType<Task<Cliente>>(response);
        }

        [Fact]
        public async Task GetClienteById_testNullDB ()
        {
            int input = 1000;
            Cliente responseBD = null;
            _clienteQuery.Setup(obj => obj.GetCliente(input)).ReturnsAsync(responseBD);

            var response = await _clienteServiceQuery.GetClienteById(input);

            Assert.Null(response);
        }

        [Fact]
        public async Task CreateCliente_test ()
        {
            _changeModels.Setup(obj => obj.ClienteRequestChangeCliente(_clienteRequest.Object)).Returns(_cliente.Object);
            _IclienteCommand.Setup(obj => obj.InsertCliente(_cliente.Object));
            _carritoServiceCommand.Setup(obj => obj.CreateCarrito(_carritoRequest.Object));

            var response = _clienteServiceCommand.CreateCliente(_clienteRequest.Object);

            await Assert.IsType<Task<Cliente>>(response);
        }
    }
}
