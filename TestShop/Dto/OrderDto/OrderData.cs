using IXORA.PlatonovNikita.TestShop.Model.Entities;
using System;
using System.Collections.Generic;

namespace IXORA.PlatonovNikita.TestShop.Dto.OrderDto
{
    public class OrderData
    {
        /// <summary>
        /// Order id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Client, who make order
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Order lines included to order.
        /// </summary>
        public IEnumerable<OrderLineData> OrderLines { get; set; }

        /// <summary>
        /// Date and time, when order was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }
    }
}
