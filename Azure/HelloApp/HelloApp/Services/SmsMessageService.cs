namespace HelloApp.Services
{
    public class SmsMessageService : IMessageService
    {
        public string Send()
        {
            var str = "<h3>Sent my sms<h3>";
            return str;
        }
    }
}