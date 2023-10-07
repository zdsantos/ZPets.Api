using ZPets.Domain.Entities.Pets;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Pets.GetPet
{
    //public class GetPetUseCase : BaseUseCase<GetPetRequest, Pet>
    //{
    //    public GetPetUseCase(ApplicationContext appContext) : base(appContext)
    //    {
    //    }

    //    public override Task Process()
    //    {
    //        var result = _appContext.Set<Pet>().Find(_request.PetId);

    //        if (result == null)
    //        {
    //            _response.SetNotFound("", $"Pet {_request.PetId} não encontrado");
    //        }
    //        else
    //        {
    //            _response.SetData(result);
    //        }

    //        return Task.CompletedTask;
    //    }

    //    public override async Task Validate()
    //    {
    //        //if (_request.TutorId == _request.TutorId)
    //        //{
    //        //    _response.SetUnauthorized("", "Acesso ao Pet negado");
    //        //}
    //    }
    //}
}
