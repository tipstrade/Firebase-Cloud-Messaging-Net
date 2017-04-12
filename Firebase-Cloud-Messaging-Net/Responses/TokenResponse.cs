using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace net.tipstrade.FCMNet.Responses
{
    public class TokenResponse
    {
        // ini comment 
        [JsonProperty("notification_key")]
        public string Notification_key { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }

    }
}
