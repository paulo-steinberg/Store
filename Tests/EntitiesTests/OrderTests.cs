using Domain.StoreContext.Entities;
using Domain.StoreContext.Enums;
using Domain.StoreContext.ValueObjects;
using FluentAssertions;
using Xunit;

namespace Tests.EntitiesTests
{
    public class OrderTests
    {
        private readonly Customer _customer;
        private readonly Order _order;

        private readonly Product _mouse;
        private readonly Product _keyboard;
        private readonly Product _chair;
        private readonly Product _monitor;
        private readonly Product _pad;

        public OrderTests()
        {
            var document = new Document("36202315083");
            var name = new Name("Paulo", "Steinberg");
            var email = new Email("pvcsteinberg@hotmail.com");
            _customer = new Customer(name, email, document, "23985633365");
            _order = new Order(_customer);

            _mouse = new Product("Mouse Gamer", "Mouse Gamer", "mouse.jpg", 100M, 10);
            _keyboard = new Product("Teclado Gamer", "Teclado Gamer", "mouse.jpg", 100M, 10);
            _chair = new Product("Cadeira Gamer", "Cadeira Gamer", "mouse.jpg", 100M, 10);
            _monitor = new Product("Monitor Gamer", "Monitor Gamer", "mouse.jpg", 100M, 10);
            _pad  = new Product("Pad Gamer", "Pad Gamer", "mouse.jpg", 100M, 10);
        }

        [Fact]
        public void Constructor_WhenCreateProduct_IsValidShouldBeTrue()
        {
            _order.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Constructor_whenCreateProduct_StatusShouldBeCreated()
        {
            _order.Status.Should().Be(EOrderStatus.Created);
        }

        [Fact]
        public void AddItem_WhenAddTwoItems_QuantityShouldbeTwo()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            _order.Items.Count.Should().Be(2);
        }

        [Fact]
        public void AddItem_WhenAddFiveItems_QuantityShouldbeFive()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_chair, 5);
            _order.AddItem(_keyboard, 5);
            _order.AddItem(_monitor, 5);
            _order.AddItem(_pad, 5);

            _order.Items.Count.Should().Be(5);
        }

        [Fact]
        public void Place_WhenCalled_ShouldGenerateNewGuid()
        {
            _order.Place();
            _order.Number.Should().NotBeEmpty();
        }

        [Fact]
        public void Pay_WhenCalled_shouldSetStatusToPaid()
        {
            _order.Pay();
            _order.Status.Should().Be(EOrderStatus.Paid);
        }

        [Fact]
        public void Ship_WhenCountIsTen_ShouldReturnTwoDeliveries()
        {
            _order.AddItem(_mouse,5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);

            _order.Ship();
            _order.Deliveries.Count.Should().Be(2);
        }

        [Fact]
        public void Cancel_WhenCalled_ShouldSetStatusToCanceled()
        {
            _order.Cancel();
            _order.Status.Should().Be(EOrderStatus.Canceled);
        }

        [Fact]
        public void Cancel_WhenCalled_ShouldCancelDelivery()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);

            _order.Ship();
            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                x.Status.Should().Be(EDeliveryStatus.Canceled);
            }
        }
    }
}
