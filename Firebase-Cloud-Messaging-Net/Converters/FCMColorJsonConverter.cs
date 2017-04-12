using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;

namespace net.tipstrade.FCMNet.Converters {
  /// <summary>
  /// Instructs the Newtonsoft.Json.JsonSerializer to use the specified FCMColorJsonConverter when serializing the property.
  /// </summary>
  public class FCMColorJsonConverter : JsonConverter {
    /// <summary>
    /// Determines whether this instance can convert the specified object type.
    /// </summary>
    public override bool CanConvert(Type objectType) {
      return objectType == typeof(Color);
    }

    /// <summary>
    ///  Gets a value indicating whether this Newtonsoft.Json.JsonConverter can read JSON.
    /// </summary>
    public override bool CanRead {
      get {
        return true;
      }
    }

    /// <summary>
    ///  Gets a value indicating whether this Newtonsoft.Json.JsonConverter can write JSON.
    /// </summary>
    public override bool CanWrite {
      get {
        return true;
      }
    }

    /// <summary>
    /// Reads the JSON representation of the object.
    /// </summary>
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
      // Value expected as #rrggbb
      uint val = 0xff000000 + uint.Parse(((string)reader.Value).Substring(1), System.Globalization.NumberStyles.HexNumber);
      // Disable checks as we want it to overflow
      unchecked {
        return Color.FromArgb((int)val);
      }
    }

    /// <summary>
    /// Writes the JSON representation of the object.
    /// </summary>
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
      var c = (Color)value;
      writer.WriteValue(string.Format("#{0:x2}{1:x2}{2:x2}", c.R, c.G, c.B));
    }
  }
}
