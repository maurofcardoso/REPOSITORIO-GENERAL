namespace Aplication.Interfaces.Helpers
{
    public interface IPayload
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RolId { get; set; }
        public string Permissions { get; set; }
        public string Email { get; set; }
        public string AreaId { get; set; }
    }
}
