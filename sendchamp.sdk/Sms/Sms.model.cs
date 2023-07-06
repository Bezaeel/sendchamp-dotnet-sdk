using sendchamp.sdk.Sms.Enums;
using System.Text.Json.Serialization;

namespace sendchamp.sdk.Sms.Models
{
    public class SendChampResponse<T>
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("errors")]
        public string Error { get; set; }

        [JsonPropertyName("data")]
        public T Data { get; set; }
    }

    public class BulkSmsDeliveryReportData
    {
    }

    public class SmsDeliveryReportData
    {
    }

    public class CreateSenderIdRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sample")]
        public string Sample { get; set; }

        [JsonPropertyName("use_case")]
        public string UseCase { get; set; }
    }

    public class CreateSenderIdRequestDTO
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("sample")]
        public string Sample { get; set; }

        [JsonPropertyName("use_case")]
        public SendChampUseCase UseCase { get; set; }
    }

    public class CreateSenderIdResponseData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("uid")]
        public string UID { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("business_id")]
        public long BusinessId { get; set; }

        [JsonPropertyName("use_case")]
        public string UseCase { get; set; }

        [JsonPropertyName("sample")]
        public string Sample { get; set; }

        [JsonPropertyName("staus")]
        public string Staus { get; set; }

        [JsonPropertyName("approved_for_verification")]
        public bool ApprovedForVerification { get; set; }

        [JsonPropertyName("is_whitelisted")]
        public bool IsWhitelisted { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }
    }

    public class SendSmsRequest
    {
        [JsonPropertyName("to")]
        public List<string> To { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("sender_name")]
        public string SenderName { get; set; }

        [JsonPropertyName("route")]
        public string Route { get; set; }
    }

    public class SendSmsRequestDTO
    {
        public List<string> To { get; set; }
        public string Message { get; set; }
        public string SenderName { get; set; }
        public SendChampRoutes Route { get; set; }
    }

    public class SendSmsResponseData
    {
        [JsonPropertyName("total_contacts")]
        public int TotalContacts { get; set; }

        [JsonPropertyName("business_id")]
        public string BusinessID { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

    }
}
