using Aplication.Interfaces.IArea;
using Aplication.Interfaces.ITicket;
using Aplication.Interfaces.ITicketComment;
using Aplication.Mappers;
using Aplication.Models;
using Aplication.Response;
using Aplication.Response.ServiceUser;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class TicketCommentService : ITicketCommentService
    {
        private readonly ITicketCommentCommand _command;
        private readonly ITicketCommentQuery _query;
        private readonly ITicketService _ticketService;
        private readonly ITicketQuery _ticketQuery;
        private readonly IAreaQuery _areaQuery;

        public TicketCommentService(ITicketCommentCommand command, ITicketCommentQuery query, ITicketService ticketService, ITicketQuery ticketQuery, IAreaQuery areaQuery)
        {
            _command = command;
            _query = query;
            _ticketQuery = ticketQuery;
            _ticketService = ticketService;
            _areaQuery = areaQuery;
        }

        public ResponseGral CreateTicketComment(TicketCommentRequest request, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            //Se verifica permiso para alta y/o modificacion de tickets
            if (!userJwt.Permissions.Contains("2"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee permisos para modificar un ticket" });
            }
            Area area = _areaQuery.GetAreaById(userJwt.AreaId);

            List<string> ticketCategoryString = Mapper.MapperCategoryString(area.ticketCategories);

            var ticket = _ticketQuery.GetById(request.idTicket);
            if (ticket == null)
            {
                return new ResponseGral(404, new { Message = "El Ticket indicado NO existe" });
            }

            if (userJwt.RolId == 1 || ticket.idUser == userJwt.UserId || ticketCategoryString.Contains((ticket.idTicketCategory).ToString()))
            {
                UserResponse user = _ticketQuery.GetUser(ticket.idUser, jwt);
                if (user == null)
                {
                    return new ResponseGral(404, new { Message = "El usuario indicado NO existe" });
                }

                var ticketComment = new TicketComment
                {
                    idTicket = request.idTicket,
                    idUser = userJwt.UserId,
                    comment = request.comment,
                    file = request.file,
                    dateComment = DateTime.Now,
                    edited = false
                };
                _command.CreateTicketComment(ticketComment);
                _ticketService.AddCommentToTicket(ticketComment.idTicket, ticketComment);
                UserResponse userResponse = _ticketQuery.GetUser(ticketComment.idUser, jwt);
                TicketCommentResponse response = Mappers.Mapper.MapperticketComment(ticketComment);

                return new ResponseGral(201, response);
            }
            return new ResponseGral(401, new { Message = "El usuario NO posee la categoria indicada para acceder al ticket" });
            
        }


        public ResponseGral GetAllTicketComments(int TicketId, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            if (!userJwt.Permissions.Contains("2"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee permisos para modificar un ticket" });
            }
            Area area = _areaQuery.GetAreaById(userJwt.AreaId);

            var ticket = _ticketQuery.GetById(TicketId);
            if (ticket == null)
            {
                return new ResponseGral(404, new { Message = "El Ticket indicado NO existe" });
            }

            List<string> ticketCategoryString = Mapper.MapperCategoryString(area.ticketCategories);

            if (userJwt.RolId != 1)
            {
                if (ticket.idUser != userJwt.UserId)
                {
                    if (!ticketCategoryString.Contains(ticket.idTicketCategory.ToString()))
                    {
                        return new ResponseGral(401, new { Message = "El usuario NO posee la categoria indicada para acceder al ticket" });
                    }
                }
            }

            var ticketComments = _query.GetListTicketComment(TicketId);
            List<TicketCommentResponse> ticketCommentResponse = new List<TicketCommentResponse>();
            foreach (TicketComment ticketComment in ticketComments)
            {
                TicketCommentResponse response = Mappers.Mapper.MapperticketComment(ticketComment);
                ticketCommentResponse.Add(response);
            }
            return new ResponseGral(200, ticketCommentResponse);
        }




        public ResponseGral DeleteTicketComment(int idTicketComment,string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            if (!userJwt.Permissions.Contains("2"))
            {
                return new ResponseGral(409, new { Message = "El usuario indicado NO posee permisos para modificar un ticket" });
            }
            Area area = _areaQuery.GetAreaById(userJwt.AreaId);

            var ticketComment = _query.GetTicketCommentById(idTicketComment);
            if (ticketComment == null)
            {
                return new ResponseGral(400, new { Message = "NO se ha encontrado un comentario con el ID indicado" });
            }

            var ticket = _ticketQuery.GetById(ticketComment.idTicket);
            if (ticket == null)
            {
                return new ResponseGral(404, new { Message = "El Ticket indicado NO existe" });
            }

            List<string> ticketCategoryString = Mapper.MapperCategoryString(area.ticketCategories);

            if (userJwt.RolId != 1)
            {
                if (ticket.idUser != userJwt.UserId)
                {
                    if (!ticketCategoryString.Contains(ticket.idTicketCategory.ToString()))
                    {
                        return new ResponseGral(401, new { Message = "El usuario NO posee la categoria indicada para acceder al ticket" });
                    }
                }
            }

            _command.RemoveTicketComment(ticketComment);
            return new ResponseGral(200, new { Message = "El comentario fue eliminado con éxito." });
        }



        public ResponseGral UpdateTicketComment(int idTicketComment, TicketCommentUpdateRequest request, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            //Se verifica permiso para Resolucion de tickets
            if (!userJwt.Permissions.Contains("2"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee permisos para modificar un ticket" });
            }
            Area area = _areaQuery.GetAreaById(userJwt.AreaId);
            List<string> ticketCategoryString = Mapper.MapperCategoryString(area.ticketCategories);

            TicketComment ticketComment = _query.GetTicketCommentById(idTicketComment);

            var ticket = _ticketQuery.GetById(ticketComment.idTicket);
            if (ticket == null)
            {
                return new ResponseGral(404, new { Message = "El Ticket indicado NO existe" });
            }

            if (userJwt.RolId != 1)
            {
                if (ticket.idUser != userJwt.UserId)
                {
                    if (!ticketCategoryString.Contains(ticket.idTicketCategory.ToString()))
                    {
                        return new ResponseGral(401, new { Message = "El usuario NO posee la categoria indicada para acceder al ticket" });
                    }
                }
            }

            UserResponse user = _ticketQuery.GetUser(ticket.idUser, jwt);
            if (user == null)
            {
                return new ResponseGral(404, new { Message = "El usuario indicado NO existe" });
            }


            if (ticketComment == null)
            {
                return new ResponseGral(404, new { Message = "El comentario que se quiere modificar no existe." });
            }

            ticketComment.comment = request.comment;
            ticketComment.file = request.file;
            ticketComment.dateComment = DateTime.Now;
            ticketComment.edited = true;

            _command.UpdateTicketComment(ticketComment);
            TicketCommentResponse response = Mappers.Mapper.MapperticketComment(ticketComment);
            return new ResponseGral(200, response);
        }

    }
}
