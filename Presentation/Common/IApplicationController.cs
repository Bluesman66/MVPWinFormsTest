namespace Presentation.Common
{
    public interface IApplicationController
    {
        IApplicationController RegisterPresenter<TPresenter>()
            where TPresenter : class;

        IApplicationController RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : IView;

        IApplicationController RegisterInstance<TArgument>(TArgument instance) 
            where TArgument : class;

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;        

        void Run<TPresenter>()
            where TPresenter : class, IPresenter;

        void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
            where TPresenter : class, IPresenter<TArgumnent>;

        IApplicationController BuildContainer();
        IApplicationController OpenContainerScope();
        IApplicationController CloseContainerScope();
    }
}
