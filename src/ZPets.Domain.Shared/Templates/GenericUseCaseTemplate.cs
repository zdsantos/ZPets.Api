using AutoMapper;
using ZPets.Domain.Shared.Interfaces;
using ZPets.Infra.Data;

namespace ZPets.Domain.Shared.Templates
{
    public abstract class GenericUseCaseTemplate<TRequest, TValidator, TResponseData> where TRequest : IRequest where TValidator : IUseCaseValidator<TRequest>
    {
        protected readonly ApplicationContext _appContext;
        protected readonly IMapper _mapper;

        protected readonly TValidator _validator;
        protected TRequest _request;
        protected UseCaseResponseData<TResponseData> _response;

        protected GenericUseCaseTemplate(ApplicationContext appContext, TValidator validator, IMapper mapper)
        {
            _appContext = appContext;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<UseCaseResponseData<TResponseData>> Execute(TRequest request)
        {
            _request = request;
            _response = new UseCaseResponseData<TResponseData>();
            _validator.SetRequest(_request);
            _validator.SetResponse(_response);
            
            await _validator.Validate();

            if (!_response.Success())
                return _response;

            await Process();
            _appContext.SaveChanges();

            if (!_response.Success())
                return _response;

            _response.SetData(GetResult());

            return _response;
        }

        protected abstract TResponseData GetResult();

        protected abstract Task Process();
    }
}
