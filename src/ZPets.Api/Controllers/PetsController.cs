using Microsoft.AspNetCore.Mvc;

namespace ZPets.Api.Controllers
{
    [ApiController]
    [Route("api/{tutorId}/pets")]
    public class PetsController : ControllerBase
    {
        //private IServiceProvider _serviceProvider;
        //private ApplicationContext _appContext;

        //public PetsController(IServiceProvider serviceProvider, ApplicationContext appContext)
        //{
        //    _serviceProvider = serviceProvider;
        //    _appContext = appContext;
        //}

        //[HttpPost]
        //public async Task<ActionResult> CreatePet([FromRoute] Guid tutorId, [FromBody] CreatePetRequest request)
        //{
        //    request.TutorId = tutorId;

        //    UseCaseResponseData<string> response = await new CreatePetUseCase(_appContext).Execute(request);

        //    if (!response.Success())
        //    {
        //        return new ObjectResult(response.Errors)
        //        {
        //            StatusCode = (int)response.GetErrorKind().Value,
        //        };
        //    }

        //    return new OkObjectResult(response.Data);
        //}

        //[HttpGet("{petId}")]
        //public async Task<ActionResult> GetPet([FromRoute] Guid tutorId, [FromRoute] Guid petId)
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

        //[HttpGet]
        //public async Task<ActionResult<List<Pet>>> ListPets([FromRoute] Guid tutorId)
        //{
        //    UseCaseResponseData<List<Pet>> response = await new ListPetsUseCase(_appContext).Execute(new ListPetsRequest() { TutorId = tutorId });

        //    if (!response.Success())
        //    {
        //        return new ObjectResult(response.Errors)
        //        {
        //            StatusCode = (int)response.GetErrorKind().Value,
        //        };
        //    }

        //    return new OkObjectResult(response.Data);
        //}
    }
}
