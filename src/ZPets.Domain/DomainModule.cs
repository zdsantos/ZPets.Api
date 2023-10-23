using Autofac;
using ZPets.Domain.UseCases.Identity;
using ZPets.Domain.UseCases.Pets.CreatePet;
using ZPets.Domain.UseCases.Pets.ListPets;
using ZPets.Domain.UseCases.Tutors.GetTutor;
using ZPets.Domain.UseCases.Tutors.RegisterTutor;
using ZPets.Domain.UseCases.Tutors.UpdateTutor;

namespace ZPets.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            LoadUseCases(builder);
            LoadValidators(builder);
        }

        private static void LoadUseCases(ContainerBuilder builder)
        {
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            
            builder.RegisterType<RegisterTutorUseCase>().As<IRegisterTutorUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetTutorUseCase>().As<IGetTutorUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateTutorUseCase>().As<IUpdateTutorUseCase>().InstancePerLifetimeScope();

            builder.RegisterType<CreatePetUseCase>().As<ICreatePetUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<ListPetsUseCase>().As<IListPetsUseCase>().InstancePerLifetimeScope();
        }

        private static void LoadValidators(ContainerBuilder builder)
        {
            builder.RegisterType<LoginValidator>().InstancePerLifetimeScope();
            
            builder.RegisterType<RegisterTutorValidator>().InstancePerLifetimeScope();
            builder.RegisterType<GetTutorValidator>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateTutorValidator>().InstancePerLifetimeScope();

            builder.RegisterType<CreatePetValidator>().InstancePerLifetimeScope();
            builder.RegisterType<ListPetsValidator>().InstancePerLifetimeScope();
        }
    }
}
