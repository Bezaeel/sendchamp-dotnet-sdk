using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sendchamp.sdk
{
    public interface ISms
    {
        Task<BaseResponse<SendSmsResponseData>> Send(List<string> to, string message, string senderName, string route);
    }
}
