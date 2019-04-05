using Presentation.Common;
using System;

namespace Presentation.Views
{
    public interface IChangeUsernameView : IView
    {
        string Username { get; }

        event Action Save;
    }
}
