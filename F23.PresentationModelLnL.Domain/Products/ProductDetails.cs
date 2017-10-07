namespace F23.PresentationModelLnL.Domain.Products
{
    public class ProductDetails
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public string ProductSku { get; set; }

        public string Description { get; set; }

        public decimal VendorPrice { get; set; }

        public decimal SellingPrice { get; set; }
    }
}
