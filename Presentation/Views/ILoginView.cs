using Presentation.Common;
using System;

namespace Presentation.Views
{
    public interface ILoginView : IView
    {
        string Username { get; }
        string Password { get; }
        event Action Login;
        void ShowError(string errorMessage);
    }
}
