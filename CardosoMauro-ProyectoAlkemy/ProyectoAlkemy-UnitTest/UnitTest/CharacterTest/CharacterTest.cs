using Application.Exceptions;
using Application.Interfaces.CommandAndQuery;
using Application.Interfaces.Mappers;
using Application.Interfaces.ServiceCommandAndQuery;
using Application.Models.Request;
using Application.UseCase.Characters;
using Domain.Entities;
using Moq;

namespace ProyectoAlkemy_UnitTest.UnitTest.CharacterTest
{
    public class CharacterTest
    {
        private readonly CharacterService _characterService;

        private readonly Mock<IMapperDisney> _mapperDisney;
        private readonly Mock<ICommand<Character>> _commandCharacter;
        private readonly Mock<IQueryWithCharacter<CharacterRequest, Character>> _queryCharacter;
        private readonly Mock<IServiceQueryWithCharacter<CharacterRequest, Character>> _characterServiceMock;

        private readonly Mock<CharacterRequest> _characterRequest;
        private readonly Mock<Character> _character;

        public CharacterTest()
        {
            _mapperDisney = new Mock<IMapperDisney>();
            _commandCharacter = new Mock<ICommand<Character>>();
            _queryCharacter = new Mock<IQueryWithCharacter<CharacterRequest, Character>>();
            _characterServiceMock = new Mock<IServiceQueryWithCharacter<CharacterRequest, Character>>();
            _characterRequest = new Mock<CharacterRequest>();
            _character = new Mock<Character>();


            _characterService = new CharacterService(_commandCharacter.Object, _queryCharacter.Object, _mapperDisney.Object);
        }

        [Fact]
        public async Task CreateElement_testCharacterRequestIsNull ()
        {
            CharacterRequest characterRequest = null;
            await Assert.ThrowsAsync<ItemError>(() => _characterService.CreateElement(characterRequest));
        }

        [Fact]
        public async Task CreateElement_testOk()
        {
            _mapperDisney.Setup(obj => obj.CharacterRequestAtCharacter(_characterRequest.Object)).Returns(_character.Object);
            _commandCharacter.Setup(obj => obj.Insert(_character.Object));

            var response = await _characterService.CreateElement(_characterRequest.Object);

            Assert.IsAssignableFrom<Character>(response);
            _commandCharacter.Verify(command => command.Insert(_character.Object), Times.Once());
        }

        [Fact]
        public async Task DeleteElement_testElementIdIncorrect ()
        {
            int elementId = 0;
            await Assert.ThrowsAsync<ItemError>(() => _characterService.DeleteElement(elementId));
        }

        [Fact]
        public async Task DeleteElement_testNoExist ()
        {
            int elementId = 1;
            Character character = null;

            _characterServiceMock.Setup(obj => obj.exists(It.IsAny<int>())).ReturnsAsync(character);

            await Assert.ThrowsAsync<ItemDuplicate>(() => _characterService.DeleteElement(elementId));
        }

        [Fact]
        public async Task DeleteElement_testOk ()
        {
            int elementId = 1;

            _characterServiceMock.Setup(obj => obj.exists(It.IsAny<int>())).ReturnsAsync(_character.Object);
            _commandCharacter.Setup(obj => obj.Remove(_character.Object));
            _queryCharacter.Setup(obj => obj.GetById(It.IsAny<int>())).ReturnsAsync(_character.Object);

            Character response = await _characterService.DeleteElement(elementId);

            Assert.IsAssignableFrom<Character>(response);
        }

        [Fact]
        public async Task Exists_testElementIdIncorrect ()
        {
            int elementId = 0;

            await Assert.ThrowsAsync<ItemError>(() => _characterService.DeleteElement(elementId));
        }

