using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RecipePal.Core.Models
{
    public class Favorites:IDataEntity
    {
        [JsonProperty(PropertyName = "userid")]
        public string UserId { get; set; }
        [JsonProperty(PropertyName = "recipetag")]
        public int RecipeTag { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Version]
        public string Version { get; set; }
    }
}