﻿using Microsoft.AspNetCore.Mvc;
using ZPets.Api.Entities;
using ZPets.Api.Infra.Data;
using ZPets.Api.UseCases.Base;
using ZPets.Api.UseCases.Tutors.CreateTutor;
using ZPets.Api.UseCases.Tutors.GetTutor;
using ZPets.Api.UseCases.Tutors.UpdateTutor;

namespace ZPets.Api.Controllers
{
    [ApiController]
    [Route("api/tutors")]
    public class TutorsController : Controller
    {
        private IServiceProvider _serviceProvider;
        private ApplicationContext _appContext;

        public TutorsController(IServiceProvider serviceProvider, ApplicationContext appContext)
        {
            _serviceProvider = serviceProvider;
            _appContext = appContext;
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateTutor([FromBody] CreateTutorRequest request)
        {
            UseCaseResponseData<string> response = await new CreateTutorUseCase(_appContext).Execute(request);

            if (!response.Success())
            {
                return new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.GetErrorKind().Value,
                };
            }

            return new OkObjectResult(response.Data);
        }

        [HttpGet("{tutorId}")]
        public async Task<ActionResult<Tutor>> GetTutor([FromRoute] Guid tutorId)
        {
            UseCaseResponseData<Tutor> response = await new GetTutorUseCase(_appContext).Execute(new GetTutorRequest { TutorId = tutorId });

            if (!response.Success())
            {
                return new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.GetErrorKind().Value,
                };
            }

            return new OkObjectResult(response.Data);
        }

        [HttpPut("{tutorId}")]
        public async Task<ActionResult<string>> UpdateTutor([FromRoute] string tutorId, [FromBody] UpdateTutorRequest request)
        {
            request.TutorId = Guid.Parse(tutorId);

            UseCaseResponseData<string> response = await new UpdateTutorUseCase(_appContext).Execute(request);

            if (!response.Success())
            {
                return new ObjectResult(response.Errors)
                {
                    StatusCode = (int)response.GetErrorKind().Value,
                };
            }

            return new OkObjectResult(response.Data);
        }
    }
}
