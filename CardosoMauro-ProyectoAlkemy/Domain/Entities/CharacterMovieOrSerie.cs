namespace Domain.Entities
{
    public class CharacterMovieOrSerie
    {
            public int CharacterId { get; set; }

            public int MovieOrSerieId { get; set; }

            public Character Character { get; set; }

            public MovieOrSerie MovieOrSerie { get; set; }
    }
}
