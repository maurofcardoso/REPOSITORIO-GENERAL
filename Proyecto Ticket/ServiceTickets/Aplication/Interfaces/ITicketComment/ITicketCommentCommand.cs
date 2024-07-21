using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Interfaces.ITicketComment
{
    public interface ITicketCommentCommand
    {
        void CreateTicketComment(TicketComment ticketComment);

        Task UpdateTicketComment(TicketComment ticketComment);

        void RemoveTicketComment(TicketComment ticketComment);
    }
}
