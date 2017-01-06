using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace net.tipstrade.FCMNet.Responses {
  /// <summary>
  /// Represents a Firebase Cloud Messaging message response result object.
  /// </summary>
  public class Result {
    /// <summary>
    /// Gets or sets the type of error that occurred.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
    public Error Error { get; set; }

    /// <summary>
    /// Gets whether the result contains an error.
    /// </summary>
    [JsonIgnore]
    public bool HasError {
      get {
        return Error != Responses.Error.None;
      }
    }

    /// <summary>
    /// Gets or sets the unique ID for each successfully processed message.
    /// </summary>
    [JsonProperty("message_id")]
    public string MessageID { get; set; }

    /// <summary>
    /// Gets or sets the registraion ID of the result.
    /// </summary>
    [JsonProperty("registration_id", NullValueHandling = NullValueHandling.Ignore)]
    public string RegistrationID { get; set; }
  }
}
