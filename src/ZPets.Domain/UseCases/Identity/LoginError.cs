using ZPets.Domain.Shared.Templates;

namespace ZPets.Domain.UseCases.Identity
{
    public static class LoginError
    {
        private static readonly string Prefix = "ERR-LOGIN-";

        private static readonly string EmailNotFoundCode = "0001";
        private static readonly string WrongPasswordCode = "0002";


        private static readonly string EmptyEmailCode = "0011";
        private static readonly string EmptyPasswordCode = "0012";

        public static class Message
        {
            public static readonly ErrorMessage EmailNotFound = new(Prefix + EmailNotFoundCode, "Email não cadastrado");
            public static readonly ErrorMessage WrongPassword = new(Prefix + WrongPasswordCode, "Senha inválida");

            public static readonly ErrorMessage EmptyEmail = new(Prefix + EmptyEmailCode, "Email é obrigatório");
            public static readonly ErrorMessage EmptyPassword = new(Prefix + EmptyPasswordCode, "Senha é obrigatório");
        }
    }
}
