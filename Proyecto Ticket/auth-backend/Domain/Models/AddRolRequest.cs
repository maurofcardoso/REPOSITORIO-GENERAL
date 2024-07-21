namespace Domain.Models
{
    public class AddRolRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
        public List<AddPermissionToRolRequest> permissions { get; set; }
}
}
