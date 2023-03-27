using Domain.Entities;

namespace Application.Interfaces.ServiceCommandAndQuery
{
    public interface IServiceCommand<TR, T>
    {
        Task<T> CreateElement(TR elementRequest);

        Task<T> UpdateElement(TR elementRequest, int elementId);

        Task<T> DeleteElement(int elementId);
    }
}
