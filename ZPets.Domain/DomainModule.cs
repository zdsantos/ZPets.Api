using Autofac;

namespace ZPets.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoadUseCases(builder);
            LoadValidators(builder);
        }

        private void LoadValidators(ContainerBuilder builder)
        {
        }

        private void LoadUseCases(ContainerBuilder builder)
        {
        }
    }
}
