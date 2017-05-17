using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RecipePal.Core.Models
{
    public class Recipe : IDataEntity
    {
        [JsonProperty(PropertyName = "photourl")]
        public string PhotoUrl { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        public int Difficulty { get; set; }

        [JsonProperty(PropertyName = "serves")]
        public int Serves { get; set; }

        [JsonProperty(PropertyName = "cooktime")]
        public int CookTime { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "ingredientsnumber")]
        public int IngredientsNumber { get; set; }

        [JsonProperty(PropertyName = "categorytag")]
        public int CategoryTag { get; set; }

        [JsonProperty(PropertyName = "userid")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "tag")]
        public int Tag { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Version]
        public string Version { get; set; }
    }
}