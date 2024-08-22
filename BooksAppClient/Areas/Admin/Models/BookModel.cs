using System.Text.Json.Serialization;

namespace BooksAppClient.Areas.Admin.Models
{
    public class BookModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("IsHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Properties")]
        public string Properties { get; set; }

        [JsonPropertyName("Summary")]
        public string Summary { get; set; }

        [JsonPropertyName("Stock")]
        public int Stock { get; set; }

        [JsonPropertyName("Price")]
        public decimal Price { get; set; }

        [JsonPropertyName("PageCount")]
        public int PageCount { get; set; }

        [JsonPropertyName("EditionYear")]
        public int EditionYear { get; set; }

        [JsonPropertyName("EditionNumber")]
        public int EditionNumber { get; set; }

        [JsonPropertyName("ImageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("Categories")]
        public List<CategoryModel> Categories { get; set; }

        [JsonPropertyName("Author")]
        public AuthorModel Author { get; set; }
    }
}
