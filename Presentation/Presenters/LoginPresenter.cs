using DomainModels;
using Presentation.Common;
using Presentation.Views;
using System;

namespace Presentation.Presenters
{
    public class LoginPresenter : BasePresener<ILoginView>
    {
        private readonly ILoginService _service;

        public LoginPresenter(IApplicationController controller, ILoginView view, ILoginService service)
            : base(controller, view)
        {
            _service = service;

            View.Login += () => Login(View.Username, View.Password);
        }

        private void Login(string username, string password)
        {
            if (username == null)
                throw new ArgumentNullException("username");
            if (password == null)
                throw new ArgumentNullException("password");

            var user = new User { Name = username, Password = password };
            if (!_service.Login(user))
            {
                View.ShowError("Invalid username or password");
            }
            else
            {
                Controller.Run<MainPresener, User>(user);
                View.Close();
            }
        }
    }
}
