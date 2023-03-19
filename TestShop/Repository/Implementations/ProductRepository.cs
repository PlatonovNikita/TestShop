using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using IXORA.PlatonovNikita.TestShop.Context;
using IXORA.PlatonovNikita.TestShop.Repository;
using IXORA.PlatonovNikita.TestShop.Dto.ProductDto;
using IXORA.PlatonovNikita.TestShop.Dto;

namespace IXORA.PlatonovNikita.TestShop.Repository.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly TestShopContext _dbContext;
        private readonly IMapper _mapper;

        public ProductRepository(TestShopContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Guid AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product.Id;
        }

        public Guid AddProductType(ProductType productType)
        {
            _dbContext.ProductTypes.Add(productType);
            _dbContext.SaveChanges();
            return productType.Id;
        }

        public void AddRange(IEnumerable<Product> products)
        {
            if (products == null)
            {
                throw new ArgumentNullException(nameof(products));
            }

            _dbContext.Products.AddRange(products);
            _dbContext.SaveChanges();
        }

        public void DeleteProduct(Guid id)
        {
            var orderLine = _dbContext.OrderLines.FirstOrDefault(x => x.ProductId == id);
            if (orderLine != null)
            {
                throw new InvalidOperationException($"Product with id: {id} can't be remove, because there is order line, that refers to this product.");
            }
            _dbContext.Products.Remove(new Product { Id = id });
            _dbContext.SaveChanges();
        }

        public void DeleteProductType(Guid id)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductTypeId == id);
            if (product != null)
            {
                throw new InvalidOperationException($"Product type with id: {id} can't be remove, because there is product, that refers to this type.");
            }
            _dbContext.ProductTypes.Remove(new ProductType { Id = id });
            _dbContext.SaveChanges();
        }

        public ProductData GetProduct(Guid id)
        {
            var product = _dbContext.Products
                                    .Include(p => p.Type)
                                    .FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                throw new InvalidOperationException($"Product with id:{id} hasn't in repository!");
            }

            return _mapper.Map<ProductData>(product);
        }

        public ProductData[] GetProducts(ProductFilterData productFilterData)
        {
            IQueryable<Product> query = _dbContext.Products;

            if (productFilterData?.MaxPrice != null)
            {
                query = query.Where(p => p.Price <= productFilterData.MaxPrice.Value);
            }
            if (productFilterData?.MinPrice != null)
            {
                query = query.Where(p => p.Price <= productFilterData.MinPrice.Value);
            }
            if (productFilterData?.ProductTypeId != null)
            {
                query = query.Where(p => p.ProductTypeId == productFilterData.ProductTypeId);
            }
            if (productFilterData?.IsInStock == true)
            {
                query = query.Where(p => p.Quantity > 0);
            }
            if (productFilterData?.IsOrderByAscendungPrice != null)
            {
                if (productFilterData.IsOrderByAscendungPrice.Value)
                {
                    query = query.OrderBy(p => p.Price);
                }
                else
                {
                    query = query.OrderByDescending(p => p.Price);
                }
            }

            query = AddPaginationToQuery(query, productFilterData.Pagination);

            return query.Include(p => p.Type)
                .ProjectTo<ProductData>(_mapper.ConfigurationProvider).ToArray();
        }

        public ProductType[] GetProductTypes(GetProductTypeData getProductTypeData)
        {
            IQueryable<ProductType> query = _dbContext.ProductTypes;

            query = AddPaginationToQuery(query, getProductTypeData.Pagination);

            return query.ToArray();
        }

        private IQueryable<T> AddPaginationToQuery<T>(IQueryable<T> query, Pagination pagination)
        {
            var count = pagination?.Count ?? 1;
            var page = pagination?.Page ?? 1;
            query = query.Take(count * page).Skip(count * (page - 1));

            return query;
        }
    }
}
