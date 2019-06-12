using System;
using System.Collections.Generic;
using Domain.StoreContext.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controller
{
    public class CustomerController : Microsoft.AspNetCore.Mvc.Controller
    {
        [HttpGet]
        public List<Customer> Get()
        {
            return null;
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