using Application.Models.ClienteModels;
using Domain.Entities;

namespace Application.Interfaces.ICliente
{
    public interface IClienteServiceCommand
    {
        Task<Cliente> CreateCliente(ClienteRequest clienteRequest);

        Task<Cliente> DeleteCliente(Cliente cliente);

        Task<Cliente> UpdateCliente(ClienteRequest clienteRequest, int clienteId);

        Task<Cliente> AddCarritoActive(int clienteId);
    }
}
