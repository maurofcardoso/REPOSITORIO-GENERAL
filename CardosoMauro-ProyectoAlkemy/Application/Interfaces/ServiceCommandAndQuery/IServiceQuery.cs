namespace Application.Interfaces.ServiceCommandAndQuery
{
    public interface IServiceQuery<T>
    {
        Task<IEnumerable<T>> GetListElement();

        Task<T> GetElement(int elementId);

        Task<T> exists(int elementId);
    }
}
