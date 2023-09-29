﻿using Microsoft.EntityFrameworkCore;
using ZPets.Api.Entities;
using ZPets.Api.Infra.Data;
using ZPets.Api.UseCases.Base;

namespace ZPets.Api.UseCases.Pets.ListPets
{
    public class ListPetsUseCase : BaseUseCase<ListPetsRequest, List<Pet>>
    {
        public ListPetsUseCase(ApplicationContext appContext) : base(appContext)
        {
        }

        public override Task Process()
        {
            var pets = _appContext.Tutors.Find(_request.TutorId)!.Pets;

            _response.SetData(pets);

            return Task.CompletedTask;
        }

        public override Task Validate()
        {
            ValidateTutor();

            return Task.CompletedTask;
        }

        private void ValidateTutor()
        {
            var tutor = _appContext.Tutors.Find(_request.TutorId);

            if (tutor == null)
            {
                _response.SetBadRequest("", "Tutor não encontrado");
            }
        }
    }
}
