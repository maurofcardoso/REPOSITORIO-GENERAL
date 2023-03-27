namespace Application.Exceptions
{
    public class ItemDuplicate : Exception
    {
        public readonly string message;

        public ItemDuplicate(string eMessage)
        {
            message = eMessage;
        }
    }
}
