namespace ZPetz.Api.UseCases.Base
{
    public class UseCaseResponse
    {
        public List<ErrorMessage>? Errors { get; set; }

        public bool Success()
        {
            return Errors == null || !Errors.Any();
        }

        public void SetBadRequest(string code, string message)
        {
            SetError(new ErrorMessage() { ErrorKind = ErrorKind.BadRequest, Code = code, Message = message });
        }

        public void SetNotFound(string code, string message)
        {
            SetError(new ErrorMessage() { ErrorKind = ErrorKind.NotFound, Code = code, Message = message });
        }

        public void SetUnauthorized(string code, string message)
        {
            SetError(new ErrorMessage() { ErrorKind = ErrorKind.Unauthorized, Code = code, Message = message });
        }

        public ErrorKind? GetErrorKind()
        {
            if (Success())
            {
                return null;
            }

            return Errors.First().ErrorKind;
        }

        private void SetError(ErrorMessage error)
        {
            Errors ??= new List<ErrorMessage>();

            Errors.Add(error);
        }
    }

    public class UseCaseResponseData<T> : UseCaseResponse
    {
        public T? Data { get; private set; }

        public void SetData(T data)
        {
            Data = data;
        }
    }
}
