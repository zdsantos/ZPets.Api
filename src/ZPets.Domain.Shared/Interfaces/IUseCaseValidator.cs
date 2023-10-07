using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.Shared.Interfaces
{
    public interface IUseCaseValidator<in TRequest> where TRequest : IRequest
    {
        void SetRequest(TRequest request);

        void SetResponse(UseCaseResponse response);

        Task Validate();
    }
}
