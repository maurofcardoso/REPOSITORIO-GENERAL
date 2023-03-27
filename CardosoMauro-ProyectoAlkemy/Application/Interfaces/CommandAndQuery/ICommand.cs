namespace Application.Interfaces.CommandAndQuery
{
    public interface ICommand<T>
    {
        Task Insert(T element);

        Task Update(T element);

        Task Remove(T element);
    }
}
