using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using StudentManagement.IRepository;

namespace StudentManagement.DapperRepository.Installer
{
    public class DapperRepositoryInstaller: IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IStudentRepository>().ImplementedBy<StudentDapperRepository>().LifestyleSingleton());
        }
    }
}
