using Application.Interfaces.CommandAndQuery;
using Application.Interfaces.Mappers;
using Application.Models.Request;
using Application.Models.Response;
using Application.Tools;
using Domain.Entities;

namespace Application.Mappers.MapperDisney
{
    public class MapperDisney : IMapperDisney
    {
        private readonly IQuery<Character> _queryCharactert;
        private readonly IQuery<MovieOrSerie> _queryMovieOrSerie;
        private readonly IQuery<Gender> _queryGender;

        public MapperDisney(IQuery<Character> query, IQuery<MovieOrSerie> queryMovieOrSerie, IQuery<Gender> queryGender)
        {
            _queryCharactert = query;
            _queryMovieOrSerie = queryMovieOrSerie;
            _queryGender = queryGender;
        }

        public Gender GenderRequestAtGender (GenderRequest genderRequest)
        {
            return new Gender
            {
                Name = genderRequest.Name,
                Image = genderRequest.Image,
            };
        }

        public GenderResponseSL GenderAtGenderResponseSL(Gender gender)
        {
            GenderResponseSL genderResponse = new GenderResponseSL
            {
                GenderId = gender.GenderId,
                Name = gender.Name,
                Image = gender.Image,
            };
            return genderResponse;
        }

        public GenderResponse GenderAtResponse(Gender gender)
        {
            GenderResponse genderResponse = new GenderResponse
            {
                GenderId = gender.GenderId,
                Name = gender.Name,
                Image = gender.Image,
            };
            List<MovieOrSerieResponseSL> movieOrSerieResponseSLList = new List<MovieOrSerieResponseSL>();
            foreach (MovieOrSerie x in gender.MoviesOrSeriesAssociated)
            {
                movieOrSerieResponseSLList.Add(this.MovieOrSerieAtMovieOrSerieResponseSL(x));
            }
            genderResponse.MoviesOrSeriesAssociated = movieOrSerieResponseSLList;
            return genderResponse;
        }

        public Gender GenderAtGenderUpdate(Gender gender, GenderRequest genderRequest)
        {
            return new Gender
            {
                GenderId = gender.GenderId,
                Name = genderRequest.Name,
                Image = genderRequest.Image,
                MoviesOrSeriesAssociated = gender.MoviesOrSeriesAssociated,
            };
        }

        public MovieOrSerie MovieOrSerieAtMovieOrSerieUpdate(MovieOrSerie movieOrSerie, MovieOrSerieRequest movieOrSerieRequest)
        {
            return new MovieOrSerie
            {
                MovieOrSerieId = movieOrSerie.MovieOrSerieId,
                Image = movieOrSerieRequest.Image,
                Title = movieOrSerieRequest.Title,
                CreationDate = movieOrSerieRequest.CreationDate,
                Qualification = movieOrSerieRequest.Qualification,
                Gender = movieOrSerie.Gender,
            };
        }

        public MovieOrSerie MovieOrSerieRequestAtMovieOrSerie (MovieOrSerieRequest movieOrSerieRequest)
        {
            return new MovieOrSerie
            {
                Image = movieOrSerieRequest.Image,
                Title = movieOrSerieRequest.Title,
                CreationDate = movieOrSerieRequest.CreationDate,
                Qualification = movieOrSerieRequest.Qualification,
            };
        }

        public async Task<MovieOrSerieResponse> MovieOrSerieAtMovieOrSerieResponse(MovieOrSerie movieOrSerie)
        {
            MovieOrSerieResponse movieOrSerieResponse = new MovieOrSerieResponse
            {
                MovieOrSerieId = movieOrSerie.MovieOrSerieId,
                Image = movieOrSerie.Image,
                Title = movieOrSerie.Title,
                CreationDate = movieOrSerie.CreationDate,
                Qualification = movieOrSerie.Qualification,
            };
            List<CharacterResponseSL> characterResponseList = new List<CharacterResponseSL>();
            foreach (CharacterMovieOrSerie x in movieOrSerie.CharacterAssociated)
            {
                Character character = await _queryCharactert.GetById(x.CharacterId);
                characterResponseList.Add(this.CharacterAtCharacterResponseSL(character));
            }
            movieOrSerieResponse.CharacterAssociated = characterResponseList;
            movieOrSerieResponse.Gender = this.GenderAtGenderResponseSL(await _queryGender.GetById(movieOrSerie.GenderId));
            return movieOrSerieResponse;
        }

