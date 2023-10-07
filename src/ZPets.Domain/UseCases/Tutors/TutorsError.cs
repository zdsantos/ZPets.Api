using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Tutors
{
    public static class TutorsError
    {
        private static readonly string Prefix = "ERR-TUTOR-";

        private static readonly string NotFoundCode = "0001";
        private static readonly string EmailAlreadInUseCode = "0002";
        private static readonly string WrongPatternPasswordCode = "0003";


        private static readonly string EmptyIdCode = "0011";
        private static readonly string EmptyNameCode = "0012";
        private static readonly string EmptyPasswordCode = "0013";
        private static readonly string EmptyEmailCode = "0014";

        public static class Message
        {
            public static readonly ErrorMessage NotFound = new(Prefix + NotFoundCode, "Tutor não encontrado");
            public static readonly ErrorMessage EmailAlreadInUse = new(Prefix + EmailAlreadInUseCode, "Email já está em uso");
            public static readonly ErrorMessage WrongPatternPassword = new(Prefix + WrongPatternPasswordCode, "Password não está no padrão");

            public static readonly ErrorMessage EmptyId = new(Prefix + EmptyIdCode, "TutorId é obrigatório");
            public static readonly ErrorMessage EmptyName = new(Prefix + EmptyNameCode, "Nome é obrigatório");
            public static readonly ErrorMessage EmptyPassword = new(Prefix + EmptyPasswordCode, "Senha é obrigatória");
            public static readonly ErrorMessage EmptyEmail = new(Prefix + EmptyEmailCode, "Email é obrigatório");
        }
    }
}
