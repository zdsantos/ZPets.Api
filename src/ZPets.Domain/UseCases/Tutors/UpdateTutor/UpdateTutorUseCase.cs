using ZPets.Domain.Entities.Tutors;
using ZPets.Infra.Data;

namespace ZPets.Domain.UseCases.Tutors.UpdateTutor
{
    //public class UpdateTutorUseCase : BaseUseCase<UpdateTutorRequest, string>
    //{
    //    private Tutor? _tutor;

    //    public UpdateTutorUseCase(ApplicationContext appContext) : base(appContext)
    //    {
    //    }

    //    public override Task Process()
    //    {
    //        _appContext.Tutors.Update(_tutor!);
    //        _appContext.SaveChanges();
    //        _response.SetData(_tutor!.Id.ToString());

    //        return Task.CompletedTask;
    //    }

    //    public override Task Validate()
    //    {
    //        ValidateEmptyFields();

    //        if (!_response.Success())
    //        {
    //            return Task.CompletedTask;
    //        }

    //        ValidateTutor();

    //        if (!_response.Success())
    //        {
    //            return Task.CompletedTask;
    //        }

    //        ValidateEmailAvalability();

    //        return Task.CompletedTask;
    //    }

    //    private void ValidateEmptyFields()
    //    {
    //    }

    //    private void ValidateTutor()
    //    {
    //        _tutor = _appContext.Tutors.Find(_request.TutorId);

    //        if (_tutor == null)
    //        {
    //            _response.SetBadRequest("", "Tutor não encontrado");
    //        }
    //    }

    //    private void ValidateEmailAvalability()
    //    {
    //        var tutor = _appContext.Tutors.Where(t => t.Email == _request.Email);
    //        if (tutor.Any() && tutor.First().Id != _tutor!.Id)
    //        {
    //            _response.SetBadRequest("", "Email já está sendo utilizado");
    //        }
    //    }
    //}
}
