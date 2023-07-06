using sendchamp.sdk.Sms.Models;

namespace sendchamp.sdk.Sms
{
    public interface ISms
    {
        Task<BaseResponse<SendChampResponse<BulkSmsDeliveryReportData>>> BulkSmsDeliveryReport(string smsUID);
        Task<BaseResponse<SendChampResponse<SmsDeliveryReportData>>> SingleSmsDeliveryReport(string smsUID);
        Task<BaseResponse<SendChampResponse<CreateSenderIdResponseData>>> CreateSenderId(CreateSenderIdRequestDTO dto);
        Task<BaseResponse<SendChampResponse<SendSmsResponseData>>> Send(SendSmsRequestDTO dto);
    }
}
