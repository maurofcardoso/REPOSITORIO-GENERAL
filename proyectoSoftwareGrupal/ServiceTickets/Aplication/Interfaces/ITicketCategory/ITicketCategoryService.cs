using Aplication.Models;
using Aplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketCategory
{
    public interface ITicketCategoryService
    {
        ResponseGral CreateTicketCategory(TicketCategoryRequest request, string jwt);
        ResponseGral UpdateTicketCategory(int idTicketCategory, TicketCategoryPutRequest request, string jwt);
        ResponseGral GetAllTicketCategories(string jwt);
        ResponseGral GetTicketCategoryById(int idTicketCategory, string jwt);
    }
}
