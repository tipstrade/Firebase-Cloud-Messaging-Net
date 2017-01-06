using Newtonsoft.Json;
using System;

namespace net.tipstrade.FCMNet.Requests {
  /// <summary>
  /// Represents a Firebase Cloud Messaging notification object for iOS devices.
  /// </summary>
  public class iOSNotification : LocalizedNotification {
    /// <summary>
    /// Gets or sets the badge on the client app home icon.
    /// </summary>
    [JsonProperty("badge", NullValueHandling = NullValueHandling.Ignore)]
    public string Badge { get; set; }

    /// <summary>
    /// Gets or sets the sound that is played when the device receives a notification.
    /// </summary>
    [JsonProperty("sound", NullValueHandling = NullValueHandling.Ignore)]
    public string Sound { get; set; }
  }
}
