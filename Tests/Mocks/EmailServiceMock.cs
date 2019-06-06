using Domain.StoreContext.Services;

namespace Tests.Mocks
{
    public class EmailServiceMock : IEmailService
    {
        public void Send(string to, string @from, string subject, string body)
        {
            
        }
    }
}
