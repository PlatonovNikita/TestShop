using System;
using System.Collections.Generic;

namespace IXORA.PlatonovNikita.TestShop.Model.Entities
{
    /// <summary>
    /// Order.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Order id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id of client, who make order.
        /// </summary>
        public Guid ClientId { get; set; }

        /// <summary>
        /// Client, who make order
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Order lines included to order.
        /// </summary>
        public List<OrderLine> OrderLines { get; set; }

        /// <summary>
        /// Date and time, when order was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
