using Presentation.Views;
using System;
using System.Windows.Forms;

namespace UI
{
    public partial class MainForm : Form, IMainView
    {
        private readonly ApplicationContext _context;
        public MainForm(ApplicationContext context)
        {
            _context = context;
            InitializeComponent();

            btnChangeUserName.Click += (sender, args) => Invoke(ChangeUsername);
        }

        public new void Show()
        {
            _context.MainForm = this;
            base.Show();
        }

        public void SetUserInfo(string username, string password)
        {
            lblUserName.Text = username;
            lblPassword.Text = password;
        }

        public event Action ChangeUsername;

        private void Invoke(Action action)
        {
            if (action != null) action();
        }
    }
}
