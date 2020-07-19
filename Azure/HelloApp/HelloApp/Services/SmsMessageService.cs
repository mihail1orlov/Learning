namespace HelloApp.Services
{
    public class SmsMessageService : IMessageService
    {
        public string Send()
        {
            var str = "Sent my sms";
            return str;
        }
    }
}