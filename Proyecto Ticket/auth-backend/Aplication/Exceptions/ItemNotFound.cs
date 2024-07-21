namespace Aplication.Exceptions
{
    public class ItemNotFound: Exception
    {
        public string mensaje;
        public ItemNotFound(string mensaje)
        {
            this.mensaje = mensaje;
        }
    }
}
