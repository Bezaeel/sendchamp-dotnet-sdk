using sendchamp.sdk.Sms.Models;

namespace sendchamp.sdk.Sms
{
    public interface ISms
    {
        Task<BaseResponse> SingleSmsDeliveryReport(string smsUID);
        Task<BaseResponse> BulkSmsDeliveryReport(string smsUID);
        Task<BaseResponse<CreateSenderIdResponseData>> CreateSenderId(CreateSenderIdRequestDTO dto);
        Task<BaseResponse<SendSmsResponseData>> Send(SendSmsRequestDTO dto);
    }
}
