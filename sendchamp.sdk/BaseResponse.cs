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
        [JsonPropertyName("status")]
        public bool Status { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("response")]
        public T Response { get; set; }
    }
}
