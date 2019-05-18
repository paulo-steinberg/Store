using System;
using System.Runtime.InteropServices.ComTypes;
using Domain.StoreContext.Entities;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var customer = new Customer(
                "Paulo", 
                "Steinberg", 
                "12345678911", 
                "pvcsteinberg@hotmail.com", 
                "22981000573", 
                "Estrada Nelore, 252");

            var order = new Order(customer);

            order.AddItem();


        }
    }
}