        [Fact]
        public async Task Exists_testCharacterIsNull ()
        {
            int elementId = 1;

            Character character = null;

            _queryCharacter.Setup(obj => obj.GetById(It.IsAny<int>())).ReturnsAsync(character);
            _characterServiceMock.Setup(obj => obj.exists(It.IsAny<int>())).ReturnsAsync(character);

            await Assert.ThrowsAsync<ItemDuplicate>(() => _characterService.DeleteElement(elementId));
        }

        [Fact]
        public async Task Exists_testOk ()
        {
            int elementId = 1;

            _queryCharacter.Setup(obj => obj.GetById(It.IsAny<int>())).ReturnsAsync(_character.Object);
            _characterServiceMock.Setup(obj => obj.exists(It.IsAny<int>())).ReturnsAsync(_character.Object);

            Character response = await _characterService.DeleteElement(elementId);

            Assert.IsAssignableFrom<Character>(response);
        }

        [Fact]
        public async Task GetElement_testElementIdIncorrect ()
        {
            int elementId = 0;

            await Assert.ThrowsAsync<ItemError>(() => _characterService.GetElement(elementId));
        }

        [Fact]
        public async Task GetElement_testCharacterIsNull ()
        {
            int elementId = 1;

            Character character = null;

            _queryCharacter.Setup(obj => obj.GetById(It.IsAny<int>())).ReturnsAsync(character);
            _characterServiceMock.Setup(obj => obj.exists(It.IsAny<int>())).ReturnsAsync(character);

            await Assert.ThrowsAsync<ItemNotFound>(() => _characterService.GetElement(elementId));
        }

        [Fact]
        public async Task GetElement_testOk ()
        {
            int elementId = 1;

            _queryCharacter.Setup(obj => obj.GetById(It.IsAny<int>())).ReturnsAsync(_character.Object);
            _characterServiceMock.Setup(obj => obj.exists(It.IsAny<int>())).ReturnsAsync(_character.Object);

            Character response = await _characterService.GetElement(elementId);

            Assert.IsAssignableFrom<Character>(response);
        }

        [Fact]
        public async Task GetListElement_testFailBD ()
        {
            IEnumerable<Character> listFail = null;
            _queryCharacter.Setup(obj => obj.GetList()).ReturnsAsync(listFail);

            var response = await _characterService.GetListElement();

            Assert.Null(response);
        }

        [Fact]
        public async Task GetListElement_testOk ()
        {
            IEnumerable<Character> list = new List<Character>();

            _queryCharacter.Setup(obj => obj.GetList()).ReturnsAsync(list);

            var response = await _characterService.GetListElement();

            Assert.IsType<List<Character>>(response);
        }

        [Fact]
        public async Task UpdateElement_testElementIdIncorrect ()
        {
            int elementId = 0;

            await Assert.ThrowsAsync<ItemError>(() => _characterService.UpdateElement(_characterRequest.Object, elementId));
        }

        [Fact]
        public async Task updateElement_testCharacterRequestIsNull ()
        {
            int elementId = 1;

            CharacterRequest characterRequest = null;

            await Assert.ThrowsAsync<ItemError>(() => _characterService.UpdateElement(characterRequest, elementId));
        }

        [Fact]
        public async Task updateElement_testCharactertIsNull()
        {
            int elementId = 1;

            Character character = null;

            _characterServiceMock.Setup(obj => obj.exists(It.IsAny<int>())).ReturnsAsync(character);

            await Assert.ThrowsAsync<ItemDuplicate>(() => _characterService.UpdateElement(_characterRequest.Object, elementId));
        }

        [Fact]
        public async Task updateElement_testOk()
        {
            int elementId = 1;

            _mapperDisney.Setup(obj => obj.CharacterAtCharacterUpdate(_character.Object, _characterRequest.Object)).Returns(_character.Object);
            _commandCharacter.Setup(obj => obj.Update(_character.Object));
            _queryCharacter.Setup(obj => obj.GetById(elementId)).ReturnsAsync(_character.Object);

            var response = await _characterService.UpdateElement(_characterRequest.Object, elementId);

            Assert.IsAssignableFrom<Character>(response);
            _commandCharacter.Verify(command => command.Update(_character.Object), Times.Once());
        }

