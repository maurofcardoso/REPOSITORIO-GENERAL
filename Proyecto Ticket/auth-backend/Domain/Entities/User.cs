namespace Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string DNI { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Boolean ActiveUser { get; set; }
        public Rol Rol { get; set; }
        public int RolId { get; set; }
        public int AreaId { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
        public int CreateUser { get; set; }
        public int UpdateUser { get; set; }    
    }
}
