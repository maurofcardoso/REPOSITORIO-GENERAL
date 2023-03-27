namespace Application.Models.Response
{
    public class GenderResponse
    {
        public GenderResponse()
        {
            this.MoviesOrSeriesAssociated = new List<MovieOrSerieResponseSL>();
        }
        public int GenderId { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public IEnumerable<MovieOrSerieResponseSL> MoviesOrSeriesAssociated { get; set; }
    }
}
