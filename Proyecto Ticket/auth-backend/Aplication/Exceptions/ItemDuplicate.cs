namespace Aplication.Exceptions
{
    public class ItemDuplicate: Exception
    {
        public string mensaje;
        public ItemDuplicate(string mensaje)
        {
            this.mensaje = mensaje;
        }
    }
}
