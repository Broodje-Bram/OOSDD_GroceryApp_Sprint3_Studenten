using Grocery.App.ViewModels;

namespace Grocery.App.Views
{
    public partial class UserRegistrationView : ContentPage
    {
        public UserRegistrationView(UserRegistrationViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}