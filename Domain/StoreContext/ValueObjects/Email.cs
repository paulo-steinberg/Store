using FluentValidator;
using FluentValidator.Validation;

namespace Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable

    {
    public Email(string email)
    {
        Address = email;

        AddNotifications(new ValidationContract()
            .Requires()
            .IsEmail(Address, "Email", "O email é inválido.")
            );
        }

    public string Address { get; set; }

    public override string ToString()
    {
        return Address;
    }
    }
}
