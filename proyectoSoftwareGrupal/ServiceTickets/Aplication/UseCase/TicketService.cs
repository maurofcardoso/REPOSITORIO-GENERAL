using Aplication.Interfaces.IArea;
using Aplication.Interfaces.ITicket;
using Aplication.Mappers;
using Aplication.Models;
using Aplication.Response;
using Aplication.Response.ServiceUser;
using Domain.Entities;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Aplication.UseCase
{
    public class TicketService : ITicketService
    {
        private readonly ITicketCommand _command;
        private readonly ITicketLogCommand _ticketLogCommand;
        private readonly ITicketQuery _query;
        private readonly IAreaQuery _AreaQuery;

        public TicketService(ITicketCommand command, ITicketQuery query, IAreaQuery areaQuery, ITicketLogCommand ticketLogCommand)
        {
            _command = command;
            _query = query;
            _AreaQuery = areaQuery;
            _ticketLogCommand = ticketLogCommand;
        }
        public ResponseGral AddCommentToTicket(int idTicket, TicketComment ticketComment)
        {
            Ticket ticket = _query.GetById(idTicket);
            ticket.ticketComments.Add(ticketComment);
            _command.UpdateTicket(ticket);
            return new ResponseGral(200, new { Message = "El comentario fue agregado con éxito." });
        }

        //Permite cambiar la CATEGORIA de un ticket (derivar)
        public ResponseGral UpdateCategory(TicketUpdateCategoryRequest request, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            //Se verifica permiso para Resolucion de tickets
            if (!userJwt.Permissions.Contains("3"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee el permiso de Resolucion de Tickets" });
            }
            Area area = _AreaQuery.GetAreaById(userJwt.AreaId);

            List<string> ticketCategoryString = Mapper.MapperCategoryString(area.ticketCategories);

            var ticket = _query.GetById(request.idTicket);
            if (ticket == null)
            {
                return new ResponseGral(404, new { Message = "El Ticket indicado NO existe" });
            }

            if (userJwt.RolId != 1)
            {
                if (!ticketCategoryString.Contains(ticket.idTicketCategory.ToString()))
                {
                    return new ResponseGral(401, new { Message = "El usuario NO posee la categoria indicada para acceder al ticket" });
                }
            }

            UserResponse user = _query.GetUser(ticket.idUser, jwt);
            if (user == null)
            {
                return new ResponseGral(404, new { Message = "El usuario indicado NO existe" });
            }


            TicketCategory ticketCategory = _query.GetCategory(request.CategoryId);
            if (ticketCategory == null)
            {
                return new ResponseGral(404, new { Message = "La category indicada NO existe" });
            }

            var ticketLog = new TicketLog
            {
                idTicket = ticket.idTicket,
                idUser = userJwt.UserId,
                dateAction = DateTime.Now,
                action = "Derivado"
            };
            _ticketLogCommand.CreateTicketLog(ticketLog);

            Ticket newTicket = _command.UpdateTicketCategory(ticket, ticketCategory);
            TicketResponse response = Mappers.Mapper.MapperTicket(newTicket, user);

            return new ResponseGral(201, response);
        }


        //Permite actualizar el ESTADO de un ticket
        public ResponseGral UpdateStatus(TicketUpdateStatusRequest request, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);
            
            //Se verifica permiso para Resolucion de tickets
            if (!userJwt.Permissions.Contains("3"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee el permiso de Resolucion de Tickets" });
            }
            Area area = _AreaQuery.GetAreaById(userJwt.AreaId);

            List<string> ticketCategoryString = Mapper.MapperCategoryString(area.ticketCategories);

            var ticket = _query.GetById(request.idTicket);
            if (ticket == null)
            {
                return new ResponseGral(404, new { Message = "El Ticket indicado NO existe" });
            }

            if (userJwt.RolId != 1)
            {
                if (!ticketCategoryString.Contains(ticket.idTicketCategory.ToString()))
                {
                    return new ResponseGral(401, new { Message = "El usuario NO posee la categoria indicada para acceder al ticket" });
                }
            }         

            UserResponse user = _query.GetUser(ticket.idUser, jwt);
            if (user == null)
            {
                return new ResponseGral(404, new { Message = "El usuario indicado NO existe" });
            }
  
            TicketStatus ticketStatus = _query.GetStatus(request.StatusId);
            if (ticketStatus == null)
            {
                return new ResponseGral(404, new { Message = "El status indicado NO existe" });
            }

            var ticketLog = new TicketLog
            {
                idTicket = ticket.idTicket,
                idUser = userJwt.UserId,
                dateAction = DateTime.Now,
                action = "Actualizado el estado"
            };
            _ticketLogCommand.CreateTicketLog(ticketLog);

            Ticket newTicket = _command.UpdateTicketStatus(ticket, ticketStatus);
            TicketResponse response = Mappers.Mapper.MapperTicket(newTicket, user);
            
            return new ResponseGral(201, response);
        }

        //Permite crear tickets
        public ResponseGral Create(TicketRequest request, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);
            UserResponse user = _query.GetUser(userJwt.UserId, jwt);

            //Se verifica permiso para crear tickets
            if (!userJwt.Permissions.Contains("2"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee el permiso de Crear Tickets" });
            }

            TicketPriority ticketPriority = _query.GetPriority(request.PriorityId);
            if (ticketPriority == null)
            {
                return new ResponseGral(404, new { Message = "La priority indicada NO existe" });
            }

            TicketCategory ticketCategory = _query.GetCategory(request.CategoryId);
            if (ticketCategory == null)
            {
                return new ResponseGral(404, new { Message = "La category indicada NO existe" });
            }

            var ticketCount = new TicketCount
            {
                countOpen = 0,
                countApproved = 0,
                countDisapproved = 0
            };
            _command.CreateTicketCount(ticketCount);

            var ticketBody = new TicketBody
            {
                title = request.title,
                description = request.description,
                file = request.fileAdjunt
            };
            _command.CreateTicketBody(ticketBody);

            var ticket = new Ticket
            {
                idUser = userJwt.UserId,
                idStatus = 1,
                idPriority = request.PriorityId,
                idTicketCount = ticketCount.idTicketCount,
                idTicketCategory = request.CategoryId,
                idTicketBody = ticketBody.idTicketBody,
            };
            _command.Create(ticket);

            var ticketLog = new TicketLog
            {
                idTicket = ticket.idTicket,
                idUser = userJwt.UserId,
                dateAction = DateTime.Now,
                action = "Creado"
            };
            _ticketLogCommand.CreateTicketLog(ticketLog);
            TicketResponse response = Mappers.Mapper.MapperTicket(_query.GetById(ticket.idTicket), user);
            return new ResponseGral(201, response);
        }

        //Permite obtener un ticket en particular (debe ser del area del usuario logueado o bien el usuario ser su creador)
        public ResponseGral GetById(int id, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);
            UserResponse user = _query.GetUser(userJwt.UserId, jwt);
            Area area = _AreaQuery.GetAreaById(userJwt.AreaId);

            List<string> ticketCategoryString = Mapper.MapperCategoryString(area.ticketCategories);

            var ticket = _query.GetById(id);
            if (ticket == null)
            {
                return new ResponseGral(404, new { Message = "El Ticket indicado NO existe" });
            }

            //Se accede al ticket si el usuario es administrador, el creador, o si su area es la correspondiente
            if(userJwt.RolId == 1 || ticket.idUser == userJwt.UserId || ticketCategoryString.Contains((ticket.idTicketCategory).ToString()))
            {
                var response = Mappers.Mapper.MapperTicket(ticket, user);
                return new ResponseGral(200, response);
            }
            return new ResponseGral(401, new { Message = "El usuario NO posee la categoria indicada para acceder al ticket" });
        }

        //Obtiene todos los tickets del area del usuario logueado y todos los creados por el mismo
        public ResponseGral GetAll(string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);
            Area area = _AreaQuery.GetAreaById(userJwt.AreaId);
            List<Ticket >tickets;

            //Si el ussuario es administrador obtiene TODOS los tickets
            if (userJwt.RolId == 1)
            {
                tickets = _query.GetAll();
            }
            //Si NO es administrador obtiene solo los tickets de su area
            else
            {
                //Se obtienen todos los tickets del area
                List<Ticket> ticketsAll = _query.GetAllByCategory(area.ticketCategories);

                //Se obtienen los tickets creados por el usuario
                List<Ticket> ticketsCreados = _query.GetAllCreated(userJwt.UserId);

                //Se unen las listas SIN tener en cuenta los repetidos
                tickets = ticketsAll.Union(ticketsCreados).ToList();

            }
            
            if (tickets.Count == 0)
            {
                return new ResponseGral(404, new { Message = "NO existen tickets del area "+userJwt.AreaId });
            }
            
            //Genera el response de cada ticket
            List<TicketsReponse> ticketsResponse = new List<TicketsReponse>();
            foreach (Ticket ticket in tickets)
            {
                UserResponse user = _query.GetUser(ticket.idUser, jwt);
                ticketsResponse.Add(new TicketsReponse
                {
                    user = user,
                    ticket = Mappers.Mapper.MapperTicket(ticket, user)
                });
            }

            //Agrega todos los tickets a la lista final
            List<TicketResponse> response = new List<TicketResponse>();
            foreach (TicketsReponse ticket in ticketsResponse)
            {
                response.Add(ticket.ticket);
            }
            return new ResponseGral(200, response);
        }

    }
}
