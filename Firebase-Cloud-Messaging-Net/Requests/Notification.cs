using Newtonsoft.Json;
using System;

namespace net.tipstrade.FCMNet.Requests {
  /// <summary>
  /// Represents a Firebase Cloud Messaging notification object.
  /// </summary>
  /// <remarks>See https://firebase.google.com/docs/cloud-messaging/http-server-ref#notification-payload-support </remarks>
  public class Notification {
    /// <summary>
    /// Gets or sets the body text of the notification.
    /// </summary>
    [JsonProperty("body", NullValueHandling = NullValueHandling.Ignore)]
    public string Body { get; set; }

    /// <summary>
    /// Gets or sets the URL of the notification's icon.
    /// </summary>
    [JsonProperty("icon", NullValueHandling = NullValueHandling.Ignore)]
    public Uri Icon { get; set; }

    /// <summary>
    /// Gets or sets the action associated with a user click on the notification.
    /// </summary>
    [JsonProperty("click_action", NullValueHandling = NullValueHandling.Ignore)]
    public string ClickAction { get; set; }

    /// <summary>
    /// Gets or sets the title of the notification.
    /// </summary>
    [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
    public string Title { get; set; }
  }
}
