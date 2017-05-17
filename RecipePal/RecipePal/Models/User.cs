using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RecipePal.Core.Models
{
    public class User:IDataEntity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "imageurl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Version]
        public string Version { get; set; }
    }
}