using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksAppClient.Areas.Admin.Models
{
    public class AddBookModel
    {

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("isHome")]
        public bool IsHome { get; set; }

        [JsonPropertyName("name")]
        [DisplayName("Kitap Adı")]
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        [MinLength(5,ErrorMessage ="Bu alanın uzunluğu 5 karakterden kısa olamaz")]
        public string Name { get; set; }

        [JsonPropertyName("properties")]
        [DisplayName("Özellikler")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(5, ErrorMessage = "Bu alanın uzunluğu 5 karakterden kısa olamaz")]
        public string Properties { get; set; }

        [JsonPropertyName("summary")]
        [DisplayName("Özet")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [MinLength(5, ErrorMessage = "Bu alanın uzunluğu 5 karakterden kısa olamaz")]
        public string Summary { get; set; }

        [JsonPropertyName("stock")]
        [DisplayName("Stok")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(minimum:0, maximum:1000,ErrorMessage ="Bu alana 0-1000 aralığı dışında bir değer girilemez")]
        public int? Stock { get; set; }

        [JsonPropertyName("price")]
        [DisplayName("Fiyat")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(minimum: 0, maximum: 10000, ErrorMessage = "Bu alana 0-10000 aralığı dışında bir değer girilemez")]
        public decimal? Price { get; set; }

        [JsonPropertyName("pageCount")]
        [DisplayName("Sayfa")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(minimum: 1, maximum: 10000, ErrorMessage = "Bu alana 1-10000 aralığı dışında bir değer girilemez")]
        public int? PageCount { get; set; }

        [JsonPropertyName("editionYear")]
        [DisplayName("Yıl")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(minimum: 1900, maximum: 2050, ErrorMessage = "Bu alana 1900-2025 aralığı dışında bir değer girilemez")]
        public int? EditionYear { get; set; }

        [JsonPropertyName("editionNumber")]
        [DisplayName("Baskı")]
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(minimum: 1, maximum: 100, ErrorMessage = "Bu alana 1-100 aralığı dışında bir değer girilemez")]
        public int? EditionNumber { get; set; }

        [JsonPropertyName("imageUrl")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("categoryIds")]
        public List<int> CategoryIds { get; set; }

        [JsonPropertyName("authorId")]
        public int AuthorId { get; set; }

        public List<CategoryModel> CategoryList { get; set; }
        public List<SelectListItem> AuthorList { get; set; }
    }
}
