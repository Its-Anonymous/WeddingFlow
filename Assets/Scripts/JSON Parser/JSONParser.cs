using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace JSONParser
{
    #region Save/Load stuff
    public partial class SaveSystem
    {
        [JsonProperty("backgroundName")]
        public string BackgroundName { get; set; }

        [JsonProperty("objectInfo")]
        public List<ObjectInfo> ObjectInfo { get; set; }
    }

    public partial class ObjectInfo
    {
        [JsonProperty("prefabName")]
        public string PrefabName { get; set; }

        [JsonProperty("coords")]
        public Coords Coords { get; set; }
    }

    public partial class Coords
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public partial class SaveSystem
    {
        public static SaveSystem FromJson(string json) => JsonConvert.DeserializeObject<SaveSystem>(json, JSONParser.Converter.Settings);
    }
    #endregion


    public static class Serialize
    {
        public static string ToJson(this SaveSystem self) => JsonConvert.SerializeObject(self, JSONParser.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
