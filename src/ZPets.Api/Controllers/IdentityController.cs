using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<string>> Login([FromBody] LoginRequest request)
        {
            UseCaseResponseData<string> response = await _serviceProvider.GetService<ILoginUseCase>()!.Execute(request);

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
