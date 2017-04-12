using Newtonsoft.Json;
using System;

namespace net.tipstrade.FCMNet.Responses {
  /// <summary>
  /// Represents a Firebase Cloud Messaging message response object.
  /// </summary>
    public class Response
    {
    /// <summary>
    /// Gets or sets the nuber of results that contain a canonical registration token.
    /// </summary>
    [JsonProperty("canonical_ids")]
    public int CanonicalIDs { get; set; }

    /// <summary>
    /// Gets or sets the number of messages that could not be processed.
    /// </summary>
    [JsonProperty("failure")]
    public int Failure { get; set; }

    /// <summary>
    /// Gets or sets the unique ID identifying the multicast message.
    /// </summary>
    [JsonProperty("multicast_id")]
    public Int64 MulticastID { get; set; }

    /// <summary>
    /// Gets or sets the list of results respresenting the status of the messages processed.
    /// </summary>
    public Result[] Results { get; set; }

    /// <summary>
    /// Gets or sets the number of messages that were processed without an error.
    /// </summary>
    [JsonProperty("success")]
    public int Success { get; set; }
  }
}
