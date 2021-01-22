using Newtonsoft.Json;

namespace WooliesX.API.Resources
{
    public abstract class BaseResource
    {
        [JsonProperty(Order = -2)]
        public string Href { get; set; }
    }
}
