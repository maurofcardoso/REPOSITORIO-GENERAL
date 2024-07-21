namespace Aplication.Response
{
    public class ErrorResponse
    {
        public string Date { get; set; }
        public int Status { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
    }
}
