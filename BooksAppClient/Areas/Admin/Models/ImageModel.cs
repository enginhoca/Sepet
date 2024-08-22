using System.Text.Json.Serialization;

namespace BooksAppClient.Areas.Admin.Models
{
    public class ImageModel
    {
        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
