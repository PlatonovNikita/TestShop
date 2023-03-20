using AutoMapper;
using IXORA.PlatonovNikita.TestShop.Dto;
using IXORA.PlatonovNikita.TestShop.Dto.ClientDto;
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
    public class ClientController : ControllerBase
    {
        private const int PAGINATION_COUNT = 20;
        private const int PAGINATION_PAGE = 1;

        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<Client> GetClients([FromQuery]GetClientsData getClientsData = null)
        {
            getClientsData ??= new GetClientsData();
            getClientsData.Pagination = SetDefaultPagination(getClientsData.Pagination);

            return _clientRepository.GetClients(getClientsData);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetClient(Guid id)
        {
            try
            {
                return Ok(_clientRepository.GetClient(id));
            }
            catch(InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Add(AddClientData addClientData)
        {
            var validationResult = addClientData.ValidateThis();
            if (validationResult.IsValid)
            {
                var client = _mapper.Map<Client>(addClientData);
                _clientRepository.Add(client);

                return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
            }
            return BadRequest(validationResult);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _clientRepository.Delete(id);
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
