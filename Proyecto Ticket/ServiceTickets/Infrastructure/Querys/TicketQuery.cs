using Aplication.Interfaces;
using Aplication.Interfaces.ITicket;
using Aplication.Models;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Aplication.Interfaces.ITicket;
using RestSharp;
using Newtonsoft.Json.Linq;
using RestSharp.Authenticators.OAuth2;
using Newtonsoft.Json;
using Aplication.Response;
using Aplication.Response.ServiceUser;

namespace Infrastructure.Querys
{
    public class TicketQuery : ITicketQuery
    {
        private readonly AppDbContext _context;
        public TicketQuery(AppDbContext context)
        {
            _context = context;
        }

        public List<Ticket> GetAll()
        {
            var tickets = _context.Ticket
                         .Include(t => t.ticketComments)
                         .Include(t => t.ticketLogs)
                         .Include(t => t.ticketStatus)
                         .Include(t => t.ticketPriority)
                         .Include(t => t.ticketBody)
                         .Include(t => t.ticketCount)
                         .Include(t => t.ticketCategory)
                         .ToList();
            return tickets;
        }


        public List<Ticket> GetAllByCategory(List<TicketCategory> ticketsCategory)
        {
            List<Ticket> tickets = new List<Ticket>();

            foreach (TicketCategory ticketCategory in ticketsCategory)
            {
                var ticketscat = _context.Ticket
                         .Include(t => t.ticketComments)
                         .Include(t => t.ticketLogs)
                         .Include(t => t.ticketStatus)
                         .Include(t => t.ticketPriority)
                         .Include(t => t.ticketBody)
                         .Include(t => t.ticketCount)
                         .Include(t => t.ticketCategory)
                         .Where(t => t.idTicketCategory == ticketCategory.idTicketCategory)
                         .ToList();
                tickets.AddRange(ticketscat);
            }
            return tickets;
        }

        public List<Ticket> GetAllCreated(int UserId)
        {
            var tickets = _context.Ticket
                         .Include(t => t.ticketComments)
                         .Include(t => t.ticketLogs)
                         .Include(t => t.ticketStatus)
                         .Include(t => t.ticketPriority)
                         .Include(t => t.ticketBody)
                         .Include(t => t.ticketCount)
                         .Include(t => t.ticketCategory)
                         .Where(t => t.idUser == UserId)
                         .ToList();
            return tickets;
        }

        public Ticket GetById(int id)
        {
            var ticket = _context.Ticket
                         .Include(t => t.ticketComments)
                         .Include(t => t.ticketLogs)
                         .Include(t => t.ticketStatus)
                         .Include(t => t.ticketPriority)
                         .Include(t => t.ticketBody)
                         .Include(t => t.ticketCount)
                         .Include(t => t.ticketCategory)
                         .FirstOrDefault(t => t.idTicket == id);
            return ticket;
        }

        
        public UserResponse GetUser(int id, string jwt)
        {
            jwt = jwt.Remove(0, 7);
            var client = new RestClient("https://localhost:7051/api/Users/"+id);
            client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(jwt, "Bearer");
            var request = new RestRequest();
            var response = client.Execute(request);

            if(response.StatusDescription == "Not Found")
            {
                return null;
            }

            UserResponse user = JsonConvert.DeserializeObject<UserResponse>(response.Content);
            return user;
        }
        

        public TicketStatus GetStatus(int StatusId)
        {
            return _context.TicketStatus.FirstOrDefault(t => t.idTicketStatus == StatusId);
        }

        public TicketPriority GetPriority(int PriorityId)
        {
            return _context.TicketPriority.FirstOrDefault(t => t.idPriority == PriorityId);
        }

        public TicketCategory GetCategory(int CategoryId)
        {
            return _context.TicketCategory.FirstOrDefault(t => t.idTicketCategory == CategoryId);
        }

    }
}
