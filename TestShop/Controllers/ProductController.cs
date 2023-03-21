using AutoMapper;
using IXORA.PlatonovNikita.TestShop.Dto;
using IXORA.PlatonovNikita.TestShop.Dto.ProductDto;
using IXORA.PlatonovNikita.TestShop.Model.Entities;
using IXORA.PlatonovNikita.TestShop.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IXORA.PlatonovNikita.TestShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private const int PAGINATION_COUNT = 20;
        private const int PAGINATION_PAGE = 1;

        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }


        [HttpGet("Type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<ProductType> GetProductTypes([FromQuery]GetProductTypeData getProductTypeData)
        {
            getProductTypeData ??= new GetProductTypeData();
            getProductTypeData.Pagination = SetDefaultPagination(getProductTypeData.Pagination);
            
            return _productRepository.GetProductTypes(getProductTypeData);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProducts([FromQuery]ProductFilterData productFilterData)
        {
            try
            {
                productFilterData ??= new ProductFilterData();
                productFilterData.Pagination = SetDefaultPagination(productFilterData.Pagination);

                var products = _productRepository.GetProducts(productFilterData);
                return Ok(products);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetProduct(Guid id)
        {
            try
            {
                var result = _productRepository.GetProduct(id);
                return Ok(result);
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Type")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddProductType(AddProductTypeData addProductTypeData)
        {
            var validationResult = addProductTypeData.ValidatrThis();
            if (validationResult.IsValid)
            {
                var productType = _mapper.Map<ProductType>(addProductTypeData);
                _productRepository.AddProductType(productType);
                return CreatedAtAction(nameof(AddProductType), productType);
            }
            return BadRequest(validationResult);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddProduct(AddProductData addProductData)
        {
            var validationResult = addProductData.ValidateThis();
            if (validationResult.IsValid)
            {
                try
                {
                    var product = _mapper.Map<Product>(addProductData);
                    _productRepository.AddProduct(product);
                    return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
                }
                catch (InvalidOperationException ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return BadRequest(validationResult);
        }

        [HttpDelete("Type/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProductType(Guid id)
        {
            try
            {
                _productRepository.DeleteProductType(id);
                return Ok();
            }
            catch(InvalidOperationException ex){
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteProduct(Guid id)
        {
            try
            {
                _productRepository.DeleteProduct(id);
                return Ok();
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private Pagination SetDefaultPagination(Pagination pagination)
        {
            pagination ??= new Pagination();
            pagination.Count ??= PAGINATION_COUNT;
            pagination.Page ??= PAGINATION_PAGE;
            return pagination;
        }
    }
}
