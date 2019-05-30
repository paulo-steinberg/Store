﻿using System;
using Domain.StoreContext.Enums;
using FluentValidator;
using Shared.Commands;

namespace Domain.StoreContext.Commands.Customer.Inputs
{
    public class AddAdressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        public bool Valid()
        {
            return IsValid;
        }
    }
}