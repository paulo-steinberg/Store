﻿using FluentValidator;
using FluentValidator.Validation;
using Shared.Commands;

namespace Domain.StoreContext.Commands.Customer.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "First Name", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 40, "First Name", "O nome deve conter no máximo 40 caracteres")
                .HasMinLen(LastName, 3, "Last Name", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 40, "Last Name", "O sobrenome deve conter no máximo 40 caracteres")
                .IsEmail(Email, "Email", "O email é inválido.")
                .HasLen(Document, 11, "Document", "CPF inválido")
            );
            return IsValid;
        }
    }
}