using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using System.Runtime.CompilerServices;

namespace sendchamp.sdk
{
    public class SendSmsResponseData
    {
        public int Id { get; set; }
        public string  PhoneNumber { get; set; }
        public string REference { get; set; }
        public string Amount { get; set; }
        public string ServiceCharge { get; set; }
        public string Status { get; set; }
        public string DeliveredAt { get; set; }
        public int TotalSms { get; set; }
        public string BusinessUID { get; set; }
        public string UID { get; set; }
        public string SentAt { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }

    }
    public class Sms : ISms
    {
        private readonly RestClient _client;
        private readonly ILogger<Sms> _logger;
        private readonly SendChampConfig _sendChampConfig;

        public Sms(ILogger<Sms> logger, IOptions<SendChampConfig> sendChampConfig)
        {
            _logger = logger;
            _sendChampConfig = sendChampConfig.Value;
            _client = new RestClient(new RestClientOptions(_sendChampConfig.BaseUrl)
            {
                Authenticator = new Httpbas
            })
        }
        public Task<BaseResponse<SendSmsResponseData>> Send(List<string> to, string message, string senderName, string route)
        {
            throw new NotImplementedException();
        }
    }
}