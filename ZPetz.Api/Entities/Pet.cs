namespace ZPetz.Api.Entities
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float ActualWeight { get; set; }
        public string Breed { get; set; }
        public Gender Gender { get; set; }
        public string PictureUrl { get; set; }
        public List<Tutor> Tutors { get; set; } = new();
        public List<Vaccine> Vaccines { get; set; } = new();
        public List<Weight> Weights { get; set; } = new();

        public static Pet Create(Tutor tutor, string name, DateTime birthDate, string breed, Gender gender, float weight)
        {
            var pet =  new Pet
            {
                Id = Guid.NewGuid(),
                Name = name,
                BirthDate = birthDate,
                Breed = breed,
                Gender = gender,
                Tutors = new List<Tutor> { tutor }
            };

            pet.AddWeight(new Weight { Value = weight, Date = DateTime.UtcNow });
            
            return pet;
        }

        public void AddWeight(Weight weight)
        {
            Weights ??= new();
            Weights.Add(weight);

            var lastWeight = Weights.OrderByDescending(w => w.Date).First();
            ActualWeight = lastWeight.Value;
        }

        public void AddVaccine(Vaccine vaccine)
        {
            Vaccines ??= new();
            Vaccines.Add(vaccine);
        }

        public bool IsOwnedBy(Guid tutorId)
        {
            return Tutors.Find(t => t.Id == tutorId) != null;
        }
    }
}
