namespace HelloApp.Services
{
    public class EmailMessageService : IMessageService
    {
        public string Send()
        {
            var str = "<h3>Sent my email</h3>";
            return str;
        }
    }
}