using IXORA.PlatonovNikita.TestShop.Dto.ProductDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using System;
using System.Collections.Generic;

namespace IXORA.PlatonovNikita.TestShop.Repository
{
    /// <summary>
    /// Interface of product repository.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Add product type to repository.
        /// </summary>
        /// <param name="productType">Name of product type.</param>
        /// <returns>Id of added product type.</returns>
        public Guid AddProductType(ProductType productType);

        /// <summary>
        /// Add product to repository.
        /// </summary>
        /// <param name="product">Added product</param>
        /// <returns>Id of product, that was added.</returns>
        public Guid AddProduct(Product product);

        /// <summary>
        /// Returns product types.
        /// </summary>
        /// <returns>Product types.</returns>
        public ProductType[] GetProductTypes(GetProductTypeData getProductTypeData);

        /// <summary>
        /// Returns product by id.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Product by id.</returns>
        public ProductData GetProduct(Guid id);

        /// <summary>
        /// Returns filtered range of products.
        /// </summary>
        /// <param name="maxPrice">Maximum product price.</param>
        /// <param name="minPrice">Minimum product price.</param>
        /// <param name="productType">Type of product.</param>
        /// <param name="isInStock">Is product in stock?</param>
        /// <returns>Filtered range of products.</returns>
        public ProductData[] GetProducts(ProductFilterData productFilterData);

        /// <summary>
        /// Delete product type by id. 
        /// If there is a product with this type throws an InvalidOperationException.
        /// </summary>
        /// <param name="id">Product type id.</param>
        public void DeleteProductType(Guid id);

        /// <summary>
        /// Delete product by id.
        /// If there if a order included this product throws an InvalidOperationException.
        /// </summary>
        /// <param name="id">Product id.</param>
        public void DeleteProduct(Guid id);
    }
}
