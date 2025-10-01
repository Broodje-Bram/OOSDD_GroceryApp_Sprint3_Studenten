using Grocery.Core.Models;
using System.Collections.Generic;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IRegistrationRepository
    {
        Client Add(Client client);
        Client? Get(string email);
        List<Client> GetAll();
    }
}