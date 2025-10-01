using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Grocery.Core.Data.Repositories
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly List<Client> clients = new();

        public Client Add(Client client)
        {
            int nextId = clients.Count == 0 ? 1 : clients.Max(c => c.Id) + 1;
            client.Id = nextId;
            clients.Add(client);
            return client;
        }

        public Client? Get(string email)
        {
            return clients.FirstOrDefault(c => c.EmailAddress == email);
        }

        public List<Client> GetAll()
        {
            return clients;
        }
    }
}