using System;

namespace IXORA.PlatonovNikita.TestShop.Model.Entities
{
    /// <summary>
    /// Item of shop.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Product id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id of product type.
        /// </summary>
        public Guid ProductTypeId { get; set; }

        /// <summary>
        /// Type of product
        /// </summary>
        public ProductType Type { get; set; }

        /// <summary>
        /// Product name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price for one item of products.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Available quantity of products.
        /// </summary>
        public int Quantity { get; set; }
    }
}
