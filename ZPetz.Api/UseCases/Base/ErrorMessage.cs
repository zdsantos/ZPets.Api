namespace ZPetz.Api.UseCases.Base
{
    public class ErrorMessage
    {
        public ErrorKind ErrorKind { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}