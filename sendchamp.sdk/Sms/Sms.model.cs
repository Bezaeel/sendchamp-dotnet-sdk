using sendchamp.sdk.Sms.Enums;

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
        public List<string> To { get; set; }
        public string Message { get; set; }
        public string SenderName { get; set; }
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
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Reference { get; set; }
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
}
