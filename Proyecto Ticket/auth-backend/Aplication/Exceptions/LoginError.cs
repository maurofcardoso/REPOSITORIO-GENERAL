namespace Aplication.Exceptions
{
    public class LoginError:Exception
    {
        public string mensaje;
        public LoginError(string mensaje)
        {
            this.mensaje = mensaje;
        }
    }
}
