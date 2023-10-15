using Microsoft.AspNetCore.Mvc;
using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Templates;
using ZPets.Domain.UseCases.Identity;

namespace ZPets.Api.Controllers
{
    [ApiController]
    [Route("api/identity")]
    public class IdentityController
    {
        private readonly IServiceProvider _serviceProvider;

        public IdentityController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginRequest request)
        {
            UseCaseResponseData<LoginDto> response = await _serviceProvider.GetService<ILoginUseCase>()!.Execute(request);

            if (!response.Success())
            {
                return new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.ErrorKind
                };
            }

            return new OkObjectResult(response.Data);
        } 
    }
}
