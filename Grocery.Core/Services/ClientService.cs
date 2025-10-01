using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using Grocery.Core.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private readonly IRegistrationRepository _registrationRepository;

        public ClientService(IClientRepository clientRepository, IRegistrationRepository registrationRepository)
        {
            _clientRepository = clientRepository;
            _registrationRepository = registrationRepository;
        }

        public Client? Get(string email)
        {
            var c = _clientRepository.Get(email);
            if (c != null) return c;
            return _registrationRepository.Get(email);
        }

        public Client? Get(int id)
        {
            var c = _clientRepository.Get(id);
            if (c != null) return c;
            return _registrationRepository.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public List<Client> GetAll()
        {
            var a = _clientRepository.GetAll();
            var b = _registrationRepository.GetAll();
            return a.Concat(b).ToList();
        }

        public Client Register(string name, string email, string password)
        {
            var existing = Get(email);
            if (existing != null) return existing;

            var hashed = PasswordHelper.HashPassword(password);
            var client = new Client(0, name, email, hashed);
            return _registrationRepository.Add(client);
        }
    }
}