using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Core.Helpers;
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels
{
    public partial class UserRegistrationViewModel : BaseViewModel
    {
        private readonly IClientService _clientService;
        private readonly IRegistrationRepository _registrationRepository;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        string email;

        [ObservableProperty]
        string password;

        [ObservableProperty]
        string message;

        public UserRegistrationViewModel(IClientService clientService, IRegistrationRepository registrationRepository)
        {
            _clientService = clientService;
            _registrationRepository = registrationRepository;
        }

        [RelayCommand]
        public void Register()
        {
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                Message = "Vul alle velden in.";
                return;
            }

            var existing = _clientService.Get(Email);
            if (existing != null)
            {
                Message = "E-mailadres is al geregistreerd.";
                return;
            }

            var hashed = PasswordHelper.HashPassword(Password);
            var client = new Client(0, Name, Email, hashed);
            _registrationRepository.Add(client);

            Message = "Registratie gelukt.";
            Name = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }
    }
}