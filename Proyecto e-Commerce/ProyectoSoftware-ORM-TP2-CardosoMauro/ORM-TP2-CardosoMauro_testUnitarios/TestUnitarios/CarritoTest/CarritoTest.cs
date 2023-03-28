using Application.Interfaces.ChangeModels;
using Application.Interfaces.ICarrito;
using Application.Interfaces.ICarritoProducto;
using Application.Interfaces.ICliente;
using Application.Interfaces.IProducto;
using Application.Models.CarritoModels;
using Application.Models.CarritoProductoModels;
using Application.Models.ResponseCompleto;
using Application.UseCase.Carritos;
using Domain.Entities;
using Moq;

namespace ORM_TP2_CardosoMauro_testUnitarios.TestUnitarios.CarritoTest
{
    public class CarritoTest
    {
        private readonly Mock<ICarritoCommand> _carritoCommand;
        private readonly Mock<IClienteServiceQuery> _clienteServiceQuery;
        private readonly Mock<ICarritoProductoServiceCommand> _carritoProductoServiceCommand;
        private readonly Mock<IProductoServiceQuery> _productoServiceQuery;
        private readonly Mock<IChangeModels> _changeModels;
        private readonly Mock<BodyCarritoModels> _bodyCarritoModels;
        private readonly Mock<Carrito> _carrito;
        private readonly Mock<CarritoProducto> _carritoProducto;
        private readonly Mock<Producto> _producto;
        private readonly Mock<Cliente> _cliente;
        private readonly Mock<List<Producto>> _listaProductos;
        private readonly Mock<List<Cliente>> _listaClientes;
        private readonly Mock<CarritoRequest> _carritoRequest;
        private readonly Mock<ProductoResponseCompleto> _productoResponseCompleto;

        private readonly CarritoServiceCommand _carritoServiceCommand;

        public CarritoTest()
        {
            _carritoCommand = new Mock<ICarritoCommand>();
            _clienteServiceQuery = new Mock<IClienteServiceQuery>();
            _carritoProductoServiceCommand = new Mock<ICarritoProductoServiceCommand>();
            _productoServiceQuery = new Mock<IProductoServiceQuery>();
            _changeModels = new Mock<IChangeModels>();
            _bodyCarritoModels = new Mock<BodyCarritoModels>();
            _carrito = new Mock<Carrito>();
            _carritoProducto = new Mock<CarritoProducto>();
            _listaProductos = new Mock<List<Producto>>();
            _producto = new Mock<Producto>();
            _cliente = new Mock<Cliente>();
            _carritoRequest = new Mock<CarritoRequest>();
            _listaClientes = new Mock<List<Cliente>>();
            _productoResponseCompleto = new Mock<ProductoResponseCompleto>();

            _carritoServiceCommand = new CarritoServiceCommand(_carritoCommand.Object, _clienteServiceQuery.Object, _carritoProductoServiceCommand.Object, _productoServiceQuery.Object, _changeModels.Object);
        }

        //carritoServiceCommand

        [Fact]
        public async Task AddProducto_testBodyModelsIsNull()
        {
            BodyCarritoModels bodyCarritoModels = null;

            var response = await _carritoServiceCommand.AddProducto(bodyCarritoModels);

            Assert.Null(response);
        }

