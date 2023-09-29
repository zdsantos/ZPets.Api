using ZPetz.Api.Infra.Data;

namespace ZPetz.Api.UseCases.Base
{
    public abstract class BaseUseCaseNoResponse<TRequest>
    {
        private TRequest _request;
        private UseCaseResponse _response;
        private readonly ApplicationContext _appContext;

        public BaseUseCaseNoResponse(ApplicationContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<UseCaseResponse> Execute(TRequest request)
        {
            _request = request;
            await Validate();
            _response = new UseCaseResponse();

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
