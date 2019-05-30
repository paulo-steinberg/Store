using Domain.StoreContext.Commands.Customer.Inputs;
using Xunit;
using FluentAssertions;

namespace Tests.Commands
{
    public class CreateCustommerCommandTests
    {
        [Fact]
        public void Create_ShouldValidate_WhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Paulo";
            command.LastName = "Steinberg";
            command.Document = "36202315083";
            command.Email = "pvcsteinberg@hotmail.com";
            command.Phone = "22999999999";

            command.IsValid.Should().BeTrue();
        }
    }
}