using System;
using System.Collections.Generic;
using System.Reflection;

public interface IContainer
{
    void Register<TService, TImplementation>() where TImplementation : TService;
    void Register<TService>();
    void Register(Type serivceType, Type implementingType, string serviceName);
    void Register(Type serivceType, Type implementingType);
    void Register(Type serivceType, IEnumerable<Assembly> assambly);
    void Register<TService>(Func<TService> instanceCreator) where TService : class;
    void RegisterInstance<T>(T instance) where T : class;
    void RegisterDecorator(Type serviceType, Type decoratorType);
    TService Resolve<TService>() where TService : class;
    object Resolve(Type serviceType);
    IEnumerable<TService> ResolveAll<TService>() where TService : class;
    bool IsRegistered<TService>() where TService : class;
}