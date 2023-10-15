namespace ZPets.Domain.Shared.Templates
{
    public class UseCaseResponse
    {
        public List<ErrorMessage>? Errors { get; set; }
        public ErrorKind ErrorKind { get; private set; }

        public bool Success()
        {
            return Errors == null || !Errors.Any();
        }

        public void SetBadRequest(ErrorMessage errorMessage)
        {
            SetError(ErrorKind.BadRequest, errorMessage);
        }

        public void SetNotFound(ErrorMessage errorMessage)
        {
            SetError(ErrorKind.Unauthorized, errorMessage);
        }

        public void SetUnauthorized(ErrorMessage errorMessage)
        {
            SetError(ErrorKind.Unauthorized, errorMessage);
        }

        public void SetForbidden()
        {
            SetError(ErrorKind.Forbidden, new ErrorMessage("", ""));
        }

        private void SetError(ErrorKind errorKind, ErrorMessage error)
        {
            ErrorKind = errorKind;

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
