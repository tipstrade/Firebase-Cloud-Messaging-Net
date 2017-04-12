using net.tipstrade.FCMNet.Converters;
using Newtonsoft.Json;
using System;
using System.Drawing;

namespace net.tipstrade.FCMNet.Requests {
  /// <summary>
  /// Represents a Firebase Cloud Messaging notification object for Android devices.
  /// </summary>
  public class AndroidNotification : LocalizedNotification {
    /// <summary>
    /// Gets or sets whether each notification results in a new entry in the notification drawer. Notifications with the same tag replace the existing one.
    /// </summary>
    [JsonConverter(typeof(FCMColorJsonConverter))]
    [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
    public Color? Color { get; set; }

    /// <summary>
    /// Gets or sets the sound that is played when the device receives a notification.
    /// </summary>
    [JsonProperty("sound", NullValueHandling = NullValueHandling.Ignore)]
    public string Sound { get; set; }
 
    /// <summary>
    /// Gets or sets whether each notification results in a new entry in the notification drawer. Notifications with the same tag replace the existing one.
    /// </summary>
    [JsonProperty("tag", NullValueHandling = NullValueHandling.Ignore)]
    public string Tag { get; set; }
  }
}
