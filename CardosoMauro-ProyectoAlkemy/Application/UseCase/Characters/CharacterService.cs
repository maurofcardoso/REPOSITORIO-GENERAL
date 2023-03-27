using Application.Exceptions;
using Application.Interfaces.CommandAndQuery;
using Application.Interfaces.Mappers;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Request;
using Domain.Entities;

namespace Application.UseCase.Characters
{
    public class CharacterService : IServiceQueryWithCharacter<CharacterRequest, Character>
    {
        private readonly ICommand<Character> _commandCharacter;
        private readonly IQueryWithCharacter<CharacterRequest, Character> _queryCharacter;
        private readonly IMapperDisney _mapperDisney;

        public CharacterService(ICommand<Character> commandCharacter, IQueryWithCharacter<CharacterRequest, Character> queryCharacter, IMapperDisney mapperDisney)
        {
            _commandCharacter = commandCharacter;
            _queryCharacter = queryCharacter;
            _mapperDisney = mapperDisney;
        }

        public async Task<Character> CreateElement(CharacterRequest elementRequest)
        {
            if (elementRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            Character character = _mapperDisney.CharacterRequestAtCharacter(elementRequest);

            await _commandCharacter.Insert(character);

            return character;
        }

        public async Task<Character> DeleteElement(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            Character character = await this.exists(elementId);
            if (character == null)
            {
                throw new ItemDuplicate("El personaje no existe.");
            }

            await _commandCharacter.Remove(character);
            return character;
        }

        public async Task<Character> exists(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos");
            }

            Character character = await _queryCharacter.GetById(elementId);
            if (character == null)
            {
                return null;
            }
            return character;
        }

        public async Task<Character> GetElement(int elementId)
        {
            if (elementId < 1)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            Character character = await _queryCharacter.GetById(elementId);

            if (character == null)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }

            return character;
        }

        public async Task<IEnumerable<Character>> GetListElement()
        {
            return await _queryCharacter.GetList();
        }

        public async Task<Character> UpdateElement(CharacterRequest elementRequest, int elementId)
        {
            if (elementId < 1 || elementRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            Character character = await exists(elementId);
            if (character == null)
            {
                throw new ItemDuplicate("El personaje no existe.");
            }

            character = _mapperDisney.CharacterAtCharacterUpdate(character, elementRequest);
            await _commandCharacter.Update(character);
            return character;
        }

        public async Task<Character> GetByRequest(CharacterRequest characterRequest)
        {
            if (characterRequest == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }
            Character character = await _queryCharacter.GetByRequest(characterRequest);
            if (character == null)
            {
                return null;
            }
            return character;
        }

        public async Task<Character> GetByName(string characterName)
        {
            if (characterName == null)
            {
                throw new ItemError("Error en ingreso de datos.");
            }
            Character character = await _queryCharacter.GetByName(characterName);
            if (character == null)
            {
                return null;
            }
            return character;
        }

        public async Task<Character> GetByAge(int characterAge)
        {
            if (characterAge < 1)
            {
                throw new ItemError("Error en ingreso de datos.");
            }
            Character character = await _queryCharacter.GetByAge(characterAge);
            if (character == null)
            {
                return null;
            }
            return character;
        }

        public async Task<IEnumerable<Character>> GetByMoviOrSerieId(int moviOrSerieId)
        {
            if (moviOrSerieId < 1)
            {
                throw new ItemError("Error en ingreso de datos.");
            }

            List<Character> characterList = new List<Character>();
            IEnumerable<Character> characters = await _queryCharacter.GetList();
            if (characters == null || characters.Count() < 1)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }
            foreach (Character x in characters)
            {
                foreach (CharacterMovieOrSerie y in x.MoviesOrSeriesAssociated)
                {
                    if (y.MovieOrSerieId == moviOrSerieId)
                    {
                        characterList.Add(x);
                    }
                }
            }
            if (characterList == null || characterList.Count() < 1)
            {
                throw new ItemNotFound("No hay coincidencias.");
            }
            return characterList;
        }
    }
}
