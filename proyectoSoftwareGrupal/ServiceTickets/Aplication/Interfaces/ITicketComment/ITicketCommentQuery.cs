using Aplication.Response.ServiceUser;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketComment
{
    public interface ITicketCommentQuery
    {
        List<TicketComment> GetListTicketComment(int TicketId);
        TicketComment GetTicketCommentById(int TicketCommentId);
        UserResponse GetUser(int id);
    }
}
