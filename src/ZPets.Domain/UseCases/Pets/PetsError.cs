using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Pets
{
    public static class PetsError
    {
        private static readonly string Prefix = "ERR-PET-";

        private static readonly string NotFoundCode = "0001";
        private static readonly string InvalidWeightCode = "0002";
        private static readonly string InvalidBirthDateCode = "0003";

        private static readonly string EmptyIdCode = "0011";
        private static readonly string EmptyNameCode = "0012";
        private static readonly string EmptyBreedCode = "0013";

        public static class Message
        {
            public static readonly ErrorMessage NotFound = new(Prefix + NotFoundCode, "Pet não encontrado");
            public static readonly ErrorMessage InvalidWeight = new (Prefix + InvalidWeightCode, "Peso deve ser um valor maior que zero");
            public static readonly ErrorMessage InvalidBirthDate = new(Prefix + InvalidBirthDateCode, "Data de nascimento inválida");

            public static readonly ErrorMessage EmptyId = new(Prefix + EmptyIdCode, "PetId é obrigatório");
            public static readonly ErrorMessage EmptyName = new(Prefix + EmptyNameCode, "Nome é obrigatório");
            public static readonly ErrorMessage EmptyBreed = new(Prefix + EmptyBreedCode, "Raça é obrigatória");

        }
    }
}