        [Fact]
        public async Task GetByRequest_testCharacterRequestIsNull ()
        {
            CharacterRequest characterRequest = null;

            await Assert.ThrowsAsync<ItemError>(() => _characterService.GetByRequest(characterRequest));
        }

        [Fact]
        public async Task GetByRequest_testCharacterIsNull ()
        {
            Character character = null;

            _queryCharacter.Setup(obj => obj.GetByRequest(_characterRequest.Object)).ReturnsAsync(character);

            var response = await _characterService.GetByRequest(_characterRequest.Object);

            Assert.Null(response);
        }

        [Fact]
        public async Task GetByRequest_testOk ()
        {
            _queryCharacter.Setup(obj => obj.GetByRequest(_characterRequest.Object)).ReturnsAsync(_character.Object);

            var response = await _characterService.GetByRequest(_characterRequest.Object);

            Assert.IsAssignableFrom<Character>(response);
        }

        [Fact]
        public async Task GetByName_testCharacterNameIsNull ()
        {
            string characterName = null;

            await Assert.ThrowsAsync<ItemError>(() => _characterService.GetByName(characterName));
        }

        [Fact]
        public async Task GetByName_testCharacterIsNull ()
        {
            string characterName = "";
            Character character = null;

            _queryCharacter.Setup(obj => obj.GetByName(characterName)).ReturnsAsync(character);

            var response = await _characterService.GetByName(characterName);

            Assert.Null(response);
        }

        [Fact]
        public async Task GetByName_testOk ()
        {
            string characterName = "";

            _queryCharacter.Setup(obj => obj.GetByName(characterName)).ReturnsAsync(_character.Object);

            var response = await _characterService.GetByName(characterName);

            Assert.IsAssignableFrom<Character>(response);
        }

        [Fact]
        public async Task GetByAge_testAgeIncorrect ()
        {
            int age = 0;

            await Assert.ThrowsAsync<ItemError>(() => _characterService.GetByAge(age));

        }

        [Fact]
        public async Task GetByAge_testCharacterIsNull ()
        {
            int age = 1;
            Character character = null;

            _queryCharacter.Setup(obj => obj.GetByAge(age)).ReturnsAsync(character);

            var response = await _characterService.GetByAge(age);

            Assert.Null(response);
        }

        [Fact]
        public async Task GetByAge_testOk ()
        {
            int age = 1;

            _queryCharacter.Setup(obj => obj.GetByAge(age)).ReturnsAsync(_character.Object);

            var response = await _characterService.GetByAge(age);

            Assert.IsAssignableFrom<Character>(response);
        }

        [Fact]
        public async Task GetByMoviOrSerieId_testMovieOrSerieIdIncorrect ()
        {
            int movieOrSerieId = 0;

            await Assert.ThrowsAsync<ItemError>(() => _characterService.GetByMoviOrSerieId(movieOrSerieId));

        }

        [Fact]
        public async Task GetByMoviOrSerieId_testCharacterListIsNull ()
        {
            int movieOrSerieId = 1;

            IEnumerable<Character> characterList = null;

            _queryCharacter.Setup(obj => obj.GetList()).ReturnsAsync(characterList);

            await Assert.ThrowsAsync<ItemNotFound>(() => _characterService.GetByMoviOrSerieId(movieOrSerieId));
        }

        [Fact]
        public async Task GetByMoviOrSerieId_testCharacterListIsCero ()
        {
            int movieOrSerieId = 1;

            IEnumerable<Character> characterList = new List<Character>();

            _queryCharacter.Setup(obj => obj.GetList()).ReturnsAsync(characterList);

            await Assert.ThrowsAsync<ItemNotFound>(() => _characterService.GetByMoviOrSerieId(movieOrSerieId));
        }

        [Fact]
        public async Task GetByMoviOrSerieId_testOk ()
        {

        }
    }
}
