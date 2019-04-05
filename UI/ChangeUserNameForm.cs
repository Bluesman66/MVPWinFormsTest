using Presentation.Views;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class ChangeUserNameForm : Form, IChangeUsernameView
    {
        public ChangeUserNameForm()
        {
            InitializeComponent();

            btnSave.Click += (sender, args) => Invoke(Save);
        }

        public string Username { get { return txtUserName.Text; } }
        public event Action Save;

        public new void Show()
        {
            ShowDialog();
        }        

        private void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }
    }
}
