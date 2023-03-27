namespace Application.Interfaces.CommandAndQuery
{
    public interface IQuery<T>
    {
        Task<IEnumerable<T>> GetList();

        Task<T> GetById(int elementId);
    }
}
