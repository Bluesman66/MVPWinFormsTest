namespace Presentation.Common
{
    public class ApplicationController : IApplicationController
    {
        private readonly IContainer _container;

        public ApplicationController(IContainer container)
        {
            _container = container;
            _container.RegisterInstance<IApplicationController>(this);
        }

        public IApplicationController RegisterPresenter<TPresenter>() where TPresenter : class
        {
            _container.Register<TPresenter>();
            return this;
        }

        public IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public IApplicationController RegisterInstance<TInstance>(TInstance instance) 
            where TInstance : class
        {
            _container.RegisterInstance<TInstance>(instance);
            return this;
        }

        public IApplicationController RegisterService<TModel, TImplementation>()
            where TImplementation : class, TModel
        {
            _container.Register<TModel, TImplementation>();
            return this;
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {   
            var presenter = _container.Resolve<TPresenter>();
            presenter.Run();            
        }

        public void Run<TPresenter, TArgumnent>(TArgumnent argumnent) where TPresenter : class, IPresenter<TArgumnent>
        {
            var presenter = _container.Resolve<TPresenter>();
            presenter.Run(argumnent);            
        }
        
        public IApplicationController BuildContainer()
        {
            _container.BuildContainer();
            return this;
        }

        public IApplicationController OpenContainerScope()
        {
            _container.OpenContainerScope();
            return this;
        }

        public IApplicationController CloseContainerScope()
        {
            _container.CloseContainerScope();
            return this;
        }
    }
}
