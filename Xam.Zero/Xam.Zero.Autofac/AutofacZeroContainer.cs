using System;
using Autofac;
using IContainer = Xam.Zero.Ioc.IContainer;

namespace Xam.Zero.Autofac
{
    public class AutofacZeroContainer: IContainer
    {
        private readonly ContainerBuilder _autofacContainer;
        private global::Autofac.IContainer _builder;
        
        public AutofacZeroContainer(ContainerBuilder autofacContainer)
        {
            _autofacContainer = autofacContainer;
        }
        
        public void Register<T>(bool transient) where T : class
        {
            if (transient)
            {
                _autofacContainer.RegisterType<T>();
                return;
            }
            
            _autofacContainer.RegisterType<T>().SingleInstance();
        }

        public void Register<T, TImpl>(bool transient) where TImpl : T
        {
            if (transient)
            {
                _autofacContainer.RegisterType<TImpl>().As<T>();
                return;
            }
            _autofacContainer.RegisterType<TImpl>().As<T>().SingleInstance();
        }

        public void Register(Type type, bool transient)
        {
            if (transient)
            {
                _autofacContainer.RegisterType(type);
                return;
            }
            _autofacContainer.RegisterType(type).SingleInstance();
        }

        public void RegisterInstance<T>(T instance)
        {
            _autofacContainer.RegisterInstance(instance.GetType());
        }

        public T Resolve<T>()
        {
            return _builder.Resolve<T>();
        }

        public object Resolve(Type type)
        {
            return _builder.Resolve(type);
        }

        public static AutofacZeroContainer Build(ContainerBuilder container)
        {
            return new AutofacZeroContainer(container);
        }

        /// <summary>
        /// Call this method after all registration to initialize to create a new container with the component registrations that have been made.
        /// </summary>
        public void BuildContainer()
        {
            _builder = _autofacContainer.Build();
        }
    }
}