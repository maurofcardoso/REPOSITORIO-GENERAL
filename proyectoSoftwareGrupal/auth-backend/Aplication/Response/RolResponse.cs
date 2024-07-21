using Domain.Models;

namespace Aplication.Response
{
    public class RolResponse
    {
        public int RolId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public List<PermissionToRol> Permissions { get; set; }
    }
}