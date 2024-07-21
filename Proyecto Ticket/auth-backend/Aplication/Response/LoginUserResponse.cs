namespace Aplication.Response
{
    public class LoginUserResponse
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public string Email { get; set; }        
        public Boolean ActiveUser { get; set; }
        public RolResponse Rol { get; set; } 
        public int  AreaId { get; set; }
        public string Token { get; set; }
    }
}
