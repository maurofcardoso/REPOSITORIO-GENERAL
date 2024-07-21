using Aplication.Response;
using Aplication.Response.ServiceUser;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IArea
{
    public interface IAreaQuery
    {
        List<Area> GetListArea();
        Area GetAreaById(int id);
        UserResponse GetUser(int id);
    }
}
