using Aplication.Interfaces.IArea;
using Aplication.Interfaces.ITicket;
using Aplication.Mappers;
using Aplication.Models;
using Aplication.Response;
using Aplication.Response.ServiceUser;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.UseCase
{
    public class AreaService : IAreaService
    {
        private readonly IAreaCommand _areaCommand;
        private readonly IAreaQuery _areaQuery;
        private readonly ITicketQuery _ticketQuery;

        public AreaService(IAreaCommand areaCommand, IAreaQuery areaQuery, ITicketQuery ticketQuery)
        {
            _areaCommand = areaCommand;
            _areaQuery = areaQuery;
            _ticketQuery = ticketQuery;
        }

        public ResponseGral CreateArea(AreaCreateRequest request, string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            if (!userJwt.Permissions.Contains("4"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee el permiso de ABM Areas" });
            }

            if (request == null)
                return new ResponseGral(400, new { Message = "Request inválido."});
            List<Area> areas = _areaQuery.GetListArea();

            foreach (Area x in areas)
            {
                if (x.nameArea.ToLower() == request.nameArea.ToLower())
                {
                    return new ResponseGral(400, new { Message = "El nombre del área ya está registrado en la base de datos." });
                }
            }

            UserResponse user = _ticketQuery.GetUser(userJwt.UserId, jwt);
            if (user == null)
                return new ResponseGral(404, new { Message = "El usuario indicado NO existe" });

            var area = new Area
            {
                activeArea = true,
                nameArea = request.nameArea,
                description = request.description,
                dateCreate = DateTime.Now,
                createUser = userJwt.UserId,
                dateUpdate = DateTime.Now,
                updateUser = userJwt.UserId
            };

            _areaCommand.CreateArea(area);

            AreaResponse response = Mappers.Mapper.MapperArea(area);
            return new ResponseGral(201, response);
        }

        public ResponseGral GetAllAreas(string jwt)
        {
            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            if (!userJwt.Permissions.Contains("4"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee el permiso de ABM Areas" });
            }

            var areas = _areaQuery.GetListArea();
            List<AreaResponse> areasResponse = new List<AreaResponse>();
            foreach (Area area in areas)
            {
                AreaResponse response = Mappers.Mapper.MapperArea(area);
                areasResponse.Add(response);
            }
            return new ResponseGral(200, areasResponse);
        }

        public ResponseGral GetAreaById(int idArea)
        {
            Area area = _areaQuery.GetAreaById(idArea);

            if (area == null)
                return new ResponseGral(404, new { Message = "No se encontró un área con el ID proporcionado." });

            AreaResponse response = Mappers.Mapper.MapperArea(area);
            return new ResponseGral(200, response);
        }

        public ResponseGral UpdateArea(int idArea, AreaUpdateRequest request, string jwt)
        {
            if (request == null)
                return new ResponseGral(400, new { Message = "Request inválido." });

            UserResponseJwt userJwt = Mapper.MapperUser(jwt);

            if (!userJwt.Permissions.Contains("4"))
            {
                return new ResponseGral(400, new { Message = "El usuario indicado NO posee el permiso de ABM Areas" });
            }

            Area areaSelect = _areaQuery.GetAreaById(idArea);

            if (areaSelect == null)
                return new ResponseGral(400, new { Message = "No se encontró un área con el ID proporcionado para modificar." });

            UserResponse user = _ticketQuery.GetUser(userJwt.UserId,jwt);
            if (user == null)
                return new ResponseGral(404, new { Message = "El usuario indicado NO existe" });

            areaSelect.activeArea = request.activeArea;
            areaSelect.nameArea = request.nameArea;
            areaSelect.description = request.description;
            areaSelect.dateUpdate = DateTime.Now;
            areaSelect.updateUser = userJwt.UserId;

            _areaCommand.UpdateArea(areaSelect);

            AreaResponse response = Mappers.Mapper.MapperArea(areaSelect);
            return new ResponseGral(200, response);
        }

        public void AddTicketCategory(int idArea, TicketCategory ticketCategory)
        {
            Area area = _areaQuery.GetAreaById(idArea);
            area.ticketCategories.Add(ticketCategory);
            _areaCommand.UpdateArea(area);
        }
    }
}
