using System;
using System.Collections.Generic;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Queries;
using Domain.StoreContext.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly  ICustomerRepository _repository;

        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            return null;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            return null;
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]Customer customer)
        {
            return null;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]Customer customer)
        {
            return null;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public Customer Delete()
        {
            return null;
        }

    }
}