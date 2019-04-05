using Autofac;

namespace UI
{
    public class AutofacAdapter : Presentation.Common.IContainer
    {
        private readonly ContainerBuilder _builder;
        private IContainer _container;
        private ILifetimeScope _scope;

        public AutofacAdapter()
        {
            _builder = new ContainerBuilder();            
        }

        public void BuildContainer()
        {
            _container = _builder.Build();
        }

        public void OpenContainerScope()
        {
            _scope = _container.BeginLifetimeScope();
        }

        public void CloseContainerScope()
        {
            _scope.Dispose();
        }        

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _builder.RegisterType<TImplementation>().As<TService>();
        }

        public void Register<TService>()
        {
            _builder.RegisterType<TService>();
        }

        public void RegisterInstance<T>(T instance) where T : class
        {
            _builder.RegisterInstance(instance).As<T>();
        }

        public TService Resolve<TService>()
        {
            return _scope.Resolve<TService>();            
        }

        public bool IsRegistered<TService>()
        {
            return _container.IsRegistered(typeof(TService));
        }
    }
}
