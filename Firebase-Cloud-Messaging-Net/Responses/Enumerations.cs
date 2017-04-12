using System;
using System.ComponentModel;

namespace net.tipstrade.FCMNet.Responses {
  public enum Error {
    /// <summary>No error occurred.</summary>
    [Description("No error")]
    None = 0,

    /// <summary></summary>
    [Description("Missing Registration Token")]
    MissingRegistration,
    /// <summary></summary>
    [Description("Invalid Registration Token")]
    InvalidRegistration,
    /// <summary></summary>
    [Description("Unregistered Device")]
    NotRegistered,
    /// <summary></summary>
    [Description("Invalid Package Name")]
    InvalidPackageName,
    /// <summary></summary>
    [Description("Mismatched Sender")]
    MismatchSenderId,
    /// <summary></summary>
    [Description("Message Too Big")]
    MessageTooBig,
    /// <summary></summary>
    [Description("Invalid Data Key")]
    InvalidDataKey,
    /// <summary></summary>
    [Description("Invalid Time to Live")]
    InvalidTtl,
    /// <summary></summary>
    [Description("Timeout")]
    Unavailable,
    /// <summary></summary>
    [Description("Internal Server Error")]
    InternalServerError,
    /// <summary></summary>
    [Description("Device Message Rate Exceeded")]
    DeviceMessageRateExceeded,
    /// <summary></summary>
    [Description("Topics Message Rate Exceeded")]
    TopicsMessageRateExceeded
  }
}
