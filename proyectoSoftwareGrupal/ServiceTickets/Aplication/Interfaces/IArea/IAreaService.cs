using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.IArea
{
    public interface IAreaService
    {
        ResponseGral CreateArea(AreaCreateRequest request, string jwt);
        ResponseGral UpdateArea(int idArea, AreaUpdateRequest request, string jwt);
        ResponseGral GetAllAreas(string jwt);
        ResponseGral GetAreaById(int idArea);
        void AddTicketCategory(int idArea, TicketCategory ticketCategory);
    }
}