        [Fact]
        public async Task AddProducto_testCarritoIsNull()
        {
            Carrito carrito = null;
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(carrito);
            _productoServiceQuery.Setup(obj => obj.GetProductos()).ReturnsAsync(_listaProductos.Object);

            var response = await _carritoServiceCommand.AddProducto(_bodyCarritoModels.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task AddProducto_testListProductIsNull()
        {
            List<Producto> productos = null;
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);
            _productoServiceQuery.Setup(obj => obj.GetProductos()).ReturnsAsync(productos);

            var response = await _carritoServiceCommand.AddProducto(_bodyCarritoModels.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task AddProducto_testProductIdExist()
        {
            _bodyCarritoModels.Object.productId = 1;
            _carritoProducto.Object.ProductoId = 1;
            _carrito.Object.ListCarritoProductos.Add(_carritoProducto.Object);
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);
            _productoServiceQuery.Setup(obj => obj.GetProductos()).ReturnsAsync(_listaProductos.Object);

            var response = await _carritoServiceCommand.AddProducto(_bodyCarritoModels.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task AddProducto_testNotExistProduct()
        {
            _bodyCarritoModels.Object.productId = 1;
            _carrito.Object.ListCarritoProductos.Add(_carritoProducto.Object);
            _listaProductos.Object.Add(_producto.Object);
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);
            _productoServiceQuery.Setup(obj => obj.GetProductos()).ReturnsAsync(_listaProductos.Object);

            var response = await _carritoServiceCommand.AddProducto(_bodyCarritoModels.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task AddProducto_testAddProductoOK()
        {
            _bodyCarritoModels.Object.productId = 1;
            _producto.Object.ProductoId = 1;
            _carrito.Object.ListCarritoProductos.Add(_carritoProducto.Object);
            _listaProductos.Object.Add(_producto.Object);
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);
            _productoServiceQuery.Setup(obj => obj.GetProductos()).ReturnsAsync(_listaProductos.Object);
            _carritoProductoServiceCommand.Setup(obj => obj.CreateCarritoProducto(It.IsAny<CarritoProductoRequest>())).ReturnsAsync(_carritoProducto.Object); ;

            var response = _carritoServiceCommand.AddProducto(_bodyCarritoModels.Object);

            await Assert.IsType<Task<Carrito>>(response);
        }

        [Fact]
        public async Task CreateCarrito_testCarritoRequestIsNull()
        {
            CarritoRequest carritoRequest = null;

            var response = await _carritoServiceCommand.CreateCarrito(carritoRequest);

            Assert.Null(response);
        }

        [Fact]
        public async Task CreateCarrito_testCarritoRequestIs()
        {
            _carritoCommand.Setup(obj => obj.InsertCarrito(_carrito.Object));

            var response = await _carritoServiceCommand.CreateCarrito(_carritoRequest.Object);

            Assert.IsType<Carrito>(response);
        }

        [Fact]
        public async Task DeleteProductoOfCarrito_testClienteIdIsNull()
        {
            int inputClienteId = -1;
            int inputProductoId = 1;

            var response = await _carritoServiceCommand.DeleteProductoOfCarrito(inputClienteId, inputProductoId);

            Assert.False(response);
        }

        [Fact]
        public async Task DeleteProductoOfCarrito_testProductoIdIsNull()
        {
            int inputClienteId = 1;
            int inputProductoId = -1;

            var response = await _carritoServiceCommand.DeleteProductoOfCarrito(inputClienteId, inputProductoId);

            Assert.False(response);
        }

        [Fact]
        public async Task DeleteProductoOfCarrito_testCarritoIsNull()
        {
            int inputClienteId = 1;
            int inputProductoId = 1;
            Carrito carrito = null;
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(carrito);

            var response = await _carritoServiceCommand.DeleteProductoOfCarrito(inputClienteId, inputProductoId);

            Assert.False(response);
        }

        [Fact]
        public async Task DeleteProductoOfCarrito_testListCarritoProductoIsZero()
        {
            int inputClienteId = 1;
            int inputProductoId = 1;
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);

            var response = await _carritoServiceCommand.DeleteProductoOfCarrito(inputClienteId, inputProductoId);

            Assert.False(response);
        }

        [Fact]
        public async Task DeleteProductoOfCarrito_testProductoNoExistInCarrito()
        {
            int inputClienteId = 1;
            int inputProductoId = 1;
            _carrito.Object.ListCarritoProductos.Add(_carritoProducto.Object);
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);

            var response = await _carritoServiceCommand.DeleteProductoOfCarrito(inputClienteId, inputProductoId);

            Assert.False(response);
        }

        [Fact]
        public async Task DeleteProductoOfCarrito_testDeleteProductoOfCarritoOK ()
        {
            int inputClienteId = 1;
            int inputProductoId = 1;
            _carritoProducto.Object.ProductoId = 1;
            _carrito.Object.ListCarritoProductos.Add(_carritoProducto.Object);
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);

            var response = await _carritoServiceCommand.DeleteProductoOfCarrito(inputClienteId, inputProductoId);

            Assert.True(response);
        }

        [Fact]
        public async Task UpdateCarritoCantidad_testCarritoModelIsNull ()
        {
            BodyCarritoModels bodyCarritoModels = null;

            var response = await _carritoServiceCommand.UpdateCarritoCantidad(bodyCarritoModels);

            Assert.Null(response);
        }

        [Fact]
        public async Task UpdateCarritoCantidad_testCarritoIsNull ()
        {
            Carrito carrito = null;
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(carrito);

            var response = await _carritoServiceCommand.UpdateCarritoCantidad(_bodyCarritoModels.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task UpdateCarritoCantidad_testNoExistClienteOListaVaciaClientes ()
        {
            _bodyCarritoModels.Object.clientId = 1;
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);
            _clienteServiceQuery.Setup(obj => obj.GetClientes()).ReturnsAsync (_listaClientes.Object);

            var response = await _carritoServiceCommand.UpdateCarritoCantidad(_bodyCarritoModels.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task UpdateCarritoCantidad_testProductNoExistInCarrito ()
        {
            _cliente.Object.ClienteId = 1;
            _bodyCarritoModels.Object.clientId = 1;
            _bodyCarritoModels.Object.productId = 1;
            _listaClientes.Object.Add(_cliente.Object);
            _carritoProducto.Object.ProductoId = 2;
            _carrito.Object.ListCarritoProductos.Add(_carritoProducto.Object);
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);
            _clienteServiceQuery.Setup(obj => obj.GetClientes()).ReturnsAsync(_listaClientes.Object);

            var response = await _carritoServiceCommand.UpdateCarritoCantidad(_bodyCarritoModels.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task UpdateCarritoCantidad_testProductarrito ()
        {
            _cliente.Object.ClienteId = 1;
            _bodyCarritoModels.Object.clientId = 1;
            _bodyCarritoModels.Object.productId = 1;
            _carritoProducto.Object.ProductoId = 1;
            _listaClientes.Object.Add(_cliente.Object);
            _carrito.Object.ListCarritoProductos.Add(_carritoProducto.Object);
            _clienteServiceQuery.Setup(obj => obj.GetCarritoActive(It.IsAny<int>())).ReturnsAsync(_carrito.Object);
            _clienteServiceQuery.Setup(obj => obj.GetClientes()).ReturnsAsync(_listaClientes.Object);
            _productoServiceQuery.Setup(obj => obj.GetProductoById(It.IsAny<int>())).ReturnsAsync(_producto.Object);
            _carritoProductoServiceCommand.Setup(obj => obj.UpdateCarritoProducto(_carritoProducto.Object));
            _changeModels.Setup(obj => obj.ProductoResponseCompleto(_producto.Object, It.IsAny<int>())).Returns(_productoResponseCompleto.Object) ;

            var response = _carritoServiceCommand.UpdateCarritoCantidad(_bodyCarritoModels.Object);

            await Assert.IsType<Task<ProductoResponseCompleto>>(response);
        }

        //carritoServiceQuery
    }
}