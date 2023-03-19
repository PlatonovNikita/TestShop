using System;

namespace IXORA.PlatonovNikita.TestShop.Model.Entities
{
    /// <summary>
    /// Order line, that include product, its price and quantity.
    /// </summary>
    public class OrderLine
    {
        /// <summary>
        /// Order line id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id of order, that include this order line.
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Id of product, that included in order.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Product, that included in order.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Price of product, that included in order.
        /// </summary>
        public decimal ProductPrice { get; set; }

        /// <summary>
        /// Quantiry of products, that included in order.
        /// </summary>
        public int ProductQuantity { get; set; }
    }
}
