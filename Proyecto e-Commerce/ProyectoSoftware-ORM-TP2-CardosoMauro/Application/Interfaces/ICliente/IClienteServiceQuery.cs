using Domain.Entities;

namespace Application.Interfaces.ICliente
{
    public interface IClienteServiceQuery
    {
        Task<List<Cliente>> GetClientes();

        Task<Cliente> GetClienteById(int clienteId);
        
        Task<Carrito> GetCarritoActive (int clienteId);
    }
}
