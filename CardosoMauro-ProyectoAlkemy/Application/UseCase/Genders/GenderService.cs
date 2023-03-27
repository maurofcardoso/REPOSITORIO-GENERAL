using Application.Exceptions;
using Application.Interfaces.CommandAndQuery;
using Application.Interfaces.Mappers;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Request;
using Domain.Entities;

namespace Application.UseCase.Genders
{
    public class GenderService : IServiceCommand<GenderRequest, Gender>, IServiceQuery<Gender>
    {
        private readonly ICommand<Gender> _commandGender;
        private readonly IQuery<Gender> _queryGender;
        private readonly IMapperDisney _mapperDisney;

        public GenderService(ICommand<Gender> commandGender, IQuery<Gender> queryGender, IMapperDisney mapperDisney)
        {
            _commandGender = commandGender;
            _queryGender = queryGender;
            _mapperDisney = mapperDisney;
        }

        public async Task<Gender> CreateElement(GenderRequest elementRequest)
        {
            if (elementRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            Gender gender = _mapperDisney.GenderRequestAtGender(elementRequest);

            await _commandGender.Insert(gender);

            return gender;
        }

        public async Task<Gender> DeleteElement(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            Gender gender = await this.exists(elementId);
            if (gender == null)
            {
                throw new ItemDuplicate("El personaje no existe.");
            }

            await _commandGender.Remove(gender);
            return gender;
        }

        public async Task<Gender> exists(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos");
            }

            Gender gender = await _queryGender.GetById(elementId);
            if (gender == null)
            {
                return null;
            }
            return gender;
        }

        public async Task<Gender> GetElement(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("El valor ingresado es incorrecto.");
            }

            Gender genderAux = await _queryGender.GetById(elementId);

            if (genderAux == null)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }

            return genderAux;
        }

        public async Task<IEnumerable<Gender>> GetListElement()
        {
            return await _queryGender.GetList();
        }

        public async Task<Gender> UpdateElement(GenderRequest elementRequest, int elementId)
        {
            if (elementId < 1 || elementRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            var gender = await this.exists(elementId);
            if (gender == null)
            {
                throw new ItemDuplicate("El personaje no existe.");
            }

            gender = _mapperDisney.GenderAtGenderUpdate(gender, elementRequest);
            await _commandGender.Update(gender);
            return gender;
        }
    }
}
