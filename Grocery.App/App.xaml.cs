using Grocery.App.ViewModels;
using Grocery.App.Views;

namespace Grocery.App
{
    public partial class App : Application
    {
        public App(LoginViewModel viewModel, UserRegistrationView registrationView)
        {
            InitializeComponent();
            MainPage = new NavigationPage(new LoginView(viewModel, registrationView));
        }
    }
}