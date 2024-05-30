using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ZPets.Domain.Helpers
{
    public static class ValidatorsHelper
    {
        public static bool ValidatePassword(string password)
        {
            // Add rules: special caracters
            return password.Length >= 6;
        }
    }
}
