using System;
using Domain.StoreContext.Commands.Customer.Inputs;
using Domain.StoreContext.Commands.Customer.Outputs;
using Domain.StoreContext.Entities;
using Domain.StoreContext.Repositories;
using Domain.StoreContext.Services;
using Domain.StoreContext.ValueObjects;
using FluentValidator;
using Shared.Commands;

namespace Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAdressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public IcommandResult Handle(CreateCustomerCommand command)
        {
            if (_repository.CheckDocument(command.Document))    
                AddNotification("Document", "Este CPF já está em uso");

            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já está em uso");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            var customer = new Customer(name, email, document, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            _repository.Save(customer);

            _emailService.Send(email.Address, "hello@mail.com", "Welcome", "Welcome to Store");

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public IcommandResult Handle(AddAdressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}