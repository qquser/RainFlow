using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace RF.ConsoleApp.AppController
{
    public class SimpleInjectorAdapter : IContainer
    {
        private readonly Container _container = new Container();

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _container.Register(typeof(TService), typeof(TImplementation));
        }

        public void Register<TService>(Func<TService> instanceCreator) where TService : class
        {
            _container.Register(instanceCreator);
        }

        public void Register<TService>()
        {
            _container.Register(typeof(TService));
        }

        public void Register(Type serivceType, Type implementingType, string serviceName)
        {
            _container.Register(serivceType, implementingType);
        }

        public void Register(Type serivceType, Type implementingType)
        {
            _container.Register(serivceType, implementingType);
        }

        public void RegisterInstance<T>(T instance) where T : class
        {
            _container.RegisterSingleton(instance);
        }

        public void RegisterDecorator(Type serviceType, Type decoratorType)
        {
            _container.RegisterDecorator(serviceType, decoratorType);
        }

        public TService Resolve<TService>() where TService : class
        {
            return _container.GetInstance<TService>();
        }

        public object Resolve(Type serviceType)
        {
            return _container.GetInstance(serviceType);
        }

        public IEnumerable<TService> ResolveAll<TService>() where TService : class
        {
            return _container.GetAllInstances<TService>();
        }

        public bool IsRegistered<TService>() where TService : class
        {
            return (Resolve<TService>() != null);
        }

        public void Register(Type serivceType, IEnumerable<Assembly> assambly)
        {
            _container.Register(serivceType, assambly);
        }
    }
}
