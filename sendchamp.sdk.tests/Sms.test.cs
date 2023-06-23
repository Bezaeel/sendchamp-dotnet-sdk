using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using sendchamp.sdk.Sms;
using sendchamp.sdk.Sms.Models;

namespace sendchamp.sdk.tests
{
    public class SmsTest
    {
        private ISms _sms;
        public SmsTest()
        {
            var services = new ServiceCollection();
            //services.
            var config = new SendChampConfig()
            {
                BaseUrl = "https://api.sendchamp.com/api/v1",
                PublicKey = ""
            };

            var options = Options.Create(config);

            services.AddSingleton(options);
            services.AddLogging();
            services.AddSingleton<ISms, Sms.Sms>();
            var service = services.BuildServiceProvider();
            _sms = service.GetRequiredService<ISms>();
        }

        [Fact]
        public async Task ShouldSendSms()
        {
            SendSmsRequestDTO dto = new SendSmsRequestDTO()
            {
                To = new List<string>
                {
                    "",
                },
                Message = "This is a test from the open api",
                Route = Sms.Enums.SendChampRoutes.DND,
                SenderName = "Sendchamp"
            };

            var res = await _sms.Send(dto);
            Assert.NotNull(res);
        }
    }
}