using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RecipePal.Core.Models
{
    
    public class Category: IDataEntity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "categoryimage")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "tag")]
        public int Tag { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Version]
        public string Version { get; set; }
    }
}