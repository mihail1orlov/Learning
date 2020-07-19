namespace HelloApp.Services
{
    public class EmailMessageService : IMessageService
    {
        public string Send()
        {
            var str = "Sent my email";
            return str;
        }
    }
}