﻿using ZPetz.Api.Entities;
using ZPetz.Api.Infra.Data;
using ZPetz.Api.UseCases.Base;

namespace ZPetz.Api.UseCases.Tutors.CreateTutor
{
    public class CreateTutorUseCase : BaseUseCase<CreateTutorRequest, string>
    {
        public CreateTutorUseCase(ApplicationContext appContext) : base(appContext)
        {
        }

        public override Task Process()
        {
            Tutor newTutor = new Tutor
            {
                Id = Guid.NewGuid(),
                Email = _request.Email,
                Name = _request.Name,
            };

            _appContext.Tutors.Add(newTutor);
            _appContext.SaveChanges();

            _response.SetData(newTutor.Id.ToString());

            return Task.CompletedTask;
        }

        public override Task Validate()
        {
            var found = _appContext.Tutors.Where(t => t.Email == _request.Email);

            if (found.Any())
            {
                _response.SetBadRequest("", "Email já existe");
            }

            return Task.CompletedTask;
        }
    }
}
