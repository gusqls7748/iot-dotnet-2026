namespace ProductApi.Models
{
    using System.Text.Json.Serialization; // 이 네임스페이스가 필요합니다

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}