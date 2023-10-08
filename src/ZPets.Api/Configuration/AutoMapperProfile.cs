using AutoMapper;
using ZPets.Domain.Dto;
using ZPets.Domain.Entities.Pets;
using ZPets.Domain.Entities.Tutors;

namespace ZPets.Api.Configuration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Tutor, TutorDto>();
            CreateMap<Pet, PetDto>();
            CreateMap<Weight, WeightDto>();
            CreateMap<Vaccine, VaccineDto>();
        }
    }
}
