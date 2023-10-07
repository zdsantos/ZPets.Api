using Microsoft.EntityFrameworkCore;
using ZPets.Domain.Entities.Pets;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Pets.ListPets
{
    //public class ListPetsUseCase : BaseUseCase<ListPetsRequest, List<Pet>>
    //{
    //    public ListPetsUseCase(ApplicationContext appContext) : base(appContext)
    //    {
    //    }

    //    public override async Task Process()
    //    {
    //        var tutor = await _appContext.Tutors
    //            .Include(t => t.Pets)
    //            .ThenInclude(po => po.Pet).AsSplitQuery()
    //            .FirstAsync(t => t.Id == _request.TutorId);

    //        _response.SetData(tutor.Pets.Select(po => po.Pet).ToList());
    //    }

    //    public override Task Validate()
    //    {
    //        ValidateTutor();

    //        return Task.CompletedTask;
    //    }

    //    private void ValidateTutor()
    //    {
    //        var tutor = _appContext.Tutors.Find(_request.TutorId);

    //        if (tutor == null)
    //        {
    //            _response.SetBadRequest("", "Tutor não encontrado");
    //        }
    //    }
    //}
}
