using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Interview.Model.Models
{
    public class LoginRespondModel
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }
        public long TokenExpired { get; set; }

    }
}
