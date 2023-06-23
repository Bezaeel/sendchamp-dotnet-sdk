using sendchamp.sdk.Sms.Enums;
using System.Text.Json.Serialization;

namespace sendchamp.sdk.Sms.Models
{
    public class CreateSenderIdRequest
    {
        public string Name { get; set; }
        public string Sample { get; set; }
        public string UseCase { get; set; }
    }

    public class CreateSenderIdRequestDTO
    {
        public string Name { get; set; }
        public string Sample { get; set; }
        public SendChampUseCase UseCase { get; set; }
    }

    public class CreateSenderIdResponseData
    {
        public string UID { get; set; }
        public string Name { get; set; }
        public string BusinessUID { get; set; }
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
