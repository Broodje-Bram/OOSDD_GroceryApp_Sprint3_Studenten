using Grocery.Core.Models;
using System.Collections.Generic;

namespace Grocery.Core.Interfaces.Services
{
    public interface IClientService
    {
        Client? Get(string email);
        Client? Get(int id);
        List<Client> GetAll();
        Client Register(string name, string email, string password);
    }
}