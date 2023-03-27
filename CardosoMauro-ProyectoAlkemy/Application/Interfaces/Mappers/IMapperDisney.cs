using Application.Models.Request;
using Application.Models.Response;
using Domain.Entities;

namespace Application.Interfaces.Mappers
{
    public interface IMapperDisney
    {
        Gender GenderRequestAtGender(GenderRequest genderRequest);

        GenderResponseSL GenderAtGenderResponseSL(Gender gender);

        GenderResponse GenderAtResponse(Gender gender);

        Gender GenderAtGenderUpdate (Gender gender, GenderRequest genderRequest);

        MovieOrSerie MovieOrSerieAtMovieOrSerieUpdate(MovieOrSerie movieOrSerie, MovieOrSerieRequest movieOrSerieRequest);

        MovieOrSerie MovieOrSerieRequestAtMovieOrSerie(MovieOrSerieRequest movieOrSerieRequest);

        Task<MovieOrSerieResponse> MovieOrSerieAtMovieOrSerieResponse(MovieOrSerie movieOrSerie);

        MovieOrSerieResponseMin MovieOrSerieAtMovieOrSerieResponseMin(MovieOrSerie movieOrSerie);

        MovieOrSerieResponseSL MovieOrSerieAtMovieOrSerieResponseSL(MovieOrSerie movieOrSerie);

        Character CharacterRequestAtCharacter(CharacterRequest characterRequest);

        CharactersResponse CharacterAtCharactersResponse(Character character);

        Task<CharacterResponse> CharacterAtCharacterResponse(Character character);

        CharacterResponseSL CharacterAtCharacterResponseSL(Character character);

        Character CharacterAtCharacterUpdate(Character character, CharacterRequest characterRequest);

        CharacterMovieOrSerieResponse CharacterMovieOrSerieATResponse(CharacterMovieOrSerie characterMovieOrSerie);

        CharacterMovieOrSerie CharacterMovieOrSerieRequestAtCharacterMovieOrSerie (CharacterMovieOrSerieRequest characterMovieOrSerieRequest);

        User UserRequestAtUser(UserRequest userRequest);

        UserResponse UserAtResponse(User user);

        PayloadUserResponse userAtPayloadNoToken(User user);

        User UserAtUserUpdate(User user, UserRequest userRequest);
    }
}
