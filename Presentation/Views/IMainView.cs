using Presentation.Common;
using System;

namespace Presentation.Views
{
    public interface IMainView : IView
    {
        void SetUserInfo(string username, string password);
        event Action ChangeUsername;
    }
}
