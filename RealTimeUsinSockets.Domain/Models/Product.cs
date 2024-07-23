namespace RealTimeUsingSockets.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? LastUpldatedAt { get; set; }
        public int NumberOfItemsInStock { get; set; }
        public int NumberOfSales { get; set; } = 0;
    }
}
