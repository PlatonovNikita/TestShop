using System;

namespace IXORA.PlatonovNikita.TestShop.Dto.OrderDto
{
    public class OrderLineData
    {
        /// <summary>
        /// Id of product, that included in order.
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Type of product.
        /// </summary>
        public string ProductType { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string ProductName { get; set; }

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
