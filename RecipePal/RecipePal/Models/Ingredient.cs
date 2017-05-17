using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RecipePal.Core.Models
{
    public class Ingredient:IDataEntity
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "recipetag")]
        public int RecipeTag { get; set; }
        [JsonProperty(PropertyName = "quantitytag")]
        public int QuantityTag { get; set; }
        [JsonProperty(PropertyName = "quantity")]
        public double Quantity { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [Version]
        public string Version { get; set; }
    }
}