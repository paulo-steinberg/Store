using System;
using System.Runtime.InteropServices.ComTypes;
using Domain.StoreContext.Entities;
using Domain.StoreContext.ValueObjects;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var name = new Name("Paulo", "Steinberg");
            var document = new Document("10940569795");
            var email = new Email("pvcsteinberg@hotmail.com");
            var customer = new Customer(name, email, document, "22981000573");

            var mouse = new Product("Mouse", "Mouse ué", "image.png", 59.15M, 10);
            var teclado = new Product("Teclado", "Teclado ué", "image.png", 159.15M, 10);
            var impressora = new Product("Impressora", "Impressora ué", "image.png", 359.15M, 10);
            var cadeira = new Product("Cadeira", "Cadeira ué", "image.png", 559.15M, 10);

            var order = new Order(customer);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(teclado, 5));
            order.AddItem(new OrderItem(cadeira, 5));
            order.AddItem(new OrderItem(impressora, 5));

            order.Place();
            order.Pay();
            order.Ship();
            order.Cancel();

        }
    }
}
