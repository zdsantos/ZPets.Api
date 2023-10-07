namespace ZPets.Domain.Shared.Interfaces
{
    public interface IUseCase<TRequest, TResponse> where TRequest : IRequest
    {
        Task<TResponse> Execute(TRequest request); 
    }
}
