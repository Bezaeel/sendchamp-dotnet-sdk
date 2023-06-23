using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace sendchamp.sdk
{
    public class BaseResponse<T>
    {
        [JsonPropertyName("status_code")]
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

    public class BaseResponse
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("errors")]
        public string Error { get; set; }
    }
}