        public MovieOrSerieResponseSL MovieOrSerieAtMovieOrSerieResponseSL(MovieOrSerie movieOrSerie)
        {
            MovieOrSerieResponseSL movieOrSerieResponse = new MovieOrSerieResponseSL
            {
                MovieOrSerieId = movieOrSerie.MovieOrSerieId,
                Image = movieOrSerie.Image,
                Title = movieOrSerie.Title,
                CreationDate = movieOrSerie.CreationDate,
                Qualification = movieOrSerie.Qualification,
                Gender = this.GenderAtGenderResponseSL(movieOrSerie.Gender),
            };
            return movieOrSerieResponse;
        }

        public MovieOrSerieResponseMin MovieOrSerieAtMovieOrSerieResponseMin(MovieOrSerie movieOrSerie)
        {
            return new MovieOrSerieResponseMin
            {
                Image = movieOrSerie.Image,
                Title = movieOrSerie.Title,
                CreationDate = movieOrSerie.CreationDate,
            };
        }

        public Character CharacterRequestAtCharacter(CharacterRequest characterRequest)
        {
            return new Character
            {
                Image = characterRequest.Image,
                Name = characterRequest.Name,
                Age = characterRequest.Age,
                Weight = characterRequest.Weight,
                History = characterRequest.History,
            };
        }

        public CharactersResponse CharacterAtCharactersResponse(Character character)
        {
            return new CharactersResponse
            {
                Imagen = character.Image,
                Name = character.Name,
            };
        }

        public async Task<CharacterResponse> CharacterAtCharacterResponse(Character character)
        {
            CharacterResponse characterResponse = new CharacterResponse
            {
                CharacterId = character.CharacterId,
                Image = character.Image,
                Name = character.Name,
                Age = character.Age,
                Weight= character.Weight,
                History = character.History,
            };

            List<MovieOrSerieResponseSL> movieOrSerieList = new List<MovieOrSerieResponseSL>();
            foreach (CharacterMovieOrSerie x in character.MoviesOrSeriesAssociated)
            {
                MovieOrSerie movieOrSerie = await _queryMovieOrSerie.GetById(x.MovieOrSerieId);
                movieOrSerieList.Add(this.MovieOrSerieAtMovieOrSerieResponseSL(movieOrSerie));
            }

            characterResponse.MoviesOrSeriesAssociated = movieOrSerieList;
            return characterResponse;
        }

        public CharacterResponseSL CharacterAtCharacterResponseSL(Character character)
        {
            CharacterResponseSL characterResponse = new CharacterResponseSL
            {
                CharacterId = character.CharacterId,
                Image = character.Image,
                Name = character.Name,
                Age = character.Age,
                Weight = character.Weight,
                History = character.History,
            };

            return characterResponse;
        }

        public Character CharacterAtCharacterUpdate(Character character, CharacterRequest characterRequest)
        {
            character.CharacterId = character.CharacterId;
            character.Image = characterRequest.Image;
            character.Name = characterRequest.Name;
            character.Age = characterRequest.Age;
            character.Weight = characterRequest.Weight;
            character.History = characterRequest.History;
            character.MoviesOrSeriesAssociated = character.MoviesOrSeriesAssociated;
            return character;
        }

        public CharacterMovieOrSerieResponse CharacterMovieOrSerieATResponse(CharacterMovieOrSerie characterMovieOrSerie)
        {
            return new CharacterMovieOrSerieResponse
            {
                CharacterId = characterMovieOrSerie.CharacterId,
                MovieOrSerieId = characterMovieOrSerie.MovieOrSerieId,
            };
        }

        public CharacterMovieOrSerie CharacterMovieOrSerieRequestAtCharacterMovieOrSerie(CharacterMovieOrSerieRequest characterMovieOrSerieRequest)
        {
            return new CharacterMovieOrSerie
            {
                CharacterId = characterMovieOrSerieRequest.CharacterId,
                MovieOrSerieId = characterMovieOrSerieRequest.MovieOrSerieId,
            };
        }

        public User UserRequestAtUser(UserRequest userRequest)
        {
            return new User
            {
                Email = userRequest.Email,
                Password = Encript.GetSHA256(userRequest.Password),
                Name = userRequest.Name,
                LastName = userRequest.LastName,
            };
        }

        public UserResponse UserAtResponse(User user)
        {
            return new UserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                LastName = user.LastName,
            };
        }

        public PayloadUserResponse userAtPayloadNoToken(User user)
        {
            return new PayloadUserResponse
            {
                UserId = user.UserId,
                Email = user.Email,
                Password = user.Password,
                Name = user.Name,
                LastName = user.LastName,
            };
        }

        public User UserAtUserUpdate(User user, UserRequest userRequest)
        {
            user.Email = userRequest.Email;
            user.Password = userRequest.Password;
            user.Name = userRequest.Name;
            user.LastName = userRequest.LastName;
            return user;
        }
    }
}
