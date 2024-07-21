using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response
{
    public class UserResponseJwt
    {
        public int UserId { get; set; }
        public string NameUser { get; set; }
        public string Email { get; set; }
        public int RolId { get; set; }
        public int AreaId { get; set; }
        public List<string> Permissions { get; set; }
    }
}
