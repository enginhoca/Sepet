using System.Text.Json.Serialization;

namespace BooksAppClient.Areas.Admin.Models
{
    public class AuthorModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("ModifiedDate")]
        public DateTime ModifiedDate { get; set; }

        [JsonPropertyName("IsActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("FirstName")]
        public string FirstName { get; set; }

        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [JsonPropertyName("About")]
        public string About { get; set; }

        [JsonPropertyName("PhotoUrl")]
        public string PhotoUrl { get; set; }
    }
}
