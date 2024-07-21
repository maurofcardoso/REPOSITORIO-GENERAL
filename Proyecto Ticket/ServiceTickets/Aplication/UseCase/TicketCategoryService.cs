using Aplication.Interfaces.IArea;
using Aplication.Interfaces.ITicketCategory;
using Aplication.Mappers;
using Aplication.Models;
using Aplication.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Aplication.UseCase
{
    public class TicketCategoryService : ITicketCategoryService
    {
        private readonly ITicketCategoryCommand _command;
        private readonly ITicketCategoryQuery _query;
        private readonly IAreaService _areaService;

        public TicketCategoryService(ITicketCategoryCommand command, ITicketCategoryQuery query, IAreaService areaService)
        {
            _command = command;
            _query = query;
            _areaService = areaService;
        }

        public ResponseGral CreateTicketCategory(TicketCategoryRequest request, string jwt)
        {
            if (request == null)
                return new ResponseGral(400, new { Message = "Request inválido." });

            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            if (!userJwt.Permissions.Contains("5"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee el permiso de ABM TicketCategory" });
            }

            List<TicketCategory> ticketCategories = _query.GetListTicketCategory();

            foreach (TicketCategory ticketCat in ticketCategories)
            {
                if (ticketCat.name.ToLower() == request.name.ToLower())
                {
                    return new ResponseGral(400, new { Message = "El nombre de la categoría ya está registrada en la base de datos." });
                }
            }

            ResponseGral areaOfTicketCategory = _areaService.GetAreaById(request.idAreadestino);
            if (areaOfTicketCategory.Codigo == 400)
                return new ResponseGral(400, new { Message = "El área a la cual se le quiere agregar la categoría no existe." });

            var ticketCategory = new TicketCategory
            {
                name = request.name,
                description = request.description,
                reqApproval = request.reqApproval,
                minApprovers = request.minApprovers,
                idAreadestino = request.idAreadestino,
                active = true
            };

            _command.CreateTicketCategory(ticketCategory);

            _areaService.AddTicketCategory(request.idAreadestino, ticketCategory);

            TicketCategoryResponse response = Mappers.Mapper.MapperticketCategory(ticketCategory);
            return new ResponseGral(201, response);
        }

        public ResponseGral GetAllTicketCategories(string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            var ticketCategories = _query.GetListTicketCategory();
            List<TicketCategoryResponse> ticketCategoryResponse = new List<TicketCategoryResponse>();
            foreach (TicketCategory ticketCategory in ticketCategories)
            {
                TicketCategoryResponse response = Mappers.Mapper.MapperticketCategory(ticketCategory);
                ticketCategoryResponse.Add(response);
            }
            return new ResponseGral(200, ticketCategoryResponse);
        }

        public ResponseGral GetTicketCategoryById(int idTicketCategory, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            var ticketCategory = _query.GetTicketCategoryById(idTicketCategory);

            if (ticketCategory == null)
                return new ResponseGral(400, new { Message = "No se encontró una categoría con el ID proporcionado." });

            TicketCategoryResponse response = Mappers.Mapper.MapperticketCategory(ticketCategory);
            return new ResponseGral(200, response);
        }

        public ResponseGral UpdateTicketCategory(int idTicketCategory, TicketCategoryPutRequest request, string jwt)
        {
            if (request == null)
                return new ResponseGral(400, new { Message = "Request inválido." });

            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            if (!userJwt.Permissions.Contains("5"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee el permiso de ABM TicketCategory" });
            }

            TicketCategory ticketCategorySelect = _query.GetTicketCategoryById(idTicketCategory);

            if (ticketCategorySelect == null)
                return new ResponseGral(400, new { Message = "No se encontró una categoría con el ID proporcionado para modificar." });

            ResponseGral areaOfTicketCategory = _areaService.GetAreaById(request.idAreadestino);
            if (areaOfTicketCategory.Codigo == 400)
                return new ResponseGral(400, new { Message = "El área a la cual se le quiere agregar la categoría no existe." });

            ticketCategorySelect.name = request.name;
            ticketCategorySelect.description = request.description;
            ticketCategorySelect.reqApproval = request.reqApproval;
            ticketCategorySelect.idAreadestino = request.idAreadestino;
            ticketCategorySelect.minApprovers = request.minApprovers;
            ticketCategorySelect.active = request.active;

            _areaService.AddTicketCategory(request.idAreadestino, ticketCategorySelect);

            _command.UpdateTicketCategory(ticketCategorySelect);

            TicketCategoryResponse response = Mappers.Mapper.MapperticketCategory(ticketCategorySelect);
            return new ResponseGral(200, response);
        }
    }
}
