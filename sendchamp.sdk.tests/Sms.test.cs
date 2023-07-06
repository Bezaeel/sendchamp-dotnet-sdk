using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using RichardSzalay.MockHttp;
using sendchamp.sdk.Sms;
using sendchamp.sdk.Sms.Models;
using System.Text.Json;

namespace sendchamp.sdk.tests
{
    public class SmsTest
    {
        private ISms _sms;
        private readonly SendChampConfig _config;
        private readonly IOptions<SendChampConfig> _options;
        private readonly MockHttpMessageHandler _msgHandler;
        private readonly Mock<ILogger<Sms.Sms>> _loggerMock;

        public SmsTest()
        {
            var services = new ServiceCollection();
            _loggerMock = new Mock<ILogger<Sms.Sms>>();
            _config = new SendChampConfig()
            {
                BaseUrl = "https://api.sendchamp.com",
                PublicKey = "<api-key>"
            };
            _options = Options.Create(_config);

            _msgHandler = new MockHttpMessageHandler();

        }

        [Fact]
        public async Task ShouldGetBulkSmsDeliveryReport()
        {
            var fres = @"{
                ""code"": 200,
                ""data"": {
                },
                ""errors"": null,
                ""message"": ""sms sender created"",
                ""status"": ""success""
            }";
            var expected = JsonSerializer.Deserialize<SendChampResponse<BulkSmsDeliveryReportData>>(fres);

            var id = "";
            var route = $"{_config.BaseUrl}/api/v1/sms/bulk-sms-status/{id}";
            _msgHandler.When(route).Respond("application/json", fres);


            _sms = new sdk.Sms.Sms(_loggerMock.Object, _options, _msgHandler.ToHttpClient());
            var actual = await _sms.BulkSmsDeliveryReport(id);


            Assert.True(actual.Status);
            Assert.Equal(actual.Response.Code, 200);
        }

        [Fact]
        public async Task ShouldGetSmsDeliveryReport_Fail()
        {
            var fres = @"{
                ""code"": 400,
                ""data"": {},
                ""errors"": null,
                ""message"": ""sms sender created"",
                ""status"": ""success""
            }";
            var expected = JsonSerializer.Deserialize<SendChampResponse<SmsDeliveryReportData>>(fres);

            var id = "";
            var route = $"{_config.BaseUrl}/api/v1/sms/status/{id}";
            _msgHandler.When(route).Respond("application/json", fres);


            _sms = new sdk.Sms.Sms(_loggerMock.Object, _options, _msgHandler.ToHttpClient());
            var actual = await _sms.SingleSmsDeliveryReport(id);


            Assert.False(actual.Status);
        }

        [Fact]
        public async Task ShouldGetSmsDeliveryReport()
        {
            var fres = @"{
                ""code"": 200,
                ""data"": {},
                ""errors"": null,
                ""message"": ""sms sender created"",
                ""status"": ""success""
            }";
            var expected = JsonSerializer.Deserialize<SendChampResponse<SmsDeliveryReportData>>(fres);

            var id = "MN-SMS-duHiwPDcSh";
            var route = $"{_config.BaseUrl}/api/v1/sms/status/{id}";
            _msgHandler.When(route).Respond("application/json", fres);


            _sms = new sdk.Sms.Sms(_loggerMock.Object, _options, _msgHandler.ToHttpClient());
            var actual = await _sms.SingleSmsDeliveryReport(id);


            Assert.True(actual.Status);
            Assert.Equal(actual.Response.Code, 200);
        }

        [Fact]
        public async Task ShouldCreateSenderId()
        {
            var opt = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                NumberHandling = System.Text.Json.Serialization.JsonNumberHandling.AllowReadingFromString
            };

            var fres = @"{
                ""code"": 200,
                ""data"": {
                    ""id"": 7042,
                    ""uid"": ""070ad606-21d8-4c09-99eb-892938445ddd"",
                    ""name"": ""Bez"",
                    ""use_case"": ""transactional"",
                    ""business_id"": 2343,
                    ""sample"": ""Hi, your otp"",
                    ""status"": ""pending"",
                    ""approved_for_verification"": false,
                    ""is_whitelisted"": false,
                    ""business"": {
                        ""id"": 2726,
                        ""uid"": ""00000000-0000-0000-0000-000000000000"",
                        ""name"": """"
                    },
                    ""created_at"": ""2023-07-06T14:01:12Z"",
                    ""updated_at"": ""2023-07-06T14:01:12Z""
                },
                ""errors"": null,
                ""message"": ""sms sender created"",
                ""status"": ""success""
            }";
            var expected = JsonSerializer.Deserialize<SendChampResponse<CreateSenderIdResponseData>>(fres);


            var route = $"{_config.BaseUrl}/api/v1/sms/create-sender-id";
            _msgHandler.When(HttpMethod.Post, route).Respond("application/json", fres);

            CreateSenderIdRequestDTO dto = new CreateSenderIdRequestDTO
            {
                Name = "name",
                Sample = "unhs",
                UseCase = Sms.Enums.SendChampUseCase.TRANSACTIONAL
            };
            _sms = new sdk.Sms.Sms(_loggerMock.Object, _options, _msgHandler.ToHttpClient());
            var actual = await _sms.CreateSenderId(dto);


            Assert.True(actual.Status);
            Assert.Equal(actual.Response.Code, 200);
        }

        [Fact]
        public async Task ShouldSendSms()
        {
            var fres = @"{
                ""code"": 200,
                ""data"": {
                    ""id"": ""MN-SMS-duHiwPDcSh"",
                    ""phone_number"": """",
                    ""reference"": ""MN-SMS-duHiwPDcSh"",
                    ""status"": ""processing""
                },
                ""errors"": null,
                ""message"": ""processing"",
                ""status"": ""success""
            }";

            var expected = JsonSerializer.Deserialize<SendChampResponse<SendSmsResponseData>>(fres);
            

            var route = $"{_config.BaseUrl}/api/v1/sms/send";
            _msgHandler.When(route).Respond("application/json", fres);

            SendSmsRequestDTO dto = new SendSmsRequestDTO()
            {
                To = new List<string>
                {
                    "<phone>",
                },
                Message = "This is a test from the open api",
                Route = sdk.Sms.Enums.SendChampRoutes.DND,
                SenderName = "Sendchamp"
            };
            _sms = new sdk.Sms.Sms(_loggerMock.Object, _options, _msgHandler.ToHttpClient());
            var actual = await _sms.Send(dto);


            Assert.True(actual.Status);
            Assert.Equal(actual.Response.Code, 200);
        }
    }
}