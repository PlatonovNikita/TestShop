using IXORA.PlatonovNikita.TestShop.Context;
using IXORA.PlatonovNikita.TestShop.Dto.ClientDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IXORA.PlatonovNikita.TestShop.Repository.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly TestShopContext _dbContext;

        public ClientRepository(TestShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Client client)
        {
            _dbContext.Clients.Add(client);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.ClientId == id);
            if (order != null)
            {
                throw new InvalidOperationException($"Client with id: {id} can't be remove, because there is order, that refers to this client.");
            }

            _dbContext.Clients.Remove(new Client { Id = id });
            _dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<Client> clients)
        {
            if (clients == null)
            {
                throw new ArgumentNullException($"Can't be added to repository {nameof(clients)}, those are null!");
            }

            _dbContext.Clients.AddRange(clients);
            _dbContext.SaveChanges();
        }

        public Client GetClient(Guid id)
        {
            var client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
            if (client == null)
            {
                throw new InvalidOperationException($"Client with id:{id} hasn't in repository.");
            }

            return client;
        }

        public Client[] GetClients(GetClientsData getClientsData)
        {
            IQueryable<Client> query = _dbContext.Clients;

            var count = getClientsData?.Pagination?.Count ?? 1;
            var page = getClientsData?.Pagination?.Page ?? 1;

            query = query.Take(count * page).Skip(count * (page - 1));

            return query.ToArray();
        }
    }
}
