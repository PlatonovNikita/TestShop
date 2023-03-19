using IXORA.PlatonovNikita.TestShop.Dto.ClientDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using System;
using System.Collections.Generic;

namespace IXORA.PlatonovNikita.TestShop.Repository
{
    /// <summary>
    /// Interface of clients repository.
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Add client to repository.
        /// </summary>
        /// <param name="client">Added client.</param>
        public void Add(Client client);

        /// <summary>
        /// Add clients to repository.
        /// </summary>
        /// <param name="clients">Added clients.</param>
        public void AddRange(IEnumerable<Client> clients);

        /// <summary>
        /// Returns all clients, who store in repository.
        /// </summary>
        /// <param name="take">Number of clients, who will be returned.</param>
        /// <param name="skip">Number of clients, who will be skiped.</param>
        /// <returns>All clients, who store in repository.</returns>
        public Client[] GetClients(GetClientsData getClientsData);

        /// <summary>
        /// Returns client by id.
        /// </summary>
        /// <param name="id">Client id.</param>
        /// <returns>Client by id.</returns>
        public Client GetClient(Guid id);

        /// <summary>
        /// Delete client from repository.
        /// If there is an order included this client throws an InvalidOperationException.
        /// </summary>
        /// <param name="id">Id of deleted client</param>
        public void Delete(Guid id);
    }
}
