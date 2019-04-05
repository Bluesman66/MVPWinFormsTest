using DomainModels;
using Presentation.Common;
using Presentation.Presenters;
using Presentation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var controller = new ApplicationController(new AutofacAdapter())
                .RegisterPresenter<ChangeUsernamePresenter>()
                .RegisterPresenter<LoginPresenter>()
                .RegisterPresenter<MainPresener>()
                .RegisterView<ILoginView, LoginForm>()
                .RegisterView<IMainView, MainForm>()
                .RegisterView<IChangeUsernameView, ChangeUserNameForm>()
                .RegisterService<ILoginService, StupidLoginService>()
                .RegisterInstance(new ApplicationContext())
                .BuildContainer()
                .OpenContainerScope();
            
            controller.Run<LoginPresenter>();

            controller.CloseContainerScope();
        }
    }
}
