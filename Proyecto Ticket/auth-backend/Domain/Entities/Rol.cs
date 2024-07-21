namespace Domain.Entities
{
    public class Rol
    {   
        public int RolId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<RolPermission> RolPermissions { get; set; }
        public List<User> Users { get; set; }
    }
}
