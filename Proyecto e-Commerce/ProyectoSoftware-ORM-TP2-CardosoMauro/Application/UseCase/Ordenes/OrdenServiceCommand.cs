using Application.Interfaces.ICliente;
using Application.Interfaces.IOrden;
using Application.Models.OrdenModels;
using Domain.Entities;

namespace Application.UseCase.Ordenes
{
    public class OrdenServiceCommand : IOrdenServiceCommand
    {
        private readonly IOrdenCommand _command;
        private readonly IClienteServiceQuery _clienteServiceQuery;

        public OrdenServiceCommand(IOrdenCommand command, IClienteServiceQuery clienteServiceQuery)
        {
            _command = command;
            _clienteServiceQuery = clienteServiceQuery;
        }

        public async Task<Orden> CreateOrden(int clienteId)
        {
            if (clienteId < 1)
            {
                return null;
            }
            Carrito carrito = await _clienteServiceQuery.GetCarritoActive(clienteId);
            if (carrito == null)
            {
                return null;
            }
            if (carrito.ListCarritoProductos.Count == 0)
            {
                return null;
            }
            var orden = new Orden
            {
                OrdenId = Guid.NewGuid(),
                CarritoId = carrito.CarritoId,
                Fecha = DateTime.Now,
                Total = Convert.ToDecimal(this.OrdenGetTotals(carrito)),
            };
            await _command.InsertOrden(orden);
            return orden;
        }

        public async Task<Orden> DeleteOrden(Orden orden)
        {
            if (orden == null)
            {
                return null;
            }
            await _command.RemoveOrden(orden);
            return orden;
        }

        public async Task<Orden> UpdateOrden(OrdenRequest ordenRequest, Guid ordenId)
        {
            if (ordenRequest == null | ordenId == Guid.Empty)
            {
                return null;
            }
            var orden = new Orden
            {
                OrdenId = ordenId,
            };
            await _command.UpdateOrden(orden);
            return orden;
        }

        public decimal OrdenGetTotals(Carrito carrito)
        {
            decimal total = 0;
            if (carrito == null)
            {
                return -1;
            }
            foreach (CarritoProducto x in carrito.ListCarritoProductos)
            {
                if (x.Cantidad != 0)
                {
                    total += (x.Cantidad * x.Producto.Precio);
                }
            }
            return total;
        }
    }
}
