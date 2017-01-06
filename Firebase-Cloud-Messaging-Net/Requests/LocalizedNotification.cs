using Newtonsoft.Json;
using System;

namespace net.tipstrade.FCMNet.Requests {
  /// <summary>
  /// Represents a Firebase Cloud Messaging notification object with localization properties.
  /// </summary>
  public abstract class LocalizedNotification : Notification {
    /// <summary>
    /// Gets or sets the key for the body string localization.
    /// </summary>
    [JsonProperty("body_loc_key", NullValueHandling = NullValueHandling.Ignore)]
    public string BodyLocalizationKey { get; set; }

    /// <summary>
    /// Gets or sets the string value to replace format specifiers in the body string for localization.
    /// </summary>
    [JsonProperty("body_loc_args", NullValueHandling = NullValueHandling.Ignore)]
    public string BodyLocalizationArgs { get; set; }

    /// <summary>
    /// Gets or sets the key for the title string localization.
    /// </summary>
    [JsonProperty("title_loc_key", NullValueHandling = NullValueHandling.Ignore)]
    public string TitleLocalizationKey { get; set; }

    /// <summary>
    /// Gets or sets the string value to replace format specifiers in the title string for localization.
    /// </summary>
    [JsonProperty("title_loc_args", NullValueHandling = NullValueHandling.Ignore)]
    public string TitleLocalizationArgs { get; set; }
  }
}
