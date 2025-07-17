namespace YMTDotNetTrainingBatch2.WebApi.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
