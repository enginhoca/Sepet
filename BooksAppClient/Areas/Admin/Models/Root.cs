﻿using System.Text.Json.Serialization;

namespace BooksAppClient.Areas.Admin.Models
{
    public class Root<T>
    {
        [JsonPropertyName("IsSucceeded")]
        public bool IsSucceeded { get; set; }

        [JsonPropertyName("StatusCode")]
        public int StatusCode { get; set; }

        [JsonPropertyName("Error")]
        public string Error { get; set; }

        [JsonPropertyName("Data")]
        public T Data { get; set; }
    }
}
