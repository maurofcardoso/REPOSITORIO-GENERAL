using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response.ServiceUser
{
    public class RolPermissionResponse
    {
        public int RolId { get; set; }
        public int PermissionId { get; set; }

        public RolResponse Rol { get; set; }
        public PermissionResponse Permission { get; set; }
    }
}
