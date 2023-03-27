using Application.Exceptions;
using Application.Interfaces.Mappers;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoAlkemy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class CharactersController : ControllerBase
    {
        private readonly IServiceQueryWithCharacter<CharacterRequest, Character> _serviceCharacter;
        private readonly IMapperDisney _mapper;

        public CharactersController(IServiceQueryWithCharacter<CharacterRequest, Character> serviceCharacter, IMapperDisney mapper)
        {
            _serviceCharacter = serviceCharacter;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacters(string? name, int? age, int? movies)
        {
            try
            {
                if (Request.QueryString.Value == "")
                {
                    IEnumerable<Character> Characters = await _serviceCharacter.GetListElement();
                    if (Characters == null)
                    {
                        return new JsonResult(Characters) { StatusCode = 404 };
                    }
                    List<CharactersResponse> charactersResponse = new List<CharactersResponse>();
                    foreach (Character character in Characters)
                    {
                        charactersResponse.Add(_mapper.CharacterAtCharactersResponse(character));
                    }
                    return new JsonResult(charactersResponse) { StatusCode = 200 };
                }
                var var1 = Request.QueryString.Value.Split("?")[1].Split("=");
                var option = var1[0].ToString();
                var value = var1[1].ToString();
                if (option == "name" && value != null)
                {
                    Character character = await _serviceCharacter.GetByName(value);
                    if (character == null)
                    {
                        return new JsonResult(character) { StatusCode = 404 };
                    }
                    return new JsonResult(await _mapper.CharacterAtCharacterResponse(character)) { StatusCode = 200 };
                }

                if (option == "age" && value != null)
                {
                    Character character = await _serviceCharacter.GetByAge(int.Parse(value));
                    if (character == null)
                    {
                        return new JsonResult(character) { StatusCode = 404 };
                    }
                    return new JsonResult(await _mapper.CharacterAtCharacterResponse(character)) { StatusCode = 200 };
                }

                if (option == "movies" && value != null )
                {
                    IEnumerable<Character> character = await _serviceCharacter.GetByMoviOrSerieId(int.Parse(value));
                    if (character == null || character.Count() < 1)
                    {
                        return new JsonResult(character) { StatusCode = 404 };
                    }
                    List<CharacterResponse> characterList = new List<CharacterResponse>();
                    foreach (Character x in character)
                    {
                        characterList.Add(await _mapper.CharacterAtCharacterResponse(x));
                    }
                    return new JsonResult(characterList) { StatusCode = 200 };
                }

                return new JsonResult("Error al ingresar datos.");
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpGet("detail")]
        public async Task<IActionResult> GetDetailCharacters()
        {
            try
            {
                IEnumerable<Character> characters = await _serviceCharacter.GetListElement();
                if (characters == null)
                {
                    return new JsonResult(characters) { StatusCode = 404 };
                }
                if (characters.Count() < 1)
                {
                    return new JsonResult("La lista esta vacia") { StatusCode = 200 };
                }
                List<CharacterResponse> charactersResponse = new List<CharacterResponse>();
                foreach (Character character in characters)
                {
                    charactersResponse.Add(await _mapper.CharacterAtCharacterResponse(character));
                }
                return new JsonResult(charactersResponse) { StatusCode = 200 };

            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpPost("addCharacter")]
        public async Task<IActionResult> CreateCharacter([FromBody] CharacterRequest characterRequest)
        {
            if (characterRequest == null)
            {
                return new JsonResult(characterRequest) { StatusCode = 404 };
            }
            try
            {
                Character character = await _serviceCharacter.CreateElement(characterRequest);
                if (character == null)
                {
                    return new JsonResult(character) { StatusCode = 404 };
                }
                return new JsonResult(_mapper.CharacterAtCharacterResponse(character)) { StatusCode = 200 };
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpPut("updateCharacter/{characterId:int}")]
        public async Task<IActionResult> UpdateCharacter([FromBody] CharacterRequest characterRequest, int characterId)
        {
            if (characterRequest == null)
            {
                return new JsonResult(characterRequest) { StatusCode = 404 };
            }
            try
            {
                Character character = await _serviceCharacter.UpdateElement(characterRequest, characterId);
                if (character == null)
                {
                    return new JsonResult(character) { StatusCode = 404 };
                }
                return new JsonResult(_mapper.CharacterAtCharacterResponse(character)) { StatusCode = 200 };
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }

        [HttpDelete("removeCharacter/{characterId:int}")]
        public async Task<IActionResult> RemoveCharacter(int characterId)
        {
            if (characterId < 1)
            {
                return new JsonResult(characterId) { StatusCode = 404 };
            }
            try
            {
                Character character = await _serviceCharacter.DeleteElement(characterId);
                if (character == null)
                {
                    return new JsonResult(character) { StatusCode = 404 };
                }
                return new JsonResult(_mapper.CharacterAtCharacterResponse(character)) { StatusCode = 200 };
            }
            catch (ItemDuplicate e)
            {
                return BadRequest(e.message);
            }
            catch (ItemNotFound e)
            {
                return NotFound(e.message);
            }
            catch (ItemError e)
            {
                return BadRequest(e.message);
            }
            catch (Exception)
            {
                return BadRequest("Hubo un error.");
            }
        }
    }
}
