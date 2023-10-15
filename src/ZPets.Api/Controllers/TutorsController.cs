using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Templates;
using ZPets.Domain.UseCases.Tutors.GetTutor;
using ZPets.Domain.UseCases.Tutors.RegisterTutor;
using ZPets.Domain.UseCases.Tutors.UpdateTutor;

namespace ZPets.Api.Controllers
{
    [ApiController]
    [Route("api/tutors")]
    public class TutorsController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public TutorsController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("register")]
        public async Task<ActionResult<TutorDto>> RegisterTutor([FromBody] RegisterTutorRequest request)
        {
            UseCaseResponseData<TutorDto> response = await _serviceProvider.GetService<IRegisterTutorUseCase>()!.Execute(request);

            if (!response.Success())
            {
                return new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.ErrorKind
                };
            }

            return new OkObjectResult(response.Data);
        }

        [Authorize]
        [HttpGet("{tutorId}")]
        public async Task<ActionResult<TutorDto>> GetTutor([FromRoute] string tutorId)
        {
            UseCaseResponseData<TutorDto> response = await _serviceProvider.GetService<IGetTutorUseCase>()!.Execute(new GetTutorRequest { TutorId = tutorId });

            if (!response.Success())
            {
                return new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.ErrorKind
                };
            }

            return new OkObjectResult(response.Data);
        }

        [Authorize]
        [HttpPut("{tutorId}")]
        public async Task<ActionResult<TutorDto>> UpdateTutor([FromRoute] string tutorId, UpdateTutorRequest request)
        {
            request.TutorId = tutorId;

            UseCaseResponseData<TutorDto> response = await _serviceProvider.GetService<IUpdateTutorUseCase>()!.Execute(request);

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
