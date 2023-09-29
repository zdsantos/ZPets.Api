namespace ZPetz.Api.UseCases.Tutors.UpdateTutor
{
    public class UpdateTutorRequest
    {
        public Guid TutorId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}
