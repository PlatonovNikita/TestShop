using IXORA.PlatonovNikita.TestShop.Dto.OrderDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using System;
using System.Collections.Generic;

namespace IXORA.PlatonovNikita.TestShop.Repository
{
    /// <summary>
    /// Interface of orders repository.
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Add order to repository.
        /// </summary>
        /// <param name="order">Added order.</param>
        /// <returns>Id of added order.</returns>
        public Guid Add(Order order);

        /// <summary>
        /// Returns orders of client for a certain time span, that store in repository.
        /// </summary>
        /// <param name="clientId">Id of client, who made order.</param>
        /// <param name="dateFrom">Date after which order was created.</param>
        /// <param name="dateTo">Dade before which order was created.</param>
        /// <returns>O
        /// rders of client for a certain time span.</returns>
        public OrderData[] GetAllClientOrders(GetClientOrdersData getClientOrdersData);
    }
}
