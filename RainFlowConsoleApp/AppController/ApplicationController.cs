using System;
using System.Collections.Generic;
using System.Reflection;

namespace RF.ConsoleApp.AppController
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContainer _container;

        public ApplicationController(IContainer container)
        {
            _container = container;
            _container.RegisterInstance<IApplicationController>(this);
            _container.RegisterInstance(container);
        }

        public IApplicationController RegisterInstance<TInstance>(TInstance instance) where TInstance : class
        {
            _container.RegisterInstance(instance);
            return this;
        }

        public IApplicationController Register(Type service, Type implementation)
        {
            _container.Register(service, implementation);
            return this;
        }

        public IApplicationController Register<TService>(Func<TService> instanceCreator) where TService : class
        {
            _container.Register(instanceCreator);
            return this;
        }

        public IApplicationController RegisterDecorator(Type serviceType, Type decoratorType)
        {
            _container.RegisterDecorator(serviceType, decoratorType);
            return this;
        }

        public object GetInstance(Type serviceType)
        {
            return _container.Resolve(serviceType);
        }

        public object GetInstance<TService>()
        {
            return _container.Resolve(typeof(TService));
        }

        public IApplicationController RegisterService<TModel, TImplementation>()
            where TImplementation : class, TModel
        {
            _container.Register<TModel, TImplementation>();
            return this;
        }

        public IApplicationController Register(Type service, IEnumerable<Assembly> assambly)
        {
            _container.Register(service, assambly);
            return this;
        }
    }
}
