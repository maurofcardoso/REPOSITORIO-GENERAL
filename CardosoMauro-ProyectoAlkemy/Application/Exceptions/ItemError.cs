namespace Application.Exceptions
{
    public class ItemError : Exception
    {
        public readonly string message;

        public ItemError(string eMessage)
        {
            message = eMessage;
        }
    }
}
