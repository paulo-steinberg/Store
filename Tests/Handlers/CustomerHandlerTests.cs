using Domain.StoreContext.Commands.Customer.Inputs;
using Domain.StoreContext.Handlers;
using FluentAssertions;
using Tests.Mocks;
using Xunit;

namespace Tests.Handlers
{
    public class CustomerHandlerTests
    {
        [Fact]
        public void Valid_ShouldRegisterCustomer_WhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Paulo";
            command.LastName = "Steinberg";
            command.Document = "36202315083";
            command.Email = "pvcsteinberg@hotmail.com";
            command.Phone = "22999999999";

            command.IsValid.Should().BeTrue();

            var handler = new CustomerHandler(new CustomerRepositoryMock(), new EmailServiceMock());
            var result = handler.Handle(command);

            result.Should().NotBe(null);
            handler.IsValid.Should().BeTrue();
        }
    }
}