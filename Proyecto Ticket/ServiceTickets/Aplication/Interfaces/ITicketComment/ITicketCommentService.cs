using Aplication.Models;
using Aplication.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketComment
{
    public interface ITicketCommentService
    {
        ResponseGral CreateTicketComment(TicketCommentRequest request, string jwt);
        ResponseGral UpdateTicketComment(int idTicketComment, TicketCommentUpdateRequest request, string jwt);
        ResponseGral DeleteTicketComment(int idTicketComment, string jwt);
        ResponseGral GetAllTicketComments(int TicketId, string jwt);
    }
}
