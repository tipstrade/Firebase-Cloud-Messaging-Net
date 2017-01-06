using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace net.tipstrade.FCMNet.Requests {
  /// <summary>
  /// Represents a Firebase Cloud Messaging message object.
  /// </summary>
  /// <remarks>See https://firebase.google.com/docs/cloud-messaging/http-server-ref#downstream-http-messages-json </remarks>
  public class Message<T> where T : Notification {
    #region Constants
    /// <summary>
    /// The URI to which messages are posted.
    /// </summary>
    protected const string FCMSendUri = "https://fcm.googleapis.com/fcm/send";
    #endregion

    #region Targets
    /// <summary>
    /// Gets or sets the logical expression of conditions that determine the message target.
    /// </summary>
    [JsonProperty("condition", NullValueHandling = NullValueHandling.Ignore)]
    public string[] Condition { get; set; }

    /// <summary>
    /// Gets or sets whether the message should not actually be sent.
    /// </summary>
    [JsonProperty("dry_run")]
    [DefaultValue(false)]
    public bool DryRun { get; set; }

    /// <summary>
    /// Gets or sets the list of devices (registration tokens or IDs) receiving a multicast message.
    /// </summary>
    [JsonProperty("registration_ids", NullValueHandling = NullValueHandling.Ignore)]
    public string[] RegistrationIDs { get; set; }

    /// <summary>
    /// Gets or sets the recipient of the message.
    /// The value must be a registration token, notification key, or topic.
    /// Do not set this field when sending to multiple topics.
    /// </summary>
    [JsonProperty("to", NullValueHandling = NullValueHandling.Ignore)]
    public string To { get; set; }
    #endregion

    #region Options
    /// <summary>
    /// Gets or sets the parameter that identifies a group of messages.
    /// </summary>
    [JsonProperty("collapse_key", NullValueHandling = NullValueHandling.Ignore)]
    public string CollapseKey { get; set; }

    /// <summary>
    /// Gets or sets the iOS content-available field.
    /// </summary>
    [JsonProperty("content_available")]
    [DefaultValue(false)]
    public bool ContentAvailable { get; set; }

    /// <summary>
    /// Gets or sets the priority of the message.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("priority", NullValueHandling = NullValueHandling.Ignore)]
    public Priority? Priority { get; set; }

    /// <summary>
    ///  Gets or sets the package name of the application where the registraion tokens must match in order to receive the message.
    /// </summary>
    [JsonProperty("restricted_package_name", NullValueHandling = NullValueHandling.Ignore)]
    public string RestrictedPackagename { get; set; }

    /// <summary>
    /// Gets or sets how long the message should be kept in FCM storage if the device is offline.
    /// </summary>
    [DefaultValue(4 * 7 * 24 * 60 * 60)]
    [JsonProperty("time_to_live")]
    public int TTL { get; set; }
    #endregion

    #region Payload
    /// <summary>
    /// Gets or sets key-value pairs of the message's payload
    /// </summary>
    [JsonProperty("data", NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> Data { get; set; }

    /// <summary>
    /// Gets or sets the predifined, user-visible key-value pairs of the notification payload.
    /// </summary>
    [JsonProperty("notification", NullValueHandling = NullValueHandling.Ignore)]
    public T Notification { get; set; }
    #endregion

    #region Constructors
    /// <summary>
    /// Creates an instance of the net.tipstrade.FCMNet.Requests.Message class.
    /// </summary>
    public Message() {
      ContentAvailable = false;
      DryRun = false;
      TTL = 4 * 7 * 24 * 60 * 60;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Sends the message.
    /// </summary>
    /// <param name="key">The Firebase Cloud Messaging authorization key.</param>
    public Responses.Response Send(string key) {
      var req = (HttpWebRequest)HttpWebRequest.Create(FCMSendUri);
      req.Method = "POST";
      req.ContentType = "application/json";
      req.Headers.Add("Authorization", "key=" + key);

      using (var writer = new StreamWriter(req.GetRequestStream())) {
#if DEBUG
        var json = JsonConvert.SerializeObject(this);
#endif
        writer.Write(JsonConvert.SerializeObject(this));
      }

      HttpWebResponse resp = null;
      try {
        resp = (HttpWebResponse)(req.GetResponse());

        using (var reader = new StreamReader(resp.GetResponseStream())) {
          return JsonConvert.DeserializeObject<Responses.Response>(reader.ReadToEnd());
        }

      } finally {
        if (resp != null)
          resp.Dispose();
      }
    }

    /// <summary>
    /// Sends the message.
    /// </summary>
    /// <param name="key">The Firebase Cloud Messaging authorization key.</param>
    public async Task<Responses.Response> SendAsync(string key) {
      return await Task.Run(() => Send(key));
    }
    #endregion
  }
}
