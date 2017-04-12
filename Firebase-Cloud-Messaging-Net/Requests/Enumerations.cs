using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace net.tipstrade.FCMNet.Requests {
  [JsonConverter(typeof(StringEnumConverter))]
  public enum Priority {
    /// <summary></summary>
    [EnumMember(Value = "normal")]
    Normal,
    /// <summary></summary>
    [EnumMember(Value = "high")]
    High
  }
}
