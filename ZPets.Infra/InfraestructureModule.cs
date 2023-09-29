using Autofac;

namespace ZPets.Infra
{
    public class InfraestructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoadServices(builder);
        }

        private static void LoadServices(ContainerBuilder builder)
        {
        }
    }
}
