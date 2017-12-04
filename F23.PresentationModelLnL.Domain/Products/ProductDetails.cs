namespace F23.PresentationModelLnL.Domain.Products
{
    /// <summary>
    /// Flattened view of products. Since my app can't create/update/delete products,
    /// there's no need for the standard Product class.
    /// </summary>
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
