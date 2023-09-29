using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Base
{
    public abstract class BaseUseCase<TRequest, TResponse>
    {
        protected TRequest _request;
        protected UseCaseResponseData<TResponse> _response;
        protected readonly ApplicationContext _appContext;

        public BaseUseCase(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<UseCaseResponseData<TResponse>> Execute(TRequest request)
        {
            _request = request;
            _response = new UseCaseResponseData<TResponse>();
            await Validate();

            if (!_response.Success())
            {
                return _response;
            }

            await Process();

            return _response;
        }

        public abstract Task Process();

        public abstract Task Validate();
    }
}
