using Microsoft.AspNetCore.Mvc;
using ZPets.Domain.Dto;
using ZPets.Domain.Shared.Templates;
using ZPets.Domain.UseCases.Pets.CreatePet;
using ZPets.Domain.UseCases.Pets.ListPets;

namespace ZPets.Api.Controllers
{
    [ApiController]
    [Route("api/{tutorId}/pets")]
    public class PetsController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public PetsController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost]
        public async Task<ActionResult<PetDto>> CreatePet([FromRoute] string tutorId, [FromBody] CreatePetRequest request)
        {
            request.TutorId = tutorId;

            UseCaseResponseData<PetDto> response = await _serviceProvider.GetService<ICreatePetUseCase>()!.Execute(request);

            if (!response.Success())
            {
                return new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.ErrorKind,
                };
            }

            return new OkObjectResult(response.Data);
        }

        //[HttpGet("{petId}")]
        //public async Task<ActionResult> GetPet([FromRoute] string tutorId, [FromRoute] string petId)
        //{
        //    UseCaseResponseData<Pet> response = await new GetPetUseCase(_appContext).Execute(new GetPetRequest() { TutorId = tutorId, PetId = petId });

        //    if (!response.Success())
        //    {
        //        return new ObjectResult(response.Errors)
        //        {
        //            StatusCode = (int)response.GetErrorKind().Value,
        //        };
        //    }

        //    return new OkObjectResult(response.Data);
        //}

        [HttpGet]
        public async Task<ActionResult<List<PetDto>>> ListPets([FromRoute] string tutorId)
        {
            UseCaseResponseData<List<PetDto>> response = await _serviceProvider.GetService<IListPetsUseCase>()!.Execute(new ListPetsRequest() { TutorId = tutorId });

            if (!response.Success())
            {
                return new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.ErrorKind,
                };
            }

            return new OkObjectResult(response.Data);
        }
    }
}
