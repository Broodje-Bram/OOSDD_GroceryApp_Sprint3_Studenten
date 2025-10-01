using Grocery.App.ViewModels;

namespace Grocery.App.Views;

public partial class LoginView : ContentPage
{
    private readonly UserRegistrationView _registrationView;

    public LoginView(LoginViewModel viewModel, UserRegistrationView registrationView)
    {
        InitializeComponent();
        BindingContext = viewModel;
        _registrationView = registrationView;
    }

    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(_registrationView);
    }
}