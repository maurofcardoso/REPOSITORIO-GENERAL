using Aplication.Interfaces.ITicket;
using Aplication.Response;
using Aplication.Response.ServiceUser;
using Aplication.UseCase;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Aplication.Mappers
{
    public class Mapper
    {
        public static UserResponseJwt MapperUser(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            string authHeader = jwt.Replace("Bearer ", "");
            var jsonToken = handler.ReadToken(authHeader);//no lo usa
            var tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            UserResponseJwt response = new UserResponseJwt
            {
                UserId = Int32.Parse(tokenS.Claims.First(claim => claim.Type == "nameid").Value),
                NameUser = tokenS.Claims.First(claim => claim.Type == "unique_name").Value,
                Email = tokenS.Claims.First(claim => claim.Type == "email").Value,
                RolId = Int32.Parse(tokenS.Claims.First(claim => claim.Type == "role").Value),
                Permissions = tokenS.Claims.First(claim => claim.Type == "gender").Value.Split(',').ToList(),
                AreaId = Int32.Parse(tokenS.Claims.First(claim => claim.Type == "actort").Value),
            };
            return response;
        }


        public static List<string> MapperCategoryString(List<TicketCategory> TicketsCategory)
        {
            List<string> TicketsCategoryString = new List<string>();

            foreach(TicketCategory ticketCategory in TicketsCategory)
            {
                TicketsCategoryString.Add(ticketCategory.idTicketCategory.ToString());
            }
            return TicketsCategoryString;
        }


        public static TicketResponse MapperTicket(Ticket ticket, UserResponse user)
        {
            List<TicketCommentResponse> ticketComments = new List<TicketCommentResponse>();
            foreach(TicketComment comment in ticket.ticketComments)
            {
                ticketComments.Add(MapperticketComment(comment));
            }

            List<TicketLogResponse> ticketLogs = new List<TicketLogResponse>();
            foreach (TicketLog log in ticket.ticketLogs)
            {
                ticketLogs.Add(MapperticketLog(log));
            }

            TicketResponse response = new TicketResponse
            {
                idTicket = ticket.idTicket,
                user = user,
                ticketComments = ticketComments,
                ticketLogs = ticketLogs,
                ticketStatus = Mapper.MapperticketStatus(ticket.ticketStatus),
                ticketPriority = Mapper.MapperticketPriority(ticket.ticketPriority),
                ticketCount = Mapper.MapperticketCount(ticket.ticketCount),
                ticketCategory = Mapper.MapperticketCategory(ticket.ticketCategory),
                ticketBody = Mapper.MapperticketBody(ticket.ticketBody)
            };
            return response;
        }


        public static TicketCommentResponse MapperticketComment(TicketComment ticketComment)
        {
            TicketCommentResponse response = new TicketCommentResponse
            {
                idComment = ticketComment.idComment,
                idUser = ticketComment.idUser,
                idTicket = ticketComment.idTicket,
                comment = ticketComment.comment,
                file = ticketComment.file,
                dateComment = ticketComment.dateComment,
            };
            return response;
        }

        
        public static TicketLogResponse MapperticketLog(TicketLog ticketLog)
        {
            TicketLogResponse response = new TicketLogResponse
            {
                idTicketLog = ticketLog.idTicketLog,
                idTicket = ticketLog.idTicket,
                idUser = ticketLog.idUser,
                dateAction = ticketLog.dateAction,
                action = ticketLog.action
            };
            return response;
        }


        public static TicketStatusResponse MapperticketStatus(TicketStatus ticketStatus)
        {
            TicketStatusResponse response = new TicketStatusResponse
            {
                idTicketStatus = ticketStatus.idTicketStatus,
                description = ticketStatus.description
            };
            return response;
        }


        public static TicketPriorityResponse MapperticketPriority(TicketPriority ticketPriority)
        {
            TicketPriorityResponse response = new TicketPriorityResponse
            {
                idPriority = ticketPriority.idPriority,
                description = ticketPriority.description
            };
            return response;
        }


        public static TicketBodyResponse MapperticketBody(TicketBody ticketBody)
        {
            TicketBodyResponse response = new TicketBodyResponse
            {
               idTicketBody = ticketBody.idTicketBody,
               title = ticketBody.title,
               description = ticketBody.description,
               file = ticketBody.file
            };
            return response;
        }


        public static TicketCountResponse MapperticketCount(TicketCount ticketCount)
        {
            TicketCountResponse response = new TicketCountResponse
            {
                idTicketCount = ticketCount.idTicketCount,
                countOpen = ticketCount.countOpen,
                countApproved = ticketCount.countApproved,
                countDisapproved = ticketCount.countDisapproved
            };
            return response;
        }


        public static TicketCategoryResponse MapperticketCategory(TicketCategory ticketCategory)
        {
            TicketCategoryResponse response = new TicketCategoryResponse
            {
                idTicketCategory = ticketCategory.idTicketCategory,
                name = ticketCategory.name,
                description = ticketCategory.description,
                reqApproval = ticketCategory.reqApproval,
                minApprovers = ticketCategory.minApprovers,
                idAreadestino = ticketCategory.idAreadestino,
                active = ticketCategory.active
            };
            return response;
        }

        public static AreaResponse MapperArea(Area area)
        {
            List<TicketCategoryResponse> ticketCategoriesResp = new List<TicketCategoryResponse>();
            foreach (TicketCategory ticketCat in area.ticketCategories)
            {
                TicketCategoryResponse response = Mappers.Mapper.MapperticketCategory(ticketCat);
                ticketCategoriesResp.Add(response);
            }

            AreaResponse areaResponse = new AreaResponse
            {
                idArea = area.idArea,
                activeArea = area.activeArea,
                nameArea = area.nameArea,
                description = area.description,
                dateCreate = area.dateCreate,
                createUser = area.createUser,
                dateUpdate = area.dateUpdate,
                updateUser = area.updateUser,
                ticketCategories = ticketCategoriesResp
            };
            return areaResponse;
        }
        public static TicketCategoryResponse MapperTicketCategory (TicketCategory ticketCategory)
        {
            TicketCategoryResponse ticketCategoryResponse = new TicketCategoryResponse
            {
                idTicketCategory = ticketCategory.idTicketCategory,
                name = ticketCategory.name,
                description = ticketCategory.description,
                reqApproval = ticketCategory.reqApproval,
                minApprovers = ticketCategory.minApprovers,
                idAreadestino = ticketCategory.idAreadestino,
                active = ticketCategory.active
            };
            return ticketCategoryResponse;
        }

    }
}
