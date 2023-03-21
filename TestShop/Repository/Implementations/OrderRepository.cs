using AutoMapper;
using AutoMapper.QueryableExtensions;
using IXORA.PlatonovNikita.TestShop.Context;
using IXORA.PlatonovNikita.TestShop.Dto;
using IXORA.PlatonovNikita.TestShop.Dto.OrderDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace IXORA.PlatonovNikita.TestShop.Repository.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly TestShopContext _dbContext;
        private readonly IMapper _mapper;

        public OrderRepository(TestShopContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public Guid Add(Order order)
        {
            using (var trantransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    if (_dbContext.Clients.FirstOrDefault(c => c.Id == order.ClientId) == null)
                    {
                        throw new InvalidOperationException($"Client with id:{order.ClientId} hasn't in repository!");
                    }

                    foreach (var orderLine in order.OrderLines)
                    {
                        var product = _dbContext.Products
                                                .FirstOrDefault(p => p.Id == orderLine.ProductId);

                        if (product == null)
                        {
                            throw new InvalidOperationException($"No product with id {orderLine.ProductId}");
                        }
                        if (product.Quantity < orderLine.ProductQuantity)
                        {
                            throw new InvalidOperationException($"Product {product.Name} hasn't required quantity ({orderLine.ProductQuantity})");
                        }

                        product.Quantity -= orderLine.ProductQuantity;
                        orderLine.ProductPrice = product.Price;
                    }

                    order.CreatedAt = DateTime.Now;
                    _dbContext.OrderLines.AddRange(order.OrderLines);
                    _dbContext.Orders.Add(order);
                    _dbContext.SaveChanges();
                    trantransaction.Commit();
                    return order.Id;
                }
                catch (Exception ex)
                {
                    trantransaction.Rollback();
                    throw ex;
                }
            }
        }

        public OrderData[] GetAllClientOrders(GetClientOrdersData getClientOrdersData)
        {
            IQueryable<Order> query = _dbContext.Orders;

            if (getClientOrdersData?.ClientId != null)
            {
                var client = _dbContext.Clients.FirstOrDefault(c => c.Id == getClientOrdersData.ClientId);
                if (client == null)
                {
                    throw new InvalidOperationException($"Client with id:{getClientOrdersData.ClientId} hasn't in repository!");
                }
                query = query.Where(o => o.ClientId == client.Id);
            }

            if (getClientOrdersData.DateFrom != null)
            {
                query = query.Where(o => o.CreatedAt 
                                         >= getClientOrdersData.DateFrom.Value);
            }
            if (getClientOrdersData.DateTo != null)
            {
                query = query.Where(o => o.CreatedAt 
                                         <= getClientOrdersData.DateTo.Value);
            }

            query = AddPaginationToQuery(query, getClientOrdersData.Pagination);

            return query.Include(o => o.Client)
                        .Include(o => o.OrderLines)
                            .ThenInclude(ol => ol.Product)
                                .ThenInclude(p => p.Type)
                        .OrderBy(o => o.CreatedAt)
                        .ProjectTo<OrderData>(_mapper.ConfigurationProvider)
                        .ToArray();
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
