using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Response.ServiceUser
{
    public class RolResponse
    {
        public int RolId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<RolPermissionResponse> permissions { get; set; }
    }
}
