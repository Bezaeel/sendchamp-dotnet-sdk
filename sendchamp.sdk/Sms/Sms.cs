using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using sendchamp.sdk.Sms.Enums;
using sendchamp.sdk.Sms.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace sendchamp.sdk.Sms
{
    public class Sms : ISms
    {
        private readonly RestClient _client;
        private readonly ILogger<Sms> _logger;
        private readonly SendChampConfig _config;
        private readonly HttpClient client = new HttpClient();

        public Sms(ILogger<Sms> logger, IOptions<SendChampConfig> config)
        {
            _logger = logger;
            _config = config.Value;
            _client = new RestClient(new RestClientOptions(_config.BaseUrl)
            {
                Authenticator = new Authenticator(_config)
            });
            client.BaseAddress = new Uri(_config.BaseUrl);
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_config.PublicKey}");

        }

        public async Task<BaseResponse> SingleSmsDeliveryReport(string smsUID)
        {
            string requestRoute = $"sms/status/{smsUID}";
            var request = new RestRequest(requestRoute, Method.Get);
            var response = await _client.ExecuteAsync<BaseResponse<CreateSenderIdResponseData>>(request);

            if (response.IsSuccessful)
            {
                return new BaseResponse
                {
                    Status = response.Data.Status,
                    Message = response.Data.Message,
                };
            }

            return new BaseResponse { Status = response.Data.Status, Message = response.Content };
        }

        public async Task<BaseResponse> BulkSmsDeliveryReport(string smsUID)
        {
            string requestRoute = $"sms/bulk-sms-status/{smsUID}";
            var request = new RestRequest(requestRoute, Method.Get);
            var response = await _client.ExecuteAsync<BaseResponse<CreateSenderIdResponseData>>(request);

            if (response.IsSuccessful)
            {
                return new BaseResponse
                {
                    Status = response.Data.Status,
                    Message = response.Data.Message,
                };
            }

            return new BaseResponse { Status = response.Data.Status, Message = response.Content };
        }

        public async Task<BaseResponse<CreateSenderIdResponseData>> CreateSenderId(CreateSenderIdRequestDTO dto)
        {
            var body = new CreateSenderIdRequest
            {
                Name = dto.Name,
                Sample = dto.Sample,
                UseCase = dto.UseCase.GetDescription(),
            };

            string requestRoute = "sms/create-sender-id";
            var request = new RestRequest(requestRoute, Method.Post);
            request.AddJsonBody(body);
            var response = await _client.ExecuteAsync<BaseResponse<CreateSenderIdResponseData>>(request);

            if (response.IsSuccessful)
            {
                return new BaseResponse<CreateSenderIdResponseData>
                {
                    Status = response.Data.Status,
                    Message = response.Data.Message,
                    Data = response.Data.Data,
                    Error = response.Data.Error,
                    Code = response.Data.Code,
                };
            }

            return new BaseResponse<CreateSenderIdResponseData> { Status = response.Data.Status, Message = response.Content };
        }

        public async Task<BaseResponse<SendSmsResponseData>> Send(SendSmsRequestDTO dto)
        {
            var body = new SendSmsRequest
            {
                SenderName = dto.SenderName,
                Message = dto.Message,
                Route = dto.Route.GetDescription(),
                To = dto.To,
            };

            string requestRoute = "/sms/send";
            //var request = new RestRequest(requestRoute, Method.Post);
            //request.AddJsonBody(body);
            //var response = await _client.ExecuteAsync<BaseResponse<SendSmsResponseData>>(request);
            var response = await client.PostAsJsonAsync<SendSmsRequest>(requestRoute, body);
            var r = await response.Content.ReadAsStringAsync();
            var rs = JsonSerializer.Deserialize<BaseResponse<SendSmsResponseData>>(r);
            return rs;

            //if (response.IsSuccessStatusCode)
            //{
            //    return new BaseResponse<SendSmsResponseData>
            //    {
            //        Status = response.Data.Status,
            //        Message = response.Data.Message,
            //        Data = response.Data.Data,
            //        Error = response.Data.Error,
            //        Code = response.Data.Code,
            //    };
            //}
            //return new BaseResponse<SendSmsResponseData> { Status = response.Data.Status, Message = response.Content};
        }
    }
}