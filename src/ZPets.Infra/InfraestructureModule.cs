using Autofac;
using ZPets.Infra.Helpers;

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
            LoadHelpers(builder);
        }

        private static void LoadHelpers(ContainerBuilder builder)
        {
            builder.RegisterType<IdentityHelper>().InstancePerLifetimeScope();
        }
    }
}
