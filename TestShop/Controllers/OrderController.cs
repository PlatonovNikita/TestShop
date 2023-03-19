using AutoMapper;
using IXORA.PlatonovNikita.TestShop.Dto;
using IXORA.PlatonovNikita.TestShop.Dto.OrderDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using IXORA.PlatonovNikita.TestShop.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace IXORA.PlatonovNikita.TestShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private const int PAGNATION_COUNT = 20;
        private const int PAGNATION_PAGE = 1;

        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult CreateOrder(CreateOrderData createOrderData)
        {
            var validationResult = createOrderData.ValidateThis();
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult);
            }

            try
            {
                var order = _mapper.Map<Order>(createOrderData);
                _orderRepository.Add(order);
                return CreatedAtAction(nameof(CreateOrder), order);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetClientOrders([FromQuery]GetClientOrdersData getClientOrdersData)
        {
            var validateResult = getClientOrdersData.ValidateThis();
            if (!validateResult.IsValid)
            {
                return BadRequest(validateResult);
            }

            getClientOrdersData ??= new GetClientOrdersData();
            getClientOrdersData.Pagination = SetDefaultPagination(getClientOrdersData.Pagination);

            var orders = _orderRepository.GetAllClientOrders(getClientOrdersData); 
            return Ok(orders);
        }

        private Pagination SetDefaultPagination(Pagination pagination)
        {
            pagination ??= new Pagination();
            pagination.Count ??= PAGNATION_COUNT;
            pagination.Page ??= PAGNATION_PAGE;
            return pagination;
        }
    }
}
