using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace RecipePal.Core.Models
{
    public interface IDataEntity
    {
        [JsonProperty(PropertyName = "id")]
        string Id { get; set; }

        [Version]
        string Version { get; set; }
    }
}