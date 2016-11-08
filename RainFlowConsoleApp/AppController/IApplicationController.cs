using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RF.ConsoleApp.AppController
{
    public interface IApplicationController
    {
        IApplicationController RegisterInstance<TArgument>(TArgument instance) where TArgument : class;

        IApplicationController Register(Type service, Type implementation);

        IApplicationController Register(Type service, IEnumerable<Assembly> assambly);

        IApplicationController Register<TService>(Func<TService> instanceCreator) where TService : class;

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        IApplicationController RegisterDecorator(Type serviceType, Type decoratorType);

        object GetInstance(Type serviceType);

        object GetInstance<TService>();
    }
}
