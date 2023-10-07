using Microsoft.AspNetCore.Http;
using ZPets.Domain.Shared.Interfaces;
using ZPets.Infra.Data;
using ZPets.Infra.Extensions;

namespace ZPets.Domain.Shared.Templates
{
    public abstract class GenericValidatorTemplate<TRequest> : IUseCaseValidator<TRequest> where TRequest : IRequest
    {
        protected readonly ApplicationContext _appContext;
        protected readonly string _tutorId;
        protected UseCaseResponse _response;
        protected TRequest _request;

        protected GenericValidatorTemplate(ApplicationContext appContext, IHttpContextAccessor httpContextAccessor)
        {
            _appContext = appContext;
            _tutorId = httpContextAccessor.HttpContext!.GetUserId();
        }

        public void SetRequest(TRequest request)
        {
            _request = request;
        }

        public void SetResponse(UseCaseResponse response)
        {
            _response = response;
        }

        public async Task Validate()
        {
            await ValidatePermissions();

            if (!_response.Success())
                return;

            ValidateRequest();

            if (!_response.Success())
                return;

            await ValidateData();
        }

        protected abstract void ValidateRequest();

        protected abstract Task ValidateData();

        private async Task ValidatePermissions()
        {
            if (!await HasPermissions())
            {
                _response.SetForbidden();
            }
        }

        protected abstract Task<bool> HasPermissions();
    }
}
