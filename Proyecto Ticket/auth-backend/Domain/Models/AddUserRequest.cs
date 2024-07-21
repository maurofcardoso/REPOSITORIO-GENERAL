namespace Aplication.Models
{
    public class AddUserRequest
    {        
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }   
        public int RolId { get; set; }
        public int AreaId { get; set; }
    }
}
