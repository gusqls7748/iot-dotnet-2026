using System;
using System.Text.Json.Serialization;

namespace WpfProductAdmin.Models
{
    public class Product
    {
        [JsonPropertyName("productId")]
        public int ProductId { get; set; }

        [JsonPropertyName("productName")]
        public string ProductName { get; set; }

        [JsonPropertyName("category")]
        public string? Category { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }

        [JsonPropertyName("stock")]
        public int Stock { get; set; }

        [JsonPropertyName("createAt")] // <--- 핵심: JSON의 'createAt'과 매핑
        public DateTime CreatedAt { get; set; }
    }
}