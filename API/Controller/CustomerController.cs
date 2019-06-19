using System;
using System.Collections.Generic;
using Domain.StoreContext.Commands.Customer.Inputs;
using Domain.StoreContext.Commands.Customer.Outputs;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Handlers;
using Domain.StoreContext.Queries;
using Domain.StoreContext.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly  ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.GetCustomerById(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        [ResponseCache(Duration = 60)]
        public IActionResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult) _handler.Handle(command);

            if (_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return Ok(result);
        }

        /*
         TODO
            Create Update Customer Handler.
            Create Delete Customer Handler.
        */

        [HttpPut]
        [Route("v1/customers/{id}")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public Customer Put([FromBody]Customer customer)
        {
            return null;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public Customer Delete()
        {
            return null;
        }

    }
}