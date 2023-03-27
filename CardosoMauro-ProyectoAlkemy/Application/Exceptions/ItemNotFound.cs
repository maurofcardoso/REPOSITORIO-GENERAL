namespace Application.Exceptions
{
    public class ItemNotFound : Exception
    {
        public readonly string message;

        public ItemNotFound(string eMessage)
        {
            message = eMessage;
        }
    }
}
