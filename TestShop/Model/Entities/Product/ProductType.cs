using System;

namespace IXORA.PlatonovNikita.TestShop.Model.Entities
{
    /// <summary>
    /// Type of product.
    /// </summary>
    public class ProductType
    {
        /// <summary>
        /// Product type id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of product type.
        /// </summary>
        public string NameOfType { get; set; }
    }
}
