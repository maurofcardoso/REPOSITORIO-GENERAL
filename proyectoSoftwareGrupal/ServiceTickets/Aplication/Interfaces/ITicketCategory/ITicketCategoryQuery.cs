using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketCategory
{
    public interface ITicketCategoryQuery
    {
        List<TicketCategory> GetListTicketCategory();

        TicketCategory GetTicketCategoryById(int id);
    }
}
