namespace Presentation.Common
{
    public interface IContainer
    {
        void Register<TService, TImplementation>() where TImplementation : TService;
        void Register<TService>();
        void RegisterInstance<T>(T instance) where T : class;
        TService Resolve<TService>();
        void BuildContainer();
        void OpenContainerScope();
        void CloseContainerScope();
        bool IsRegistered<TService>();
    }
}
