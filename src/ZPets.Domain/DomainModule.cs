using Autofac;
using ZPets.Domain.UseCases.Identity;
using ZPets.Domain.UseCases.Tutors.GetTutor;
using ZPets.Domain.UseCases.Tutors.RegisterTutor;

namespace ZPets.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoadUseCases(builder);
            LoadValidators(builder);
        }

        private void LoadUseCases(ContainerBuilder builder)
        {
            builder.RegisterType<GetTutorUseCase>().As<IGetTutorUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterTutorUseCase>().As<IRegisterTutorUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
        }

        private void LoadValidators(ContainerBuilder builder)
        {
            builder.RegisterType<GetTutorValidator>().InstancePerLifetimeScope();
            builder.RegisterType<RegisterTutorValidator>().InstancePerLifetimeScope();
            builder.RegisterType<LoginValidator>().InstancePerLifetimeScope();
        }
    }
}
