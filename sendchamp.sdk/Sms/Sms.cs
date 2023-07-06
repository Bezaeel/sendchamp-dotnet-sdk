using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestSharp;
using sendchamp.sdk.Sms.Enums;
using sendchamp.sdk.Sms.Models;
using System.Diagnostics;
using System.Net.Http.Json;
using System.Text.Json;

namespace sendchamp.sdk.Sms
{
    public class Sms : ISms
    {
        private readonly HttpClient _client;
        private readonly ILogger<Sms> _logger;
        private readonly SendChampConfig _config;

        public Sms(ILogger<Sms> logger, IOptions<SendChampConfig> config, HttpClient client)
        {
            _logger = logger;
            _config = config.Value;
            _client = client;
            _client.BaseAddress = new Uri(_config.BaseUrl);
            _client.DefaultRequestHeaders.Add("Accept", "application/json");
            _client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_config.PublicKey}");

        }

        public async Task<BaseResponse<SendChampResponse<BulkSmsDeliveryReportData>>> BulkSmsDeliveryReport(string smsUID)
        {
            try
            {
                string requestRoute = $"/api/v1/sms/bulk-sms-status/{smsUID}";
                var response = await _client.GetAsync(requestRoute);
                var rr = await response.Content.ReadAsStringAsync();
                var sendchampResponse = JsonSerializer.Deserialize<SendChampResponse<BulkSmsDeliveryReportData>>(rr);
                return new BaseResponse<SendChampResponse<BulkSmsDeliveryReportData>>
                {
                    Status = true,
                    Response = sendchampResponse
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<SendChampResponse<BulkSmsDeliveryReportData>>
                {
                    Status = false,
                    Message = ex.ToString()
                };
            }
        }

        public async Task<BaseResponse<SendChampResponse<SmsDeliveryReportData>>> SingleSmsDeliveryReport(string smsUID)
        {

            try
            {
                if (string.IsNullOrEmpty(smsUID))
                {
                    throw new ArgumentException("smsUID is required");
                }

                string requestRoute = $"/api/v1/sms/status/{smsUID}";
                var response = await _client.GetAsync(requestRoute);
                var rr = await response.Content.ReadAsStringAsync();
                var sendchampResponse = JsonSerializer.Deserialize<SendChampResponse<SmsDeliveryReportData>>(rr);

                return new BaseResponse<SendChampResponse<SmsDeliveryReportData>>
                {
                    Status = true,
                    Response = sendchampResponse
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<SendChampResponse<SmsDeliveryReportData>>
                {
                    Status = false,
                    Message = ex.ToString()
                };
            }
        }

        public async Task<BaseResponse<SendChampResponse<CreateSenderIdResponseData>>> CreateSenderId(CreateSenderIdRequestDTO dto)
        {
            try
            {
                var body = new CreateSenderIdRequest
                {
                    Name = dto.Name,
                    Sample = dto.Sample,
                    UseCase = dto.UseCase.GetDescription(),
                };

                string requestRoute = "/api/v1/sms/create-sender-id";
                var response = await _client.PostAsJsonAsync(requestRoute, body);
                var rr = await response.Content.ReadAsStringAsync();
                var sendchampResponse = JsonSerializer.Deserialize<SendChampResponse<CreateSenderIdResponseData>>(rr);

                return new BaseResponse<SendChampResponse<CreateSenderIdResponseData>>
                {
                    Status = true,
                    Response = sendchampResponse
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<SendChampResponse<CreateSenderIdResponseData>>
                {
                    Status = false,
                    Message = ex.ToString()
                };
            }
        }

        public async Task<BaseResponse<SendChampResponse<SendSmsResponseData>>> Send(SendSmsRequestDTO dto)
        {
            try
            {
                var body = new SendSmsRequest
                {
                    SenderName = dto.SenderName,
                    Message = dto.Message,
                    Route = dto.Route.GetDescription(),
                    To = dto.To,
                };

                string requestRoute = "/api/v1/sms/send";
                var response = await _client.PostAsJsonAsync(requestRoute, body);
                var rr = await response.Content.ReadAsStringAsync();
                var sendchampResponse =  JsonSerializer.Deserialize<SendChampResponse<SendSmsResponseData>>(rr);

                return new BaseResponse<SendChampResponse<SendSmsResponseData>>
                {
                    Status = true,
                    Response = sendchampResponse
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<SendChampResponse<SendSmsResponseData>>
                {
                    Status = false,
                    Message = ex.ToString()
                };
            }
        }
    }
}