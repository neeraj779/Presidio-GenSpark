namespace ProductAPI.Core.Models.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
